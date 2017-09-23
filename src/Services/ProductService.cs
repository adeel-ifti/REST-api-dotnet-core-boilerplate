using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using AlphaCompanyWebApi.Models;
using Microsoft.EntityFrameworkCore;
using AlphaCompanyWebApi.Entitites;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using System.Text;

namespace AlphaCompanyWebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ApiDbContext _context;
        const string ServiceBusConnectionString = "Endpoint=sb://AlphaCompanydevsb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=k7Ek7Qu/tuclCkqknL5Db8kGPRyD4trnWbNfqcYFz44=";
        const string QueueName = "AlphaCompany.we.dev.sbcrmqueue";
        static IQueueClient queueClient;

        public ProductService(ApiDbContext context)
        {
            _context = context;
        }

        //Logic App CRM Connecter here
        public async Task<List<ProductModel>> GetProductsAsync(CancellationToken ct)
        {
            var entity = await _context
                .Products.ToArrayAsync();

            return Mapper.Map<List<ProductModel>>(entity);
        }

        public async void SendMessageToCrmQueue(ActivityModel messageBody)
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
            //messageBody = $"Message test";
            var message = new Message(Encoding.UTF8.GetBytes(messageBody.Firstname + " " + messageBody.Lastname));

            // Send the message to the queue
            await queueClient.SendAsync(message);
        }
    }
}

