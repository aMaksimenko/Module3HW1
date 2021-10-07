using System;
using System.Collections.ObjectModel;
using HomeWork.Helpers;
using HomeWork.Models;

namespace HomeWork
{
    public class Starter
    {
        public void Run()
        {
            var arrayInit = new[]
            {
                new MyModel() { Title = "This" },
                new MyModel() { Title = "Is" },
                new MyModel() { Title = "Initiation" },
            };
            var myList = new MyList<MyModel>(arrayInit);
            var array = new[]
            {
                new MyModel() { Title = "array #1" },
                new MyModel() { Title = "array #2" },
                new MyModel() { Title = "array #3" },
            };
            var collection = new Collection<MyModel>();
            var itemToRemove = new MyModel() { Title = "This is one to delete after" };

            collection.Add(new MyModel() { Title = "collection #1" });
            collection.Add(new MyModel() { Title = "collection #2" });
            collection.Add(new MyModel() { Title = "collection #3" });

            myList.Add(new MyModel() { Title = "1" });
            myList.Add(new MyModel() { Title = "2" });
            myList.Add(new MyModel() { Title = "3" });
            myList.Add(new MyModel() { Title = "4" });
            myList.Add(new MyModel() { Title = "5" });
            myList.Add(new MyModel() { Title = "6" });
            myList.Add(itemToRemove);

            myList.AddRange(array);
            myList.AddRange(collection);

            myList.Remove(itemToRemove);
            myList.RemoveAtIndex(3);

            foreach (var item in myList)
            {
                Console.WriteLine(item.Title);
            }

            Console.WriteLine("---------------------------");

            myList.Sort(new TitleComparer());

            foreach (var item in myList)
            {
                Console.WriteLine(item.Title);
            }

            Console.WriteLine("---------------------------");
            Console.WriteLine($"capacity is -> {myList.Capacity}");
        }
    }
}