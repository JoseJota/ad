using System;
using System.Data;

using Serpis.Ad;
using CArticulo;

namespace CArticulo
{
    public partial class ArticuloWindow : Gtk.Window
	{
		public ArticuloWindow(Articulo articulo) : base(Gtk.WindowType.Toplevel)
        {
			this.Build();
			entryNombre.Text = articulo.Nombre;
            spinbutton1.Value = (double)articulo.Precio;
            combobox1.

			saveAction.Activated += delegate {
				articulo.Nombre = entryNombre.Text;
				ArticuloDao.Save(articulo);
				Destroy();
			};
		}

        protected void OnCombobox1Changed(object sender, EventArgs e)
        {
        }
    }
}