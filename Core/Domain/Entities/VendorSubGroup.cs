using Domain.Bases;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class VendorSubGroup : BaseEntityCommon, IEntity
    {
        public string VendorGroupId { get; set; } = null!;

        public VendorSubGroup() : base() { } // For EF

        public VendorSubGroup(
            string? userId,
            string name,
            string customerGroupId,
            string? description = null
            ) : base(userId , name, description)
        {
            VendorGroupId = customerGroupId.Trim();
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
