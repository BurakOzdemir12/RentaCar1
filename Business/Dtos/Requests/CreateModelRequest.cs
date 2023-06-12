using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests
{
    public class CreateModelRequest
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set;}
    }
}
