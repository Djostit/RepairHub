namespace RepairHub.Domain.Requests
{
    public class UserRequest
    {
        public string Login { get; set; } = null!;
        public string HashPassword { get; set; } = null!;
    }
}
