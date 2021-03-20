using System.ComponentModel.DataAnnotations;

namespace Curso.API.Models.Usuários
{
    public class RegistroViewModelInput
    {
        [Required(ErrorMessage = "O login é obrigatório!")]

        public string Login { get; set; }

        [Required(ErrorMessage = "O email é obrigatório!")]

        public string Email { get; set; }
        
        [Required(ErrorMessage = "A senha é obrigatória!")]

        public string Senha { get; set; }
    }
}
