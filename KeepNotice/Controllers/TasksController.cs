using KeepNotice.Data;
using KeepNotice.Models.Domin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeepNotice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly DbContextClass context;

        public TasksController(DbContextClass context)
        {
            
   
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetTasks()
        {
            var dbdata = await context.tasks.ToListAsync();

            return Ok(dbdata);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSinglTask(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var data = await context.tasks.FirstOrDefaultAsync(x=>x.Id==id);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult>AddTask( [FromBody] Tasks task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            await context.tasks.AddAsync(task);
            await context.SaveChangesAsync();
            return Ok(new
            {
                Data=task,
                message= "Data Added Successfully!"
            });

        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateStudents(int id, Tasks task)
        {

            if (task == null  || id<=0)
            {
                return BadRequest();
            }
           

            var isExistTask = await  context.tasks.FirstOrDefaultAsync(t=>t.Id==id);
            if (isExistTask == null)
            {
                return NotFound();
            }

            isExistTask.title = task.title;
            isExistTask.description = task.description;
            context.SaveChanges();
            
            return Ok(new
            {
                Data = isExistTask,
                Message="Data Updated Successfully"
            });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult>DeleteData(int id)
        {
            if (id<=0)
            {
                return BadRequest();
            }

            var data = await context.tasks.FirstOrDefaultAsync(t=>t.Id== id);
            if (data == null) 
            {
                return NotFound();
            }
            context.tasks.Remove(data);
            await context.SaveChangesAsync();
            return Ok(new
            {
               Message="Data Removed From The List",
               Data = data
            });

        }


    }
}








