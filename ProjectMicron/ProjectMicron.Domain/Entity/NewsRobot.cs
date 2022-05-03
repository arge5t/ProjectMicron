using System;
using System.Collections.Generic;
using ProjectMicron.Domain.Enum;

namespace ProjectMicron.Domain.Entity
{
    public class NewsRobot
    {


        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TypeNew TypeNew { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
