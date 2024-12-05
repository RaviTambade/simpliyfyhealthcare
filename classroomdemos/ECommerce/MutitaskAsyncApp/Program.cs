using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutitaskAsyncApp
{
    internal class Program
    {
        static async Task<string> FetchDataAsync()
        {
        
            // Simulate fetching data asynchronously with a delay of 2 seconds
            await Task.Delay(10);
            return "Data fetched successfully!";
        }

        static async Task ProcessDataAsync()
        {
            try
            {
                // Call FetchDataAsync() and await its completion
                string data = await FetchDataAsync();
                Console.WriteLine(data); // Data fetched successfully!
                                        // Process the fetched data...
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching data: " + ex.Message);
            }
        }

        static async Task Main(string[] args)
        {
            // Call ProcessDataAsync() and await its completion
            await ProcessDataAsync();
        }
    }
}
