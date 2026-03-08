using System;

namespace Clearpulse.Domain.Entities
{
    public class Pulse
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PublicId { get; set; } = Guid.NewGuid();
        public Guid SecretToken { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
