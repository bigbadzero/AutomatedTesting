using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public interface IUserInput
    {
        public int GetIntFromUser();
        public int GetIntFromUserWithRange(int start, int end);

        public bool Proceed();
    }
}
