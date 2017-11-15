using Gtk;
using System;
using System.Data;
using MySql.Data.MySqlClient;
using Serpis.Ad;
using CArticulo;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
		Build();
		Title = "Articulo";
		deleteAction.Sensitive = false;
		editAction.Sensitive = false;

		App.Instance.Connection = new MySqlConnection("server=localhost;database=dbprueba;user=root;password=sistemas");
		App.Instance.Connection.Open();

        TreeViewHelper.Fill(treeView, ArticuloDao.SelectAll);

		//treeView.AppendColumn("id", new CellRendererText(), "text", 0);
		//treeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
		ListStore listStore = new ListStore(typeof(string), typeof(string));
		treeView.Model = listStore;

		fillListStore(listStore);

		treeView.Selection.Changed += delegate {
			bool hasSelected = treeView.Selection.CountSelectedRows() > 0;
			deleteAction.Sensitive = hasSelected;
			editAction.Sensitive = hasSelected;

			//if (treeView.Selection.CountSelectedRows() > 0)
			//    deleteAction.Sensitive = true;
			//else
			//deleteAction.Sensitive = false;
		};

		newAction.Activated += delegate {
			Articulo articulo = new Articulo();
			new ArticuloWindow(articulo);
		};

		editAction.Activated += delegate {
			object id = TreeViewHelper.GetId(treeView);
			Articulo articulo = ArticuloDao.Load(id);
			new ArticuloWindow(articulo);
		};

		refreshAction.Activated += delegate {
            TreeViewHelper.Fill(treeView, ArticuloDao.SelectAll);
		};

		deleteAction.Activated += delegate {
			if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?"))
			{
				object id = TreeViewHelper.GetId(treeView);
				ArticuloDao.Delete(id);
			}


		};
	}

	//private object getId()
	//{
	//  TreeIter treeIter;
	//  treeView.Selection.GetSelected(out treeIter);
	//  return treeView.Model.GetValue(treeIter, 0);
	//}

	private void fillListStore(ListStore listStore)
	{
		listStore.Clear();
		IDbCommand dbCommnand = App.Instance.Connection.CreateCommand();
		dbCommnand.CommandText = "select * from articulo order by id";
		IDataReader dataReader = dbCommnand.ExecuteReader();
		while (dataReader.Read())
			listStore.AppendValues(dataReader["id"].ToString(), dataReader["nombre"]);
		dataReader.Close();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		App.Instance.Connection.Close();

		Application.Quit();
		a.RetVal = true;
	}
}