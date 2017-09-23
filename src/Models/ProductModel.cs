using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AlphaCompanyWebApi.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDetailSummary { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
