using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessBrand
    {
        public List<Brand> listar() 
        {
            List<Brand> brandList = new List<Brand>();
            DataAccess data = new DataAccess();
            try
            {
                data.setQuery("select Id, Descripcion from MARCAS");
                data.executeRead();
                while (data.Reader.Read())
                {
                    Brand auxBrand = new Brand();
                    auxBrand.Id = (int)data.Reader["Id"];
                    auxBrand.Description = (string)data.Reader["Descripcion"];
                    
                    brandList.Add(auxBrand);
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

            return brandList;
        }
    }
}
