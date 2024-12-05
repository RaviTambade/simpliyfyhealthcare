using System.Threading.Tasks;
namespace MathLib
{
    //Business Logic Layer Class
    public class Calculator
    {

        //Synchronous methods : Asynchronous

        //Blocking Call

        public int Sum(int x, int y)
        {
            return  x +y;
        }

        public int Subtract(int x, int y)
        {
            return x-y;
        }
        public int Multiply(int x, int y)
        {
            return  x * y;
        }

        public int Divide(int x, int y)
        {
            return x/y;
        }


        //Asychronous Function
        public async  Task<int> ProcessRequestAsync()
        {
            try
            {
                //Long running process
                //you would invoke remote rest api 
                //which would take some time duration to return result
                 await Task.Delay(5000); //simulate delay
                return 78;
            }
            catch (Exception e) {
                return -1;
            }
        }
    }
}