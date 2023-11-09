using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessCategory
    {
        public void addCategory(string newCategory)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery($"insert into CATEGORIAS(Descripcion) values ('{newCategory}')");
                data.executeAction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public List<Category> listar() 
        {
            List<Category> categoryList = new List<Category>();
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("select Id, Descripcion from CATEGORIAS");
                data.executeRead();
                while (data.Reader.Read())
                {
                    Category auxCategory = new Category();
                    auxCategory.Id = (int)data.Reader["Id"];
                    auxCategory.Description = (string)data.Reader["Descripcion"];

                    categoryList.Add(auxCategory);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                data.closeConnection();
            }

            return categoryList;
        }
    }
}
