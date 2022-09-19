using EmporiumRemuneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmporiumRemuneration.Context;

namespace EmporiumRemuneration.Repositories
{
    public class ConsumerRepository : IConsumerInfo
    {
        private static  List<ConsumerInfo> _consumerList = new List<ConsumerInfo>() {  new ConsumerInfo { ConsumerID = 100, FirstName="VenkataChari" , LastName="Thummapala", Address1="Amalapuram" , Address2="Vidyut Nagar" , PhoneNumber="919866341701", ZipCode="533201" },
                    
            new ConsumerInfo { ConsumerID = 101, FirstName="Susella" , LastName="Thummapala", Address1="Amalapuram" , Address2="Vidyut Nagar" , PhoneNumber="917411586573", ZipCode="533201" } };

        readonly EmporiumContext _emporiumContext;

        public ConsumerRepository(EmporiumContext emporiumCxt)
        {
            _emporiumContext = emporiumCxt;
        }
        public bool AddConsumer(ConsumerInfo consumer)
        {
          
            try
            {

                _emporiumContext.Consumers.Add(consumer);
                _emporiumContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
          
            return true ;
        }

        public void DeleteConsumer(long Id)
        {
            ConsumerInfo _conInfo = _emporiumContext.Consumers.Where(X => X.ConsumerID == Id).FirstOrDefault();
            _emporiumContext.Consumers.Remove(_conInfo);
            _emporiumContext.SaveChanges();
        }

        public ConsumerInfo EditConsumer(ConsumerInfo consumer, long Id)
        {
            var _ConsumerInfo = _emporiumContext.Consumers.Where(X => X.ConsumerID == Id).FirstOrDefault();

            if (_ConsumerInfo == null)
                return null;

            _ConsumerInfo.FirstName = consumer.FirstName;
            _ConsumerInfo.LastName = consumer.LastName;
            _ConsumerInfo.PhoneNumber = consumer.PhoneNumber;

            _emporiumContext.SaveChanges();
            return _ConsumerInfo;
        }

        public ConsumerInfo GetConsumerById(long Id)
        {
            return _emporiumContext.Consumers.Where(X => X.ConsumerID == Id).FirstOrDefault();
            
        }

        public List<ConsumerInfo> GetConsumers()
        {
            return _emporiumContext.Consumers.ToList();
        }
    }
}
