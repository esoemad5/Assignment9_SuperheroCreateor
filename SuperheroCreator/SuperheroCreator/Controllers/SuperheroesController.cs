using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroCreator.Controllers
{
    public class SuperheroesController : Controller
    {
        ApplicationDbContext db;
        public SuperheroesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Superheroes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View(db.Superheroes.ToList());
        }

        // GET: Superheroes/Details/5
        public ActionResult Read(int id)
        {
            return View(db.Superheroes.Where(s => s.ID == id).Single());
        }

        // GET: Superheroes/Create
        public ActionResult Create()
        {
            return View(new Superhero());
        }

        // POST: Superheroes/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Name,AlterEgo,PrimaryAbility,SecondaryAbility,Catchphrase")] Superhero hero)// binding
        {
            try
            {
                //Superhero newSuperhero = new Superhero();
                //newSuperhero.Name = collection.ToValueProvider().GetValue("Name").AttemptedValue;
                //newSuperhero.AlterEgo = collection.ToValueProvider().GetValue("AlterEgo").AttemptedValue;
                //newSuperhero.PrimaryAbility = collection.ToValueProvider().GetValue("PrimaryAbility").AttemptedValue;
                //newSuperhero.SecondaryAbility = collection.ToValueProvider().GetValue("SecondaryAbility").AttemptedValue;
                //newSuperhero.Catchphrase = collection.ToValueProvider().GetValue("Catchphrase").AttemptedValue;

                //db.Superheroes.Add(newSuperhero);
                db.Superheroes.Add(hero);
                db.SaveChanges();
                // The hero object gets a new ID when it is put into the database. Prior to that, it is set to default 0.
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Edit/5
        public ActionResult Update(int id)
        {
            return View();
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        public ActionResult Update(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superheroes/Delete/5
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
