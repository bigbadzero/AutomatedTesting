using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills.RedSkills
{
    public class CheatDeath : Skill
    {
        public Level Level => Level.Red;
        public bool Applied { get; set; } = false;
        public void ApplySkill(Survivor survivor)
        {
            survivor.CheatDeath = true;
            Applied = true;
            survivor.PushEvent(new SuccessfulOperationEvent($"{survivor.Name} gained Cheat Death Skill"));
        }
    }
}
