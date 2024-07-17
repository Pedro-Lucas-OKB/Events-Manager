using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventsManager.Application.Requests.Organizer;

public class CreateOrganizerRequest
{
    [Required(ErrorMessage = "O campo 'Nome' não pode ficar em branco!")]
    [MaxLength(100, ErrorMessage = "O campo 'Nome' não pode ter mais de 100 caracteres!")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Email' não pode ficar em branco!")]
    [EmailAddress(ErrorMessage = "Digite um email válido!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Senha' não pode ficar em branco!")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Descrição' não pode ficar em branco!")]
    [MaxLength(1000, ErrorMessage = "O campo 'Descrição' não pode ter mais de 1000 caracteres!")]
    public string Description { get; set; } = string.Empty;
}
