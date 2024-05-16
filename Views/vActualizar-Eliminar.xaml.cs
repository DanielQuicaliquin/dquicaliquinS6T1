using System.Collections.Specialized;
using System.Net;

namespace dquicaliquinS6T1.Views;

public partial class vActualizar_Eliminar : ContentPage
{
	public vActualizar_Eliminar(Sitio datos)
	{
		InitializeComponent();
        txtIdSitio.Text = datos.IdSitio.ToString();
        txtIdUbicacion.Text = datos.IdUbicacion.ToString();
        txtNombreSitio.Text = datos.NombreSitio;
        txtDescripcionSitio.Text = datos.DescripcionSitio;
        txtReferenciaSitio.Text = datos.ReferenciaSitio;
        txtLongitudSitio.Text = datos.LongitudSitio.ToString();
        txtLatitudSitio.Text = datos.LatitudSitio.ToString();
        txtCiudadSitio.Text = datos.CiudadSitio;
        txtProvinciaSitio.Text = datos.CiudadSitio;
    }
    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var sitio = new WebClient();
            var parametros = new NameValueCollection();
            parametros.Add("IdSitio", txtIdSitio.Text);
            parametros.Add("IdUbicacion", txtIdUbicacion.Text);
            parametros.Add("NombreSitio", txtNombreSitio.Text);
            parametros.Add("DescripcionSitio", txtDescripcionSitio.Text);
            parametros.Add("ReferenciaSitio", txtReferenciaSitio.Text);
            parametros.Add("LongitudSitio", txtLongitudSitio.Text);
            parametros.Add("LatitudSitio", txtLatitudSitio.Text);
            parametros.Add("CiudadSitio", txtCiudadSitio.Text);
            parametros.Add("ProvinciaSitio", txtProvinciaSitio.Text);
            sitio.UploadValues("http://localhost/TareaSem6/post.php", "PUT", parametros);
            DisplayAlert("Éxito", "Los datos se han actualizado correctamente", "Aceptar");
            Navigation.PushAsync(new Sitios());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Ocurrió un error al actualizar los datos: {ex.Message}", "Cerrar");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var sitio = new WebClient();
            string url = $"http://localhost/TareaSem6/post.php?IdSitio={txtIdSitio.Text}";
            sitio.UploadDataTaskAsync(url, "DELETE", new byte[] { });
            DisplayAlert("Éxito", "El sitio se ha eliminado correctamente", "Aceptar");
            Navigation.PushAsync(new Sitios());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Ocurrió un error al eliminar el sitio: {ex.Message}", "Cerrar");
        }
    }
}