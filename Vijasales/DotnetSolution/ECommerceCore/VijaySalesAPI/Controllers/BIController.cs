using CRM.Entities;
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

        [HttpGet("getCustomer/{id}")]

        public async Task<IActionResult> GetCustomerProfile(int id)
        {
            var api = "http://localhost:5218/api/Users/";

            try
            {
                HttpClient client = new HttpClient();
                
                var response = await client.GetAsync(api);

                if (!response.IsSuccessStatusCode)
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

        [HttpGet("getOrders/{id}")]

        public async Task<IActionResult> GetOrderHistory(int id)
        {

            //shipment api -- api/shipment/getshipment/id
            //order api --- api/orders/getorders/id

            var shipmentStatusAPI = "http://localhost:5218/api/shipments/order/";
            var ordersAPI = "http://localhost:5218/api/Orders/Customer/" + id;

            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(ordersAPI);
                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest(new { message = "order not found!" });
                }
                else
                {
                    var orderResponse = await response.Content.ReadAsStringAsync();

                    var orderData = JsonConvert.DeserializeObject<List<OrderList>>(orderResponse);

                    List<FilteredOrder> orders = new List<FilteredOrder>();

                    foreach (OrderList order in orderData)
                    {
                        var shipmentResponse = await client.GetAsync(shipmentStatusAPI + order.OrderId);

                        var status = await shipmentResponse.Content.ReadAsStringAsync();

                        var shipmentStatus = JsonConvert.DeserializeObject(status);

                        orders.Add(new FilteredOrder { order = order, status =  shipmentStatus.ToString()});

                    }
                    return Ok(orders);

                }

            }

            catch (Exception ex)
            { 
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }

        }

        //fetch balance based on user id

        [HttpGet("getOrdersByMonth/{id}")]
        public async Task<IActionResult> GetOrdersByMonth(int id)
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
        }
    }

}

