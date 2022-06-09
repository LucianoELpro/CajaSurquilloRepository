using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class CardRequest
    {
        public string IdCardRequest { get; set; }
        public string IdMasterModeOfDelivery { get; set; }
        public string DeliveryAddress { get; set; }
        public string IdMasterAgencyOfDelivery { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string IdMasterCardType { get; set; }
        public string IdMasterSecurityType { get; set; }
        public decimal DesgravamentValue { get; set; }
        public string IdMasterCreditRisk { get; set; }
        public int IdProduct { get; set; }
        public bool CardDisposition { get; set; }
        public bool PurchaseAbroad { get; set; }
        public bool PuchaseOnline { get; set; }

        public DateTime Create { get; set; }
        public int CreateBy { get; set; }
        public DateTime Modified { get; set; }
        public int LastModififiedBy { get; set; }
        public string RecordStatus { get; set; }
        public string IdMasterFlowStatus { get; set; }
    }
}
