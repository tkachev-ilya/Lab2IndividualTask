namespace Lab2IndividualTask;

public partial class AdminLoginPage : ContentPage
{
    private const string AdminUsername = "admin";
    private const string AdminPassword = "password";

    public AdminLoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (UsernameEntry.Text == AdminUsername && PasswordEntry.Text == AdminPassword)
        {
            await Navigation.PushAsync(new AdminPanelPage());
        }
        else
        {
            await DisplayAlert("Ошибка", "Неверное имя пользователя или пароль", "OK");
        }
    }
}
