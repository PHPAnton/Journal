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
    // Класс ViewModel для управления предметами, реализующий интерфейс INotifyPropertyChanged
    public class SubjectViewModel : INotifyPropertyChanged
    {
        // Поле для хранения контекста базы данных
        private readonly DataBaseFiles.DbContextApp DataBaseContext;

        // Конструктор, инициализирующий контекст базы данных и команды
        public SubjectViewModel(DataBaseFiles.DbContextApp DBContext)
        {
            DataBaseContext = DBContext;
            // Инициализация команд
            AddSubjectCommand = new RelayCommand(AddSubject);
            DeleteSubjectCommand = new RelayCommand(DeleteSubject);
            // Инициализация создаваемого предмета
            CreateSubject = new Subject();

            // Загрузка данных предметов
            LoadSubjects();
        }

        // Событие, уведомляющее об обновлении списка предметов
        public event EventHandler SubjectsUpdated;

        // Коллекция для хранения списка предметов
        public ObservableCollection<Subject> Subjects { get; set; }

        // Модель предмета для создания нового предмета
        public Subject CreateSubject { get; set; }

        // Команда для добавления предмета
        public ICommand AddSubjectCommand { get; }

        // Команда для удаления предмета
        public ICommand DeleteSubjectCommand { get; }

        // Асинхронный метод для загрузки списка предметов из базы данных
        public async Task LoadSubjects()
        {
            // Получение списка предметов с включением информации о преподавателях и группах
            Subjects = new ObservableCollection<Subject>(await DataBaseContext.Subjects.Include(s => s.Teachers).Include(s => s.Groups).ToListAsync());
            // Уведомление об изменении свойства Subjects
            OnPropertyChanged(nameof(Subjects));
        }

        // Метод для добавления нового предмета
        private async void AddSubject(object parameter)
        {
            // Создание нового предмета на основе данных из CreateSubject
            var newSubject = new Subject { Name = CreateSubject.Name };

            // Добавление нового предмета в контекст базы данных
            DataBaseContext.Subjects.Add(newSubject);

            // Сохранение изменений в базе данных
            await DataBaseContext.SaveChangesAsync();

            // Добавление нового предмета в коллекцию Subjects
            Subjects.Add(newSubject);

            // Очистка поля Name в CreateSubject после добавления нового предмета
            CreateSubject.Name = string.Empty;

            // Уведомление об изменении свойства CreateSubject
            OnPropertyChanged(nameof(CreateSubject));

            // Вызов события SubjectsUpdated для уведомления об обновлении списка предметов
            SubjectsUpdated?.Invoke(this, EventArgs.Empty);
        }

        // Метод для удаления предмета
        private async void DeleteSubject(object parameter)
        {
            // Получение идентификатора предмета из параметра
            int subjectId = (int)parameter;

            // Поиск предмета в базе данных по идентификатору
            var subject = DataBaseContext.Subjects.FirstOrDefault(s => s.Id == subjectId);
            if (subject != null)
            {
                // Удаление предмета из контекста базы данных
                DataBaseContext.Subjects.Remove(subject);

                // Сохранение изменений в базе данных
                await DataBaseContext.SaveChangesAsync();

                // Удаление предмета из коллекции Subjects
                Subjects.Remove(subject);

                // Вызов события SubjectsUpdated для уведомления об обновлении списка предметов
                SubjectsUpdated?.Invoke(this, EventArgs.Empty);
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
