using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class Log
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }
    public int NumberOfPagesRead { get; set; }
    public int NumberOfPagesReadTotal { get; set; }
    public string ProgressPersentage { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
  }
}