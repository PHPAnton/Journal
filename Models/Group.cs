
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Schedule> Schedules { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; } = new ObservableCollection<Subject>();
    }
}
