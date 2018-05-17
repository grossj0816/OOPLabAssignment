using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OOPLab2.Models;

namespace OOPLab2.Controllers
{
    public class HomeController : Controller
    {
        NewProducts products = null;
        Errors errors = new Errors();


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //grabs all records of products in db
        public ActionResult ProductList(string btnSelect)
        {
            List<NewProducts> productsList = null;
            products = new NewProducts(new SelectProducts());
            productsList = products.PerformReadOperation();
            ViewBag.Products = productsList;


            return View();
        }

        //form to add products
        public ActionResult AddProductForm(string name, string catid, string supid, string price)
        {
            ViewBag.Name = name;
            ViewBag.CatID = catid;
            ViewBag.SupID = supid;
            ViewBag.Price = price;


            return View();
        }

        //validating 
        public ActionResult AddProduct(string name, string catid, string supid, string price)
        {

            CheckProductValues check = null;

            if (name == "" || catid == "" || supid == "" || price == "")
            {
                AddProductForm(name, catid, supid, price);
                string readErrors = check.Save();
                ViewBag.ReadErrors = readErrors;
                return View("AddProductForm");
            }
            else
            {

                if (name.Length > 20 || catid.Length > 4 || supid.Length > 4 || price.Length > 4)
                {
                    check = new CheckProductValues(name, catid, supid, price);
                    AddProductForm(name, catid, supid, price);
                    string readErrors = check.Save();
                    ViewBag.ReadErrors = readErrors;
                    errors.ReadErrors(check.Save());
                    return View("AddProductForm");
                }
                else
                {
                    products = new NewProducts(new InsertProducts());
                    products.PerformInsertOperation(name, catid, supid, price);
                    check = new CheckProductValues(name, catid, supid, price);
                    errors.ReadErrors(check.Save());
                    return RedirectToAction("ProductList");
                }

            }

        }



        //executing query and redirecting back to view
        public ActionResult DeleteProduct(int idDelete)
        {
            products = new NewProducts(new DeleteProducts());
            products.PerformDeleteOperation(idDelete);

            return RedirectToAction("ProductList");

        }



        //form to update products
        public ActionResult UpdateProductForm(int idUpdate)
        {
            List<NewProducts> selectedProduct = null;
            products = new NewProducts(new SelectProductByID());
            selectedProduct = products.PerformSelectOperation(idUpdate);
            ViewBag.SelectedItem = selectedProduct;
            return View();
        }

        //executing query and redirecting back to view
        public ActionResult UpdateProduct(int id, string name, string catid, string supid, string price)
        {
            CheckProductValues check = null;

            if (name.Length > 20 || catid.Length > 4 || supid.Length > 4 || price.Length > 4)
           {
                check = new CheckProductValues(name, catid, supid, price);
                string readErrors = check.Save();
                ViewBag.ReadErrors = readErrors;
                errors.ReadErrors(check.Save());
                return View("Errors");
            }
           else
           {
                products = new NewProducts(new UpdateProducts());
                products.PerformUpdateOperation(id, name, catid, supid, price);
                check = new CheckProductValues(name, catid, supid, price);
                errors.ReadErrors(check.Save());
                return RedirectToAction("ProductList");
           }
        }
    }
}