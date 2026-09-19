using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroEstudiantes.Context;
using RegistroEstudiantes.Models;

namespace RegistroEstudiantes.Services;

public class EstudianteServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(string nombre)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.AnyAsync(e => e.Nombre.ToLower().Trim().Equals(nombre.ToLower().Trim()));
    }

    public async Task<bool> Guardar(Estudiante estudiante)
    {
        if(!await Existe(estudiante.Nombre))
        {
            return await Insertar(estudiante);
        }
        else
        {
            return await Modificar(estudiante);
        }
    }

    public async Task<bool> Insertar(Estudiante estudiante)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Estudiantes.Add(estudiante);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Estudiante estudiante)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Estudiantes.Update(estudiante);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int estudianteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.AsNoTracking().Where(e => e.EstudianteId == estudianteId).ExecuteDeleteAsync() > 0;
    }

    public async Task<Estudiante?> Buscar(int estudianteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.FirstOrDefaultAsync(e => e.EstudianteId == estudianteId);
    }

    public async Task<List<Estudiante>> Listar(Expression<Func<Estudiante,bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.Where(criterio).ToListAsync();
    }
    
}