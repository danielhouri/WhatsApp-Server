using System.ComponentModel.DataAnnotations;

namespace ClientSide.Models
{
    public class Feedback
    {
        public DateTime Date { get; set; }

        [Key]
        public string? name { get; set; }

        [Range(1,5)]
        public int? grade { get; set; }

        public string? comment { get; set; }
    }
}