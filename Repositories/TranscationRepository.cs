using EmporiumRemuneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmporiumRemuneration.Context;



namespace EmporiumRemuneration.Repositories
{
    public class TranscationRepository : ITranscationInfo
    {
        public static List<TranscationDetails> _TrnsDetails = new List<TranscationDetails>()
        {
            new TranscationDetails { CustomerID = 1000, TranscationID = Guid.NewGuid(), TransDate = DateTime.Now , PurchaseList = new List<ProductInfo> { new ProductInfo { Id= 1000 , Name="Item01", Price=100 , Quantity = 2 }, new ProductInfo{ Id = 1001 , Name="Item02",Price= 200 , Quantity= 3 }} },
            new TranscationDetails { CustomerID = 1001, TranscationID = Guid.NewGuid(), TransDate = DateTime.Now , PurchaseList = new List<ProductInfo> { new ProductInfo { Id= 1000 , Name="Item03", Price=100 , Quantity = 2 }, new ProductInfo{ Id = 1001 , Name="Item03",Price= 200 , Quantity= 3 }} },

        };

         EmporiumContext  _TranscationContext;

        public TranscationRepository(EmporiumContext _TranscationCxt)
        {
            _TranscationContext = _TranscationCxt;
        }

        public bool AddTransDetails(TranscationDetails transdetails)
        {
            try
            {
                var transInfo  = DataTransformed2DB(transdetails);
                transInfo.TransDate = DateTime.Now;
                _TranscationContext.EmporiumTranscations.Add(transInfo);
                _TranscationContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

       
        public List<TranscationDetails> GetTransListByConsumerId(long Id)
        {
            List<TranscationDetails> _TransDetails = new List<TranscationDetails>();
            
            List<TranscationInformation> _TransByCustomerIdList = _TranscationContext.EmporiumTranscations.Where(X=>X.CustomerID == Id).Select(Y=>Y).ToList();
            
            foreach(TranscationInformation _TransInfo in _TransByCustomerIdList)
            {
                _TransDetails.Add(DataTransformedfromDB(_TransInfo));
            }

            return _TransDetails;
        }

        public List<TranscationDetails> GetTransListByCosumerIdwithMonth(long ConsumerId, int month , int count)
        {
            DateTime _startDt;
            DateTime _endDt;
            List<TranscationDetails> _TransDetails = new List<TranscationDetails>();
            GetDateRange(out _startDt, out _endDt, month, count);

           var _transInformationList =  _TranscationContext.EmporiumTranscations.Where(X => X.CustomerID == ConsumerId && (X.TransDate > _startDt && X.TransDate <= _endDt)).Select(X => X).ToList();
           
            foreach(TranscationInformation _TransInfo in _transInformationList)
            {
                _TransDetails.Add(DataTransformedfromDB(_TransInfo));
            }

            return _TransDetails;
            
        }


        private void GetDateRange(out DateTime _DtStart, out DateTime _DtEnd, int Month, int Count)
        {
            _DtStart = new DateTime(DateTime.Now.Year, Month, 1);
            _DtEnd = _DtStart.AddMonths(Count).AddDays(-1);
        }

        private TranscationInformation DataTransformed2DB(TranscationDetails _transDetails)
        {
            TranscationInformation _TransInfo = new TranscationInformation();

            _TransInfo.CustomerID = _transDetails.CustomerID;
            _TransInfo.TranscationID = _transDetails.TranscationID;
            _TransInfo.TransDate = _transDetails.TransDate;
            _TransInfo.PurchaseList = JsonSerializer.Serialize<List<ProductInfo>>(_transDetails.PurchaseList);

            return _TransInfo;
        }

        private TranscationDetails DataTransformedfromDB(TranscationInformation _transInfo)
        {
            TranscationDetails _TransInfo = new TranscationDetails();

            _TransInfo.CustomerID = _transInfo.CustomerID;
            _TransInfo.TranscationID = _transInfo.TranscationID;
            _TransInfo.TransDate = _transInfo.TransDate;
            _TransInfo.PurchaseList = JsonSerializer.Deserialize<List<ProductInfo>>(_transInfo.PurchaseList);
            _TransInfo.TransTotal = _TransInfo.PurchaseList.Select(X => X.Price * X.Quantity).Sum();
            _TransInfo.RewardPoints = CalcRewardPoints(_TransInfo.TransTotal);
            return _TransInfo;
        }
        private int  CalcRewardPoints(decimal TransTotal)
        {
            if (TransTotal < 50)
                return 0;

            if (TransTotal >= 50 && TransTotal <= 100)
                return 1;

            decimal _divident = 50;
            decimal _rewardPoints = (TransTotal/_divident) ;

            return (int)_rewardPoints;
  
        }

    }
}
