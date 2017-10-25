using System;
using System.Data;
using Serpis.Ad;
namespace CCategoria
{
    public class CategoriaDao
    {
        public Categoria Load(object id) {
			IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
			dbCommand.CommandText = "select * from categoria where id = @id";

			DbCommandHelper.AddParameter(dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader();
			dataReader.Read();
			string nombre = (string)dataReader["nombre"];
			dataReader.Close();

			Categoria categoria = new Categoria();
            categoria.Id = Convert.ToInt64(id);
            categoria.Nombre = "el que lea";
            return categoria;
        }

        public static void Save(Categoria categoria) {
            if (categoria.Id == 0)
                ; //insert
            else
                ; //update
        }

   //     public static void Delete(object id) {
			//if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?"))
			//{
			//	object id = getId();
			//	IDbCommand dbCommand = App.Instance.Connection.CreateCommand();
			//	dbCommand.CommandText = "delete from categoria where id = @id";
			//	DbCommandHelper.AddParameter(dbCommand, "id", id);
			//	dbCommand.ExecuteNonQuery();
			//}
        //}
    }
}
