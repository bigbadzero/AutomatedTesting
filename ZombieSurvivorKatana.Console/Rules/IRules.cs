using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Rules.InHandRules;

namespace ZombieSurvivorKatana.ConsoleApp.Rules
{
    public interface IRules
    {
        public bool IsRuleApplicable(InHandEvent inHandEvent);

        public void ExecuteRule(InHandEvent inHandEvent);
    }
}
