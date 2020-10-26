using AspCrudBE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCrudDL
{
    public class ProductDL : DataWorker
    {
        public void Insertar (string pProductName,
                              decimal pPrice,
                              int pCount,
                              string pDescription)
        {
            using (DbConnection connection = database.CreateOpenConnection())
            {
                using (DbCommand command = database.CreateStoredProcCommand("ProductAddOrEdit", connection))
                {
                    try
                    {
                        DbParameter param = database.CreateParameter("_productid", DbType.Int32, 0);
                        command.Parameters.Add(param);
                        param = database.CreateParameter("_product", DbType.String, pProductName);
                        command.Parameters.Add(param);
                        param = database.CreateParameter("_price", DbType.Decimal, pPrice);
                        command.Parameters.Add(param);
                        param = database.CreateParameter("_count", DbType.Int32, pCount);
                        command.Parameters.Add(param);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }
        public void Modificar(int pProductId,
                              string pProductName,
                              decimal pPrice,
                              int pCount,
                              string pDescription)
        {
            using (DbConnection connection = database.CreateOpenConnection())
            {
                using (DbCommand command = database.CreateStoredProcCommand("ProductAddOrEdit", connection))
                {
                    try
                    {
                        DbParameter param = database.CreateParameter("_productid", DbType.Int32, pProductId);
                        command.Parameters.Add(param);
                        param = database.CreateParameter("_product", DbType.String, pProductName);
                        command.Parameters.Add(param);
                        param = database.CreateParameter("_price", DbType.Decimal, pPrice);
                        command.Parameters.Add(param);
                        param = database.CreateParameter("_count", DbType.Int32, pCount);
                        command.Parameters.Add(param);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        public void Borrar(int pProductId,
                              string pProductName,
                              decimal pPrice,
                              int pCount,
                              string pDescription)
        {
            using (DbConnection connection = database.CreateOpenConnection())
            {
                using (DbCommand command = database.CreateStoredProcCommand("ProductDeleteByID", connection))
                {
                    try
                    {
                        DbParameter param = database.CreateParameter("_productid", DbType.Int32, pProductId);
                        command.Parameters.Add(param);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
            }
        }

        /*
        public List<ProductBE> ProductViewById(int productId)
        {
            List<ProductBE> res = new List<ProductBE>();
            string wsql = "SELECT * FROM Product where productid = " + productId.ToString();
            using (DbConnection connection = database.CreateOpenConnection())
            {
                using (DbCommand command = database.CreateStoredProcCommand("ProductAddOrEdit", connection))
                {
                    DbParameter param = database.CreateParameter("_productid", DbType.Int32, 10);
                    command.Parameters.Add(param);
                    param = database.CreateParameter("p2", DbType.Int32, 30);
                    command.Parameters.Add(param);
                    param = database.CreateParameter("p3", DbType.Int32, ParameterDirection.Output);
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["DES_PERFIL"]);
                            ProductBE pcBe = new ProductBE();
                            pcBe.ProductId = Convert.ToInt32(reader["PRODUCTID"]);
                            pcBe.ProductName = Convert.ToString(reader["PRODUCT"]);
                            pcBe.Price = Convert.ToDecimal(reader["PRICE"]);
                            pcBe.Count = Convert.ToInt32(reader["COUNT"]);
                            pcBe.Description = Convert.ToString(reader["COUNT"]);
                            res.Add(pcBe);
                        }
                    }
                }
            }
            return res;
        }
        */

        public List<ProductBE> ProductViewAll()
        {
            List<ProductBE> res = new List<ProductBE>();
            string wsql = "SELECT * FROM Product ";
            using (DbConnection connection = database.CreateOpenConnection())
            {
                using (DbCommand command = database.CreateCommand(wsql, connection))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductBE pcBe = new ProductBE();
                            pcBe.ProductId = Convert.ToInt32(reader["PRODUCTID"]);
                            pcBe.ProductName = Convert.ToString(reader["PRODUCT"]);
                            pcBe.Price = Convert.ToDecimal(reader["PRICE"]);
                            pcBe.Count = Convert.ToInt32(reader["COUNT"]);
                            pcBe.Description = Convert.ToString(reader["DESCRIPTION"]);
                            res.Add(pcBe);
                        }
                    }
                }
            }
            return res;
        }
        public List<ProductBE> ProductViewById(int productId)
        {
            List<ProductBE> res = new List<ProductBE>();
            string wsql = "SELECT * FROM Product where productid = " + productId.ToString();
            using (DbConnection connection = database.CreateOpenConnection())
            {
                using (DbCommand command = database.CreateCommand(wsql, connection))
                {
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["DES_PERFIL"]);
                            ProductBE pcBe = new ProductBE();
                            pcBe.ProductId = Convert.ToInt32(reader["PRODUCTID"]);
                            pcBe.ProductName = Convert.ToString(reader["PRODUCT"]);
                            pcBe.Price = Convert.ToDecimal(reader["PRICE"]);
                            pcBe.Count = Convert.ToInt32(reader["COUNT"]);
                            pcBe.Description = Convert.ToString(reader["DESCRIPTION"]);
                            res.Add(pcBe);
                        }
                    }
                }
            }
            return res;
        }
    }
}
