using System.Net;

namespace dquicaliquinS6T1.Views;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient sitio = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            //parametros.Add("IdSitio", txtIdSitio.Text);
            parametros.Add("IdUbicacion", txtIdUbicacion.Text);
            parametros.Add("NombreSitio", txtNombreSitio.Text);
            parametros.Add("DescripcionSitio", txtDescripcionSitio.Text);
            parametros.Add("ReferenciaSitio", txtReferenciaSitio.Text);
            parametros.Add("LongitudSitio", txtLongitudSitio.Text);
            parametros.Add("LatitudSitio", txtLatitudSitio.Text);
            parametros.Add("CiudadSitio", txtCiudadSitio.Text);
            parametros.Add("ProvinciaSitio", txtProvinciaSitio.Text);
            sitio.UploadValues("http://localhost/TareaSem6/post.php", "POST", parametros);
            DisplayAlert("Éxito", "El sitio se ha agregado correctamente", "Aceptar");
            Navigation.PushAsync(new Sitios());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Ocurrió un error al agregar el sitio: {ex.Message}", "Cerrar");
        }
    }
}


