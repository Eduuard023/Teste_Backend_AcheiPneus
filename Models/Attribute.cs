namespace ApiAchei.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}