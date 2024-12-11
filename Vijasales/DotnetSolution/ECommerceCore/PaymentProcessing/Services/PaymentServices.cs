using PaymentProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessing.Repositories.Connected;
using OrderProcessing.Repositories.Connected;

namespace PaymentProcessing.Services
{
    public class PaymentServices : IPaymentServices
    {
        private  IPaymentRepository _repo;

        public PaymentServices(IPaymentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Payment>> GetPaymentsByCustomerIdAsync(int customerId)
        {
            // Get the payments directly from the repository using the customerId
            List<Payment> payments = await _repo.GetPaymentsByCustomerIdAsync(customerId);

            // Return the list of payments (which was already filtered by customerId in the repository)
            return payments;
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<double> GetAmount(int OrderId)
        {
            return await _repo.GetAmount(OrderId);
        }

        public async Task<Payment> GetPaymentAsync(int id)
        {
            return await _repo.GetPaymentAsync(id);
        }

<<<<<<< HEAD
=======

>>>>>>> 3ec300bf8ce64754610ae48243db12a966af9686

        public async Task<bool> PayNow(int orderId, string fromAccountNumber, string paymentMode)
        {
            Payment payment = new Payment { OrderId=orderId,PaymentMode=paymentMode, Id=0};
            string toAccountNumber = "918888926475";
            payment.Id  = await _repo.InsertAsync(payment);
            double amount = await _repo.GetAmount(orderId);
            var (status, transactionId) = await _repo.ExecuteFundTransferProcedure(fromAccountNumber, toAccountNumber, amount, paymentMode);
            // Update the Payment object with the status and transaction ID    
            payment.PaymentStatus = status;
            payment.TransactionId = transactionId;
            payment.PaymentAmount = amount;
            DateTime currentDate = DateTime.Now.Date;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            payment.PaymentDate = formattedDate;
            // Update the Payment record with the new information
            bool updateSuccess = await _repo.UpdateAsync(payment);
            return updateSuccess;
        }
<<<<<<< HEAD
=======


<<<<<<< HEAD
=======
<<<<<<< HEAD


        public Task<bool> InsertPaymentAsync(Payment payment)
        {
            return _repo.InsertAsync(payment);
        }

        public Task<bool> UpdatePaymentAsync(Payment payment)
        {
            return _repo.UpdateAsync(payment);
        }
=======
=======
>>>>>>> 9fcdc4b5d785379b3bf1454a1696e5f49b3f0f84
>>>>>>> 3ec300bf8ce64754610ae48243db12a966af9686
>>>>>>> 5cb31ec77b5792d08c1cbffb46d7aea0ac1a310e
>>>>>>> 9f138423b37ef8986c2a0204305b3bec18594860
    }
}
