namespace Sprint2.Models
{
    public class Fornecedor
    {
        public Guid FornecedorId { get; set; }

        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public DateTime DataCad { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string Endereco { get; set; }
    }
}
