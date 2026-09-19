using System.ComponentModel.DataAnnotations;

namespace RegistroEstudiantes.Models;

public class Estudiante
{
    [Key]
    public int EstudianteId{get; set;}

    [Required(ErrorMessage ="El nombre no debe estar vacio.")]
    public string Nombre{get; set;} = string.Empty;

    [Required(ErrorMessage ="Es necesario agregar una direccion.")]
    public string Direccion{get; set;} = string.Empty;

    [Required(ErrorMessage ="Es necesario agregar un email.")]
    [EmailAddress(ErrorMessage ="Por favor, ingrese una direccion de correo valida")]
    public string Email{get; set;} = string.Empty;

    [Range(typeof(DateOnly), "1950-01-01", "2026-12-31", ErrorMessage = "Por favor, ingrese una fecha entre 1950 y 2026.")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly FechaNacimiento{get; set;}

}