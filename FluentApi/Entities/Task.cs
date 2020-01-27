using FluentApi.Entities.Builders;
using System;
using System.Collections.Generic;

namespace FluentApi.Entities
{
    public class Task
    {
        private static TaskBuilder _set;
        private static readonly ISet<Comment> _comments = new HashSet<Comment>();
        public Guid Id { get; set; }
        public string Subject { get; protected set; }
        public DateTime StartDateTime { get; protected set; }
        public TimeSpan Duration { get; protected set; }
        public string Description { get; protected set; }
        public ICollection<Comment> Comments => _comments;
        public bool IsCompleted { get; protected set; }
        public  DateTime UpdateAt{ get; protected  set; }

        public Task()
        {
            Id = Guid.NewGuid(); 
        }

        public Task(string subject, DateTime startDate, TimeSpan duration,
            string description)
        {
            Id = Guid.NewGuid();
            SetSubject(subject);
            SetStartDate(startDate);
            SetDuration(duration);
            SetDescription(description);
            UpdateAt = DateTime.UtcNow;
        }
        public TaskBuilder Set => _set;


        public void SetSubject(string subject)
        {
            if (string.IsNullOrEmpty(subject))
                throw new Exception("Subject can not be empty.");
            else if(subject.Length > 250)
                throw new Exception("Subject can not have more than 250 characters.");

            Subject = subject;
        }

        public void SetStartDate(DateTime startDate)
        {
            if (startDate < DateTime.UtcNow)
                throw new Exception("Task can not start in earlier than now.");
            StartDateTime = startDate;
        }

        public void SetDuration(TimeSpan duration)
        {
            if (duration <= TimeSpan.Zero)
                throw new Exception("Duration must have duration time greater than zero.");
            Duration = duration;
        }

        public void SetDescription(string desription)
        {
            if (string.IsNullOrEmpty(desription))
                throw new Exception("Subject can not be empty.");
            else if (desription.Length > 250)
                throw new Exception("Subject can not have more than 250 characters.");

            Description = desription;
        }

        public void SetIsCompleated(bool flag)
            => IsCompleted = flag;

        public void AddComment(string body)
        {
            _comments.Add(Comment.Create(this, body));
        }
    }
}
