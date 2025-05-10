namespace CarRental.Application.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Fluel { get; set; }
        public int Power { get; set; }
        public int ClientId { get; set; }
    }
}
