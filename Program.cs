namespace Oxygen {

    class Program {

        static async Task Main() {
            var json = BuildJson();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://sandbox-api.mydataprovider.gr/v2/invoices");
            var content = new StringContent(json);
            var token = "98|9qxcOMRQxzfqMiuzk9t7PYv5yJQEuHGVEXXIbLEFf7b3d119";
            request.Headers.Add("Authorization", "Bearer " + token);
            request.Content = content;
            var response = await client.SendAsync(request);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        private static string BuildJson() {
            using StreamReader x = new("invoice.json");
            return x.ReadToEnd();
        }

    }

}