using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskList.Data;
using TaskList.Models;

namespace TaskList.Controllers
{
    [EnableCors ("http://localhost:4200","*","*")]
    public class tasksController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetTasks()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var tasks = context.Tasks.ToList();
                    return Ok(tasks);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IHttpActionResult PostTask([FromBody]Task task) {
            try
            {
                using (var context = new AppDbContext())
                {
                    var tasks = context.Tasks.ToList();
                    var userTasks = tasks.FindAll(t=>t.UserId == task.UserId
                    && t.IsCompleted == false);
                    if (userTasks.Count >= 10) { 
                        return BadRequest("User has more than 10 open tasks!");
                    }
                    var taskExist = tasks.FindAll(t => t.UserId == task.UserId
                                                    && t.subject == task.subject);
                    if (taskExist.Count > 0)
                    {
                       return BadRequest("Task already exist");
                    }                    
                    context.Tasks.Add(task);
                    context.SaveChanges();
                    return Ok("Task created");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IHttpActionResult CheckTask(int Id) { 
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDbContext())
                {
                    var oldTask = context.Tasks.FirstOrDefault(t => t.Id == Id);
                    if (oldTask == null) return NotFound();
                    oldTask.IsCompleted = true;
                    context.SaveChanges();
                    return Ok("Task Checked");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
