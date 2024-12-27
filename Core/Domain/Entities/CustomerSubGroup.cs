using Domain.Bases;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class CustomerSubGroup : BaseEntityCommon, IEntity
    {
        public string CustomerGroupId { get; set; } = null!;

        public CustomerSubGroup() : base() { } // For EF

        public CustomerSubGroup(
            string? userId,
            string name,
            string customerGroupId,
            string? description = null
            ) : base(userId , name, description)
        {
            CustomerGroupId = customerGroupId.Trim();
        }

        internal void Update(
            string? userId,
            string name,
            string? description)
        {
            Name = name.Trim();
            Description = description?.Trim();

            SetAudit(userId);
        }

        internal void Delete(string? userId)
        {
            SetAsDeleted();
            SetAudit(userId);
        }
    }
}
