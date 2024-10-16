using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Lab2IndividualTask
{
    public class PhoneDirectoryViewModel : INotifyPropertyChanged
    {
        private static PhoneDirectoryViewModel _instance;
        private static readonly object _lock = new object();
        public static PhoneDirectoryViewModel Instance
        {
            get
            {
                // Используем блокировку для многопоточной безопасности
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PhoneDirectoryViewModel();
                    }
                    return _instance;
                }
            }
        }
        public ObservableCollection<Room> PhoneDirectory { get; set; }
        public ICommand AddRoomCommand { get; }

        private string _newPhoneNumber;
        public string NewPhoneNumber
        {
            get => _newPhoneNumber;
            set
            {
                _newPhoneNumber = value;
                OnPropertyChanged(nameof(NewPhoneNumber));
            }
        }

        private string _newRoomNumber;
        public string NewRoomNumber
        {
            get => _newRoomNumber;
            set
            {
                _newRoomNumber = value;
                OnPropertyChanged(nameof(NewRoomNumber));
            }
        }

        private string _newEmployees;
        public string NewEmployees
        {
            get => _newEmployees;
            set
            {
                _newEmployees = value;
                OnPropertyChanged(nameof(NewEmployees));
            }
        }

        public PhoneDirectoryViewModel()
        {
            PhoneDirectory = new ObservableCollection<Room>
        {
            new Room { PhoneNumber = 12, RoomNumber = 101, Employees = new List<Employee> { new Employee { Name = "Иванов" }, new Employee { Name = "Петров" } } },
            new Room { PhoneNumber = 34, RoomNumber = 102, Employees = new List<Employee> { new Employee { Name = "Сидоров" } } }
        };

            AddRoomCommand = new Command(AddRoom);
        }

        private  void AddRoom()
        {
            // Разделяем строку сотрудников
            var employeesList = NewEmployees.Split(',')
                .Select(name => new Employee { Name = name.Trim() })
                .ToList();

            // Проверяем, что количество сотрудников не превышает 4
            if (employeesList.Count > 4)
            {
                // Выдаем предупреждение, что максимум 4 сотрудника
                App.Current.MainPage.DisplayAlert("Ошибка", "Максимум 4 сотрудника могут быть в одной комнате.", "OK");
                return;
            }

            var newRoom = new Room
            {
                PhoneNumber = int.Parse(NewPhoneNumber),
                RoomNumber = int.Parse(NewRoomNumber),
                Employees = NewEmployees.Split(',').Select(name => new Employee { Name = name.Trim() }).ToList()
            };

            PhoneDirectory.Add(newRoom);
            ClearFields();
        }

        private void ClearFields()
        {
            NewPhoneNumber = string.Empty;
            NewRoomNumber = string.Empty;
            NewEmployees = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
