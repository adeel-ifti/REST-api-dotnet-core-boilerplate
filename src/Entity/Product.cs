using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaCompanyWebApi.Entitites
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDetailSummary { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ValidUntilDate { get; set; }

    }
}
