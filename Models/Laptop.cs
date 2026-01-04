namespace laptopWebsite.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        public required string Brand { get; set; }

        public required string Model { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string? ImageUrl { get; set; }

        public bool HasCharger { get; set; } // does the laptop come with a charger

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}
