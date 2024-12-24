namespace Domain.Bases
{
    public abstract class BaseEntityCommon : BaseEntityAudit
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        protected BaseEntityCommon() { } // for EF Core

        protected BaseEntityCommon(
            string? userId,
            string name,
            string? description
            ) : base(userId)
        {
            Name = name.Trim();
            Description = description?.Trim();
        }
    }
}
