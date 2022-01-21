using MyCosmos.DAO;
using MyCosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyCosmos.Controllers
{
    public class PeopleController : Controller
    {
        private static readonly ICosmosDBService service = CosmosDbServiceProvider.CosmosDBService;
        
        // GET: People
        public async Task<ActionResult> Index()
        {
            return View(await service.GetPeopleAsync("SELECT * FROM Person"));
        }

        // GET: People/Details/5
        public async Task<ActionResult> Details(string id)
        {
            return await ShowItem(id);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Id, Firstname, Lastname, Birthdate, IsMarried")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid().ToString();
                await service.InsertPersonAsync(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }



        // GET: People/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            return await ShowItem(id);
        }

        private async Task<ActionResult> ShowItem(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var person = await service.GetPersonAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Firstname, Lastname, Birthdate, IsMarried")]Person person)
        {
            if (ModelState.IsValid)
            {
                await service.UpdatePersonAsync(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            return await ShowItem(id);
        }

        // POST: People/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include = "Id, Firstname, Lastname, Birthdate, IsMarried")] Person person)
        {
            await service.DeletePersonAsync(person);
            return RedirectToAction("Index");
        }
    }
}
