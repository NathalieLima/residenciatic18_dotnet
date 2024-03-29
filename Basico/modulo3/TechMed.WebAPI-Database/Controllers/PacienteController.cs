using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class PacienteController : ControllerBase
{
   private readonly IPacienteCollection _pacientes;
   public List<Paciente> pacientes => _pacientes.GetAll().ToList();
   public PacienteController(IPacienteCollection pacientes) => _pacientes = pacientes;

   [HttpGet("pacientes")]
   public IActionResult Get()
   {
      return Ok(pacientes);
   }

   [HttpGet("paciente/{id}")]
   public IActionResult GetById(int id)
   {
      var paciente = _pacientes.GetById(id);
      return Ok(paciente);
   }

   [HttpPost("paciente")]
   public IActionResult Post([FromBody] Paciente paciente)
   {
      _pacientes.Create(paciente);
      return CreatedAtAction(nameof(Get),  paciente);
   }

   [HttpPut("paciente/{id}")]
   public IActionResult Put(int id, [FromBody] Paciente paciente)
   {
      if (_pacientes.GetById(id) == null)
         return NoContent();
      _pacientes.Update(id, paciente);
      return Ok(_pacientes.GetById(id));
   }

   [HttpDelete("paciente/{id}")]
   public IActionResult Delete(int id)
   {
      if (_pacientes.GetById(id) == null)
         return NoContent();
      _pacientes.Delete(id);
      return Ok();
   }

   // [HttpGet("paciente/{id}/atendimentos")]
   // public IActionResult GetAtendimentos(int id)
   // {
   //    var atendimento = Enumerable.Range(1, 5).Select(index => new Atendimento
   //      {
   //          AtendimentoId = index,
   //          DataHora = DateTime.Now,
   //          pacienteId = id,
   //          paciente = new paciente
   //          {
   //              pacienteId = id,
   //              Nome = $"paciente {id}"
   //          }
   //      })
   //      .ToArray();
   //    return Ok(atendimento);
   // }
}
