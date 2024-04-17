using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Curdoperation1.Models;
using PagedList;


namespace Curdoperation1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Entities DBContext = new Entities();
            List<STUDENT> StuList = DBContext.STUDENTs.ToList();
            return View(StuList);   
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
       public ActionResult Create(STUDENT MODEL)
       {
            Entities DBContext = new Entities();
            if (ModelState.IsValid)
            {
                DBContext.STUDENTs.Add(MODEL);
                DBContext.SaveChanges();
                ViewBag.Messsage = "Record Create Successfully";
                return RedirectToAction("Index");
            }
 
            return View();
       }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Entities DBContext = new Entities();
            var data = DBContext.STUDENTs.Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(STUDENT MODEL)
        {
            Entities DBContext = new Entities();
            var data = DBContext.STUDENTs.Where(x => x.ID == MODEL.ID).FirstOrDefault();


            if (data != null)
            {
                data.NAME = MODEL.NAME;
                data.GENDER = MODEL.GENDER;
                data.PHONE_NO = MODEL.PHONE_NO;
                DBContext.SaveChanges();
                ViewBag.Messsage = "Record Update Successfully";

            }
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int?id)
        {
            Entities DBContext = new Entities();
            var data = DBContext.STUDENTs.Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int?id)
        {
            Entities DBContext = new Entities();
            var data = DBContext.STUDENTs.Where(x => x.ID == id).FirstOrDefault();
            DBContext.STUDENTs.Remove(data);
            DBContext.SaveChanges();
            ViewBag.Messsage = "Record Remove Successfully";

            return RedirectToAction("Index");
        }



    }
}