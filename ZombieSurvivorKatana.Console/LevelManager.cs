using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public static class LevelManager
    {
        public static bool LevelUp(int experience)
        {
            if(experience == 6 || experience == 18 || experience == 42)
                return true;
            else
                return false;
        }

        public static Level NextLevel(Level level)
        {
            switch(level)
            {
                case Level.Blue:
                    return Level.Yellow;
                case Level.Yellow:
                    return Level.Orange;
                case Level.Orange:
                    return Level.Red;
                default: 
                    return level;
            }
        }
    }
}
