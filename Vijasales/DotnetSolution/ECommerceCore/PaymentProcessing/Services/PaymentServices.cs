﻿using PaymentProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentProcessing.Repositories.Connected;

namespace PaymentProcessing.Services
{
    public class PaymentServices : IPaymentServices
    {
        private IPaymentRepository _repo;
        public PaymentServices(IPaymentRepository repo)
        {
            _repo = repo;
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



        public async Task<bool> PayNow(int orderId, string fromAccountNumber, string paymentMode)
        {
            Payment payment = new Payment { OrderId=orderId,PaymentMode=paymentMode};
            string toAccountNumber = "918888926475";
             await _repo.InsertAsync(payment);
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
>>>>>>> 3e3c6050d1e1936886f42a5a5c2b4994c8f8a699
        public Task<bool> InsertPaymentAsync(Payment payment)
        {
            return _repo.InsertAsync(payment);
        }

        public Task<bool> UpdatePaymentAsync(Payment payment)
        {
            return _repo.UpdateAsync(payment);
        }
    }
}
