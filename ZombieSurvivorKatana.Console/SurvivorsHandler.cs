using System;
using ZombieSurvivorKatana.ConsoleApp.Domain;

namespace ZombieSurvivorKatana.ConsoleApp;

public class SurvivorsHandler : IObservable<Survivor>
{
    private List<Survivor> _survivors;
    private List<IObserver<Survivor>> _observers;

    public SurvivorsHandler()
    {
        _survivors = new List<Survivor> { };
        _observers = new List<IObserver<Survivor>>();
    }

    public IDisposable Subscribe(IObserver<Survivor> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return new SurvivorHandlerUnsubscriber<Survivor>(_observers, observer);
    }

    public void CreateSurvivor(string name)
    {
        if(SurvivorAlreadyExists(name))
        {
            var Survivor = new Survivor(name);
            _survivors.Add(Survivor);
            Console.WriteLine($"Survivor {Survivor.Name} created");
        }
        else
            Console.WriteLine($"Survivor with the name {name} already exists");
    }

    public bool SurvivorAlreadyExists(string name)
    {
        var exists = _survivors.Any(x => x.Name == name);
        return exists;
    }

    public List<Survivor> GetSurvivors()
    {
        return _survivors;
    }

    public void ResetActionsPerTurn()
    {
        foreach (var survivor in _survivors)
        {
            survivor.ActionsPerTurn = 3;
        }
    }

    public void SurvivorStatus(Survivor survivor)
    {
        if (!survivor.Active)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(survivor);
            }
            CheckGameStatus();
        }
    }

    public void CheckGameStatus()
    {
        if (_survivors.All(x => x.Active == false))

            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }
    }
}
