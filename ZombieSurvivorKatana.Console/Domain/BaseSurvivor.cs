using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain.Skills;

namespace ZombieSurvivorKatana.ConsoleApp.Domain
{
    public static class BaseSurvivor
    {
        public static int Wounds => 0;
        public static int MaxWounds => 2;
        public static int ActionsPerTurn => 3;
        public static bool Active => true;
        public static List<Equipment> Equipment => new List<Equipment>();
        public static int MaxEquipment => 5;
        public static int Experience => 0;
        public static int Dodge => 5;
        public static Level Level => Level.Blue;
        public static SkillTree SkillTree => new SkillTree();
    }
}
