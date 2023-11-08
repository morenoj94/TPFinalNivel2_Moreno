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
            List<Article> articleList;
            articleList = mappingArticle("select A.Id as id, Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl, M.Descripcion As Marca, C.Descripcion as Categoria, Precio, M.Id as MId, C.Id as CId from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria");

            return articleList;
        }

        public void addArticle(Article article)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery($"insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values ('{article.Code}', '{article.Name}', '{article.Desciption}', {article.articleBrand.Id}, {article.articleCategory.Id}, '{article.imageUrl}', {article.Price})");
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

        public void modifyArticle(Article article)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("update ARTICULOS set Codigo = @Code, Nombre = @Name, Descripcion = @Description, IdMarca = @IdBrand, IdCategoria = @IdCategory, ImagenUrl = @ImageUrl, Precio = @Price where Id = @Id");
                data.setParameters("@Code", article.Code);
                data.setParameters("@Name", article.Name);
                data.setParameters("@Description", article.Desciption);
                data.setParameters("@IdBrand", article.articleBrand.Id);
                data.setParameters("@IdCategory", article.articleCategory.Id);
                data.setParameters("@ImageUrl", article.imageUrl);
                data.setParameters("@Price", article.Price);
                data.setParameters("@Id", article.Id);

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

        public void eliminar(Article seleted)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery($"delete from ARTICULOS where id = {seleted.Id}");
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
                consulta = $"select A.Id as id, Codigo, Nombre, A.Descripcion as Descripcion, ImagenUrl, M.Descripcion As Marca, C.Descripcion as Categoria, Precio, M.Id as MId, C.Id as CId from ARTICULOS A, MARCAS M, CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria and {condicion}";
                articleList = mappingArticle(consulta);

            }
            catch (Exception)
            {

                throw;
            }

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
                    articleAux.imageUrl = (string)data.Reader["ImagenUrl"];
                    articleAux.articleBrand = new Brand();
                    articleAux.articleBrand.Id = (int)data.Reader["MId"];
                    articleAux.articleBrand.Description = (string)data.Reader["Marca"];
                    articleAux.articleCategory = new Category();
                    articleAux.articleCategory.Id = (int)data.Reader["CId"];
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
