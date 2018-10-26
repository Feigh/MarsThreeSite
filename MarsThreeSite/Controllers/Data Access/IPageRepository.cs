using MarsThreeSite.Models;
using System;
using System.Collections.Generic;

namespace MarsThreeSite.Controllers.Data_Access
{
    public interface IPageRepository
    {
        //PageModel GetPage(int? pagenr, int? chapiternr);
        PageModel GetPage();
        List<PageModel> GetPages(DateTime date);
    }
}