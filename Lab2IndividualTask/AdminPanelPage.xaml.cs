namespace Lab2IndividualTask;

public partial class AdminPanelPage : ContentPage
{
    public AdminPanelPage()
    {
        InitializeComponent();
    }

    private void OnAddOrUpdateRecordClicked(object sender, EventArgs e)
    {
        int phoneNumber, roomNumber;
        if (int.TryParse(PhoneEntry.Text, out phoneNumber) && int.TryParse(RoomEntry.Text, out roomNumber))
        {
            var employees = EmployeesEntry.Text?.Split(',').Select(name => new Employee { Name = name.Trim() }).ToList();
            var existingRoom = PhoneDirectoryService.Instance.PhoneDirectory.FirstOrDefault(r => r.PhoneNumber == phoneNumber);
            if (existingRoom != null)
            {
                existingRoom.RoomNumber = roomNumber;
                existingRoom.Employees = employees;
            }
            else
            {
                PhoneDirectoryService.Instance.PhoneDirectory.Add(new Room { PhoneNumber = phoneNumber, RoomNumber = roomNumber, Employees = employees });
            }

            DisplayAlert("Успех", "Запись добавлена или обновлена", "OK");
        }
        else
        {
            DisplayAlert("Ошибка", "Введите корректные данные", "OK");
        }
    }

    private async void ReturnToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}