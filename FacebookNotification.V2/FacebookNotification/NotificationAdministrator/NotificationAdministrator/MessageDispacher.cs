using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NotificationAdministrator
{
    public static class MessageDispacher
    {
        static HttpClient client = new HttpClient();
        public static async Task messageSender()
        {

            client.BaseAddress = new Uri("http://localhost:58258/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string message;
            do
            {
                Console.WriteLine("---------Enter Notification---------");
                 message = Console.ReadLine();
                var notification = new Notification { Message = message };
                var response = await client.PostAsJsonAsync<Notification>("api/notification/Add", notification);
                Console.WriteLine(response.ToString());
                Console.WriteLine("To Terminate the program , type exit ");
            } while (message != "exit");
        }
    }
}
