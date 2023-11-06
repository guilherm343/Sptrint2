namespace Sprint2.Models
{
    public class ItemCompra
    {
        public Guid ItemCompraId { get; set; }

        public Guid CompraId { get; set; }

        public Compra? Compras { get; set; }

        public Guid ProdutoId { get; set; }

        public Produto? Produtos { get; set; }

        public int Quantidade { get; set; }
    }
}
