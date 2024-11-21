using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Sentiment { get; set; } = string.Empty;
    }
}