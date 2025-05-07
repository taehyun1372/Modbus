using System;

namespace _21_Infinite_Loop_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var manager = new Manager();
            while (true)
            {
                Console.WriteLine("In process");
                manager.DisplayAllValues();
                var input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    manager.A_UI.Value = value;
                }
            }
        }
    }

    public class Manager
    {
        public UIDisplay A_UI { get; set; }
        public UIDisplay B_UI { get; set; }
        public BehindData MainData { get; set; }

        public Manager()
        {
            A_UI = new UIDisplay(3);
            B_UI = new UIDisplay(3);
            MainData = new BehindData(3);
            A_UI.UIChanged += UIChangedEventHandler;
            B_UI.UIChanged += UIChangedEventHandler;
            MainData.DataChanged += DataChangeEventHanlder;
        }

        public void DisplayAllValues()
        {
            Console.WriteLine($"A UI Value : {A_UI.Value}");
            Console.WriteLine($"B UI Value : {B_UI.Value}");
            Console.WriteLine($"Data Value : {MainData.Value}");
        }

        public void UIChangedEventHandler(object sender, UIChangeEventArg e)
        {
            MainData.Value = e.Value;
        }

        public void DataChangeEventHanlder(object sender, DataChangedEventArg e)
        {
            A_UI.Value = e.Value;
            B_UI.Value = e.Value;
        }
    }


    public class UIDisplay
    {
        public event Action<object, UIChangeEventArg> UIChanged;
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    UIChanged?.Invoke(this, new UIChangeEventArg(value));
                }
                
            }
        }

        public UIDisplay(int value)
        {
            Value = value;
        }
    }

    public class BehindData
    {
        public event Action<object, DataChangedEventArg> DataChanged;

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    DataChanged?.Invoke(this, new DataChangedEventArg(value));
                }
                
            }
        }

        public BehindData(int value)
        {
            Value = value;
        }

    }
       
    public class DataChangedEventArg
    {
        public int Value { get; set; }
        public DataChangedEventArg(int value) => Value = value;
    }

    public class UIChangeEventArg
    {
        public int Value { get; set; }

        public UIChangeEventArg(int value) => Value = value;
    }

}
