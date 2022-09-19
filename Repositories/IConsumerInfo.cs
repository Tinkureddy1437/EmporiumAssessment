using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmporiumRemuneration.Models;

namespace EmporiumRemuneration.Repositories
{
    public  interface IConsumerInfo
    {
        List<ConsumerInfo> GetConsumers();
        ConsumerInfo GetConsumerById(long Id);
        bool AddConsumer(ConsumerInfo consumer);
        ConsumerInfo EditConsumer(ConsumerInfo consumer, long Id);
        void DeleteConsumer(long Id);
       
    }
}
