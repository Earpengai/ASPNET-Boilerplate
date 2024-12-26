using Domain.Bases;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Currency : BaseEntityCommon, IAggregateRoot
    {
        public string Code { get; set; } = null!;
        public string Symbol { get; set; } = null!;

        public Currency() : base() { } // For EF

        public Currency(
            string userId,
            string name,
            string code,
            string symbol,
            string? description
            ) : base(userId, name, description)
        {
            Code = code.Trim();
            Symbol = symbol.Trim();
        }

        public void Update(
            string? userId,
            string name,
            string? description,
            string code,
            string symbol
            )
        {
            Name = name.Trim();
            Description = description?.Trim();
            Code = code.Trim();
            Symbol = symbol.Trim();

            SetAudit(userId);
        }

        public void Delete(
            string userId
            )
        {
            SetAsDeleted();
            SetAudit(userId);
        }
    }
}
