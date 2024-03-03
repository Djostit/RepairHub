namespace RepairHub.Database.Entities
{
    public partial class Application : Base.Entity
    {
        public int StatusId { get; set; }
        public int ProblemId { get; set; }
        public int EquipmentId { get; set; }
        public int WorkStatusId { get; set; }
        public DateOnly DateAddition { get; set; }
        public DateOnly? DateEnd { get; set; }
        public string? Comment { get; set; } = null;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public static string FIO => "[{LastName}] [{FirstName}] [{MiddleName}]";
        public float Cost { get; set; }
        public TimeSpan TimeWork { get; set; }
        public virtual WorkStatus WorkStatus { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Problem Problem { get; set; }
        public virtual Status Status { get; set; }
    }
}
