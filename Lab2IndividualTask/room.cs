
namespace Lab2IndividualTask
{
    public class Room
    {
        public int PhoneNumber { get; set; }
        public int RoomNumber { get; set; }
        public List<Employee> Employees { get; set; }

        // Вычисляемое свойство для отображения сотрудников в виде строки
        public string EmployeesString
        {
            get
            {
                return Employees != null && Employees.Count > 0
                    ? string.Join(", ", Employees.Select(e => e.Name))
                    : "Нет сотрудников";
            }
        }
    }

    public class Employee
    {
        public string Name { get; set; }
    }

}
