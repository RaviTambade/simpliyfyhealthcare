using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectXUnitVijaySales.Utility
{
    public class FlowersUtility
    {
        public List<string>  GetTodayFreshFlowers() { 
           
            List<string> flowers = new List<string>();
            flowers.Add("Gerbera");
            flowers.Add("Rose");
            flowers.Add("Lily");
            flowers.Add("Jasmine");
            flowers.Add("Lotus");

            return flowers;
        }

        public List<string> GetFreshFlowers()
        {
            List<string> flowers = new List<string>();
            flowers.Add("Lily");
            flowers.Add("Mogara");
            flowers.Add("Lily");
            flowers.Add("Jaee");
            flowers.Add("Juee");
            return flowers;
        }

    }
}
