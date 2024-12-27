using Domain.Bases;
using Domain.Constants;
using Domain.Exceptions;
using Domain.Interfaces;
using System.Globalization;

namespace Domain.Entities
{
    public class CustomerGroup : BaseEntityCommon, IAggregateRoot
    {
        public ICollection<CustomerSubGroup> CustomerSubGroups { get; set; } = [];

        public CustomerGroup() : base() { } // For EF

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

        public CustomerSubGroup CreateSubGroup(
            string? userId,
            string name,
            string? description
            )
        {
            if (CustomerSubGroups.Any(x => string.Equals(x.Name.Trim(), name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new DomainException($"{ExceptionConsts.EntitiyAlreadyExists}: {name}");
            }

            var customerSubGroup = new CustomerSubGroup(userId, name, this.Id, description);
            CustomerSubGroups.Add(customerSubGroup);
            return customerSubGroup;
        }

        public CustomerSubGroup UpdateSubGroup(
            string? userId,
            string name,
            string? description
            )
        {
            var customerSubGroup = CustomerSubGroups.SingleOrDefault(x => string.Equals(x.Name.Trim(), name, StringComparison.OrdinalIgnoreCase));
            if (customerSubGroup == null)
            {
                throw new DomainException($"{ExceptionConsts.EntitiyNotFound}: {name}");
            }
            if (CustomerSubGroups.Any(x => string.Equals(x.Name.Trim(), name, StringComparison.OrdinalIgnoreCase) 
                && x.Id != customerSubGroup.Id))
            {
                throw new DomainException($"{ExceptionConsts.EntitiyAlreadyExists}: {name}");
            }

            customerSubGroup.Update(userId, name, description);
            return customerSubGroup;
        }

        public CustomerSubGroup DeleteSubGroup(
            string? userId,
            string customerSubGroupId
            )
        {
            var customerSubGroup = CustomerSubGroups.SingleOrDefault(x => string.Equals(x.Id, customerSubGroupId, StringComparison.OrdinalIgnoreCase));
            if (customerSubGroup == null)
            {
                throw new DomainException($"{ExceptionConsts.EntitiyNotFound}: {customerSubGroupId}");
            }

            customerSubGroup.Delete(userId);
            return customerSubGroup;
        }

        public CustomerSubGroup GetCustomerSubGroup(
            string customerSubGroupId
            )
        {
            var customerSubGroup = CustomerSubGroups.SingleOrDefault(x => string.Equals(x.Id, customerSubGroupId, StringComparison.OrdinalIgnoreCase));
            if (customerSubGroup == null)
            {
                throw new DomainException($"{ExceptionConsts.EntitiyNotFound}: {customerSubGroupId}");
            }

            return customerSubGroup;
        }
    }
}
