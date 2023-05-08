using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Event
{
    public string EventDiscription { get; set; } = string.Empty;
    public Survivor? Survivor { get; set; }
}
