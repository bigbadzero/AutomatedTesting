using Microsoft.Extensions.DependencyInjection;
using ZombieSurvivorKatana.ConsoleApp;
using ZombieSurvivorKatana.ConsoleApp.UI;

var services = new ServiceCollection();
services.AddScoped<IUserInput, UserInput>();

var sp = services.BuildServiceProvider();

var game = new Game(sp.GetService<IUserInput>());
game.StartGame();
game.PlayGame();





