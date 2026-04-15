namespace Core.Models;

public class annoncer
{
    public int annonceId { get; set; }
    public string Titel { get; set; }
    public double pris { get; set; }
    public string Description { get; set; }
    public DateTime oprettet { get; set; }
    public string? staus { get; set; }
}