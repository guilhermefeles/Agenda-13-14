using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
	public HospedagemContratada(Hospedagem h)
	{
		InitializeComponent();
		lbl_quarto.Text = h.QuartoSelecionado.Descricao;
		lbl_hospedes.Text = $"{h.QtdAdultos} adulto(s), {h.QtdCriancas} criança(s)";
		lbl_periodo.Text = $"{h.DataCheckIn:dd/MM/yyyy} a {h.DataCheckOut:dd/MM/yyyy} ({h.Estadia} diária(s))";
		lbl_total.Text = h.ValorTotal.ToString("C");
	}

	private async void OnVoltarClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}
