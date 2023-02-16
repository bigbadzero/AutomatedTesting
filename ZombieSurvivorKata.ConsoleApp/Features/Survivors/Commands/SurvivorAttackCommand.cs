using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKata.ConsoleApp.Features.Survivors.Commands
{
    public class SurvivorAttackCommand : IRequest
    {
        public Survivor SurvivorAttackingZombie { get; set; }
        public Zombie ZombieBeingAttacked { get; set; }

    }
}
