using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Linq.Dynamic;
using System.Data;

namespace WebApplication1.Controllers
{
    public class SqlController : Controller
    {
        // GET: Sql
        public ActionResult Index()
        {
            return View();
        }

        // GET: WebGrid?page=1&rowsPerPage=3&sort=OrderID&sortDir=ASC
        public ActionResult WebGrid(int page = 1, int rowsPerPage = 10, string sortCol = "ProductID", string sortDir = "ASC")
        {
            List<MyModel> res;
            int count;
            string sql;
            string[] tabCol = new string[] { "PRODUCTID", "PRODUCTNAME", "UNITPRICE", "UNITSINSTOCK", "UNITSONORDER", "CATEGORYNAME", "COMPANYNAME", "COMPANYNAME", "CONTACTNAME", "COUNTRY" };
            if (tabCol.Contains(sortCol.ToUpper()))
            {

            }
            else
            {
                sortCol = "ProductID";
            }

            string[] tabDir = new string[] { "ASC", "DESC" };
            if (tabDir.Contains(sortDir.ToUpper()))
            {

            }
            else
            {
                sortDir = "ASC";
            }
            using (var nwd = new NorthwindEntities())
            {
                var _res = nwd.Products
                    .Select(o => new MyModel
                    {
                        ProductID = o.ProductID,
                        ProductName = o.ProductName,
                        UnitPrice = o.UnitPrice,
                        UnitsInStock = o.UnitsInStock,
                        UnitsOnOrder = o.UnitsOnOrder,
                        CategoryName = o.Category.CategoryName,
                        CompanyName = o.Supplier.CompanyName,
                        ContactName = o.Supplier.ContactName,
                        Country = o.Supplier.Country,
                    })
                    .OrderBy(sortCol + " " + sortDir+ ", ProductID " + sortDir )
                    .Skip((page - 1) * rowsPerPage)
                    .Take(rowsPerPage);

                sql = _res.ToString();
                res = _res.ToList();
                count = nwd.Products.Count();

            }
           
            ViewBag.sql = sql;
            ViewBag.sortCol = sortCol;
            if (sortDir == "ASC")
            {
                ViewBag.sortDir = "Ascending";
                
            }
            else
            {
                ViewBag.sortDir = "Desending";
            }

            ViewBag.rowsPerPage = rowsPerPage;
            ViewBag.count = count;
            return View(res);
        }
    }
}