using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NotificationAdministrator
{
    class Program
    {
        public static void Main()
        {
            
                    MessageDispacher.messageSender().Wait();
           
        }
    }
}
