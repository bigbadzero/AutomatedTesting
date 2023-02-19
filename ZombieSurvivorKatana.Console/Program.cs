using Microsoft.Extensions.DependencyInjection;
using ZombieSurvivorKatana.ConsoleApp;

var services = new ServiceCollection();
services.AddScoped<IUserInput, UserInput>();

var sp = services.BuildServiceProvider();


