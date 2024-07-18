using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Journal.DataBaseFiles;
using Journal.Models;
using Journal.ViewModels.Commands;

namespace Journal.ViewModels
{
    public class GroupViewModel : INotifyPropertyChanged
    {
        private readonly DataBaseFiles.DbContextApp DataBaseContext;

        // Конструктор класса GroupViewModel
        public GroupViewModel(DataBaseFiles.DbContextApp DBContext)
        {
            // Инициализация контекста базы данных
            DataBaseContext = DBContext;

            // Инициализация команд для добавления группы, предмета и удаления группы
            AddGroupCommand = new RelayCommand(AddGroup);
            DeleteGroupCommand = new RelayCommand(DeleteGroup);
            AddSubjectCommand = new RelayCommand(AssignSubject);

            // Создание новой группы для добавления
            CreateGroup = new Group();

            // Выбранная группа по умолчанию не задана
            SelectedGroup = null;

            // Загрузка списков групп, предметов и студентов из базы данных
            LoadGroups();
            LoadSubjects();
            LoadStudents();
        }

        // Событие, срабатывающее при обновлении списка групп
        public event EventHandler GroupsUpdated;

        // Список групп, связанный с интерфейсом
        public ObservableCollection<Group> Groups { get; set; }

        // Список предметов, связанный с интерфейсом
        public ObservableCollection<Subject> Subjects { get; set; }

        // Список студентов, связанный с интерфейсом
        public ObservableCollection<Student> Students { get; set; }

        // Команда обновления данных (пока не используется)
        public ICommand RefreshCommand { get; }

        // Команда добавления группы
        public ICommand AddGroupCommand { get; }

        // Команда добавления предмета к группе
        public ICommand AddSubjectCommand { get; }

        // Команда удаления группы
        public ICommand DeleteGroupCommand { get; }

        // Создаваемая группа для добавления
        public Group CreateGroup { get; set; }

        // Выбранный предмет для добавления к группе
        public Subject SelectedSubject { get; set; }

        // Выбранная группа, с которой взаимодействует пользователь
        public Group SelectedGroup { get; set; }

        // Событие, срабатывающее при изменении значения свойства
        public event PropertyChangedEventHandler PropertyChanged;

        // Метод для загрузки списка групп из базы данных
        public async Task LoadGroups()
        {
            // Загрузка групп из базы данных, включая связанные предметы и студентов
            Groups = new ObservableCollection<Group>(
                await DataBaseContext.Groups.Include(g => g.Subjects).Include(g => g.Students).ToListAsync());

            // Для каждой загруженной группы загружаем её предметы и студентов
            foreach (var group in Groups)
            {
                group.Subjects = new ObservableCollection<Subject>(
                    await DataBaseContext.Subjects.Where(s => s.Groups.Any(g => g.Id == group.Id)).ToListAsync());

                group.Students = await DataBaseContext.Students.Where(s => s.GroupId == group.Id).ToListAsync();
            }

            // Вызов события об изменении списка групп
            OnPropertyChanged(nameof(Groups));
        }

        // Метод для загрузки списка предметов из базы данных
        public async Task LoadSubjects()
        {
            // Загрузка предметов из базы данных
            Subjects = new ObservableCollection<Subject>(await DataBaseContext.Subjects.ToListAsync());

            // Вызов события об изменении списка предметов
            OnPropertyChanged(nameof(Subjects));
        }

        // Метод для загрузки списка студентов из базы данных
        public async Task LoadStudents()
        {
            // Загрузка студентов из базы данных
            Students = new ObservableCollection<Student>(await DataBaseContext.Students.ToListAsync());

            // Вызов события об изменении списка студентов
            OnPropertyChanged(nameof(Students));
        }

        // Метод для добавления новой группы
        private async void AddGroup(object parameter)
        {
            // Создание новой группы с заданным именем
            var newGroup = new Group { Name = CreateGroup.Name, Subjects = new ObservableCollection<Subject>() };

            // Добавление новой группы в контекст базы данных
            DataBaseContext.Groups.Add(newGroup);

            // Сохранение изменений в базе данных
            await DataBaseContext.SaveChangesAsync();

            // Добавление новой группы в список групп, отображаемый в интерфейсе
            Groups.Add(newGroup);

            // Очистка поля ввода для новой группы
            CreateGroup.Name = string.Empty;
            OnPropertyChanged(nameof(CreateGroup));

            // Вызов события об изменении списка групп
            GroupsUpdated?.Invoke(this, EventArgs.Empty);
        }

        // Метод для добавления предмета к выбранной группе
        private async void AssignSubject(object parameter)
        {
            // Проверка наличия выбранной группы и выбранного предмета
            if (SelectedGroup != null && SelectedSubject != null)
            {
                // Добавление выбранного предмета к выбранной группе
                SelectedGroup.Subjects.Add(SelectedSubject);

                // Сохранение изменений в базе данных
                await DataBaseContext.SaveChangesAsync();

                // Повторная загрузка списка групп (для обновления данных в интерфейсе)
                await LoadGroups();
            }
        }

        // Метод для удаления выбранной группы
        private async void DeleteGroup(object parameter)
        {
            // Получение ID группы для удаления
            int groupId = (int)parameter;

            // Поиск группы в контексте базы данных по ID
            var group = DataBaseContext.Groups.FirstOrDefault(g => g.Id == groupId);

            // Проверка, найдена ли группа
            if (group != null)
            {
                // Удаление группы из контекста базы данных
                DataBaseContext.Groups.Remove(group);

                // Сохранение изменений в базе данных
                await DataBaseContext.SaveChangesAsync();

                // Удаление группы из списка групп, отображаемого в интерфейсе
                Groups.Remove(group);

                // Вызов события об изменении списка групп
                GroupsUpdated?.Invoke(this, EventArgs.Empty);
            }
        }

        // Метод для вызова события об изменении свойства
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
