namespace RepairHub.Database.Entities
{
    public partial class Equipment : Base.Entity
    {
        public string Name { get; set; } = null!;
        public string SerialNumber { get; set; } = null!;
    }
}
