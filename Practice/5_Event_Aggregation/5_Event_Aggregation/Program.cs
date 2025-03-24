using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5_Event_Aggregation
{
    class Program
    {
        public delegate void CustomerEventHandler(EventArgs e);

        public static event CustomerEventHandler event1;
        public static event CustomerEventHandler event2;
        public static event CustomerEventHandler event3;
        public static event CustomerEventHandler event4;

        static void Main(string[] args)
        {
            //event1 += EventHandler1;
            //event2 += EventHandler2;
            //event3 += EventHandler3;
            //
            //event4 += EventHandler1;
            //event4 += EventHandler2;
            //event4 += EventHandler3;

            var eventAggregator = new EventAggregator();
            Event1.Invoke(new EventArgs(1));
            eventAggregator.Subscribe<EventArgs>(Event1, EventHandler1);
            eventAggregator.Subscribe<EventArgs>(event2, EventHandler2);
            eventAggregator.Subscribe<EventArgs>(event3, EventHandler3);

            eventAggregator.Subscribe<EventArgs>(event4, EventHandler1);
            eventAggregator.Subscribe<EventArgs>(event4, EventHandler2);
            eventAggregator.Subscribe<EventArgs>(event4, EventHandler3);

            int i = 0;
            //Main ProcessS
            while (true)
            {
                i++;
                Console.WriteLine("Please enter an input");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("1 entered");
                    //event1?.Invoke(new EventArgs(i));
                    eventAggregator.Publish<EventArgs>(Event1, new EventArgs(1));
                }
                else if(input == "2")
                {
                    Console.WriteLine("2 entered");
                    //event2?.Invoke(new EventArgs(i));
                    eventAggregator.Publish<EventArgs>(event2, new EventArgs(2));

                }
                else if(input == "3")
                {
                    Console.WriteLine("3 entered");
                    //event3?.Invoke(new EventArgs(i));
                    eventAggregator.Publish<EventArgs>(event3, new EventArgs(3));

                }
                else
                {
                    Console.WriteLine("Something else entered");
                    //event4?.Invoke(new EventArgs(i));
                    eventAggregator.Publish<EventArgs>(event4, new EventArgs(4));

                }
            }
        }

        static public void EventHandler1(EventArgs e)
        {
            Console.WriteLine("Event handler 1 called, Value : {0}", e.Value);
        }

        static public void EventHandler2(EventArgs e)
        {
            Console.WriteLine("Event handler 2 called, Value : {0}", e.Value);
        }

        static public void EventHandler3(EventArgs e)
        {
            Console.WriteLine("Event handler 3 called, Value : {0}", e.Value);
        }

        public class EventArgs
        { 
            public EventArgs(int value)
            {
                Value = value;
            }

            public int Value { get; set; }
        }

        public class EventAggregator
        {
            private readonly Dictionary<object, List<Delegate>> _subscriptions = new Dictionary<object, List<Delegate>>();

            public void Subscribe<T>(object eventInstance, Action<T> handler)
            {
                if(!_subscriptions.ContainsKey(eventInstance))
                {
                    _subscriptions[eventInstance] = new List<Delegate>();
                }
                _subscriptions[eventInstance].Add(handler);
            }
            public void Publish<T>(object eventInstance, T eventArgs)
            {
                var handlers = _subscriptions[eventInstance];
                foreach (var handler in handlers)
                {
                    var action = (Action<T>)handler;
                    action(eventArgs);
                }
            }


        }
    }
}
