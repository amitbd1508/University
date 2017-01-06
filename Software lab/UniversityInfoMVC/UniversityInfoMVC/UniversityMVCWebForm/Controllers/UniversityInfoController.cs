using LogicLayer.BussinessLogic;
using LogicLayer.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityMVCWebForm.Controllers
{
    public class UniversityInfoController : Controller
    {
        // GET: UniversityInfo
        public ActionResult Index()
        {

            UniversityInfoHandler personalHandelar = new UniversityInfoHandler();
            List<UniversityInfo> pList = personalHandelar.GetAll();
            return View(pList);
        }

        // GET: UniversityInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniversityInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversityInfo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                UniversityInfo uniInfo = new UniversityInfo();
                uniInfo.Name = collection["Name"];
                uniInfo.Details = collection["Details"];
                UniversityInfoHandler perHand = new UniversityInfoHandler();
                if (perHand.Insert(uniInfo))
                    return RedirectToAction("Index");
                else return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: UniversityInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UniversityInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UniversityInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniversityInfo/Delete/5
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
