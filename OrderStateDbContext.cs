using MassTransit.EntityFrameworkCoreIntegration;
using MassTransit.EntityFrameworkCoreIntegration.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace rabbitmq_saga.DbConfiguration
{
    public class OrderStateDbContext :
    SagaDbContext
    {
        public OrderStateDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get { yield return new OrderStateMap(); }
        }
    }
}
