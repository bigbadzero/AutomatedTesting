using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKata.ConsoleApp.Enums;

namespace ZombieSurvivorKata.ConsoleApp
{
    public class Zombie
    {
        public ZombieStatusEnum _zombieStatus;
        public Zombie()
        {
            _zombieStatus = ZombieStatusEnum.FullHealth;
        }

        public void RecieveAttack(AttackTypeEnum attack)
        {

        }

        public void Die()
        {
            _zombieStatus = ZombieStatusEnum.Dead;
            Console.Write("Zombie Died");
        }
    }
}
