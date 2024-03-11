using Microsoft.AspNetCore.Mvc;
using AS_lab1_gr1.Models;

namespace AS_lab1_gr1.Controllers
{
    public class StudentController : Controller
    {

        public IActionResult Index(int id = 1)
        {
            var students = new List<Student>
            {
                new Student
                {
                    StudentId = 1,
                    Name = "Bartosz",
                    Surname = "Dawiskiba",
                    IndexNumber = 1,
                    BirthDate = new DateTime(2000, 09, 05),
                    FieldOfStudy = "Informatyka"
                },
                new Student
                {
                    StudentId = 2,
                    Name = "Jan",
                    Surname = "Kowalski",
                    IndexNumber = 2,
                    BirthDate = new DateTime(2002, 12, 31),
                    FieldOfStudy = "Informatyka"
                },
                new Student
                {
                    StudentId = 3,
                    Name = "Krzysztof",
                    Surname = "Nowak",
                    IndexNumber = 3,
                    BirthDate = new DateTime(1998, 01, 01),
                    FieldOfStudy = "Matematyka"
                }
            };
            return View(students[id - 1]);
        }
    }
}
