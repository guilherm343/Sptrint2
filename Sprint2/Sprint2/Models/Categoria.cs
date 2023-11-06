using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Sprint2.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }

        public string Nome { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }
}
