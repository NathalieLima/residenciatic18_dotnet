using Microsoft.EntityFrameworkCore;

namespace Techmed.Model;

public class TechmedContext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    
    public TechmedContext() {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=natha123;database=techmed"; //3306
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Medico>().ToTable("medico").HasKey(m => m.cpf);
        modelBuilder.Entity<Medico>().Property(m => m.salario).IsRequired();
    }
}

public abstract class Pessoa
{
    string Id { get; set; }
    string Nome { get; set; }
}

public class Paciente : Pessoa
{
    string Endereco { get; set; }
    string Telefone { get; set; }
}

public class Medico : Pessoa
{
    int Codigo { get; set; }
    string Especialidade { get; set; }
    double Salario { get; set; }
}