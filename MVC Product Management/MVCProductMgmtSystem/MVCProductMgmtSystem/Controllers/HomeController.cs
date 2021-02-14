using MVCProductMgmtSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace MVCProductMgmtSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //db contains the table in which all records are to be inserted
        AppDBEntities db = new AppDBEntities(); //Creating an object of the entity

        // This method do searching, sorting & Pagination
        public ActionResult Index(string SearchBy, string Search, int? page, string SortBy, string AdvancedSearch)
        {
            ViewBag.SortNameParameter = string.IsNullOrEmpty(SortBy) ? "Name desc" : "";
            ViewBag.SortCategoryParameter = SortBy == "Category" ? "Category desc" : "Category";
            ViewBag.SortPriceParameter = SortBy == "Price" ? "Price desc" : "Price";

            //AsQueryable method is used to convert given input list elements to IQueryable<T> list
            var person = db.ProductLs.AsQueryable();

            //Search by Name & Category
            if (SearchBy == "Name") //When a record is searched by name
            {
                person = person.Where(x => x.ProductName.StartsWith(Search) || Search == null); //Returns the record whose name starts with the letter entered in the 'Search' function 
            }
            else if (SearchBy == "Category") //When a record is searched by Category
            {
                person = person.Where(x => x.Category.StartsWith(Search) || Search == null); //Returns the record whose Category starts with the letter entered in the 'Search' function 
            }
            else if (AdvancedSearch != null)
            {
                person = person.Where(x => x.ProductName.StartsWith(AdvancedSearch) || x.Category.StartsWith(AdvancedSearch) || x.ShortDescription.StartsWith(AdvancedSearch) || x.LongDescription.StartsWith(AdvancedSearch) || x.SmallImage.StartsWith(AdvancedSearch) || x.LargeImage.StartsWith(AdvancedSearch));
            }

            //Sort by Name & Category
            switch (SortBy)
            {
                case "Name desc":
                    person = person.OrderByDescending(x => x.ProductName);
                    break;

                case "Category desc":
                    person = person.OrderByDescending(x => x.Category);
                    break;

                case "Category":
                    person = person.OrderBy(x => x.Category);
                    break;

                default:
                    person = person.OrderBy(x => x.ProductName);
                    break;
            }
            //returns the page view as 3 records per page
            return View(person.ToPagedList(page ?? 1, 3));
        }

        // This method creates a new product
        public ActionResult Create()
        {
            return View(); //Returns the view of 'Create'
        }

        [HttpPost]
        //When user creates a new record by clicking on "Add" button on view, all data will come to the object 'p' of table ProductL
        public ActionResult Create(ProductL p)
        {
            if (p != null) // if the object 'p' has some data, then it will go inside the loop.
            {
                string filename = Path.GetFileNameWithoutExtension(p.SmallImg.FileName);  // Get name of small image file from the path and store into filename.
                string extension = Path.GetExtension(p.SmallImg.FileName);  // Get extension of small image file from the path and store into extension.
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;  // Add time to avoid duplication into filename.
                p.SmallImage = "~/Images/SmallImg/" + filename; // store the path of 'SmallImg' folder alongwith the 'filename' in the Small Image of object 'p'.
                filename = Path.Combine(Server.MapPath("~/Images/SmallImg"), filename); // store the path and filename in server to display data in the 'SmallImg' folder.
                p.SmallImg.SaveAs(filename);  //Save the path and filename in the folder containing samll Image.
            }
            if (p.LargeImg != null) //If Large Image contains some Image
            {
                string filename1 = Path.GetFileNameWithoutExtension(p.LargeImg.FileName); // Get name of small image file from the path and store into filename1.
                string extension1 = Path.GetExtension(p.LargeImg.FileName); // Get extension of large image file from the path and store into extension1.
                filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extension1; // Add time to avoid duplication into filename1.
                p.LargeImage = "~/Images/LargeImg/" + filename1; // store the path of 'LargeImg' folder alongwith the 'filename1' in the Large Image of object 'p'.
                filename1 = Path.Combine(Server.MapPath("~/Images/LargeImg"), filename1); // store the path and filename1 in server to display data in the 'LargeImg' folder.
                p.LargeImg.SaveAs(filename1); //Save the path and filename1 in the folder containing large Image.
            }
            else //If Large Image has 'null' value
            {
                p.LargeImage = "NA"; // Return the value 'NA' for LargeImage.
            }
            if (p.LongDescription == null) //If the LongDescription has 'null' value.
            {
                p.LongDescription = "NA"; // Return the value 'NA' for LongDescription. 
            }

            using (AppDBEntities db = new AppDBEntities())
            {
                db.ProductLs.Add(p); // Insert all the details contained in 'p' to dataset 'ProductLs'.
                db.SaveChanges(); // Save the changes done in the database.
            }
            ModelState.Clear(); //After saving all data, all the textboxes are now cleared. 
            db.Entry(p).State = EntityState.Modified; //Modified data will be stored in the 'p' object of table 'ProductL'
            db.SaveChanges(); //Save the changes made
            //Toastr code
            HttpCookie cookie1 = new HttpCookie("CookieAdd");
            cookie1.Value = "Add";
            Response.Cookies.Add(cookie1);
            cookie1.Expires = DateTime.Now.AddSeconds(5);
            return RedirectToAction("Index"); //Redirect the page back to 'Index' 
        }
        
        //This method is for 'Edit' the record
        public ActionResult Edit(int? id) //When user clicks on Edit, the id of that will be catched here.
        {
            if (id == null) //If id is 'null'
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //Return the view of HttpStatusCode
            }
            using (AppDBEntities db = new AppDBEntities())
            {
                var product = db.ProductLs.Find(id); // If the 'id' is not 'null', then find the value of that 'id'.
                Session["imgPath"] = product.SmallImage; // It returns the value of SmallImage present in the 'product' object.
                Session["imgPath2"] = product.LargeImage; // It returns the value of LargeImage present in the 'product' object.
                if (product == null) //If the 'product' object's value is 'null'
                {
                    return HttpNotFound(); // Return HttpNotFound
                }
                return View(product); //Return the view of 'product' object's 'not null' value.
            }
        }
        
        //Changes made in the record will be displayed using HttpPost method.
        [HttpPost]
        public ActionResult Edit(ProductL product)
        {
            try
            {
                string oldpath1 = Session["imgPath"].ToString(); //Session containing Small Image will be converted to string
                string oldpath2 = Session["imgPath2"].ToString(); //Session containing Large Image will be converted to string
                if (product.SmallImg != null && product.LargeImg != null) // If both the Small Image & Large Image have some record
                {
                    string filename1 = Path.GetFileNameWithoutExtension(product.SmallImg.FileName); // Get name of small image file from the path and store into filename.
                    string extension1 = Path.GetExtension(product.SmallImg.FileName);
                    filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extension1;
                    string path1 = "~/Images/SmallImg/";
                    product.SmallImage = path1 + filename1;
                    filename1 = Path.Combine(Server.MapPath(path1), filename1);
                    product.SmallImg.SaveAs(filename1);
                    string p1 = Request.MapPath(oldpath1); //Copy the new path for Small image
                    if (System.IO.File.Exists(p1)) //If there is old Small Image
                    {
                        System.IO.File.Delete(p1); //Delete the old small image
                    }
                    string filename2 = Path.GetFileNameWithoutExtension(product.LargeImg.FileName);
                    string extension2 = Path.GetExtension(product.LargeImg.FileName);
                    filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                    string path2 = "~/Images/LargeImg/";
                    product.LargeImage = path2 + filename2;
                    filename2 = Path.Combine(Server.MapPath(path2), filename2);
                    product.LargeImg.SaveAs(filename2);
                    string p2 = Request.MapPath(oldpath2); //Copy the new path for Large image
                    if (System.IO.File.Exists(p2))  //If there is old Large Image
                    {
                        System.IO.File.Delete(p2); //Delete the old large image
                    }

                }
                if (product.SmallImg != null) //If Small Image is not inserted
                {
                    string filename1 = Path.GetFileNameWithoutExtension(product.SmallImg.FileName);
                    string extension1 = Path.GetExtension(product.SmallImg.FileName);
                    filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + extension1;
                    string path1 = "~/Images/SmallImg/";
                    product.SmallImage = path1 + filename1;
                    filename1 = Path.Combine(Server.MapPath(path1), filename1);
                    product.SmallImg.SaveAs(filename1);
                    if (product.LargeImg == null) //If Large image is not edited
                    {
                        product.LargeImage = oldpath2; //Take older large image
                    }
                    if (product.SmallImage != oldpath1) //If new Small Image has been inserted
                    {
                        string p1 = Request.MapPath(oldpath1); //Copy the new path for Small image
                        if (System.IO.File.Exists(p1)) //If older Small Image exists
                        {
                            System.IO.File.Delete(p1); //Delete the older Small Image
                        }
                    }
                }
                if (product.LargeImg != null) //If Large Image is not edited
                {
                    string filename2 = Path.GetFileNameWithoutExtension(product.LargeImg.FileName);
                    string extension2 = Path.GetExtension(product.LargeImg.FileName);
                    filename2 = filename2 + DateTime.Now.ToString("yymmssfff") + extension2;
                    string path2 = "~/Images/LargeImg/";
                    product.LargeImage = path2 + filename2;
                    filename2 = Path.Combine(Server.MapPath(path2), filename2);
                    product.LargeImg.SaveAs(filename2);
                    if (product.SmallImg == null) //If small image is not edited
                    {
                        product.SmallImage = oldpath1; //Take older small image 
                    }
                    if (product.LargeImage != oldpath2) //If new Large Image has been inserted
                    {
                        string p2 = Request.MapPath(oldpath2); //Copy the new path for Large image
                        if (System.IO.File.Exists(p2)) //If older Large image exists
                        {
                            System.IO.File.Delete(p2); //Delete it
                        }
                    }
                }
                if (product.SmallImg == null && product.LargeImg == null) //If both the Images are null
                {
                    product.SmallImage = oldpath1; //Select older Small Image
                    product.LargeImage = oldpath2; //Select older Large Image
                }
                if (product.LongDescription == null) //If LongDescription is null
                {
                    product.LongDescription = "NA"; // Display 'NA'
                }
                db.Entry(product).State = EntityState.Modified; //Modified data will be stored in the 'product' object of table 'ProductL'
                db.SaveChanges(); //Save the changes made 
                //Toastr code
                HttpCookie cookie2 = new HttpCookie("CookieEdit");
                cookie2.Value = "Edit";
                Response.Cookies.Add(cookie2);
                cookie2.Expires = DateTime.Now.AddSeconds(5);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return View(); //Return the 'Edit' view
        }

        //This method displays the 'Details' of the record
        public ActionResult Details(int? id) //When user clicks on Details, the id of that will be catched here.
        {
            if (id == null) //If the 'id' is null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //Return the view of HttpStatusCode
            }
            using (AppDBEntities db = new AppDBEntities())
            {
                var productL = db.ProductLs.Find(id); // If the 'id' is not 'null', then find the value of that 'id'.
                if (productL == null) //If the 'productL' object's value is 'null'
                {
                    return HttpNotFound(); //Return HttpNotFound
                }
                return View(productL); //Return the view of 'productL' object's 'not null' value.
            }
        }

        //This method is for Deleting a record
        public ActionResult Delete(int? id) //When user clicks on Delete, the id of that will be catched here.
        {
            if (id == null) //If the 'id' is null
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //Return the view of HttpStatusCode
            }
            using (AppDBEntities db = new AppDBEntities())
            {
                var product = db.ProductLs.Find(id); // If the 'id' is not 'null', then find the value of that 'id'
                if (product == null) //If the 'product' object's value is 'null'
                {
                    return HttpNotFound(); //Return HttpNotFound
                }
                string currentimg1 = Request.MapPath(product.SmallImage); //Copies the path of Small Iamge into 'currentimg1'.
                string currentimg2 = Request.MapPath(product.LargeImage); //Copies the path of Small Iamge into 'currentimg2'.
                db.Entry(product).State = EntityState.Deleted; //Delete the data stored in the 'product' object of table 'ProductL'
                if (db.SaveChanges() > 0)
                {
                    if (System.IO.File.Exists(currentimg1)) //If file exists in currentimg1 
                    {
                        System.IO.File.Delete(currentimg1); //Delete currentimg1  
                    }
                    TempData["msg"] = "Record Deleted Successfully"; //Display message record deleted successfully

                    if (System.IO.File.Exists(currentimg2)) //If file exists in currentimg2
                    {
                        System.IO.File.Delete(currentimg2); //Delete currentimg2
                    }
                }
                return RedirectToAction("Index"); //Return view of Index 
            }
        }

        //This method is for deleting multiple records
        [HttpPost]
        public ActionResult DeleteAll(string[] id) //When user clicks on delete multiple record(s), all ids come here.
        {
            int[] getid = null; //'getid' of type 'int' is set to 'null' value
            if (id != null) // When 'id' has null value
            {
                getid = new int[id.Length]; 
                int j = 0;
                foreach (string i in id)
                {
                    int.TryParse(i, out getid[j++]);
                }
                List<ProductL> pids = new List<ProductL>(); 
                AppDBEntities db = new AppDBEntities();
                pids = db.ProductLs.Where(x => getid.Contains(x.Id)).ToList(); //Delete the record whose 'id' is present in 'getid'
                foreach (var s in pids)
                {
                    db.ProductLs.Remove(s);
                }
                db.SaveChanges(); //Save the changes to the database
                return RedirectToAction("Index"); //Return view of Index 
            }
            return RedirectToAction("Index");
        }

        //This method displays the Dashboard of the Product Management System
        public ActionResult Dashboard()
        {
            if (Session["UserId"] == null) // If UserId is null, redirect to Login page
            {
                return RedirectToAction("Login", "Login");
            }
            else //On successful login, user will enter into dashboard
            {
                return View(); //return the view of Dashboard
            }

        }
    }
}
