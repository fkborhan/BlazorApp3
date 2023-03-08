using BlazorApp3.Server.Data;
using BlazorApp3.Server.Interface;
using BlazorApp3.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Server.BookItems
{
    public class MasterDetailsBShop : ImasterDetail
    {
        ApplicationDbContext db;
        public MasterDetailsBShop(ApplicationDbContext _db)
        {
            db = _db;
        }

        public string AddBCShopVM(BCShopVM md2)
        {
            BookCategory m = new BookCategory() { CategoryId = md2.BookCategory.CategoryId, CategoryName = md2.BookCategory.CategoryName, Author = md2.BookCategory.Author };
            db.BookCategories.Add(m);
            db.SaveChanges();
            db.Entry(m).State = EntityState.Detached;
            foreach (var c in md2.BookItem)
            {
                BookItem d = new BookItem() { BookId = c.BookId, BookName = c.BookName, CategoryId = c.CategoryId, Description = c.Description, Active = c.Active, Date = c.Date, Price = c.Price, Image = c.Image };
                db.BookItems.Add(d);
            }
            db.SaveChanges();
            return "1";
        }
        public string RemoveBCShopVM(string id)
        {
            List<BookItem> st5 = db.BookItems.Where(xx => xx.CategoryId == id).ToList();
            db.BookItems.RemoveRange(st5);
            db.SaveChanges();
            BookCategory st6 = db.BookCategories.Find(id);
            if (st6 != null)
            {
                db.BookCategories.Remove(st6);
            }
            db.SaveChanges();
            return "1";
        }
        public string UpdateBCShopVM(BCShopVM md)
        {
            RemoveBCShopVM(md.BookCategory.CategoryId);
            AddBCShopVM(md);
            return "1";
        }

        public List<BookCategory> GetTwoTables()
        {
            List<BookCategory> md = new List<BookCategory>();
            md = (from d in db.BookCategories select d).ToList();
            return md;
        }
        public BCShopVM GetTwoTables2(string id)
        {
            BCShopVM md = new BCShopVM();
            BookCategory a = new BookCategory();
            a = (from d in db.BookCategories where d.CategoryId == id select d).FirstOrDefault();
            md.BookCategory = a;
            List<BookItem> b = new List<BookItem>();
            b = (from d in db.BookItems where d.CategoryId == id select d).ToList();
            md.BookItem = b;
            if (a != null) db.Entry(a).State = EntityState.Detached;
            return md;
        }

        //public string GenerateCode()
        //{
        //    string a1 = "";
        //    string b1 = "";

        //    try
        //    {
        //        var a = (from det in db.BookCategories select det.CategoryId.Substring(3)).Max();
        //        if (a == null)
        //            a = "0";
        //        int b = int.Parse(a.ToString()) + 1;
        //        if (b < 10)
        //        {
        //            b1 = "000" + b.ToString();
        //        }
        //        else if (b < 100)
        //        {
        //            b1 = "00" + b.ToString();
        //        }
        //        else if (b < 1000)
        //        {
        //            b1 = "0" + b.ToString();
        //        }
        //        else
        //        {
        //            b1 = b.ToString();
        //        }
        //        a1 = "AC-" + b1.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        a1 = "AC-0001";
        //    }
        //    return a1;
        //}
        //public string Child_Exists(string id)
        //{
        //    var a = (from p in db.BookItems where p.BookId == id select new { p.BookId, }).FirstOrDefault();
        //    if (a != null)
        //        return "1";
        //    else
        //        return "0";
        //}

        

        
    }
}
