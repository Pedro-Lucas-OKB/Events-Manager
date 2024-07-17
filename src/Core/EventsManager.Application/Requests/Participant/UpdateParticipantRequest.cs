using System.ComponentModel.DataAnnotations;

namespace EventsManager.Application.Requests.Participant;

public class UpdateParticipantRequest
{
    public long Id { get; set; }

    [Required(ErrorMessage = "O campo 'Nome' não pode ficar em branco!")]
    [MaxLength(100, ErrorMessage = "O campo 'Nome' não pode ter mais de 100 caracteres!")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Email' não pode ficar em branco!")]
    [EmailAddress(ErrorMessage = "Digite um email válido!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Senha' não pode ficar em branco!")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo 'Idade' não pode ficar em branco!")]
    [MinLength(18, ErrorMessage = "A idade mínima para usar o sistema é de 18 anos!")]
    public uint Age { get; set; }
}
