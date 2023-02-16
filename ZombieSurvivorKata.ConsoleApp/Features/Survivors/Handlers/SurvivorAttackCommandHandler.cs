using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKata.ConsoleApp.Enums;
using ZombieSurvivorKata.ConsoleApp.Features.Survivors.Commands;

namespace ZombieSurvivorKata.ConsoleApp.Features.Survivors.Handlers
{
    public class SurvivorAttackCommandHandler : IRequestHandler<SurvivorAttackCommand>
    {
        private readonly Random _random;
        public SurvivorAttackCommandHandler()
        {
            _random= new Random();
        }

        public Task Handle(SurvivorAttackCommand request, CancellationToken cancellationToken)
        {
            // roll what kind of attack it is
            var attackRoll = _random.Next(1, 101);
            AttackTypeEnum attackType;
            if (Enumerable.Range(1, 10).Contains(attackRoll))
                attackType = AttackTypeEnum.Miss;
            else if(Enumerable.Range(90, 100).Contains(attackRoll))
                attackType = AttackTypeEnum.HeadShot;
            else
                attackType= AttackTypeEnum.Miss;

            if(attackType == AttackTypeEnum.HeadShot)
            {
                request.ZombieBeingAttacked.Die();
                request.SurvivorAttackingZombie.GainExperience();
            }
            else if(attackType==AttackTypeEnum.Hit)
            {
                var cleanHitRoll = _random.Next(1, 101);
                if(Enumerable.Range(1, 50).Contains(cleanHitRoll))
                {
                    if(request.ZombieBeingAttacked._zombieStatus == ZombieStatusEnum.Injured)
                    {
                        request.ZombieBeingAttacked.Die();
                        request.SurvivorAttackingZombie.GainExperience();
                    }
                    else
                    {
                        request.ZombieBeingAttacked._zombieStatus = ZombieStatusEnum.Injured;
                    }
                }
                else
                {
                    if (request.ZombieBeingAttacked._zombieStatus == ZombieStatusEnum.Injured)
                    {
                        request.ZombieBeingAttacked.Die();
                        request.SurvivorAttackingZombie.GainExperience();
                        request.SurvivorAttackingZombie.RecieveWound();
                    }
                    else
                    {
                        request.ZombieBeingAttacked._zombieStatus = ZombieStatusEnum.Injured;
                        request.SurvivorAttackingZombie.RecieveWound();
                    }
                }
            }
            else
            {
                request.SurvivorAttackingZombie.RecieveWound();
            }
            return Task.CompletedTask;
        }
    }
}
