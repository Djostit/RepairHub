namespace RepairHub.Mvc.Infrastructure.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(dynamic user);
    }
}
