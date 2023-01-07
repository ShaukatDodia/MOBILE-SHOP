using external.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace external.Controllers
{
    public class MobileController : Controller
    {
        DBMobileEntities context = new DBMobileEntities();  
        // GET: Mobile
        //signup
        public ActionResult insertuser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertuser(TBLUser obj)
        {
            context.TBLUsers.Add(obj);
            context.SaveChanges();
            return RedirectToAction("Loginuser");
        }

        //Login
        public ActionResult Loginuser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loginuser(TBLUser lg)
        {
            var user = context.TBLUsers.Where(x => x.u_name == lg.u_name && x.u_psw == lg.u_psw).Count();
            if (user > 0)
            {
                Session["cc"] = lg.u_name;
                return RedirectToAction("select");

            }
            else
            {
                return View("error");
            }

        }

        //error
        public ActionResult error()
        {
            return View();
        }

        // select data

        public ActionResult select()
        {
            return View(context.TBLMobiles.ToList());
        }



        //insert
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(TBLMobile fdt)
        {
            string sm = "Samsong";
            string mi = "Xiaomi";
            string ap = "Apple";
            if (fdt.m_brand == sm)
            {
                int d = 30;
                fdt.m_discount = d;
            }
            else if (fdt.m_brand == mi)
            {
                int d = 20;
                fdt.m_discount = d;
            }
            else if (fdt.m_brand == ap)
            {
                int d = 0;
                fdt.m_discount = d;
            }
            else
            {
                int d = 10;
                fdt.m_discount = d;
            }
            context.TBLMobiles.Add(fdt);
            context.SaveChanges();

            return RedirectToAction("select");
        }


        //delete oparation

        public ActionResult delete(int id)
        {
            TBLMobile oldfood = context.TBLMobiles.Where(a => a.ID_PK == id).FirstOrDefault();
            context.TBLMobiles.Remove(oldfood);
            context.SaveChanges();
            return RedirectToAction("select");
        }


        //update data
        public ActionResult updatedata(int id)
        {
            TBLMobile olddata = context.TBLMobiles.Where(a => a.ID_PK == id).FirstOrDefault();
            return View(olddata);
        }
        
        [HttpPost]

        public ActionResult updatedata(TBLMobile newdata)
        {
            TBLMobile oldfood = context.TBLMobiles.Where(a => a.ID_PK == newdata.ID_PK).FirstOrDefault();

            string sm = "Samsong";
            string mi = "Xiaomi";
            string ap = "Apple";
            if (newdata.m_brand == sm)
            {
                int d = 30;
                oldfood.m_discount = d;
            }
            else if (newdata.m_brand == mi)
            {
                int d = 20;
                oldfood.m_discount = d;
            }
            else if (newdata.m_brand == ap)
            {
                int d = 0;
                oldfood.m_discount = d;
            }
            else
            {
                int d = 10;
                oldfood.m_discount = d;
            }
            oldfood.m_name = newdata.m_name;
            oldfood.m_brand = newdata.m_brand;
            oldfood.m_price = newdata.m_price;
            context.SaveChanges();

            return RedirectToAction("select");
        }
        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Loginuser");
        }
    }
    }