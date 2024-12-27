using Domain.Bases;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class NumberSequence : BaseEntityAudit, IAggregateRoot
    {
        public string EntityName { get; set; } = null!;
        public string? Prefix { get; set; }
        public string? Suffix { get; set; }
        public int LastUsedCount { get; set; }

        public NumberSequence() : base() { } // For EF Core

        public NumberSequence(
            string? userId,
            string entityName, 
            string prefix, 
            string suffix
        ) : base(userId)
        {
            EntityName = entityName.Trim();
            Prefix = prefix.Trim();
            Suffix = suffix.Trim();
            LastUsedCount = 0;
        }

        public void Update(
            string? userId
            )
        {
            LastUsedCount++;
            SetAudit(userId);
        }
        public void Delete(
            string? userid
            )
        {
            SetAsDeleted();
            SetAudit(userid);
        }
    }
}
