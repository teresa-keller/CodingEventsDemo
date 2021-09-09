using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
      
            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            //ViewBag.title = "Delete Events";
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        public IActionResult Edit(int eventId)
        {
            Event selectedEvent = EventData.GetById(eventId);
            ViewBag.eventToEdit = selectedEvent;
            ViewBag.eventToEdit.Title = "Edit Event " + ViewBag.eventToEdit.Name + ViewBag.eventToEdit.Id;
           
            return View();
    }

        [HttpPost]
        [Route("/Events/Edit/{eventId?}")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            ViewBag.eventToEdit.Id = EventData.GetById(eventId);
            ViewBag.eventToEdit.Name = name;
            ViewBag.eventToEdit.Description = description;
        return Redirect("/Events");
           
        }
    }
}
