using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
    }
}
