using FlightApps.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightApps.Services
{
    public class LoginService
    {
        HttpClient client = new HttpClient();
        public string tempNgrokURL = "http://abfe-122-129-122-194.ngrok.io/";

        //Post
        public async Task<List<User>> RegisterUser(User item)
        {
            List<User> users = new List<User>();
            var urlGetDashboard = "https://6ff8-2001-f40-904-4829-b054-21cb-c957-48f1.ngrok.io/Home/getAssetList";

            Uri uri = new Uri(string.Format(urlGetDashboard, string.Empty));

            string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<User>>(data);
                return Items;
            }

            return null;
        }
    }
}
