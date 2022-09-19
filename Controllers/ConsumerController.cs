using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmporiumRemuneration.Repositories;
using EmporiumRemuneration.Models;

namespace EmporiumRemuneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        IConsumerInfo _consumerInfo;
        public ConsumerController(IConsumerInfo  consumerCxt)
        {
            _consumerInfo = consumerCxt;
        }

        [HttpGet]
        [Route("getAllConsumers")]
        public IActionResult GetConsumers()
        {
            return Ok(_consumerInfo.GetConsumers());
        }
        
        [HttpGet]
        [Route("getConsumerById")]
        public IActionResult GetConsumerById(long Id)
        {
            if (_consumerInfo.GetConsumerById(Id) == null)
                return NotFound("Consumer do not exists");

            return Ok(_consumerInfo.GetConsumerById(Id));
        }

        [HttpPost]
        [Route("AddConsumer")]
        public IActionResult AddConsumer(ConsumerInfo consumer)
        {
            //_consumerInfo.AddConsumer(consumer);
            //consumer.ConsumerID = Guid.NewGuid();
            return Ok(_consumerInfo.AddConsumer(consumer));
        }


        [HttpPut]
        [Route("EditConsumer")]
        public IActionResult EditConsumer(ConsumerInfo consumer , long Id)
        {
            ConsumerInfo _consInfo = _consumerInfo.EditConsumer(consumer, Id);
          
           if (_consInfo == null)
            return NotFound("Consumer not found");

            return Ok(_consumerInfo.GetConsumers());
        }

        [HttpDelete]
        [Route("DeleteConsumer")]
        public IActionResult DeleteConsumer(long Id)
        {
             _consumerInfo.DeleteConsumer(Id);
            return Ok(_consumerInfo.GetConsumers());
        }



    }
}
