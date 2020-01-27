using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentApi.Entities
{
    public class Comment
    {
        public Guid TaskId { get; set; }
        public string Body { get; protected set; }
        public DateTime CreationDateTime { get; protected set; }

        protected Comment()
        {
        }

        public Comment(Guid taskId, string body)
        {
            TaskId = taskId;
            SetBody(body);
            CreationDateTime = DateTime.UtcNow;
        }

        public void SetBody(string body)
        {
            if (string.IsNullOrEmpty(body))
                throw new Exception("Comment can not be empty.");

            Body = body;
        }
        public static Comment Create(Task task, string body)
            => new Comment(task.Id, body);
        
        public static Comment Create(Guid id, string body)
             => new Comment(id, body);
    }
}
