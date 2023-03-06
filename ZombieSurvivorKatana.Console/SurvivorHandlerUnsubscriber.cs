using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp
{
    internal class SurvivorHandlerUnsubscriber<Survivor> : IDisposable
    {
        private List<IObserver<Survivor>> _observers;
        private IObserver<Survivor> _observer;

        public SurvivorHandlerUnsubscriber(List<IObserver<Survivor>> observers, IObserver<Survivor> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
