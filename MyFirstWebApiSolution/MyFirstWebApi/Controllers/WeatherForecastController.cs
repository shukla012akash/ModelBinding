using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        static List<Employee> employeeList = new List<Employee>();

        //MODEL BINDING USING STRING AND QUERY
        [HttpGet]
        public ActionResult GetFromUri([System.Web.Http.FromUri] string name, [System.Web.Http.FromUri] string address)
        {
            Employee employee = new Employee();
            employee.Name = name;
            employee.Address = address;
            

            var serializedOutput = JsonConvert.SerializeObject(employee); 
            return Ok(serializedOutput);
        }

        //----****FROM BODY******-----//

        [HttpGet]

        public ActionResult GetFromBody([System.Web.Http.FromBody] Employee employee)
        {
            return Ok($"Employee Name is: {employee.Name} and employee address is: {employee.Address}");
        }
        
        [HttpPost]
        public ActionResult AddEmployee(int age, string city)
        {
            return Ok("New Employee Added!");
        }

        //---DELETE FROM URI--//

        [HttpDelete("{id}")]
        public ActionResult RemoveEmployeeFromUri(int Id)
        {
            var editEmployee = employeeList.Where(obj => obj.Id == Id).FirstOrDefault();
            if (editEmployee != null)
            {
                employeeList.Remove(editEmployee);

                return Ok($"EmpId: {Id} removed from employee list.");
            }
            else
            {
                return Ok($"EmpId: {Id} not found");
            }

        }

        //-----***FROM BODY****---//

        [HttpDelete]
        public ActionResult GetItFromBody([System.Web.Http.FromBody] Employee employee)
        {
            return Ok($"Employee Id is: {employee.Id}");
        }

        //----PUT FROM URI---//

        [HttpPut]
        public ActionResult UpdateAEmployeeFromUri(int Id, string Name, string Address)
        {
            var editEmployee = employeeList.Where(obj => obj.Id == Id).FirstOrDefault();
            if (editEmployee != null)
            {
                editEmployee.Name = Name;

                editEmployee.Address = Address;

                return Ok($"EmpId: {Id} details updated.");
            }
            else
            {
                return Ok($"EmpId: {Id} not found");

            }
        }

        //-----*****FROM BODY*****----//
        [HttpPut]
        
        public ActionResult GetItByFromBody([System.Web.Http.FromBody] Employee employee)
        {
            return Ok($"Employee Id is: {employee.Id} and Employee Name is:{employee.Name} and Employee Address is:{employee.Address}" );
        }


        //[HttpPost]
        //public ActionResult AddAEmployee(int EmpId, string EmployeeName, string EmployeeAddres)
        //{
        //    employeeList.Add(new Employee { Id = EmpId, Name = EmployeeName, Address = EmployeeAddres });
        //    int i = employeeList.Count();
        //    return Ok("New Employeed Added!!");
        //}


        //[HttpGet]
        //public ActionResult GetAllEmployee()
        //{
        //    //employeeList = new List<Employee>();
        //    //employeeList.Add(new Employee { Id = 100, Name = "Akash", Address = "Lko" });
        //    return Ok(employeeList);
        //}
        //[HttpPut]
        //public ActionResult UpdateAEmployeeDetails(int Id, string Name, string Address)
        //{
        //    var editEmployee = employeeList.Where(obj => obj.Id == Id).FirstOrDefault();
        //    if (editEmployee != null)
        //    {
        //        editEmployee.Name = Name;

        //        editEmployee.Address = Address;

        //        return Ok($"EmpId: {Id} details updated.");
        //    }
        //    else
        //    {
        //        return Ok($"EmpId: {Id} not found");

        //    }
        //}
        //[HttpDelete]
        //public ActionResult RemoveEmployee(int Id)
        //{
        //    var editEmployee = employeeList.Where(obj => obj.Id == Id).FirstOrDefault();
        //    if (editEmployee != null)
        //    {
        //        employeeList.Remove(editEmployee);

        //        return Ok($"EmpId: {Id} removed from employee list.");
        //    }
        //    else
        //    {
        //        return Ok($"EmpId: {Id} not found");
        //    }

        //}
    }
}

