using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class Book
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Author> Authors { get; set; }
    public int NumberOfPages { get; set; }
    public int NumberOfPagesRead { get; set; } = 0;
    public decimal PercentageRead {get;set;} = 0;
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