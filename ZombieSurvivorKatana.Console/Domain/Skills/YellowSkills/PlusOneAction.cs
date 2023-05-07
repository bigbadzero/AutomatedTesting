using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills.YellowSkills
{
    public class PlusOneAction : Skill
    {
        public Level Level => Level.Yellow;
        public bool Applied { get; set; } = false;
        public void ApplySkill(Survivor survivor)
        {
            survivor.MaxActionsPerTurn++;
            Applied = true;
            survivor.PushEvent(new SuccessfulOperationEvent($"{survivor.Name} gained Plus 1 Action Skill"));
        }
    }
}
