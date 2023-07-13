namespace api.Models
{
  public class Log
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Thoughts { get; set; }
    public int NumberOfPagesRead { get; set; }
    public int NumberOfPagesReadTotal { get; set; }
    public string ProgressPersentage { get; set; }
    public int ReadId { get; set; }
    public Read Read { get; set; }
  }
}