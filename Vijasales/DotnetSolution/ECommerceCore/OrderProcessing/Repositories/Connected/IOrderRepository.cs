﻿using OrderProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Repositories.Connected
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetOrder(int id);
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id);
    }
}
