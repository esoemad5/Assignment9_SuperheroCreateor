using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ActionResult Index()
        {
            return View();
        }
        
    
        public ActionResult Create()
        {
            return View(new Superhero());
        }
        
        [HttpPost]
        public ActionResult Create([Bind(Include ="Name,AlterEgo,PrimaryAbility,SecondaryAbility,Catchphrase")] Superhero hero)
        {
            try
            {
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

        public ActionResult List()
        {
            return View(db.Superheroes.ToList());
        }
        
        public ActionResult Read(int id)
        {
            return View(db.Superheroes.Where(s => s.ID == id).Single());
        }
        
        public ActionResult Update(int id)
        {
            return View(db.Superheroes.Where(s => s.ID == id).Single());
        }
        
        [HttpPost]
        public ActionResult Update(int id, [Bind(Include = "ID,Name,AlterEgo,PrimaryAbility,SecondaryAbility,Catchphrase")] Superhero hero)
        {
            try
            {
                // The hero's ID changes with this method
               // db.Superheroes.Remove(db.Superheroes.Where(s => s.ID == id).Single());
                //var modifiedHero = db.Superheroes.Where(s => s.ID == hero.ID).Single();
                db.Entry(hero).State = EntityState.Modified;
                //var current = db.Entry(hero).CurrentValues;
                //var original = db.Entry(hero).OriginalValues.Clone();
                //var something = db.Entry(hero).Entity;
                ////db.Superheroes.Add(hero);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Delete(int id)
        {
            return View(db.Superheroes.Where(s => s.ID == id).Single());
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                db.Superheroes.Remove(db.Superheroes.Where(s => s.ID == id).Single());
                db.SaveChanges();

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
