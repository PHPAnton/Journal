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
    // Класс ViewModel для управления студентами, реализующий интерфейс INotifyPropertyChanged
    public class StudentViewModel : INotifyPropertyChanged
    {
        // Поле для хранения контекста базы данных
        private readonly DataBaseFiles.DbContextApp DataBaseContext;

        // Конструктор, инициализирующий контекст базы данных и команды
        public StudentViewModel(DataBaseFiles.DbContextApp DBContext)
        {
            DataBaseContext = DBContext;
            // Инициализация команд
            AddStudentCommand = new RelayCommand(AddStudent);
            DeleteStudentCommand = new RelayCommand(DeleteStudent);
            // Инициализация создаваемого студента
            CreateStudent = new Student();

            // Загрузка данных студентов и групп
            LoadStudents();
            LoadGroups();
        }

        // Коллекция для хранения списка студентов
        public ObservableCollection<Student> Students { get; set; }
        // Коллекция для хранения списка групп
        public ObservableCollection<Group> Groups { get; set; }
        // Модель студента для создания нового студента
        public Student CreateStudent { get; set; }
        // Команда для добавления студента
        public ICommand AddStudentCommand { get; }
        // Команда для удаления студента
        public ICommand DeleteStudentCommand { get; }

        // Асинхронный метод для загрузки списка студентов из базы данных
        public async Task LoadStudents()
        {
            // Получение списка студентов с включением информации о группах
            Students = new ObservableCollection<Student>(await DataBaseContext.Students.Include(s => s.Group).ToListAsync());
            // Уведомление об изменении свойства Students
            OnPropertyChanged(nameof(Students));
        }

        // Асинхронный метод для загрузки списка групп из базы данных
        public async Task LoadGroups()
        {
            // Получение списка групп из базы данных
            Groups = new ObservableCollection<Group>(await DataBaseContext.Groups.ToListAsync());
            // Уведомление об изменении свойства Groups
            OnPropertyChanged(nameof(Groups));
        }

        // Метод для добавления нового студента
        private async void AddStudent(object parameter)
        {
            // Создание нового студента на основе данных из CreateStudent
            var newStudent = new Student
            {
                FirstName = CreateStudent.FirstName,
                LastName = CreateStudent.LastName,
                DateOfBirth = CreateStudent.DateOfBirth,
                GroupId = CreateStudent.GroupId
            };

            // Добавление нового студента в контекст базы данных
            DataBaseContext.Students.Add(newStudent);
            // Сохранение изменений в базе данных
            await DataBaseContext.SaveChangesAsync();
            // Добавление нового студента в коллекцию Students
            Students.Add(newStudent);

            // Очистка полей CreateStudent после добавления нового студента
            CreateStudent.FirstName = string.Empty;
            CreateStudent.LastName = string.Empty;
            CreateStudent.DateOfBirth = DateTime.Now;
            CreateStudent.GroupId = 0;
            // Уведомление об изменении свойства CreateStudent
            OnPropertyChanged(nameof(CreateStudent));
        }

        // Метод для удаления студента
        private async void DeleteStudent(object parameter)
        {
            // Получение идентификатора студента из параметра
            int studentId = (int)parameter;
            // Поиск студента в базе данных по идентификатору
            var student = DataBaseContext.Students.FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                // Удаление студента из контекста базы данных
                DataBaseContext.Students.Remove(student);
                // Сохранение изменений в базе данных
                await DataBaseContext.SaveChangesAsync();
                // Удаление студента из коллекции Students
                Students.Remove(student);
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
