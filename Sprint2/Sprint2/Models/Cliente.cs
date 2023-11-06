using System.ComponentModel;

namespace Sprint2.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        [DisplayName("Nome")]
        public string Nome { get; set; }
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [DisplayName("Data de Nascimento")]
        public DateTime DataNasc { get; set; }

        public string Email { get; set; }

        public string? Celular { get; set; }
        [DisplayName("Endereco")]
        public string Endereco { get; set; }
    }
}
