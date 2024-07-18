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
    
    public class TeacherViewModel : INotifyPropertyChanged
    {
        // Поле для хранения контекста базы данных
        private readonly DataBaseFiles.DbContextApp DataBaseContext;

        // Конструктор, инициализирующий контекст базы данных и команды
        public TeacherViewModel(DataBaseFiles.DbContextApp DBContext)
        {
            DataBaseContext = DBContext;
            // Инициализация команд
            AddTeacherCommand = new RelayCommand(AddTeacher);
            DeleteTeacherCommand = new RelayCommand(DeleteTeacher);
            AddSubjectCommand = new RelayCommand(AssignSubject);
            // Инициализация создаваемого преподавателя и выбранных сущностей
            CreateTeacher = new Teacher();
            SelectedTeacher = null;

            // Загрузка данных преподавателей и предметов
            LoadTeachers();
            LoadSubjects();
        }

        // Событие, уведомляющее об обновлении списка преподавателей
        public event EventHandler TeachersUpdated;

        // Коллекция для хранения списка преподавателей
        public ObservableCollection<Teacher> Teachers { get; set; }

        // Коллекция для хранения списка предметов
        public ObservableCollection<Subject> Subjects { get; set; }

        // Модель преподавателя для создания нового преподавателя
        public Teacher CreateTeacher { get; set; }

        // Выбранный преподаватель
        public Teacher SelectedTeacher { get; set; }

        // Выбранный предмет
        public Subject SelectedSubject { get; set; }

        // Команда для добавления преподавателя
        public ICommand AddTeacherCommand { get; }

        // Команда для добавления предмета преподавателю
        public ICommand AddSubjectCommand { get; }

        // Команда для удаления преподавателя
        public ICommand DeleteTeacherCommand { get; }

        // Асинхронный метод для загрузки списка преподавателей из базы данных
        public async Task LoadTeachers()
        {
            // Получение списка преподавателей с включением информации о предметах
            Teachers = new ObservableCollection<Teacher>(
                await DataBaseContext.Teachers.Include(t => t.Subjects).ToListAsync());

            // Загрузка предметов для каждого преподавателя
            foreach (var teacher in Teachers)
            {
                teacher.Subjects = new ObservableCollection<Subject>(
                    await DataBaseContext.Subjects.Where(s => s.Teachers.Any(t => t.Id == teacher.Id)).ToListAsync());
            }

            // Уведомление об изменении свойства Teachers
            OnPropertyChanged(nameof(Teachers));
        }

        // Асинхронный метод для загрузки списка предметов из базы данных
        public async Task LoadSubjects()
        {
            Subjects = new ObservableCollection<Subject>(await DataBaseContext.Subjects.ToListAsync());
            OnPropertyChanged(nameof(Subjects));
        }

        // Метод для добавления нового преподавателя
        private async void AddTeacher(object parameter)
        {
            // Создание нового преподавателя на основе данных из CreateTeacher
            var newTeacher = new Teacher
            {
                FirstName = CreateTeacher.FirstName,
                LastName = CreateTeacher.LastName,
                Subjects = new ObservableCollection<Subject>()
            };

            // Добавление нового преподавателя в контекст базы данных
            DataBaseContext.Teachers.Add(newTeacher);

            // Сохранение изменений в базе данных
            await DataBaseContext.SaveChangesAsync();

            // Добавление нового преподавателя в коллекцию Teachers
            Teachers.Add(newTeacher);

            // Очистка полей FirstName и LastName в CreateTeacher после добавления нового преподавателя
            CreateTeacher.FirstName = string.Empty;
            CreateTeacher.LastName = string.Empty;

            // Уведомление об изменении свойства CreateTeacher
            OnPropertyChanged(nameof(CreateTeacher));

            // Вызов события TeachersUpdated для уведомления об обновлении списка преподавателей
            TeachersUpdated?.Invoke(this, EventArgs.Empty);
        }

        // Метод для назначения предмета преподавателю
        private async void AssignSubject(object parameter)
        {
            // Проверка, что выбран преподаватель и предмет
            if (SelectedTeacher != null && SelectedSubject != null)
            {
                // Добавление выбранного предмета к списку предметов выбранного преподавателя
                SelectedTeacher.Subjects.Add(SelectedSubject);

                // Сохранение изменений в базе данных
                await DataBaseContext.SaveChangesAsync();

                // Перезагрузка списка преподавателей
                await LoadTeachers();
            }
        }

        // Метод для удаления преподавателя
        private async void DeleteTeacher(object parameter)
        {
            // Получение идентификатора преподавателя из параметра
            int teacherId = (int)parameter;

            // Поиск преподавателя в базе данных по идентификатору
            var teacher = DataBaseContext.Teachers.FirstOrDefault(t => t.Id == teacherId);
            if (teacher != null)
            {
                // Удаление преподавателя из контекста базы данных
                DataBaseContext.Teachers.Remove(teacher);

                // Сохранение изменений в базе данных
                await DataBaseContext.SaveChangesAsync();

                // Удаление преподавателя из коллекции Teachers
                Teachers.Remove(teacher);

                // Вызов события TeachersUpdated для уведомления об обновлении списка преподавателей
                TeachersUpdated?.Invoke(this, EventArgs.Empty);
            }
        }

        // Событие для уведомления об изменениях свойств
        public event PropertyChangedEventHandler PropertyChanged;

        // Метод для вызова события PropertyChanged
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // Если есть подписчики на событие PropertyChanged, вызываем их
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
