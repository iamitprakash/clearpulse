using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clearpulse.Application.Interfaces
{
    public interface IPulseService
    {
        Task<Guid> CreatePulseAsync(string title);
        Task<object?> GetPulseDetailsAsync(Guid secretToken);
        Task<object?> GetPublicPulseAsync(Guid publicId);
    }

    public interface IFeedbackService
    {
        Task SubmitFeedbackAsync(Guid publicId, string content);
        Task<IEnumerable<object>> GetFeedbackForPulseAsync(Guid secretToken);
    }
}
