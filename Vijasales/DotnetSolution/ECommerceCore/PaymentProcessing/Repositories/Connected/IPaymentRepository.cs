using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessing.Entities;
using OrderProcessing.Entities;

namespace PaymentProcessing.Repositories.Connected
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllAsync();
        Task<Payment> GetPaymentAsync(int id);
        Task<int> InsertAsync(Payment payment);
        Task<bool> UpdateAsync(Payment payment);
        Task<double> GetAmount(int OrderId);
        Task<(string status, string Tid)> ExecuteFundTransferProcedure(string customerAccountId, string adminAccountId, double amount, string paymentMode);
        Task<List<Payment>> GetPaymentsByCustomerIdAsync(int customerId);
        Task<double> GetTotalRevenueForAccountAsync(int month, string v);
    }
}
