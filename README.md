# ExRatesSharp
[![Build Status](https://travis-ci.com/MRmlik12/ExRatesSharp.svg?branch=master)](https://travis-ci.com/MRmlik12/ExRatesSharp) [![NuGet version (SoftCircuits.Silk)](https://img.shields.io/nuget/v/ExRatesSharp.svg?style=flat)](https://www.nuget.org/packages/ExRatesSharp/)

A .NET wrapper for [exchangeratesapi.io](http://exchangeratesapi.io) to get exchange rates history and more.

## Using ExRatesSharp Library

### Get latest currency

```csharp 
using ExRatesSharp;

var result = await ExchangeRatesApi.GetLatest()

//Returns Response
```

### Get latest currency with base currency is USD
```csharp
using ExRatesSharp;

var result = await ExchangeRatesApi.GetLatest("USD");

//Returns Response
```

### Get latest currency when base currency is USD and Symbols are PLN, EUR

```csharp
using ExRatesSharp;

var result = await ExchangeRatesApi.GetLatest("USD", new [] {"PLN", "EUR"});

//Returns Response
```

### Get currency history
```csharp
using ExRatesSharp;

var result = await ExchangeRatesApi.GetHistoricalRates(new DateTime(2010, 1, 12));

//Returns Response
```

### Get custom rates when starts at 2010/1/12 and ends at 2010/12/12

```csharp
using ExRatesSharp;

var result = await ExchangeRatesApi.GetCustomRates(new DateTime(2010, 1, 12), new DateTime(2020, 12, 12));

//Returns CustomResponse
```
### Get custom rates when starts at 2010/1/12 and ends at 2010/12/12 and base currency is USD

```csharp
using ExRatesSharp;

var result = await ExchangeRatesApi.GetCustomRates(new DateTime(2010, 1, 12), new DateTime(2020, 12, 12), "USD");

//Returns CustomResponse
```

### Get custom rates when starts at 2010/1/12 and ends at 2010/12/12 with symbols PLN, USD and default currency is EUR

```csharp
using ExRatesSharp;

var result = await ExchangeRatesApi.GetCustomRates(new DateTime(2020, 1, 1), new DateTime(2020, 2, 1), "EUR", new []{"PLN", "PHP"});

//Returns CustomResponse
```
### `Response` class
```csharp
    public Dictionary<string, double> Rates { get; set; }
    public string BaseCurrency { get; set; }
    public DateTimeOffset Date { get; set; }
```
### `CustomResponse` class
```csharp
public Dictionary<string, Dictionary<string, double>> Rates { get; set; }
public DateTimeOffset StartAt { get; set; }
public string BaseCurrency { get; set; }
public DateTimeOffset EndAt { get; set; }
```


## Supported Curriencies
| Code | Currency Name         |
|------|-----------------------|
| AUD  | Australian dollar     |
| BGN  | Bulgarian lev         |
| BRL  | Brazilian real        |
| CAD  | Canadian              |
| CHF  | Swiss franc           |
| CNY  | Chinese yuan renminbi |
| CZK  | Czech koruna          |
| DKK  | Danish krone          |
| EUR  | Euro                  |
| GBP  | Pound sterling        |
| HKD  | Hong Kong dollar      |
| HRK  | Croatian kuna         |
| HUF  | Hungarian forint      |
| IDR  | Indonesian rupiah     |
| ILS  | Israeli shekel        |
| INR  | Indian rupee          |
| ISK  | Icelandic krone       |
| JPY  | Japanese yen          |
| KRW  | South Korean won      |
| MXN  | Mexican peso          |
| MYR  | Malaysian ringgit     |
| NOK  | Norwegian krone       |
| NZD  | New Zealand dollar    |
| PHP  | Philippine peso       |
| PLN  | Polish zloty          |
| RON  | Romanian leu          |
| RUB  | Russian rouble        |
| SEK  | Swedish krona         |
| SGD  | Singapore dollar      |
| THB  | Thai baht             |
| TRY  | Turkish lira          |
| USD  | US dollar             |
| ZAR  | South African rand    |

# How to build from source code
```bash
$ git clone https://github.com/MRmlik12/ExRatesSharp.git
$ dotnet restore
$ dotnet test
$ dotnet build package
```

# Used Libraries
* [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
* [RestSharp](https://github.com/restsharp/RestSharp)
* [xUnit](https://github.com/xunit/xunit)