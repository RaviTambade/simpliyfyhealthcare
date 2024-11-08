using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty
{
    public static class PenaltyHandler
    {
        public static void ServiceDisconectionPenaltyCharges(float amount)
        {
            Console.WriteLine("Disconnection charges Applied =" + amount);
        }


        public static void NotificationPenaltyCharges(float amount)
        {
            Console.WriteLine("Notification charges Applied =" + amount);
        }
    }
}
