using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKata.ConsoleApp;

namespace ZombieSurvivorKata.Tests
{
    public class GameLogicTests
    {
        [Fact]
        public void Game_WillNot_CreateChractersWith_SameName()
        {
            string nick = "Nick";
            Game.CreateCharacter(nick);
            Game.CreateCharacter(nick);

            Game._survivors.Count.ShouldBe(1);

        }
    }
}
