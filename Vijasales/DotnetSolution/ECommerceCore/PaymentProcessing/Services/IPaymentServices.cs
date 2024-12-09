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
        Task<double> GetAmount(int OrderId);
        Task<bool> PayNow(int orderId, string fromAccountNumber, string paymentMode);
        Task<bool> InsertPaymentAsync(Payment payment);
        Task<bool> UpdatePaymentAsync(Payment payment);
    }
}
