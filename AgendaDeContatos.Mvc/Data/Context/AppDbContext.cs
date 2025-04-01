using AgendaDeContatos.Mvc.Data.Repositories;
using AgendaDeContatos.Mvc.Data.Repositories.Interfaces;
using AgendaDeContatos.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaDeContatos.Mvc.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<Filial> Filiais { get; set; }
    public DbSet<Setor> Setores { get; set; }
    public DbSet<Contato> Contatos { get; set; }


    public CheckCompatibilityFilial CompatibilityFilial { get; init; }
    public CheckCompatibilitySetor CompatibilitySetor { get; init; }
    public CheckCompatibilityContato CompatibilityContato { get; init; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { 
        CompatibilityFilial = new CheckCompatibilityFilial();
        CompatibilitySetor = new CheckCompatibilitySetor();
        CompatibilityContato = new CheckCompatibilityContato();
    }


    protected override void OnModelCreating(ModelBuilder model)
    {
        base.OnModelCreating(model);

        var filial = model.Entity<Filial>();
        var setor = model.Entity<Setor>();
        var contatos = model.Entity<Contato>();

        filial.Property(f => f.Nome).HasMaxLength(30);
        filial.Property(f => f.Cidade).HasMaxLength(40);
        filial.Property(f => f.Estado).HasMaxLength(2).IsFixedLength();
        filial.Property(f => f.Cnpj).HasMaxLength(14).IsFixedLength();

        setor.Property(s => s.Nome).HasMaxLength(40);

        contatos.Property(c => c.Nome).HasMaxLength(50);
        contatos.Property(c => c.Email).HasMaxLength(100);
        contatos.Property(c => c.Ramal).HasMaxLength(10);
        contatos.Property(c => c.Celular).HasMaxLength(14);
    }
}
