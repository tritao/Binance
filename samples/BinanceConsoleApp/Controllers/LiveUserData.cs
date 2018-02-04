﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Binance.WebSocket;
using Binance.WebSocket.Events;
using Binance.WebSocket.UserData;
using Microsoft.Extensions.DependencyInjection;

namespace BinanceConsoleApp.Controllers
{
    internal class LiveUserData : IHandleCommand
    {
        public Task<bool> HandleAsync(string command, CancellationToken token = default)
        {
            if (!command.StartsWith("live ", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult(false);

            var args = command.Split(' ');

            var endpoint = string.Empty;
            if (args.Length > 1)
            {
                endpoint = args[1];
            }

            if (!endpoint.Equals("account", StringComparison.OrdinalIgnoreCase)
                && !endpoint.Equals("user", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult(false);

            if (Program.LiveUserDataTask != null)
            {
                lock (Program.ConsoleSync)
                {
                    Console.WriteLine("! A live user data task is currently active ...use 'live off' to disable.");
                }
                return Task.FromResult(true);
            }

            if (Program.User == null)
            {
                Program.PrintApiNotice();
                return Task.FromResult(true);
            }

            Program.LiveUserDataTokenSource = new CancellationTokenSource();

            Program.UserDataManager = Program.ServiceProvider.GetService<IUserDataWebSocketManager>();
            Program.UserDataManager.AccountUpdate += OnAccountUpdateEvent;
            Program.UserDataManager.OrderUpdate += OnOrderUpdateEvent;
            Program.UserDataManager.TradeUpdate += OnTradeUpdateEvent;

            Program.LiveUserDataTask = Program.UserDataManager.SubscribeAndStreamAsync(
                Program.User, Program.LiveUserDataTokenSource.Token);

            lock (Program.ConsoleSync)
            {
                Console.WriteLine();
                Console.WriteLine("  ...live account feed enabled ...use 'live off' to disable.");
            }

            return Task.FromResult(true);
        }

        private static void OnAccountUpdateEvent(object sender, AccountUpdateEventArgs e)
        {
            Program.Display(e.AccountInfo);
        }

        private static void OnOrderUpdateEvent(object sender, OrderUpdateEventArgs e)
        {
            lock (Program.ConsoleSync)
            {
                Console.WriteLine();
                Console.WriteLine($"Order [{e.Order.Id}] update: {e.OrderExecutionType}");
                Program.Display(e.Order);
                Console.WriteLine();
            }
        }

        private static void OnTradeUpdateEvent(object sender, AccountTradeUpdateEventArgs e)
        {
            lock (Program.ConsoleSync)
            {
                Console.WriteLine();
                Console.WriteLine($"Order [{e.Order.Id}] update: {e.OrderExecutionType}");
                Program.Display(e.Order);
                Console.WriteLine();
                Program.Display(e.Trade);
                Console.WriteLine();
            }
        }
    }
}
