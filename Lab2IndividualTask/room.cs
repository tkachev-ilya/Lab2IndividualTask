using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2IndividualTask
{
    public class Employee
    {
        public string Name { get; set; }
    }

    public class Room
    {
        public int PhoneNumber { get; set; } // Двузначный номер телефона
        public int RoomNumber { get; set; }
        public List<Employee> Employees { get; set; } // Список служащих
    }

}
