using Microsoft.AspNetCore.Mvc;
using TechAdvocacia.Application.ViewModels;
using TechAdvocacia.Application.InputModels;
using TechAdvocacia.Application.Services.Interfaces;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ClienteController : ControllerBase
{
   private readonly IClienteService _ClienteService;
   public List<ClienteViewModel> Clientes => _ClienteService.GetAll().ToList();
   public ClienteController(IClienteService service) => _ClienteService = service;

   [HttpGet("Clientes")]
   public IActionResult Get()
   {
      return Ok(Clientes);
   }

   [HttpGet("Cliente/{id}")]
   public IActionResult GetById(int id)
   {
      var Cliente = _ClienteService.GetById(id);
      if (Cliente is null)
         return NoContent();
      return Ok(Cliente);
   }

   [HttpPost("Cliente")]
   public IActionResult Post([FromBody] NewClienteInputModel Cliente)
   {
      _ClienteService.Create(Cliente);
      return CreatedAtAction(nameof(Get), Cliente);
 
   }

   [HttpPost("Cliente/{id}/atendimento")]
   public IActionResult Post(int id, [FromBody] NewAtendimentoInputModel atendimento)
   {
      _ClienteService.CreateAtendimento(id,atendimento);
      return CreatedAtAction(nameof(Get), atendimento);
 
   }

   [HttpPut("Cliente/{id}")]
   public IActionResult Put(int id, [FromBody] NewClienteInputModel Cliente)
   {
      if (_ClienteService.GetById(id) == null)
         return NoContent();
      _ClienteService.Update(id, Cliente);
      return Ok(_ClienteService.GetById(id));
   }

   [HttpDelete("Cliente/{id}")]
   public IActionResult Delete(int id)
   {
      if (_ClienteService.GetById(id) == null)
         return NoContent();
      _ClienteService.Delete(id);
      return Ok();
   }
}
