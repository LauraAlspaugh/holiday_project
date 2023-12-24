namespace holiday_project.Models;

public class Listing
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}