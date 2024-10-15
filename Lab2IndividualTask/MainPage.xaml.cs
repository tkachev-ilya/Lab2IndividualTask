
namespace Lab2IndividualTask
{
    public partial class MainPage : ContentPage
    {
        // Здесь можно хранить базу данных номеров, помещений и сотрудников
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnPhoneSearchClicked(object sender, EventArgs e)
        {
            int phone;
            if (int.TryParse(PhoneEntry.Text, out phone))
            {
                var room = PhoneDirectoryService.Instance.PhoneDirectory.FirstOrDefault(r => r.PhoneNumber == phone);
                if (room != null)
                {
                    DisplayAlert("Результаты", $"Номер помещения: {room.RoomNumber}\nСлужащие: {string.Join(", ", room.Employees.Select(emp => emp.Name))}", "OK");
                }
                else
                {
                    DisplayAlert("Ошибка", "Номер телефона не найден", "OK");
                }
            }
            else
            {
                DisplayAlert("Ошибка", "Введите корректный номер телефона", "OK");
            }
        }

        private void OnRoomSearchClicked(object sender, EventArgs e)
        {
            int roomNumber;
            if (int.TryParse(RoomEntry.Text, out roomNumber))
            {
                var room = PhoneDirectoryService.Instance.PhoneDirectory.FirstOrDefault(r => r.RoomNumber == roomNumber);
                if (room != null)
                {
                    DisplayAlert("Результаты", $"Номер телефона: {room.PhoneNumber}\nСлужащие: {string.Join(", ", room.Employees.Select(emp => emp.Name))}", "OK");
                }
                else
                {
                    DisplayAlert("Ошибка", "Номер помещения не найден", "OK");
                }
            }
            else
            {
                DisplayAlert("Ошибка", "Введите корректный номер помещения", "OK");
            }
        }

        private void OnLastNameSearchClicked(object sender, EventArgs e)
        {
            var employeeName = LastNameEntry.Text;
            if (!string.IsNullOrEmpty(employeeName))
            {
                var room = PhoneDirectoryService.Instance.PhoneDirectory.FirstOrDefault(r => r.Employees.Any(emp => emp.Name.Equals(employeeName, StringComparison.OrdinalIgnoreCase)));
                if (room != null)
                {
                    DisplayAlert("Результаты", $"Номер телефона: {room.PhoneNumber}\nНомер помещения: {room.RoomNumber}", "OK");
                }
                else
                {
                    DisplayAlert("Ошибка", "Служащий не найден", "OK");
                }
            }
            else
            {
                DisplayAlert("Ошибка", "Введите фамилию", "OK");
            }
        }

        private async void OnAdminLoginClicked(object sender, EventArgs e)
        {
            // Переход на страницу входа администратора
            await Navigation.PushAsync(new AdminLoginPage());
        }
    }


}
