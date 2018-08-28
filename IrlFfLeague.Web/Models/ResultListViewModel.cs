using System.Collections.Generic;
using System.Linq;

namespace IrlFfLeague.Web.Models
{
    public class ResultListViewModel
    {
        public string UserName { get; set; }

        public List<int> Points { get; set; }

        public int Total => Points.Sum();
    }
}
