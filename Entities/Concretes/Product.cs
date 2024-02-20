using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Product :IEntity //default internal => sadece entities erişebilir.Diğer katmanlarda erişsin diye public yaptık.
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }  //short int'in  bi küçüğü
        public decimal UnitPrice { get; set; }

    }
}
