namespace Pizzaria.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Sabor { get; set; } = string.Empty;
        public string Capa { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
    }
}
