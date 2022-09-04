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
        public string tempNgrokURL = "https://bde6-122-129-122-194.ngrok.io/";

        //Post
        public async Task<string> RegisterUser(User user)
        {
            List<User> users = new List<User>();
            var urlGetDashboard = tempNgrokURL + "Home/registerUsers";

            Uri uri = new Uri(string.Format(urlGetDashboard, string.Empty));

            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return data;
                //Items = JsonConvert.DeserializeObject<List<User>>(data);
                //return Items;
            }

            return "";
        }

        public async Task<User> UserLogin(User user)
        {
            var loginURL = tempNgrokURL + "Home/Login";

            Uri uri = new Uri(string.Format(loginURL, string.Empty));

            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                User selectedUser = JsonConvert.DeserializeObject<User>(data);
                return selectedUser;
            }

            return null;
        }
    }
}
