using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKata.ConsoleApp;

namespace ZombieSurvivorKata.Tests
{
    public class EquipmentCreationTests
    {
        [Fact]
        public void EquipmentCreated_WithUniqueId()
        {
            var scissors = new Equipment("Scissors");
            var gun = new Equipment("Gun");

            scissors.Id.ShouldNotBeSameAs(gun.Id);
        }
    }
}
