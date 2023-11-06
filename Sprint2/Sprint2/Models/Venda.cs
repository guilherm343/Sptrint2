namespace Sprint2.Models
{
    public class Venda
    {
        public Guid VendaId { get; set; }
        public string NumeroNota { get; set;}

        public DateTime Data { get; set;}

        public Guid ClienteId { get; set; }

        public Cliente? Clientes { get; set; }
    }
}
