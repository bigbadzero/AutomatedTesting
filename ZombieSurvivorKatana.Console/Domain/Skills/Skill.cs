using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp.Domain.Skills
{
    public interface Skill
    {
        public bool Applied { get; set; }
        public Level Level { get; }
        public void ApplySkill(Survivor survivor);
    }
}
