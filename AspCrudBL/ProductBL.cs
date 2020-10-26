using AspCrudBE;
using AspCrudDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCrudBL
{
    public class ProductBL
    {
        ProductDL productDL;

        public ProductBL()
        {
            this.productDL = new ProductDL();
        }

        public void Insertar(string pProductName,
                      decimal pPrice,
                      int pCount,
                      string pDescription)
        {
            this.productDL.Insertar(pProductName, pPrice, pCount, pDescription);
        }

        public void Modificar(int pProductId,
                            string pProductName,
                            decimal pPrice,
                            int pCount,
                            string pDescription)
        {
            this.productDL.Modificar(pProductId, pProductName, pPrice, pCount, pDescription);
        }
        
        public List<ProductBE> ProductViewAll()
        {
            List<ProductBE> res;
            try
            {
                res = this.productDL.ProductViewAll();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductBE> ProductViewById(int productId)
        {
            List<ProductBE> res;
            try
            {
                res = this.ProductViewById(productId);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
