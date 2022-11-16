using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pert4_50420221.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public static List<Models.Karyawan> karyawanList = new List<Models.Karyawan>
        {
            new Models.Karyawan
            {
                ID = 1,
                Name = "Arief Taufik Rahman",
                JoiningDate = DateTime.Now,
                Age = 20,
            },
             new Models.Karyawan
            {
                ID = 2,
                Name = "Dilan",
                JoiningDate = DateTime.Now,
                Age = 30,
            },

        };
        public ActionResult Index()
        {
            var data = from e in karyawanList
                       orderby e.ID
                       select e;
            return View(data);
        }
        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            var karyawan = karyawanList.Single(m => m.ID == id);
            return View(karyawan);
        }
        
        
        //
        // GET: /Home/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        //POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.Karyawan karyawan = new Models.Karyawan();

                karyawan.ID = karyawanList.Count + 1;
                karyawan.Name = collection["Name"];
                karyawan.JoiningDate = DateTime.Now;
                karyawan.Age = Int32.Parse(collection["Age"]);

                karyawanList.Add(karyawan);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            var karyawan = karyawanList.FirstOrDefault(m => m.ID == id);
            return View(karyawan);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var karyawanToEdit = karyawanList.FirstOrDefault(m => m.ID == id);
                if (TryUpdateModel(karyawanToEdit, collection))
                {
                    return RedirectToAction("Index");
                };

                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            var karyawan = karyawanList.FirstOrDefault(m => m.ID == id);
            return View(karyawan);
        }

        // 
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var karyawan = karyawanList.FirstOrDefault(m => m.ID == id);
                karyawanList.Remove(karyawan);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
