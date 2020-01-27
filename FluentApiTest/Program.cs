using FluentApi.Entities;
using System;

namespace FluentApi
{
    public class Program
    {
        public static void Main()
        {
            var task = new @Task();
            task.Set
                .Subject("Napisanie testów")
                .Description("Napisanie testów jednostokowych do UserService.")
                .DurationInHours(3)
                .StartNow()
                .Comment("FirstComment")
                .Comment("Second command");

            var taskSecond = new TaskSecond.Builder()
                .Id()
                .Subject("Test drugiego buildera")
                .Description("Jest to builder będący zagnieżdzoną klasą.")
                .Duration(TimeSpan.FromDays(1))
                .AddComment("Pirwszy komentarz dla drugiego buildera")
                .AddComment("drugi komentarz dla drugiego buildera")
                .build();
 
                
            Console.WriteLine($"Task Id: {task.Id} \n " +
                $"Subjec: {task.Subject} \n " +
                $"Description: {task.Description} \n" +
                $" Duration: {task.Duration}");
            Console.WriteLine("Comments:");
            foreach (var item in task.Comments)
            {
                Console.WriteLine($" Created at: {item.CreationDateTime} \n Body: {item.Body}");
            }

            Console.WriteLine($"Task Id: {taskSecond.Id} \n " +
            $"Subjec: {taskSecond.Subject} \n " +
            $"Description: {taskSecond.Description} \n" +
            $" Duration: {taskSecond.Duration}");
            Console.WriteLine("Comments:");
            foreach (var item in taskSecond.Comments)
            {
                Console.WriteLine($" Created at: {item.CreationDateTime} \n Body: {item.Body}");
            }

        }
    }
}
