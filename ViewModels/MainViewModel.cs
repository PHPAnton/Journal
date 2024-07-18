using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using Journal.DataBaseFiles;
using Journal.ViewModels.Commands;
using Journal.Views;

namespace Journal.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DbContextApp DataBaseContext;
        private Page PrivateCurrentView;

        // Конструктор класса MainViewModel
        public MainViewModel()
        {
            // Инициализация контекста базы данных
            DataBaseContext = new DbContextApp();

            // Инициализация моделей представления для каждой страницы
            GroupViewModel = new GroupViewModel(DataBaseContext);
            StudentViewModel = new StudentViewModel(DataBaseContext);
            TeacherViewModel = new TeacherViewModel(DataBaseContext);
            SubjectViewModel = new SubjectViewModel(DataBaseContext);
            ScheduleViewModel = new ScheduleViewModel(DataBaseContext);

            // Установка начальной страницы (GroupPageView) и связывание её с GroupViewModel
            PrivateCurrentView = new GroupPageView { DataContext = GroupViewModel };

            // Инициализация команд для навигации между страницами
            ShowGroupPageCommand = new RelayCommand(_ => ShowGroupPage());
            ShowStudentPageCommand = new RelayCommand(_ => ShowStudentPage());
            ShowTeacherPageCommand = new RelayCommand(_ => ShowTeacherPage());
            ShowSubjectPageCommand = new RelayCommand(_ => ShowSubjectPage());
            ShowSchedulePageCommand = new RelayCommand(_ => ShowSchedulePage());
            RunExitProgram = new RelayCommand(_ => ExitProgram());

            // Подписка на события обновления данных моделей представления
            GroupViewModel.GroupsUpdated += OnGroupsUpdated;
            SubjectViewModel.SubjectsUpdated += OnSubjectsUpdated;
            TeacherViewModel.TeachersUpdated += OnTeachersUpdated;
        }

        // Свойство для текущей отображаемой страницы
        public Page CurrentView
        {
            get { return PrivateCurrentView; }
            set
            {
                PrivateCurrentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        // Команды для отображения различных страниц
        public ICommand ShowGroupPageCommand { get; }
        public ICommand ShowStudentPageCommand { get; }
        public ICommand ShowTeacherPageCommand { get; }
        public ICommand ShowSubjectPageCommand { get; }
        public ICommand ShowSchedulePageCommand { get; }
        public ICommand RunExitProgram { get; }

        // Методы для отображения страниц
        private void ShowGroupPage()
        {
            CurrentView = new GroupPageView { DataContext = GroupViewModel };
        }

        private void ShowStudentPage()
        {
            CurrentView = new StudentPageView { DataContext = StudentViewModel };
        }

        private void ShowTeacherPage()
        {
            CurrentView = new TeacherPageView { DataContext = TeacherViewModel };
        }

        private void ShowSubjectPage()
        {
            CurrentView = new SubjectPageView { DataContext = SubjectViewModel };
        }

        private void ShowSchedulePage()
        {
            CurrentView = new SchedulePageView { DataContext = ScheduleViewModel };
        }

        // Метод для обновления данных на всех страницах
        public async void RefreshData()
        {
            await GroupViewModel.LoadGroups();
            await SubjectViewModel.LoadSubjects();
            await TeacherViewModel.LoadTeachers();
            await StudentViewModel.LoadStudents();
            await ScheduleViewModel.LoadSchedules();
        }

        // Обработчики событий обновления данных
        private void OnGroupsUpdated(object sender, EventArgs e)
        {
            StudentViewModel.LoadGroups();
            ScheduleViewModel.LoadGroups();
        }

        private void OnSubjectsUpdated(object sender, EventArgs e)
        {
            GroupViewModel.LoadSubjects();
            TeacherViewModel.LoadSubjects();
            ScheduleViewModel.LoadSubjects();
        }

        private void OnTeachersUpdated(object sender, EventArgs e)
        {
            ScheduleViewModel.LoadTeachers();
        }

        // Метод для завершения работы приложения
        public void ExitProgram()
        {
            App.Current.Shutdown();
        }

        // Свойства для доступа к моделям представления каждой страницы
        public StudentViewModel StudentViewModel { get; }
        public GroupViewModel GroupViewModel { get; }
        public TeacherViewModel TeacherViewModel { get; }
        public SubjectViewModel SubjectViewModel { get; }
        public ScheduleViewModel ScheduleViewModel { get; }

        // Событие изменения свойств
        public event PropertyChangedEventHandler PropertyChanged;

        // Метод для вызова события изменения свойства
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
