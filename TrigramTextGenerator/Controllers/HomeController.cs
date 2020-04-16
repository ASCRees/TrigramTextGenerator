using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrigramTextGenerator.Models;
using TomSwiftUnderMilkWood.Interfaces;

namespace TrigramTextGenerator.Controllers
{
    public class HomeController : Controller
    {
        internal readonly ITextGenerator _TextGenerator;
        private readonly ITrigramGenerator _TrigramGenerator;

        public HomeController(ITextGenerator TextGenerator, ITrigramGenerator TrigramGenerator)
        {
            _TextGenerator = TextGenerator;
            _TrigramGenerator = TrigramGenerator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GenerateText(TextTrigramModel sourceTrigramModel)
        {
            var trigramDictionary  = _TrigramGenerator.BuildTrigram(sourceTrigramModel.SourceText);
            var returnString = string.Empty;
            returnString = _TextGenerator.BuildRandomReturnString(trigramDictionary, returnString);

            TextTrigramModel textTrigramModel = new TextTrigramModel();

            textTrigramModel.SourceText = sourceTrigramModel.SourceText;
            textTrigramModel.GeneratedText = returnString;
            return View("Index", textTrigramModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}