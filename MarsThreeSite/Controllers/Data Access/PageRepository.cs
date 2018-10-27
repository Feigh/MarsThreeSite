using MarsThreeSite.Data;
using MarsThreeSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsThreeSite.Controllers.Data_Access
{
    public class PageRepository : IPageRepository
    {
        private readonly SiteDb _dbContext;

        public PageRepository() { }
        public PageRepository(SiteDb context)
        {
            _dbContext = context;
        }
           // $"Test{variabel}"
        virtual public PageModel GetPage()
        {
            try
            {
                var modelData = _dbContext.Pages.OrderByDescending(x => x.Published).First();
                return modelData;
            }
            catch(InvalidOperationException ex)
            {
                throw;
            }

        }

        virtual public PageModel GetPage(int pageNumber)
        {
            try
            {
                var modelData = _dbContext.Pages.Where(x => x.PageNumber == pageNumber).First();
                return modelData;
            }
            catch(InvalidOperationException ex)
            {
                throw;
            }
        }

        virtual public List<PageModel> GetPages(DateTime date)
        {
            // Värt att testa skillnaden på IEnumerable och IEnumrator
            // Testa att köra IColletion och de andra, testa yield
            // Deffered execution och Lazy Evaluation
            throw new NotImplementedException();
        }


    }
}
