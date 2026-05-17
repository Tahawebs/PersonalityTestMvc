using Microsoft.AspNetCore.Mvc;
using PersonalityTestMvc.Models;
using System.Collections.Generic;

namespace PersonalityTestMvc.Controllers
{
    public class PersonalityTestController : Controller
    {
        // Dictionary mapping image key to personality data
        private static readonly Dictionary<string, PersonalityResult> PersonalityMap =
            new Dictionary<string, PersonalityResult>
        {
            { "mountain", new PersonalityResult { ImageKey = "mountain", Title = "The Achiever",
                Description = "You are ambitious, resilient, and love challenges. You seek high goals and enjoy the journey to the top." } },
            { "ocean", new PersonalityResult { ImageKey = "ocean", Title = "The Peacemaker",
                Description = "You are calm, intuitive, and go with the flow. You value deep connections and emotional depth." } },
            { "forest", new PersonalityResult { ImageKey = "forest", Title = "The Explorer",
                Description = "You are curious, grounded, and love discovering new things. You find joy in growth and wisdom." } },
            { "desert", new PersonalityResult { ImageKey = "desert", Title = "The Survivor",
                Description = "You are independent, resourceful, and thrive in solitude. You have inner strength and clarity." } }
        };

        // GET: /PersonalityTest/
        public ActionResult Index()
        {
            return View();
        }

        // POST: /PersonalityTest/Result
        [HttpPost]
        public ActionResult Result(string imageKey)
        {
            if (string.IsNullOrEmpty(imageKey) || !PersonalityMap.ContainsKey(imageKey))
                return RedirectToAction("Index");

            var result = PersonalityMap[imageKey];
            return View(result);
        }
    }
}