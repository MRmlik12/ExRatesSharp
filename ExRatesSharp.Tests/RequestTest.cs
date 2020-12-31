using System;
using System.Collections.Generic;
using ExRatesSharp;
using Xunit;
using System.Linq;

namespace ExRatesSharp.Tests
{
    public class RequestTest
    {
        [Fact]
        public async void GetLatestRates()
        {
            var result = await ExchangeRatesApi.GetLatest();
            Assert.NotNull(result);
        }

        [Fact]
        public async void GetRatesFrom2010_01_12()
        {
            var result = await ExchangeRatesApi.GetHistoricalRates(new DateTime(2010, 1, 12));
            Assert.Equal("2010-01-12", result.Date.ToString("yyyy-MM-dd"));
        }
        
        [Fact]
        public async void GetHistoryFrom2020_01_01To2020_02_01()
        {
            var result = await ExchangeRatesApi.GetCustomRates(new DateTime(2020, 1, 1), new DateTime(2020, 2, 1));
            Assert.Equal("2020-01-01", result.StartAt.ToString("yyyy-MM-dd"));
            Assert.Equal("2020-02-01", result.EndAt.ToString("yyyy-MM-dd"));
        }
        
        [Fact]
        public async void GetHistoryFrom2020_01_01To2020_02_01WithBaseCurrencyEUR()
        {
            var result = await ExchangeRatesApi.GetCustomRates(new DateTime(2020, 1, 1), new DateTime(2020, 2, 1), "EUR");
            Assert.Equal("EUR", result.BaseCurrency);
            Assert.Equal("2020-01-01", result.StartAt.ToString("yyyy-MM-dd"));
            Assert.Equal("2020-02-01", result.EndAt.ToString("yyyy-MM-dd"));
        }
        
        [Fact]
        public async void GetHistoryFrom2020_01_01To2020_02_01WithBaseCurrencyEURWithSymbolsPLN_PHP()
        {
            var result = await ExchangeRatesApi.GetCustomRates(new DateTime(2020, 1, 1), new DateTime(2020, 2, 1), "EUR", new []{"PLN", "PHP"});
            var values = from currency in result.Rates where (currency.Key == "2020-01-07") select currency.Value;
            Assert.Equal("EUR", result.BaseCurrency);
            Assert.Equal("4.2457", result.Rates["2020-01-07"]["PLN"].ToString());
            Assert.Equal("56.832", result.Rates["2020-01-07"]["PHP"].ToString());
            Assert.Equal("2020-01-01", result.StartAt.ToString("yyyy-MM-dd"));
            Assert.Equal("2020-02-01", result.EndAt.ToString("yyyy-MM-dd"));
        }
    }
}