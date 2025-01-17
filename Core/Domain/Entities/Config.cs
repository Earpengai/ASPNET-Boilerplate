﻿using Domain.Bases;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Config : BaseEntityCommon, IAggregateRoot
    {
        public string CurrencyId { get; set; } = null!;
        public string SmtpHost { get; set; } = null!;
        public int SmtpPort { get; set; }
        public string SmtpUserName { get; set; } = null!;
        public string SmtpPassword { get; set; } = null!;
        public string SmtpUseSsl { get; set; } = null!;
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
            SmtpHost = smptHost.Trim();
            SmtpPort = smptPort;
            SmtpUserName = smptUserName.Trim();
            SmtpPassword = smptPassword.Trim();
            SmtpUseSsl = smptUseSsl.Trim();
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
            SmtpHost = smptHost.Trim();
            SmtpPort = smptPort;
            SmtpUserName = smptUserName.Trim();
            if (!string.IsNullOrEmpty(smptPassword?.Trim())) 
            {
                SmtpPassword = smptPassword!.Trim();
            }
            SmtpUseSsl = smptUseSsl.ToString();
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
