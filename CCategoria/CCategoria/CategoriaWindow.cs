using System;
using System.Data;
using Serpis.Ad;

namespace CCategoria
{
    public partial class CategoriaWindow : Gtk.Window
    {
		object id;

		public CategoriaWindow(object id) : base(Gtk.WindowType.Toplevel)
        {

            this.Build();

            this.id = id;
            Categoria categoria = CategoriaDao.Load(id);
            entryNombre.Text = categoria.Nombre;

            saveAction.Activated += delegate
            {
                update();
                Destroy();
            };
        }
        public CategoriaWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();

            saveAction.Activated += delegate
            {
                if (id == null)
                    insert();
                else
                    update();
                Destroy();
            };
        }

        private void insert()
        {
            string nombre = entryNombre.Text;
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
            DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
            dbCommand.ExecuteNonQuery();
        }
        private void update()
        {
            string nombre = entryNombre.Text;
            IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
            dbCommand.CommandText = "update categoria set nombre=@nombre where id = @id)";
            DbCommandHelper.AddParameter(dbCommand, "id", id);
            DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);

            dbCommand.ExecuteNonQuery();
        }
    }
}
