using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppGreat_API.Helpers
{
    public static class ExchangeRatesAPI
    {

        /*
         * Static method to make a call to the external API
         * so we can get the exchange rates of the user and 
         * return the correct currency depending on his currency code.
         * We do the call using the HTTP library
         */
        public static double ExchangeRate(string currencyCode)
        {
            using var client = new HttpClient();
            string connectionString = $"https://api.exchangeratesapi.io/latest?base=BGN&symbols={currencyCode}";
            var result = client.GetStringAsync(connectionString).Result;
            var resultAsArray = result.Split('{', ':', '}');
            double rate = double.Parse(resultAsArray[4]);
            return rate;
        }
    }
}
