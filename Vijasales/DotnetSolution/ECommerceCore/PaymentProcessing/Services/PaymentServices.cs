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



        public async Task<Payment> GetPaymentAsync(int id)
        {
            return await _repo.GetPaymentAsync(id);
        }

<<<<<<< HEAD
        public async Task<(string status)> PayNow(int orderId)
=======
        /*
        public async Task<(string status)> PayNow(int orderId, string fromAccountNumber, string paymentMode)
>>>>>>> 3f6c8ede93d69fab84664e5cd5e552d0ed3eb2ee
        {
            Payment payment = new Payment { OrderId=orderId,PaymentMode=paymentMode };
            return _repo.InsertAsync(payment);


        }
        */

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
