using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestDesignPatternApp
{
    public  class OfficeBoy
    {
        public static OfficeBoy _ref = null;
        private OfficeBoy() { 
        
        }

        public static OfficeBoy Create()
        {
            if (_ref == null)
            {
                _ref = new OfficeBoy();
                return _ref;
            }
            else
                return _ref;
        }
    }
}
