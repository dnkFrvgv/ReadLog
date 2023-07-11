using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class Review
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double NumberOfStars { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public string Notes { get; set; }
  }
}