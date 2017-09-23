using System;
using System.Threading;
using System.Threading.Tasks;
using AlphaCompanyWebApi.Models;
using System.Collections.Generic;

namespace AlphaCompanyWebApi.Services
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetProductsAsync( CancellationToken ct);

        void SendMessageToCrmQueue(ActivityModel messageBody);


    }
}
