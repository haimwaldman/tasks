using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskList.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsCompleted { get; set; }
        public string subject { get; set; }
    }
}