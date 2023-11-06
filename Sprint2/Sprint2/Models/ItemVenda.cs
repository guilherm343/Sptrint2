namespace Sprint2.Models
{
    public class ItemVenda
    {
        public Guid ItemVendaId { get; set; }

        public Guid VendaId { get; set; }

        public Venda? Vendas { get; set; }

        public Guid ProdutoId { get; set; }

        public Produto? Produtos { get; set; }

        public int Quantidade { get; set; }
    }
}
