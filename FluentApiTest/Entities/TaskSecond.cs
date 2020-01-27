using FluentBuilders.Entities.Builders;
using System;
using System.Collections.Generic;

namespace FluentBuilders.Entities
{
    public class TaskSecond
    {
        public Guid Id { get; set; }
        public string Subject { get; protected set; }
        public string Description { get; protected set; }
        public DateTime StartDateTime { get; protected set; }
        public TimeSpan Duration { get; protected set; }
        public ICollection<Comment> Comments { get; protected set; }
        public bool IsCompleted { get; protected set; } = false;
        public  DateTime UpdateAt{ get; protected  set; }

        public TaskSecond(Builder builder)
        {
            Id = builder.id;
            Subject = builder.subject;
            Description = builder.description;
            StartDateTime = builder.startDate;
            Duration = builder.duration;
            Comments = builder.comments;
            IsCompleted = builder.isCompleted;
            UpdateAt = builder.updateAt;
        }


        public class Builder
        {
            public Guid id;
            public string subject;
            public string description;
            public DateTime startDate;
            public TimeSpan duration;
            public DateTime updateAt ;
            public bool isCompleted;
            public ISet<Comment> comments = new HashSet<Comment>();

            public Builder Id()
            {
                id = Guid.NewGuid();
                return this;
            }
            public Builder Subject(string subject)
            {
                if (string.IsNullOrEmpty(subject))
                    throw new Exception("Subject can not be empty.");
                else if (subject.Length > 250)
                    throw new Exception("Subject can not have more than 250 characters.");
                this.subject = subject;
                return this;
            }

            public Builder StartDate(DateTime startDate)
            {
                if (startDate < DateTime.UtcNow.AddMinutes(-1))
                    throw new Exception("Task can not start in earlier than now.");
                this.startDate = startDate;
                return this;
            }

            public Builder Duration(TimeSpan duration)
            {
                if (duration <= TimeSpan.Zero)
                    throw new Exception("Duration must have duration time greater than zero.");
                this.duration = duration;
                return this;
            }

            public Builder Description(string desription)
            {
                if (string.IsNullOrEmpty(desription))
                    throw new Exception("Subject can not be empty.");
                else if (desription.Length > 250)
                    throw new Exception("Subject can not have more than 250 characters.");
                this.description = desription;
                return this;
            }

            public Builder SetIsCompleated(bool flag)
            {
                this.isCompleted = flag;
                return this;
            }

            public Builder AddComment(string body)
            {
                comments.Add(Comment.Create(id, body));
                return this;
            }
            public TaskSecond build()
            {
                return new TaskSecond(this);
            }
        }
    }
}
