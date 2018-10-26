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
        private List<PageModel> _pageList;
        public List<PageModel> PageList { get { return _pageList; } set { _pageList = value; } }
        private readonly SiteDb _dbContext;

        public PageRepository(SiteDb context)
        {
            _dbContext = context;
            _pageList = new List<PageModel>();

        }

        public PageModel GetPage()
        {
            var modelData = _dbContext.Pages.OrderByDescending(x => x.Published).FirstOrDefault();

            return modelData;
        }

        public List<PageModel> GetPages(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
