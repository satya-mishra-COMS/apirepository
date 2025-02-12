using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LovDto
    {
        public string Id { get; set; }
        public string VDesc { get; set; }
    }
    public class lovData
    {
        public List<LovDto> data { get; set; }
        public int StatusId { get; set; }
        public string? StatusText { get; set; }
    }
}
