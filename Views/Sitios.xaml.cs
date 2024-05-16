using dquicaliquinS6T1.Views;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace dquicaliquinS6T1;

public partial class Sitios : ContentPage
{
    private const string Url = "http://localhost/TareaSem6/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Sitio> sit;

    public Sitios()
	{
		InitializeComponent();
        Obtener();
	}

    public async void Obtener()
    {
        var content = await cliente.GetStringAsync(Url);
        List<Sitio> mostrarsit = JsonConvert.DeserializeObject<List<Sitio>>(content);
        sit = new ObservableCollection<Sitio>(mostrarsit);
        listaSitios.ItemsSource = sit;
    }

    private void listaSitios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objsitios = (Sitio)e.SelectedItem;
        Navigation.PushAsync(new vActualizar_Eliminar(objsitios));
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vAgregar());
    }
}


