namespace api.Models
{
  public class Book
  {    
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<BookAuthor> Authors { get; set; }
    public int NumberOfPages { get; set; }
    public ICollection<Read> Reads { get; set; }
  }
}