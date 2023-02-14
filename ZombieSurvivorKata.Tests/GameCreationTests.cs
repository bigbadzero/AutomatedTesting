using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKata.ConsoleApp;

namespace ZombieSurvivorKata.Tests
{
    public class GameCreationTests
    {
        [Fact]
        public void GameStarts_With0Survivors()
        {
            Game._survivors.Count.ShouldBe(0);
        }

      
    }
}
