

using FluentApi.Entities;

namespace FluentApi
{
    public static class FluentApi
    {
        public static void Start()
        {
            var task1 = new @Task();
            task1.Set
                .Subject("Napisanie testów")
                .Description("Napisanie testów jednostokowych do UserService.")
                .DurationInHours(3)
                .StartNow()
                .Comment("FirstComment")
                .Comment("Second command");

            System.Console.WriteLine($"Subjec: {task1.Duration} \n Description: {task1.Description} \n" +
                $"Comments: \n {task1.Comments}" );
        }
    }
}
