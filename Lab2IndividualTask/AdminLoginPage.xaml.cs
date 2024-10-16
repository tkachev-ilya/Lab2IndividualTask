namespace Lab2IndividualTask;

public partial class AdminLoginPage : ContentPage
{
    private const string AdminUsername = "1";
    private const string AdminPassword = "1";

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
            await DisplayAlert("������", "�������� ��� ������������ ��� ������", "OK");
        }
    }
}
