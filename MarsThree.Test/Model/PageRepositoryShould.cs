using MarsThreeSite.Controllers.Data_Access;
using MarsThreeSite.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Moq;
using MarsThreeSite.Data;
using System.Linq;

namespace MarsThree.Test
{
    [TestClass]
    public class PageRepositoryShould
    {
        List<PageModel> _listMock;
        PageRepository sut;

        [TestInitialize]
        public void InitalizePageList()
        {
            var dbOptions = new DbContextOptionsBuilder<SiteDb>()
                    .UseInMemoryDatabase(databaseName: "TestSiteDb")
                    .Options;
            SiteDb context = new SiteDb(dbOptions);

            _listMock = new List<PageModel>();
            ChapiterData chapiter = new ChapiterData() { ChapiterId = 0, ChapiterName = "Doggies", ChapiterNumber = 2, isDeleted = false };
            context.Add(new PageModel()
            {
                PageAddress = "/images/Photo/golden.jpg",
                PageNumber = 1,
                Published = new DateTime(2018, 10, 16),
                PagePrevious = 0,
                PageNext = 2,
                Chapiter_Id = chapiter,
                isDeleted = false
            });
            context.Add(new PageModel()
            {
                PageAddress = "/images/Photo/golden2.jpg",
                PageNumber = 2,
                Published = new DateTime(2018, 10, 17),
                PagePrevious = 1,
                PageNext = 3,
                Chapiter_Id = chapiter,
                isDeleted = false
            });
            context.Add(new PageModel()
            {
                PageAddress = "/images/Photo/golden3.jpg",
                PageNumber = 3,
                Published = new DateTime(2018, 10, 18),
                PagePrevious = 2,
                PageNext = 0,
                Chapiter_Id = chapiter,
                isDeleted = false
            });


            context.SaveChanges();
            
            sut = new PageRepository(context);
        }
        [DataTestMethod]
        [DataRow(1, "/images/Photo/golden.jpg")]
        [DataRow(2, "/images/Photo/golden2.jpg")]
        public void ReturnGetPageWByPageNumer(int number, string adress)
        {
            var result = sut.GetPage(number);
            Assert.IsTrue(result.PageAddress == adress, $"The returned page was not page {number}, it was {result.PageNumber}");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReturnExceptionIfGetPageWIfPageNotExist()
        {
            var result = sut.GetPage(5);
        }

        [TestMethod]
        public void ReturnLatestGetPageWhenParametersAreNull()
        {
            var result = sut.GetPage();
            //Assert
            Assert.IsNotNull(result, "Object was null");
            Assert.IsTrue(result.PageNumber == 3, $"The latest page was not page 3, it was {result.PageNumber}");
        }
    }
}
