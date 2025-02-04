using ApiAchei.Models;

namespace ApiAchei.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
        public int ProdutoId { get; set; }
        public Product? Product { get; set; }
    }
}