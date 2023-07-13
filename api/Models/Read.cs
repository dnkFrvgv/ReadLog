namespace api.Models
{
  public class Read
  {
    public int Id { get; set; }
    public Book Book { get; set; }
    public int BookId { get; set; }
    public int NumberOfPagesRead { get; set; } = 0;
    public decimal PercentageRead { get; set; } = 0;
    public ReadingStatus Status { get; set; } = ReadingStatus.READY_TO_START;
    public ICollection<Log> Logs { get; set; }
    public Review Review { get; set; }
  }

  public enum ReadingStatus
  {
    READY_TO_START = 1,
    READING = 2,
    FINISHED = 3,
    DID_NOT_FINISH = 4
  }
}