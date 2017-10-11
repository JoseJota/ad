using System;
using Gtk;
using System.Data;
using MySql.Data.MySqlClient;

using CCategoria;

public partial class MainWindow : Gtk.Window
{
    private IDbConnection connection;
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();




		connection = new MySqlConnection("server=localhost;database=dbprueba;user=root;password=sistemas");
        connection.Open();

        treeView.AppendColumn("id", new CellRendererText(), "text", 0);
        treeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
        ListStore listStore = new ListStore(typeof(String), typeof(string));
        treeView.Model = listStore;

        IDbCommand dbCommand = connection.CreateCommand();
        dbCommand.CommandText = "select * from categoria order by id";
        IDataReader dataReader = dbCommand.ExecuteReader();
        while (dataReader.Read())
            listStore.AppendValues(dataReader["id"], dataReader["nombre"]);
        dataReader.Close();

        newAction.Activated += delegate {
            Console.WriteLine("newAction delegate 1");
        };
		newAction.Activated += delegate {
			Console.WriteLine("newAction delegate 2");
		};
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        connection.Close();
        Application.Quit();
        a.RetVal = true;
    }
}
