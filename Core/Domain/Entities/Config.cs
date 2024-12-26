using Domain.Bases;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Config : BaseEntityCommon, IAggregateRoot
    {
        public string CurrencyId { get; set; } = null!;
        public string SmptHost { get; set; } = null!;
        public int SmptPort { get; set; }
        public string SmptUserName { get; set; } = null!;
        public string SmptPassword { get; set; } = null!;
        public string SmptUseSsl { get; set; } = null!;
        public bool Active { get; set; }

        public Config() : base() { } // For EF

        public Config(
            string userId,
            string name,
            string currencyId,
            string smptHost,
            int smptPort,
            string smptUserName,
            string smptPassword,
            string smptUseSsl,
            bool active,
            string? description = null
            ) : base(userId, name, description)
        {
            CurrencyId = currencyId.Trim();
            SmptHost = smptHost.Trim();
            SmptPort = smptPort;
            SmptUserName = smptUserName.Trim();
            SmptPassword = smptPassword.Trim();
            SmptUseSsl = smptUseSsl.Trim();
            Active = active;
        }

        public void Update(
            string? userId,
            string name,
            string? description,
            string currencyId,
            string smptHost,
            int smptPort,
            string smptUserName,
            string smptPassword,
            bool smptUseSsl,
            bool active
            )
        {
            Name = name.Trim();
            Description = description?.Trim();
            CurrencyId = currencyId.Trim();
            SmptHost = smptHost.Trim();
            SmptPort = smptPort;
            SmptUserName = smptUserName.Trim();
            if (!string.IsNullOrEmpty(smptPassword?.Trim())) 
            {
                SmptPassword = smptPassword!.Trim();
            }
            SmptUseSsl = smptUseSsl.ToString();
            Active = active;

            SetAudit(userId);
        }

        public void Delete(
            string? userId
            )
        {
            SetAsDeleted();
            SetAudit(userId);
        }
    }
}
