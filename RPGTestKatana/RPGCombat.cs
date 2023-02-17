using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGTestKatana
{
    public class RPGCombat
    {
        public class Character : ITargetable
        {
            public bool Alive { get; internal set; } = true;
            public int Health { get; private set; } = 1000;
            public int Level { get; private set; } = 1;
            public Location Location { get; set; } = new Location(1, 1);
            public Faction Faction { get; set; }
            public CharacterClass Class { get; set; }

            public Character()
            {
                Faction = NoFaction.Instance;
            }

            public void LevelUp(int increaseAmount)
            {
                Level += increaseAmount;
            }

            private List<AttackStatusRule> Rules = new List<AttackStatusRule>()
            {
                new DeathStatusRule(),
                new LevelModifierStatusRule(),
                new SelfDamageStatusRule(),
                new InRangeStatusRule(),
                new AllyDamageRule()
            };


            public void Attack(ITargetable target)
            {
                var attack = new AttackEvent(200, this);

                target.Defend(attack);
            }

            public void Defend(AttackEvent attack)
            {
                foreach (var rules in Rules.OrderBy(x => x.Priority))
                    rules.ApplyRule(attack, this);

                Health -= attack.Damage;
            }

            public void Heal(Character target)
            {
                //TODO: Probably should create rule set similar to attacks at this point
                if (!target.Alive || !IsAlly(target) && !Equals(target))
                    return;

                if (target.Health + 200 > 1000)
                    target.Health = 1000;
                else
                    target.Health += 200;
            }

            public void Join(Faction faction)
            {
                Faction = faction;
            }

            internal bool IsAlly(Character ally)
            {
                return ally.Faction.Equals(Faction);
            }
        }

        public interface AttackStatusRule
        {
            int Priority { get; }
            void ApplyRule(AttackEvent attack, Character target);
        }

        public class DeathStatusRule : AttackStatusRule
        {
            public int Priority => 2;

            public void ApplyRule(AttackEvent attack, Character target)
            {
                if (target.Health - attack.Damage <= 0)
                    target.Alive = false;
            }
        }

        public class AllyDamageRule : AttackStatusRule
        {
            public int Priority => 0;

            public void ApplyRule(AttackEvent attack, Character target)
            {
                if (target.IsAlly(attack.Attacker))
                    attack.Damage = 0;
            }
        }

        public class LevelModifierStatusRule : AttackStatusRule
        {
            public int Priority => 1;

            public void ApplyRule(AttackEvent attack, Character target)
            {
                if (attack.Attacker.Level - target.Level >= 5)
                    attack.Damage += (int)(attack.Damage * .5);
                else if (attack.Attacker.Level - target.Level <= -5)
                    attack.Damage -= (int)(attack.Damage * .5);
            }
        }

        public class SelfDamageStatusRule : AttackStatusRule
        {
            public int Priority => 0;

            public void ApplyRule(AttackEvent attack, Character target)
            {
                if (attack.Attacker.Equals(target))
                    attack.Damage = 0;
            }
        }

        public class InRangeStatusRule : AttackStatusRule
        {
            public int Priority => 0;

            public void ApplyRule(AttackEvent attack, Character target)
            {
                var distanceBetween = attack.Attacker.Location.DistanceBetween(target.Location);

                if (distanceBetween > attack.Attacker.Class?.MaxRange)
                    attack.Damage = 0;
            }
        }

        public interface CharacterClass
        {
            int MaxRange { get; }
        }

        public class Melee : CharacterClass
        {
            public int MaxRange => 2;
        }

        public class Range : CharacterClass
        {
            public int MaxRange => 20;
        }

        public class AttackEvent
        {
            public readonly Character Attacker;
            public int Damage { get; internal set; }

            public AttackEvent(int damage, Character attacker)
            {
                Attacker = attacker;
                Damage = damage;
            }
        }

        public class Location
        {
            public Location(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Location()
            { }

            public int X { get; set; }
            public int Y { get; set; }

            public double DistanceBetween(Location location)
            {
                return Math.Sqrt(Math.Pow(location.X - X, 2) + Math.Pow(location.Y - Y, 2));
            }
        }

        public class Faction : IEquatable<Faction>
        {
            public string Name { get; set; }

            public bool Equals(Faction other)
            {
                if (base.Equals(NoFaction.Instance))
                    return false;
                else
                    return base.Equals(other);
            }
        }

        public class NoFaction
        {
            private static Faction _instance;

            public static Faction Instance
            {
                get
                {
                    if (_instance == null)
                        _instance = new Faction() { Name = "No Faction" };

                    return _instance;
                }
            }
        }

        public interface ITargetable
        {
            void Defend(AttackEvent attack);
        }

        public class Prop : ITargetable
        { 
            public string Name { get; set; }
            public int Health { get; private set; } = 1000;
            public bool Destroyed { get; private set; }

            public Prop(string name, int health)
            {
                Name = name;
                Health = health;
            }

            public Prop()
            { }

            public void Defend(AttackEvent attack)
            {
                Health -= attack.Damage;

                if (Health <= 0)
                    Destroyed = true;
            }
        }
    }
}
