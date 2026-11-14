namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	public ContratacaoHospedagem()
	{
		InitializeComponent();

		pck_quarto.ItemsSource = new List<string>
		{
			"Suíte Standard",
			"Suíte Luxo",
			"Suíte Master",
		};
	}

	private async void OnSobreClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Sobre());
	}
}