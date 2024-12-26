using Domain.Bases;
using Domain.Interfaces;
namespace Domain.Entities
{
    public class Customer : BaseEntityAdvance, IAggregateRoot
    {
        public string CustomerGroupId { get; set; } = null!;
        public string? CustomerSubGroupId { get; set; }
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string StateOrProvince { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? Country { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Website { get; set; } = null!;
        public ICollection<CustomerContact> CustomerContacts { get; set; } = [];

        public Customer() : base() { } // For EF

        public Customer(
            string? userId,
            string code,
            string name,
            string customerGroupId,
            string street,
            string city,
            string stateOrProvince,
            string zipCode,
            string phone,
            string email,
            string? description = null,
            string? customerSubGroupId = null,
            string? country = null,
            string? website = null
            ) : base(userId, code, name, description)
        {
            CustomerGroupId = customerGroupId.Trim();
            CustomerSubGroupId = customerSubGroupId?.Trim();
            Street = street.Trim();
            City = city.Trim();
            StateOrProvince = stateOrProvince.Trim();
            ZipCode = zipCode.Trim();
            Country = country?.Trim();
            Phone = phone.Trim();
            Email = email.Trim();
            Website = website?.Trim();
            CustomerContacts = [];
        }

        public void Update(
            string? userId,
            string code,
            string name,
            string customerGroupId,
            string street,
            string city,
            string stateOrProvince,
            string zipCode,
            string phone,
            string email,
            string? description,
            string? customerSubGroupId,
            string? country,
            string? website
            )
        {
            Code = code.Trim();
            Name = name.Trim();
            CustomerGroupId = customerGroupId.Trim();
            CustomerSubGroupId = customerSubGroupId?.Trim();
            Street = street.Trim();
            City = city.Trim();
            StateOrProvince = stateOrProvince.Trim();
            ZipCode = zipCode.Trim();
            Country = country?.Trim();
            Phone = phone.Trim();
            Email = email.Trim();
            Website = website?.Trim();
            Description = description?.Trim();

            SetAudit(userId);
        }

        public void Delete(
            string? userId
            )
        {
            foreach (CustomerContact contact in CustomerContacts)
            {
                
            }
            SetAsDeleted();
            SetAudit(userId);
        }

        public CustomerContact CreateContact(
            string? userId,
            string firstName,
            string lastName,
            string genderId,
            string? description,
            string jobTitle,
            string? mobilePhone,
            string? socialMedia,
            string? address,
            string? city,
            string? stateOrProvince,
            string? zipCode,
            string? country,
            string phone,
            string email,
            string? website
            )
        {
            
        }
    }
}
