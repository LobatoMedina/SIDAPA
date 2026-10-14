using System.ComponentModel.DataAnnotations;

namespace SIDAPA.presentation.Models.Auth;

public class LoginViewModel
{
    [Display(Name = "Correo")]
    [Required(ErrorMessage = "Ingrese su correo.")]
    [EmailAddress(ErrorMessage = "Ingrese un correo válido.")]
    public string Email { get; set; } = "";

    [Display(Name = "Contraseña")]
    [Required(ErrorMessage = "Ingrese su contraseña.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";
}
