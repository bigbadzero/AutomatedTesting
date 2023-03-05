using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp;

public class SurvivorHandler : IObservable<Survivor>
{
    public IDisposable Subscribe(IObserver<Survivor> observer)
    {
        throw new NotImplementedException();
    }
}
