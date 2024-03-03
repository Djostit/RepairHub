namespace RepairHub.Database.Entities
{
    public partial class User : Base.Entity
    {
        public int RoleId { get; set; }
        public string Login { get; set; } = null!;
        public string HashPassword { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public virtual Role Role { get; set; }
    }
}
