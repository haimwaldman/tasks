using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskList.Models;

namespace TaskList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=tasklist")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks{ get; set; }
    }
}