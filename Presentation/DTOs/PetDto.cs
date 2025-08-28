namespace Presentation.DTOs
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Species { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
