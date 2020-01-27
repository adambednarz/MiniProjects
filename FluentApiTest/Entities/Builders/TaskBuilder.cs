using System;

namespace FluentBuilders.Entities.Builders
{
    public class TaskBuilder
    {
        private readonly Task _task;

        public TaskBuilder(Task task)
        {
            _task = task;
        }

        public TaskBuilder Subject (string subject)
        {
            _task.SetSubject(subject);
            return this;
        }

        public TaskBuilder StartAt(DateTime startDate)
        {
            _task.SetStartDate(startDate);
            return this;
        }

        public TaskBuilder StartNow()
        {
            _task.SetStartDate(DateTime.UtcNow) ;
            return this;
        }

        public TaskBuilder DurationInMinutes(int minutes)
        {
            _task.SetDuration(TimeSpan.FromMinutes(minutes));
            return this;
        }

        public TaskBuilder DurationInHours(int hours)
        {
            _task.SetDuration(TimeSpan.FromHours(hours));
            return this;
        }

        public TaskBuilder Description (string subject)
        {
            _task.SetDescription(subject);
            return this;
        }

        public TaskBuilder Compleated(bool flag)
        {
            _task.SetIsCompleated(flag);
            return this;
        }
        public TaskBuilder Comment(string body)
        {
            _task.AddComment(body);
            return this;
        }
    }
}
