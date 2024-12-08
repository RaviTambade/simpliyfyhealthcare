using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessing.Entities;

namespace PaymentProcessing.Repositories.Connected
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment> GetPaymentAsync(int id);
        Task<bool> InsertAsync(Payment payment);
        Task<bool> UpdateAsync(Payment payment);
        Task<(string status, string Tid)> ExecuteFundTransferProcedure(int customerAccountId, int adminAccountId, decimal amount, string paymentMode);
    }
}
