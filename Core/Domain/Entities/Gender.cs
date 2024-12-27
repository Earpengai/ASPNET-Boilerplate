using Domain.Bases;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Gender : BaseEntityCommon, IAggregateRoot
    {
        public Gender() : base() { } // For EF Core

        public Gender(
            string? userId,
            string name,
            string description
        ) : base(userId, name, description) { }

        public void Update(
            string? userId,
            string name,
            string description
        )
        {
            Name = name.Trim();
            Description = description.Trim();

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
