using System;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using NHibernetMVC_001.Models;

namespace NHibernetMVC_001.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/
        public ActionResult Index()
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var Books = session.Query<Book>().ToList();
                return View(Books);
            }
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                using (ISession session = NHibertnateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(book);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var Book = session.Get<Book>(id);
                return View(Book);
            }

        }


        [HttpPost]
        public ActionResult Edit(int id, Book Book)
        {
            try
            {
                using (ISession session = NHibertnateSession.OpenSession())
                {
                    var BooktoUpdate = session.Get<Book>(id);

                    BooktoUpdate.Name = Book.Name;
                    BooktoUpdate.Author = Book.Author;
                    BooktoUpdate.Publishers = Book.Publishers;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(BooktoUpdate);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var Book = session.Get<Book>(id);
                return View(Book);
            }
        }


        public ActionResult Delete(int id)
        {
            using (ISession session = NHibertnateSession.OpenSession())
            {
                var Book = session.Get<Book>(id);
                return View(Book);
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Book Book)
        {
            try
            {
                using (ISession session = NHibertnateSession.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var _Book = session.Get<Book>(id);
                        session.Delete(_Book);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

	}
}