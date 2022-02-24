using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;

namespace EmailFicoScoreConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // requires using System.Net.Http;
            var client = new HttpClient();
            // requires using System.Text.Json;
            var jsonData = JsonSerializer.Serialize(new
            {
                email = "mayank.ar@gmail.com",
                due = "4/1/2020",
                task = "Credit Report - Summary",
                message = "Your credit score changed",
                score = "820"
            });
            string url = "https://prod-29.eastus2.logic.azure.com:443/workflows/fef98fb853f541c39a273f8a2b069ab0/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=5Z5NyO35BZLS6BmEAaKP5rYETfZ-L3kcqtrzLIb1d1w";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, content).Result;

            // HttpResponseMessage result = client.PostAsync("https://prod-29.eastus2.logic.azure.com:443/workflows/fef98fb853f541c39a273f8a2b069ab0/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=5Z5NyO35BZLS6BmEAaKP5rYETfZ-L3kcqtrzLIb1d1w", new StringContent(jsonData, Encoding.UTF8, "application/json"));

            // StringContent httpContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

           // HttpResponseMessage result = client.PostAsync(new Uri("https://prod-29.eastus2.logic.azure.com:443/workflows/fef98fb853f541c39a273f8a2b069ab0/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=5Z5NyO35BZLS6BmEAaKP5rYETfZ-L3kcqtrzLIb1d1w"), new StringContent(jsonData, Encoding.UTF8, "application/json"));
    
            var statusCode = result.StatusCode.ToString();
            Console.WriteLine("Status code " + statusCode);
    
        }

       
    }
}
