using System.Drawing;

namespace ZombieSurvivorKata.ConsoleApp
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool InHand { get; set; }

        public Equipment(string name)
        {
            Name= name;
            Id= Guid.NewGuid();
            InHand = false;
        }
    }
}
