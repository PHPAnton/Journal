using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Journal.DataBaseFiles;
using Journal.Models;
using Journal.ViewModels.Commands;

namespace Journal.ViewModels
{
    public class ScheduleViewModel : INotifyPropertyChanged
    {
        private readonly DataBaseFiles.DbContextApp DataBaseContext;

        public ScheduleViewModel(DataBaseFiles.DbContextApp DBContext)
        {
            DataBaseContext = DBContext;
            AddScheduleCommand = new RelayCommand(AddSchedule);
            DeleteScheduleCommand = new RelayCommand(DeleteSchedule);
            CreateSchedule = new Schedule();

            LoadSchedules();
            LoadGroups();
            LoadTeachers();
        }

        public ObservableCollection<Schedule> Schedules { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public ObservableCollection<Teacher> Teachers { get; set; }
        public Schedule CreateSchedule { get; set; }
        public ICommand AddScheduleCommand { get; }
        public ICommand DeleteScheduleCommand { get; }

        public async Task LoadSchedules()
        {
            Schedules = new ObservableCollection<Schedule>(await DataBaseContext.Schedules.Include(s => s.Group).Include(s => s.Subject).Include(s => s.Teacher).ToListAsync());
            OnPropertyChanged(nameof(Schedules));
        }

        public async Task LoadGroups()
        {
            Groups = new ObservableCollection<Group>(await DataBaseContext.Groups.ToListAsync());
            OnPropertyChanged(nameof(Groups));
        }

        public async Task LoadSubjects()
        {
            Subjects = new ObservableCollection<Subject>(await DataBaseContext.Subjects.ToListAsync());
            OnPropertyChanged(nameof(Subjects));
        }

        public async Task LoadTeachers()
        {
            Teachers = new ObservableCollection<Teacher>(await DataBaseContext.Teachers.ToListAsync());
            OnPropertyChanged(nameof(Teachers));
        }

        private async void LoadGroupSubjects()
        {
            if (SelectedGroup != null)
            {
                Subjects = new ObservableCollection<Subject>(
                    await DataBaseContext.Subjects
                    .Where(s => s.Groups.Any(g => g.Id == SelectedGroup.Id))
                    .ToListAsync());
                OnPropertyChanged(nameof(Subjects));
            }
        }

        private async void AddSchedule(object parameter)
        {
            var newSchedule = new Schedule
            {
                GroupId = CreateSchedule.GroupId,
                SubjectId = CreateSchedule.SubjectId,
                TeacherId = CreateSchedule.TeacherId,
                Date = CreateSchedule.Date,
                StartTime = CreateSchedule.StartTime,
                EndTime = CreateSchedule.EndTime
            };

            DataBaseContext.Schedules.Add(newSchedule);
            await DataBaseContext.SaveChangesAsync();
            Schedules.Add(newSchedule);

            CreateSchedule.GroupId = 0;
            CreateSchedule.SubjectId = 0;
            CreateSchedule.TeacherId = 0;
            CreateSchedule.Date = DateTime.Now;
            CreateSchedule.StartTime = TimeSpan.Zero;
            CreateSchedule.EndTime = TimeSpan.Zero;
            OnPropertyChanged(nameof(CreateSchedule));
        }

        private async void DeleteSchedule(object parameter)
        {
            int scheduleId = (int)parameter;
            var schedule = DataBaseContext.Schedules.FirstOrDefault(s => s.Id == scheduleId);
            if (schedule != null)
            {
                DataBaseContext.Schedules.Remove(schedule);
                await DataBaseContext.SaveChangesAsync();
                Schedules.Remove(schedule);
            }
        }

        private Group privateSelectedGroup;
        public Group SelectedGroup
        {
            get { return privateSelectedGroup; }
            set
            {
                privateSelectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
                LoadGroupSubjects();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
