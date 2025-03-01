using Microsoft.AspNetCore.Mvc;
using Mission8.Models;
using Mission8.Data;
using System.Linq;

namespace Mission8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public HomeController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // Display tasks in quadrants
        public IActionResult Index()
        {
            var tasks = _taskRepository.GetAllTasks()
                .Where(t => !t.Completed)
                .ToList();

            var quadrantViewModel = new QuadrantViewModel
            {
                Quadrant1 = tasks.Where(t => t.Quadrant == 1).ToList(),
                Quadrant2 = tasks.Where(t => t.Quadrant == 2).ToList(),
                Quadrant3 = tasks.Where(t => t.Quadrant == 3).ToList(),
                Quadrant4 = tasks.Where(t => t.Quadrant == 4).ToList()
            };

            return View(quadrantViewModel);
        }

        // GET: Add Task
        public IActionResult AddTask()
        {
            return View(new Task());
        }

        // POST: Add Task
        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _taskRepository.AddTask(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Edit Task
        public IActionResult EditTask(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task == null) return NotFound();
            return View(task);
        }

        // POST: Edit Task
        [HttpPost]
        public IActionResult EditTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _taskRepository.UpdateTask(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // DELETE: Remove Task
        public IActionResult DeleteTask(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task != null)
            {
                _taskRepository.DeleteTask(id);
            }
            return RedirectToAction("Index");
        }

        // POST: Mark Task as Completed
        public IActionResult MarkComplete(int id)
        {
            var task = _taskRepository.GetTaskById(id);
            if (task != null)
            {
                task.Completed = true;
                _taskRepository.UpdateTask(task);
            }
            return RedirectToAction("Index");
        }
    }
}
