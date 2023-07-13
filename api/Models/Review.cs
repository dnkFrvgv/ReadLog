namespace api.Models
{
  public class Review
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double NumberOfStars { get; set; }
    public int ReadId { get; set; }
    public Read Read { get; set; }
    public string WrittenReview { get; set; }
  }
}