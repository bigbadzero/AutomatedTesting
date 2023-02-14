using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKata.ConsoleApp
{
    public interface IUserInput
    {
        public int GetIntFromUser();
        public int GetIntFromUserWithRange(int start, int end);
    }
}
