using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Runtime.CompilerServices;
using ZombieSurvivorKatana.ConsoleApp;
using ZombieSurvivorKatana.ConsoleApp.Domain;
using ZombieSurvivorKatana.ConsoleApp.UI;

var services = new ServiceCollection();
services.AddScoped<IUserInput, UserInput>();

var sp = services.BuildServiceProvider();

var game = new Game(sp.GetService<IUserInput>());
game.PlayGame();





