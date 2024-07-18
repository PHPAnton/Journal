using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<Group> Groups { get; set; }
    }

}
