using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Database;
using Site01.Library.Filters;
using Site01.Models;
using X.PagedList;

namespace Site01.Controllers
{
    [Login]
    public class WordController : Controller
    {
        /*List<Level> levels = new List<Level>();*/
     
        private DatabaseContext _db;
 
        public WordController(DatabaseContext db)
        {
            _db = db;
        }

        // Listar todas as palavras do banco de dados
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var words = _db.Words.ToList();
            var pagedResult = words.ToPagedList(pageNumber, 2);

            return View(pagedResult);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new Word());
        }

        [HttpPost]
        public IActionResult Register([FromForm]Word word)
        {
            if (ModelState.IsValid)
            {
                _db.Words.Add(word);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
  
            return View(word);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            Word word = _db.Words.Find(Id);
    
            return View("Register", word);
        }

        [HttpPost]
        public IActionResult Update([FromForm]Word word)
        {
            if (ModelState.IsValid)
            {
                _db.Words.Update(word);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Register", word);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _db.Words.Remove(_db.Words.Find(Id));
            _db.SaveChanges();
    
            // Excluir o registro no banco
            return RedirectToAction("Index");
        }
    }
}