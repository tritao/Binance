# Binance ![](https://github.com/sonvister/Binance/blob/master/images/logo.png?raw=true)
A full-featured .NET **[Binance API](https://www.binance.com/restapipub.html)** facade designed for ease of use.

[![](https://img.shields.io/github/last-commit/sonvister/Binance.svg)](https://github.com/sonvister/Binance)

## Features
* Compatible with **.NET Standard 2.0** and **.NET Framework 4.7.1**.
* **Complete** coverage of the [Binance API](https://www.binance.com/restapipub.html) including all REST and WebSocket endpoints (*with combined streams*).
* A **simple** API abstraction using domain/value objects that do not expose underlying (*HTTP/REST*) behavior.
* Consistent use of **domain models** whether you're querying the API or using real-time WebSocket client events.
* Customizable **dual-layer API** with access to JSON responses (*low-level*) or deserialized domain/value objects.
* API exceptions provide the Binance server response **ERROR code and message** for easier troubleshooting.
* Unique implementation supports **multiple users** and requires user authentication only where necessary.
* Web API interface includes automatic **rate limiting** and system-to-server **time synchronization** for reliability.
* Easy-to-use **WebSocket endpoint clients** and various ready-to-use **caching** implementations (*with events*).
* Low-level `BinanceHttpClient` API utilizes a single, cached HttpClient for performance (*and implemented as singleton*).
* **Limited dependencies** and use of Microsoft extensions for **dependency injection**, **logging**, and **options**.
* .NET Core **sample applications** including live displays of market depth, trades, and candlesticks for a symbol.

## Getting Started
### Binance Sign-up
To use the private (*authenticated*) API methods you must have an account with Binance and create an API Key. Please use my Referral ID: **10899093** when you [**Register**](https://www.binance.com/register.html?ref=10899093) (*an account is not required to access the public market data*).

### Installation
Using [Nuget](https://www.nuget.org/packages/Binance/) Package Manager:
```
PM> Install-Package Binance
```
[![](https://img.shields.io/nuget/v/Binance.svg)](https://www.nuget.org/packages/Binance)\
[![](https://img.shields.io/nuget/dt/Binance.svg)](https://www.nuget.org/packages/Binance)

## Development
The master branch is *currently* used for development and may differ from the latest release.\
To get the source code for a particular release, first select the corresponding **Tag**.

### Build Environment
[Microsoft Visual Studio Community 2017](https://www.visualstudio.com/vs/community/)

## Documentation
See [**Wiki**](https://github.com/sonvister/Binance/wiki)

*NOTE: Some information is currently out-of-date ...will be updated soon.*

## Donate
DCR: Dsog2jYLS65Y3N2jDQSxsiBYC3SRqq7TGd4\
LTC: MNhGkftcFDE7TsFFvtE6W9VVKhxH74T3eM\
DASH: XmFvpRgwfDRdN9wbrZjHZeH63Rt9CwHqUf\
ZEC: t1Ygz58dkcx2WXuGCjGiPo8w7Q1dcCSscGJ\
ETH: 0x3BFd7B3EAA6aE6BCF861B9B1803d67abe9360bca\
BTC: 3JjG3tRR1dx98UJyNdpzpkrxRjXmPfQHk9

Thank you.
