using RepairHub.Database.Context;

namespace RepairHub.Mvc.Infrastructure.Services
{
    public class DatabaseInit : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly IConfiguration _configuration;
        public DatabaseInit(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _provider = serviceProvider;
        }
        private async Task Handle(CancellationToken cancellationToken)
        {
            using var scope = _provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<RepairHubContext>();
            try
            {
                if (_configuration.GetValue<bool>("DeleteDatabase"))
                    await context.Database.EnsureDeletedAsync(cancellationToken);
            }
            catch { }
            await context.Database.EnsureCreatedAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Handle(stoppingToken);
        }
    }
}
