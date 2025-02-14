﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        MVCCRUDDBContext _context = new MVCCRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Students.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Student model)
        {
            _context.Students.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Inserted successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            var data = _context.Students.Where(x => x.StudentId == model.StudentId).FirstOrDefault();
            if (data != null)
            {
                data.StudentCity = model.StudentCity;
                data.StudentName = model.StudentName;
                data.StudentFee = model.StudentFee;
                _context.SaveChanges();

            }
            return RedirectToAction("index");
        }
        public ActionResult Details(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _context.SaveChanges();
            return View(data);
        }
     
        public ActionResult Delete(int id)
        {

            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "data deleted successfully";
            return RedirectToAction("index");

        }
   


    }
}