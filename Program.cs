using MassTransit;
using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using rabbitmq_message.BusConfiguration;
using rabbitmq_saga.DbConfiguration;
using rabbitmq_saga.StateMachine;
using System.Reflection;
using System.Threading.Tasks;

namespace saga_machine
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=NAG6CHANDRVAR01;Database=OrderDb;Trusted_Connection=True;";

            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddMassTransit(cfg =>
                   {
                       cfg.AddSagaStateMachine<OrderStateMachine, OrderStateData>()

                        .EntityFrameworkRepository(r =>
                        {
                            r.ConcurrencyMode = ConcurrencyMode.Pessimistic; // or use Optimistic, which requires RowVersion

                            r.AddDbContext<DbContext, OrderStateDbContext>((provider, builder) =>
                            {
                                builder.UseSqlServer(connectionString, m =>
                                {
                                    m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
                                    m.MigrationsHistoryTable($"__{nameof(OrderStateDbContext)}");
                                });
                            });
                        });

                       cfg.AddBus(provider => RabbitMqBus.ConfigureBus(provider));
                   });

                   services.AddMassTransitHostedService();
               });

            await builder.RunConsoleAsync();
        }
    }
}
