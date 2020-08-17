using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppGreat_API.Helpers
{
    public static class ExchangeRatesAPI
    {
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
