using FluentApi.Entities;
using System;

namespace FluentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var task1 = new @Task();
            task1.Set
                .Subject("Napisanie testów")
                .Description("Napisanie testów jednostokowych do UserService.")
                .DurationInHours(3)
                .StartNow()
                .Comment("FirstComment")
                .Comment("Second command");

            Console.WriteLine($"Subjec: {task1.Duration} \n Description: {task1.Description} \n" +
                $"Comments: \n {task1.Comments}");
        }
    }
}
