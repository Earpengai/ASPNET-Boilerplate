using Domain.Bases;
using Domain.Constants;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class VendorGroup : BaseEntityCommon, IAggregateRoot
    {
        public ICollection<VendorSubGroup> VendorSubGroups { get; set; } = [];

        public VendorGroup() : base() { } // For EF

        public void Update(
            string? userId,
            string name,
            string? description)
        {
            Name = name.Trim();
            Description = description?.Trim();

            SetAudit(userId);
        }

        public void Delete(
            string? userId
            )
        {
            SetAsDeleted();
            SetAudit(userId);
        }

        public VendorSubGroup CreateSubGroup(
            string? userId,
            string name,
            string? description
            )
        {
            if (VendorSubGroups.Any(x => string.Equals(x.Name.Trim(), name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new DomainException($"{ExceptionConsts.EntitiyAlreadyExists}: {name}");
            }

            var vendorSubGroup = new VendorSubGroup(userId, name, this.Id, description);
            VendorSubGroups.Add(vendorSubGroup);
            return vendorSubGroup;
        }

        public VendorSubGroup UpdateSubGroup(
            string? userId,
            string name,
            string? description
            )
        {
            var vendorSubGroup = VendorSubGroups.SingleOrDefault(x => string.Equals(x.Name.Trim(), name, StringComparison.OrdinalIgnoreCase));
            if (vendorSubGroup == null)
            {
                throw new DomainException($"{ExceptionConsts.EntitiyNotFound}: {name}");
            }
            if (VendorSubGroups.Any(x => string.Equals(x.Name.Trim(), name, StringComparison.OrdinalIgnoreCase) 
                && x.Id != vendorSubGroup.Id))
            {
                throw new DomainException($"{ExceptionConsts.EntitiyAlreadyExists}: {name}");
            }

            vendorSubGroup.Update(userId, name, description);
            return vendorSubGroup;
        }

        public VendorSubGroup DeleteSubGroup(
            string? userId,
            string vendorSubGroupId
            )
        {
            var vendorSubGroup = VendorSubGroups.SingleOrDefault(x => string.Equals(x.Id, vendorSubGroupId, StringComparison.OrdinalIgnoreCase));
            if (vendorSubGroup == null)
            {
                throw new DomainException($"{ExceptionConsts.EntitiyNotFound}: {vendorSubGroupId}");
            }

            vendorSubGroup.Delete(userId);
            return vendorSubGroup;
        }

        public VendorSubGroup GetCustomerSubGroup(
            string vendorSubGroupId
            )
        {
            var vendorSubGroup = VendorSubGroups.SingleOrDefault(x => string.Equals(x.Id, vendorSubGroupId, StringComparison.OrdinalIgnoreCase));
            if (vendorSubGroup == null)
            {
                throw new DomainException($"{ExceptionConsts.EntitiyNotFound}: {vendorSubGroupId}");
            }

            return vendorSubGroup;
        }
    }
}
