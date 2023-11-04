using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Business
{
    public class DataAccess
    {        
        private SqlConnection conection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader 
        {
            get { return reader; }
        }
        public DataAccess()
        {
            //se instancia la coneccion y el comando 
            conection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            command = new SqlCommand();
        }
        public void setQuery(string query)
        {
            // se declara el tipo de comando y se establece que sera la consulta que recibimos por parametro
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }
        public void executeRead()
        {
            // se asocia la coneccion a la base de datos con el comando
            command.Connection = conection;
            // en un bloque try catch se abre la coneccion y se ejecuta la lectura guardandola dentro del reader
            try
            {
                conection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }        
        public void closeConnection() 
        {            
            if (reader != null) 
            {
                reader.Close();
            }            
            conection?.Close(); //el operador ? sirve para consultar si conection!=null es otra forma de escribir el if de arriba
        }

    }
}
