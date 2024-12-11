using Azure;
using CRM.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProcessing.Entities;
using Shipment.Entities;
using VijaySalesAPI.Models;

namespace VijaySalesAPI.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class BIController : ControllerBase

    {
        [Authorize]
        [HttpGet("getCustomer/{id}")]

        public async Task<IActionResult> GetCustomerProfile(int id)
        {
            var api = "http://localhost:5218/api/Users/";

            try
            {
                HttpClient client = new HttpClient();
                
                var response = await client.GetAsync(api);
                ; if (!response.IsSuccessStatusCode)
                {
                    return BadRequest(new { message = "customer not found!" });
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var userData = JsonConvert.DeserializeObject<List<User>>(content);

                    var user = userData.Find(x => x.Id == id);

                    if (user == null) return BadRequest(new { message = "customer not found!" });

                    return Ok(user);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }
        [Authorize]
        [HttpGet("getOrders/{id}")]

        public async Task<IActionResult> GetOrderHistory(int id)
        {
            string orderAPI = "http://localhost:5218/api/orders/customer/" + id;
            string getStatAPI = "http://localhost:5218/api/shipments/order/";
            List<FilteredOrder> orderList = new List<FilteredOrder>();
            try
            {

                HttpClient client = new HttpClient();
                var response = await client.GetAsync(orderAPI);
                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest(new { message = "order not found!" });
                }
                else
                {
                    var orderResponse = await response.Content.ReadAsStringAsync();

                    //get orders by customer id

                    var res = await client.GetAsync(orderAPI);
                    var jsonData = await res.Content.ReadAsStringAsync();
                    var orders = JsonConvert.DeserializeObject<List<OrderList>>(jsonData);

                foreach (OrderList order in orders)
                    {
                    res = await client.GetAsync(getStatAPI + order.OrderId);
                    string delStat = await res.Content.ReadAsStringAsync();

                        orderList.Add(new FilteredOrder { order = order, status =  delStat});

                    orderList.Add(new FilteredOrder
                    {
                        order = order,
                        status = delStat
                    });

                }
                return StatusCode(200, orderList);

            }

            }catch(Exception ex)
            { 
                return StatusCode(500, ex.Message);
            }
            }

        [HttpGet("getbalance/{id}")]

        public async Task<IActionResult> GetAccountBalance(int id)
        {

            //handle both situation like when user has an account and where not.
            string api = "" + id;
            try
            {

                HttpClient client = new HttpClient();
                var res = await client.GetAsync(api);
                if (res == null)
                {
                    return StatusCode(404, $"User does not have account");
                }
                else
                {
                    var jsonbalance = await res.Content.ReadAsStringAsync();

                    var balance = JsonConvert.DeserializeObject<double>(jsonbalance);

                    return Ok(balance);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            return Ok(new { id });

        }
    }

}

       

    

