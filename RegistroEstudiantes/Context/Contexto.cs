using Microsoft.EntityFrameworkCore;
using RegistroEstudiantes.Models;

namespace RegistroEstudiantes.Context;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<Estudiante> Estudiantes{get; set;}
    
}