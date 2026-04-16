namespace Core.Models;

public class annoncer
{
    public string? annonceId { get; set; }
    public string? Titel { get; set; }
    public double pris { get; set; }
    public string? Description { get; set; }
    public DateTime oprettet { get; set; }
    public string? status { get; set; }
    public string? brugerID { get; set; }
    public string? kategori { get; set; }
    public string? billedeUrl { get; set; }
}
