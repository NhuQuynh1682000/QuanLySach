using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLySach.Controllers
{
    public class SachController : ApiController
    {
        [HttpGet]
        public List<Sach> GetSachLists()
        {
            DBSachDataContext db = new DBSachDataContext();
            return db.Saches.ToList();
        }
        [HttpGet]
        public Sach GetSach(int id)
        {
            DBSachDataContext db = new DBSachDataContext();
            return db.Saches.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet]
        public bool InsertNewSach(string Title, string AuthorName, int Price, string Content)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                Sach sach = new Sach();
                sach.Title = Title;
                sach.AuthorName = AuthorName;
                sach.Price = Price;
                sach.Content = Content;
                db.Saches.InsertOnSubmit(sach);
                db.SubmitChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }
        [HttpPut]
        public bool UpdateSach(int Id, string Title, string AuthorName, int Price, string Content)
        {
            try
            {
                DBSachDataContext db = new DBSachDataContext();
                Sach sach = db.Saches.FirstOrDefault(x => x.Id == Id);
                if (sach == null) return false;
                sach.Title = Title;
                sach.AuthorName = AuthorName;
                sach.Price = Price;
                sach.Content = Content;
                db.SubmitChanges();
                return true;
            }
            catch
            {

            }
            return false;
        }
        [HttpDelete]
        public bool DeleteSach(int id)
        {
            DBSachDataContext db = new DBSachDataContext();
            Sach sach = db.Saches.FirstOrDefault(x => x.Id == id);
            if (sach == null) return false;
            db.Saches.DeleteOnSubmit(sach);
            db.SubmitChanges();
            return true;
        }
    }
}
