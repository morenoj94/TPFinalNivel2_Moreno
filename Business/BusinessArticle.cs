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
        public List<Article> filter(string elemento, string tipo, string filtro)
        {
            List<Article> articleList = new List<Article>();
            string condicion, consulta;
            try
            {
                switch (elemento)
                {
                    case "Precio":
                        switch (tipo)
                        {
                            case "Mayor que":
                                condicion = $"Precio > {filtro}";
                                break;
                            case "Menor que":
                                condicion = $"Precio < {filtro}";
                                break;
                            default:
                                condicion = $"Precio = {filtro}";
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (tipo)
                        {
                            case "Que inicie con":
                                condicion = $"Nombre like '{filtro}%'";
                                break;
                            case "Que termine con":
                                condicion = $"Nombre like '%{filtro}'";
                                break;
                            default:
                                condicion = $"Nombre like '%{filtro}%'";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (tipo)
                        {
                            case "Que inicie con":
                                condicion = $"M.Descripcion like '{filtro}%'";
                                break;
                            case "Que termine con":
                                condicion = $"M.Descripcion like '%{filtro}'";
                                break;
                            default:
                                condicion = $"M.Descripcion like '%{filtro}%'";
                                break;
                        }
                        break;
                    default:
                        switch (tipo)
                        {
                            case "Que inicie con":
                                condicion = $"C.Descripcion like '{filtro}%'";
                                break;
                            case "Que termine con":
                                condicion = $"C.Descripcion like '%{filtro}'";
                                break;
                            default:
                                condicion = $"C.Descripcion like '%{filtro}%'";
                                break;
                        }
                        break;                        
                }
                consulta = $"select A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion As Marca, C.Descripcion as Categoria, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria and {condicion}";
                articleList = mappingArticle(consulta);

            }
            catch (Exception)
            {

                throw;
            }

            return articleList;
        }

        public List<Article> listar() 
        {
            List<Article> articleList;
            articleList = mappingArticle("select A.Id as id, Codigo, Nombre, A.Descripcion as Descripcion, M.Descripcion As Marca, C.Descripcion as Categoria, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria");

            return articleList;
        }
        public List<Article> mappingArticle(string consulta) 
        {
            List<Article> articleList = new List<Article>();
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery(consulta);
                data.executeRead();
                while (data.Reader.Read())
                {
                    Article articleAux = new Article();
                    articleAux.Id = (int)data.Reader["id"];
                    articleAux.Code = (string)data.Reader["Codigo"];
                    articleAux.Name = (string)data.Reader["Nombre"];
                    articleAux.Desciption = (string)data.Reader["Descripcion"];
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
