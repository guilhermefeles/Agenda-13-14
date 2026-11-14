using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	List<Quarto> quartos = new()
	{
		new Quarto { Descricao = "Suíte Standard", ValorDiariaAdulto = 100, ValorDiariaCrianca = 50 },
		new Quarto { Descricao = "Suíte Luxo", ValorDiariaAdulto = 180, ValorDiariaCrianca = 90 },
		new Quarto { Descricao = "Suíte Master", ValorDiariaAdulto = 300, ValorDiariaCrianca = 150 },
	};

	public ContratacaoHospedagem()
	{
		InitializeComponent();

		pck_quarto.ItemsSource = quartos;

		DateTime hoje = DateTime.Today;
		dtpck_checkin.MinimumDate = hoje;
		dtpck_checkin.MaximumDate = hoje.AddYears(1);
		dtpck_checkout.MinimumDate = hoje.AddDays(1);
		dtpck_checkout.MaximumDate = hoje.AddYears(1).AddDays(1);
		dtpck_checkout.Date = hoje.AddDays(1);
	}

	// Check-out nunca pode ser antes (ou igual) ao check-in
	private void OnCheckInChanged(object sender, DateChangedEventArgs e)
	{
		DateTime min = e.NewDate.AddDays(1);
		dtpck_checkout.MinimumDate = min;
		dtpck_checkout.MaximumDate = e.NewDate.AddYears(1);
		if (dtpck_checkout.Date < min)
			dtpck_checkout.Date = min;
	}

	private async void OnAvancarClicked(object sender, EventArgs e)
	{
		if (pck_quarto.SelectedItem is not Quarto quarto)
		{
			await DisplayAlert("Atenção", "Selecione uma suíte.", "OK");
			return;
		}
		if (stp_adultos.Value + stp_criancas.Value == 0)
		{
			await DisplayAlert("Atenção", "Informe ao menos um hóspede.", "OK");
			return;
		}

		var h = new Hospedagem
		{
			QuartoSelecionado = quarto,
			QtdAdultos = (int)stp_adultos.Value,
			QtdCriancas = (int)stp_criancas.Value,
			DataCheckIn = dtpck_checkin.Date,
			DataCheckOut = dtpck_checkout.Date,
		};
		await Navigation.PushAsync(new HospedagemContratada(h));
	}

	private async void OnSobreClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Sobre());
	}
}
