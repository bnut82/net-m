using Macrix.Database;

namespace MacrixPoc.Services;

public class StartupTask(IServiceProvider provider) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MacrixContext>();

        context.Users.RemoveRange(context.Users);
        context.SaveChanges();
      
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}