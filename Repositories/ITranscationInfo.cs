using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmporiumRemuneration.Models;

namespace EmporiumRemuneration.Repositories
{
    public interface ITranscationInfo
    {
        bool AddTransDetails(TranscationDetails transdetails);
        List<TranscationDetails> GetTransListByConsumerId(long ConsumerId);
        List<TranscationDetails> GetTransListByCosumerIdwithMonth(long ConsumerId, int  Month , int Count);

    }
}
