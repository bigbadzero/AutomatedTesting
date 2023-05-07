using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills.OrangeSkills
{
    public class Tough : Skill
    {
        public bool Applied { get; set; } = false;

        public Level Level => Level.Orange;

        public void ApplySkill(Survivor survivor)
        {
            Applied = true;
            survivor.Tough = true;
            survivor.PushEvent(new SuccessfulOperationEvent($"{survivor.Name} has gained the Tough Skill"));
        }
    }
}
