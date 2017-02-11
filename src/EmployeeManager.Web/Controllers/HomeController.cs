using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Web.Controllers
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Models.Home;

    public class HomeController : Controller
    {
        private readonly EmployeeDataContext _dbContext;

        public HomeController(EmployeeDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult>  Index()
        {
            var model = await _dbContext.Employees.AsNoTracking().Select(e => new EmployeeIndexModel
            {
                EmployeeId = e.Id,
                Name =  e.FirstName + " " + e.LastName,
                Department = e.Department
            }).ToListAsync();

            return View(model);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeAddModel model)
        {
            if (!ModelState.IsValid) return View();


            var employee = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Department = model.Department,
                WhoDidThis = HttpContext.User.Identity.Name
            };

            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateEmployee(int id)
        {

            var model = await _dbContext.Employees.Where(e=>e.Id == id).Select(e => new EmployeeUpdateModel
            {
                EmployeeId = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Department = e.Department,

            }).SingleOrDefaultAsync();

            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>  UpdateEmployee(EmployeeUpdateModel model)
        {
            if (!ModelState.IsValid) return View();

            var employee = new Employee
            {
                Id = model.EmployeeId,
                FirstName = model.FirstName,
                LastName =  model.LastName,
                Department = model.Department,
                WhoDidThis = HttpContext.User.Identity.Name
            };

            /*
             * Finally!!! 
             * Note: this works in the disconnected stated because it marks all Entities in the graph as modified
             * There is also a TrackGraph that allows finer control of what is being updated.
             */
            _dbContext.Update(employee);

            await _dbContext.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employeeToDelete = new Employee {Id = id};
            _dbContext.Entry(employeeToDelete).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
