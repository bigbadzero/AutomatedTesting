using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class UserInput : IUserInput
    {
        public int GetIntFromUser()
        {
            bool isValid = false;
            int response = 0;
            while (!isValid)
            {
                try
                {
                    response = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid entry");
                }
                isValid = true;
            }

            return response;
        }

        public int GetIntFromUserWithRange(int start, int end)
        {
            bool isValid = false;
            int result = 0;
            while (!isValid)
            {
                try
                {
                    int response = Convert.ToInt32(Console.ReadLine());
                    if (Enumerable.Range(start, end).Contains(response))
                    {
                        isValid = true;
                        result = response;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid entry");
                }
            }
            return result;
        }

        public bool Proceed()
        {
            bool isValid = false;
            bool result = false;
            while (!isValid)
            {
                try
                {
                    int response = Convert.ToInt32(Console.ReadLine());
                    if (Enumerable.Range(1, 2).Contains(response))
                    {
                        isValid = true;
                        if (response == 1)
                            result = true;
                        if (response == 2)
                            result = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid entry");
                }
            }
            return result;
        }
    }
}
