using Api_v1.Context;
using Api_v1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly AppDbContext context;

        public PatientController(AppDbContext context) { 
            this.context = context;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            try { 
                return Ok(context.Patients.ToList());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}", Name = "GetPaciente")]
        public ActionResult Get(int id)
        {
            //return "value";
            try
            {
                //return Ok(context.Patients.ToList());
                var patient = context.Patients.FirstOrDefault(pa => pa.id == id);
                return Ok(patient);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<PatientController>
        [HttpPost]
        public ActionResult Post([FromBody] Patient paciente)
        {
            try
            {
                context.Add(paciente);
                context.SaveChanges();
                return CreatedAtRoute("GetPaciente", new {id = paciente.id},paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Patient paciente)
        {
            try
            {
                //return Ok(context.Patients.ToList());
                if (paciente.id == id)
                {
                    context.Entry(paciente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();

                    return CreatedAtRoute("GetPaciente", new { id = paciente.id }, paciente);
                }
                else {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var patient = context.Patients.FirstOrDefault(pa => pa.id == id);
                //return Ok(context.Patients.ToList());
                if (patient != null)
                {
                    context.Remove(patient);
                    context.SaveChanges();

                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
