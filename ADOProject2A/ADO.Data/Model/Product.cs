using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Data.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
