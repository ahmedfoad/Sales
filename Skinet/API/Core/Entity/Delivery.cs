using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.Entity
{
    public class Delivery : BaseEntity
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public int Price { get; set; }
    }
}


//"ShortName": "UPS2",
//"Description": "Get it within 5 days",
//"DeliveryTime": "2-5 Days",
//"Price": 5