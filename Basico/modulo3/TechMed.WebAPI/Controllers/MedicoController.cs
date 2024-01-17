using Microsoft.AspNetCore.Mvc;
using Model.TechMed.WebAPI;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicoController : ControllerBase
{
    private static  string[] Summaries = new[]
    {
        "JC", "D", "ES", "Náthalie", "Ciro", "Lilívia" 
    };

    private readonly ILogger<MedicoController> _logger;

    public MedicoController(ILogger<MedicoController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IEnumerable<Medico> Post()
    {
        Medico medico = new Medico();
        medico.Name = "Náthalie";

        string[] nomes_medicos = {"Náthalie", "Gabriel", "Cauã"};

        string novo_medico = "Maurício";

        nomes_medicos.SetValue(novo_medico, nomes_medicos.Length-1);


        return Enumerable.Range(1, 5).Select(index => new Medico
        {
            Name = nomes_medicos[Random.Shared.Next(nomes_medicos.Length)]
        })
        .ToArray();
    }

    [HttpGet(Name = "GetMedico")]
    public IEnumerable<Medico> Get()
    {


        return Enumerable.Range(1, 5).Select(index => new Medico
        {
            Name = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
        
        
    }

    [HttpPut("{id}")]
    public IEnumerable<Medico> Update(Guid id)
    {
        
        return Enumerable.Range(1, 5).Select(index => new Medico
        {
            Name = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpDelete("{id}")]
    public IEnumerable<Medico> Delete(Guid id)
    {
        
        return Enumerable.Range(1, 5).Select(index => new Medico
        {
            Name = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
