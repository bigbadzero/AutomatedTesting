namespace ZombieSurvivorKata.ConsoleApp;

public class UserInput:IUserInput
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
}
