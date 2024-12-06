using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessing.Entities;

namespace PaymentProcessing.Services
{
    public interface IPaymentServices
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment> GetPaymentAsync(int id);
    }
}
