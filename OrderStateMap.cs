using MassTransit.EntityFrameworkCoreIntegration.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rabbitmq_saga.StateMachine;

namespace rabbitmq_saga.DbConfiguration
{
    public class OrderStateMap :
    SagaClassMap<OrderStateData>
    {
        protected override void Configure(EntityTypeBuilder<OrderStateData> entity, ModelBuilder model)
        {
            entity.Property(x => x.CurrentState).HasMaxLength(64);
            entity.Property(x => x.OrderCreationDateTime);
        }
    }
}
