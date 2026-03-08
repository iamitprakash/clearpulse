using Clearpulse.Application.Interfaces;
using Clearpulse.Domain.Entities;
using Clearpulse.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clearpulse.Infrastructure.Services
{
    public class PulseService : IPulseService
    {
        private readonly AppDbContext _context;

        public PulseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreatePulseAsync(string title)
        {
            var pulse = new Pulse { Title = title };
            _context.Pulses.Add(pulse);
            await _context.SaveChangesAsync();
            return pulse.SecretToken;
        }

        public async Task<object?> GetPulseDetailsAsync(Guid secretToken)
        {
            return await _context.Pulses
                .Where(p => p.SecretToken == secretToken)
                .Select(p => new { p.Id, p.Title, p.PublicId, p.Views, p.CreatedAt })
                .FirstOrDefaultAsync();
        }

        public async Task<object?> GetPublicPulseAsync(Guid publicId)
        {
            var pulse = await _context.Pulses.FirstOrDefaultAsync(p => p.PublicId == publicId);
            if (pulse == null) return null;

            pulse.Views++;
            await _context.SaveChangesAsync();

            return new { pulse.Id, pulse.Title, pulse.Views, pulse.CreatedAt };
        }
    }

    public class FeedbackService : IFeedbackService
    {
        private readonly AppDbContext _context;

        public FeedbackService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SubmitFeedbackAsync(Guid publicId, string content)
        {
            var pulse = await _context.Pulses.FirstOrDefaultAsync(p => p.PublicId == publicId);
            if (pulse == null) throw new Exception("Pulse not found");

            var feedback = new Feedback
            {
                PulseId = pulse.Id,
                Content = content
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<object>> GetFeedbackForPulseAsync(Guid secretToken)
        {
            return await _context.Pulses
                .Where(p => p.SecretToken == secretToken)
                .SelectMany(p => p.Feedbacks)
                .OrderByDescending(f => f.CreatedAt)
                .Select(f => new { f.Content, f.CreatedAt })
                .ToListAsync();
        }
    }
}
