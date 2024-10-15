using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2IndividualTask
{
    public class PhoneDirectoryService
    {
        private static PhoneDirectoryService _instance;
        private static readonly object _lock = new object();

        // Пример базы данных
        public List<Room> PhoneDirectory { get; private set; }

        private PhoneDirectoryService()
        {
            // Инициализация данных
            PhoneDirectory = new List<Room>
        {
            new Room { PhoneNumber = 12, RoomNumber = 101, Employees = new List<Employee> { new Employee { Name = "Иванов" }, new Employee { Name = "Петров" } } },
            new Room { PhoneNumber = 34, RoomNumber = 102, Employees = new List<Employee> { new Employee { Name = "Сидоров" } } },
            new Room { PhoneNumber = 56, RoomNumber = 103, Employees = new List<Employee> { new Employee { Name = "Кузнецов" }, new Employee { Name = "Смирнов" } } }
        };
        }

        public static PhoneDirectoryService Instance
        {
            get
            {
                // Используем блокировку для многопоточной безопасности
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PhoneDirectoryService();
                    }
                    return _instance;
                }
            }
        }

        // Метод для добавления или обновления записи
        public void AddOrUpdateRoom(Room newRoom)
        {
            var existingRoom = PhoneDirectory.FirstOrDefault(r => r.PhoneNumber == newRoom.PhoneNumber);
            if (existingRoom != null)
            {
                // Обновляем существующую запись
                existingRoom.RoomNumber = newRoom.RoomNumber;
                existingRoom.Employees = newRoom.Employees;
            }
            else
            {
                // Добавляем новую запись
                PhoneDirectory.Add(newRoom);
            }
        }
    }

}
