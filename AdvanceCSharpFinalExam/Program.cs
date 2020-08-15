using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvanceCSharpFinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
           

            //event Test
            EventPublisher eventPublisher = new EventPublisher();
            EventSubscriper eventSubscriper = new EventSubscriper();

            eventPublisher.MyEventHandler += eventSubscriper.OnEventPublished;
            eventPublisher.MyEventHandler += eventSubscriper.AnotherOnEventPublished;

            eventPublisher.DoSomeWork("my exam work");
            
        }
    }

    public class GenericClass<T> where T : struct
    {
        private List<T> _collection = new List<T>();

        public void Add(T parm)
        {
            _collection.Add(parm);
        }

        public T GetItem(int index)
        {
            T item = _collection[index];
            return item;
        }
        public List<T> GetSorted()
        {
            _collection.Sort();
            _collection.Reverse();
            return _collection;
            
        }

    }


    public class EventPublisher
    {
        public event EventHandler<string> MyEventHandler;
        public void DoSomeWork(string work)
        {
            Console.WriteLine("I'm doing some work: " + work);
            MyEventHandler?.Invoke(this, "Event Happened");
        }

    }

    public class EventSubscriper
    {
        public void OnEventPublished(object source, string e)
        {
            Console.WriteLine("OnEventPublished " + e);
        }

        public void AnotherOnEventPublished(object source, string e)
        {
            Console.WriteLine("AnotherOnEventPublished " + e);
        }
    }

}
