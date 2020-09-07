using FirstCoreApp.Data;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.ViewComponents
{
    public class LanguageCountViewComponent : ViewComponent
    {
        private readonly IBookRepository repository;

        public LanguageCountViewComponent(IBookRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var result = repository.BookCountByLanguage();
            return View(result);
        }
    }
}
