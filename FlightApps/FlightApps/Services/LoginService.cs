using FlightApps.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightApps.Services
{
    public class LoginService
    {
        HttpClient client = new HttpClient();
        public string tempNgrokURL = "http://f28e-122-129-122-194.ngrok.io/";

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
                Application.Current.Properties["email"] = selectedUser.Email;
                return selectedUser;
            }

            return null;
        }

        //Retrive Aiports List
        public async Task<List<Airport>> GetAirportList()
        {
            var URL = tempNgrokURL + "Home/GetAirportList";

            Uri uri = new Uri(string.Format(URL, string.Empty));

            HttpResponseMessage response = null;
            response = await client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<Airport> airports = JsonConvert.DeserializeObject<List<Airport>>(data);
                return airports;
            }

            return null;
        }

        //Retrieve Flight Schedules
        public async Task<List<Schedule>> GetDepartureScheduleList(FlightRequest request)
        {
            var URL = tempNgrokURL + "Home/GetDepartureSchedules";

            Uri uri = new Uri(string.Format(URL, string.Empty));

            string json = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<Schedule> schedules = JsonConvert.DeserializeObject<List<Schedule>>(data);
                return schedules;
            }

            return null;
        }

        public async Task<List<Schedule>> GetArrivalScheduleList(FlightRequest request)
        {
            var URL = tempNgrokURL + "Home/GetArrivalSchedules";

            Uri uri = new Uri(string.Format(URL, string.Empty));

            string json = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<Schedule> schedules = JsonConvert.DeserializeObject<List<Schedule>>(data);
                return schedules;
            }

            return null;
        }

        public async Task<string> MakeBooking(Booking booking)
        {
            var URL = tempNgrokURL + "Home/Booking";

            Uri uri = new Uri(string.Format(URL, string.Empty));

            string json = JsonConvert.SerializeObject(booking);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return data;
            }

            return "";
        }

        public async Task<List<Booking>> GetUserBooking(string email)
        {
            var URL = tempNgrokURL + "Home/GetUserBooking";

            Uri uri = new Uri(string.Format(URL, string.Empty));

            string json = JsonConvert.SerializeObject(email);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.GetAsync(uri + "?email=" + email);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                List<Booking> bookings = JsonConvert.DeserializeObject<List<Booking>>(data);
                return bookings;
            }

            return null;
        }
    }
}
