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
    public class TranscationController : ControllerBase
    {
        ITranscationInfo _TransInfo;
        public TranscationController(ITranscationInfo TransCxt)
        {
            _TransInfo = TransCxt;
        }

        [HttpGet]
        [Route("getAllTransDetailsByConsumerId")]
        public IActionResult GetTransDetailsByConsumerId(long Id)
        {
            return Ok(_TransInfo.GetTransListByConsumerId(Id));
        }

        [HttpGet]
        [Route("getMonthlyConsumerTransDetails")]
        public IActionResult GetMonthlyTransDetailsByConsumerId(long Id,int Month,int cnt)
        {
            return Ok(_TransInfo.GetTransListByCosumerIdwithMonth(Id ,Month,cnt));
        }

        [HttpPost]
        [Route("AddTransDetails")]
        public IActionResult AddTranscationDetails(TranscationDetails TransDetails)
        {
            return Ok(_TransInfo.AddTransDetails(TransDetails));
        }

    }
}
