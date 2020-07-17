
namespace Library
{
    public interface IObservable
    
    {
        void AddObserver(IObserver observer);
        void DeleteObserver(IObserver observer);
        void Notify();   
    }
}