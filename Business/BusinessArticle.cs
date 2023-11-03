using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;

namespace Business
{
    public class BusinessArticle
    {
        public List<Article> listar() 
        {
            List<Article> articleList = new List<Article>();
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("select A.Id as id, Codigo, Nombre, A.Descripcion, M.Descripcion As Marca, C.Descripcion as Categoria, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria");
                data.executeRead();
                while (data.Reader.Read())
                {
                    Article articleAux = new Article();
                    articleAux.Id = (int)data.Reader["id"];
                    articleAux.Code = (string)data.Reader["Codigo"];
                    articleAux.Name = (string)data.Reader["Nombre"];
                    articleAux.articleBrand = new Brand();
                    articleAux.articleBrand.Description = (string)data.Reader["Marca"];
                    articleAux.articleCategory = new Category();
                    articleAux.articleCategory.Description = (string)data.Reader["Categoria"];
                    articleAux.Price = (decimal)data.Reader["Precio"];

                    articleList.Add(articleAux);

                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                data.closeConnection();
            }
                        

            return articleList;
        }

    }
}
