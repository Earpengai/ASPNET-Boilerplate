﻿using Domain.Bases;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class VendorContact : BaseEntityAudit, IEntity
    {
        public string VendorId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string GenderId { get; set; } = null!;
        public string? Description { get; set; }
        public string JobTitle { get; set; } = null!;
        public string? MobilePhone { get; set; }
        public string? SocialMedia { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? StateOrProvince { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }

        public VendorContact() : base() { } // For EF Core

        internal VendorContact(
            string? userId,
            string vendorId,
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
            string? website) : base(userId)
        {
            VendorId = vendorId.Trim();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            GenderId = genderId.Trim();
            Description = description?.Trim();
            JobTitle = jobTitle.Trim();
            MobilePhone = mobilePhone?.Trim();
            SocialMedia = socialMedia?.Trim();
            Address = address?.Trim();
            City = city?.Trim();
            StateOrProvince = stateOrProvince?.Trim();
            ZipCode = zipCode?.Trim();
            Country = country?.Trim();
            Phone = phone.Trim();
            Email = email.Trim();
            Website = website?.Trim();
        }

        internal void Update(
            string? userId,
            string vendorId,
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
            VendorId = vendorId.Trim();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            GenderId = genderId.Trim();
            Description = description?.Trim();
            JobTitle = jobTitle.Trim();
            MobilePhone = mobilePhone?.Trim();
            SocialMedia = socialMedia?.Trim();
            Address = address?.Trim();
            City = city?.Trim();
            StateOrProvince = stateOrProvince?.Trim();
            ZipCode = zipCode?.Trim();
            Country = country?.Trim();
            Phone = phone.Trim();
            Email = email.Trim();
            Website = website?.Trim();

            SetAudit(userId);
        }

        internal void Delete(string userId)
        {
            SetAsDeleted();
            SetAudit(userId);
        }
    }
}