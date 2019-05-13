using Dekanat.Server.Data;
using Dekanat.Server.Models;
using Dekanat.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dekanat.Server.Controllers {
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase {
        private readonly ApplicationContext db;

        public StudentsController(ApplicationContext context) {
            db = context;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> StudentsAdd([FromBody] Student model) {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            Student user = new Student {
                FirsName = model.FirsName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Faculty = model.Faculty,
                Pulpit = model.Pulpit,
                ReceiptDate = model.ReceiptDate,
                Address = model.Address,
                TrainingDirection = model.TrainingDirection,
                FormOfStudy = model.FormOfStudy,
                PhoneNumber = model.PhoneNumber,
                YearOfBirth = model.YearOfBirth
            };

            if (user != null) {
                db.Students.Add(user);
                await db.SaveChangesAsync();
                return Ok(model);
            }
            else {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("Get")]
        public List<Student> GetSudents() {
            return db.Students.ToList();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public Student GetSudent(int id) {
            return db.Students.Find(id);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id) {
            Student obj = db.Students.Find(id);
            db.Students.Remove(obj);
            await db.SaveChangesAsync();
            return Ok(obj);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> GetSudents([FromBody] Student model) {
            if (!ModelState.IsValid) {
                return BadRequest(500);
            }

            Student obj = new Student {
                FirsName = model.FirsName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Faculty = model.Faculty,
                Pulpit = model.Pulpit,
                ReceiptDate = model.ReceiptDate,
                Address = model.Address,
                TrainingDirection = model.TrainingDirection,
                FormOfStudy = model.FormOfStudy,
                PhoneNumber = model.PhoneNumber,
                YearOfBirth = model.YearOfBirth
            };
            db.Students.Update(model);
            await db.SaveChangesAsync();
            return Ok(obj);
        }
    }
}
