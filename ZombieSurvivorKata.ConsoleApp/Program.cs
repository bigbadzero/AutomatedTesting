﻿// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using ZombieSurvivorKata.ConsoleApp;

var services = new ServiceCollection();
services.AddScoped<IUserInput, UserInput>();

var sp = services.BuildServiceProvider();
var userInput = sp.GetService<IUserInput>();
Game.Configure(userInput);


