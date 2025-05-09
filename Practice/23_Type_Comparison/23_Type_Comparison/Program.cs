using System;

namespace _23_Type_Comparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IPerson PersonInterface;
            var Mike = new Person() { Name = "Mike" };
            Mike.DisplayInfo();

            var Jake = new Student() { Name = "Jake", Id = 13 };
            Jake.DisplayInfo();

            Console.WriteLine("--------is and == typeof differnce---------");
            if (Jake is Person) //is comparison allows subclass 
            {
                Console.WriteLine("The same type by is comparason");
            }
            else
            {
                Console.WriteLine("The different type by is comparason");
            }

            if (Jake.GetType() == typeof(Person)) //GetType() == typeof() comparison allows exactly the same type
            {
                Console.WriteLine("The same type by type comparason");
            }
            else
            {
                Console.WriteLine("The different type by type comparason");
            }

            Console.WriteLine("--------is type casting---------");
            Container myContainer = new Container();
            myContainer.Content = Jake;

            if (myContainer.Content is IPerson iPerson)
            {
                iPerson.DisplayInfo();
            }

            if (myContainer.Content is Alien alien)
            {
                alien.DisplayInfo();
            }
        }
    }
    public class Container
    {
        public object Content { get; set; }
    }

    public class Alien
    {
        public int Height { get; set; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Display information, Height : {Height}");
        }
    }

    public interface IPerson
    {
        public void DisplayInfo() { }

        public void DeleteInfo() { }
    }

    public class Person : IPerson
    {
        public string Name { get; set; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Display information, Name : {Name}");
        }

        public virtual void DeleteInfo()
        {
            Console.WriteLine($"Deleting information, Name : {Name}");
            Name = "";
        }
    }

    public class Student : Person
    {
        public int Id { get; set; }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Display information, Id : {Id}");

        }

        public override void DeleteInfo()
        {
            base.DeleteInfo();
            Console.WriteLine($"Deleting information, Id : {Id}");
            Id = 0;
        }
    }
}
