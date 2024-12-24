namespace Domain.Bases
{
    public abstract class BaseEntityAdvance : BaseEntityAudit
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        protected BaseEntityAdvance() { } // for EF Core
        protected BaseEntityAdvance(
            string? userId,
            string code,
            string name,
            string? description
            ) : base(userId)
        {
            Code = code.Trim();
            Name = name.Trim();
            Description = description?.Trim();
        }
    }
}
