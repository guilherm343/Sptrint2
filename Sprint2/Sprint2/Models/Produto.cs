namespace Sprint2.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }

        public int Estoque { get; set; }

        public decimal PrecoUnitario { get; set; }

        public Guid CategoriaId { get; set; }
        public Categoria? Categorias { get; set; }

        public Guid FornecedorId { get; set; }
        public Fornecedor? Fornecedores { get; set; }
    }
}
