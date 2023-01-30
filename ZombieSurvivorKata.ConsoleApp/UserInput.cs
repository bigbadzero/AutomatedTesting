namespace ZombieSurvivorKata.ConsoleApp;

public class UserInput
{
    public int GetIntFromUser()
    {
        bool isValid = false;
        int response;
        while (!isValid)
        {
            try
            {
                response = Convert.ToInt32(Console.ReadLine());
                isValid= true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid entry");
            }
        }

        return response;
    }
}
