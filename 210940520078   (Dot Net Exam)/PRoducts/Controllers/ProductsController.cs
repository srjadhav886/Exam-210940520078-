using Products.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> list = new List<Product>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=User;Integrated Security=True;Connect Timeout=30;";
            cn.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "INDEXVIEW";

            try
            {
                SqlDataReader datareader = cm.ExecuteReader();

                while (datareader.Read())
                {
                    list.Add(new Product
                    {
                        ProductId = (int)datareader["ProductId"],
                        ProductName = (string)datareader["ProductName"],
                        Rate = (decimal)datareader["Rate"],
                        Description = (string)datareader["Description"],
                        CategoryName = (string)datareader["CategoryName"]
                    });

                }
                datareader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            cn.Close();
            
            return View(list);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pr)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=User;Integrated Security=True;Connect Timeout=30;";
            cn.Open();
            SqlCommand cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandType = System.Data.CommandType.Text;
            cm.CommandText = "EditView";
            cm.Parameters.AddWithValue("@ProductId", id);




            try
            {
                // TODO: Add update logic here
                SqlDataReader datareader = cm.ExecuteReader();
                while (datareader.Read())
                {
                   pr= new Product
                    {
                        ProductId = (int)datareader["ProductId"],
                        ProductName = (string)datareader["ProductName"],
                        Rate = (decimal)datareader["Rate"],
                        Description = (string)datareader["Description"],
                        CategoryName = (string)datareader["CategoryName"]
                    };

                }
                datareader.Close();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
