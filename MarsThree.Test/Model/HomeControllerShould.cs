using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MarsThreeLogging;
using MarsThreeSite.Controllers.Data_Access;
using Microsoft.Extensions.Logging;
using MarsThreeSite.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarsThreeSite.Data;
using MarsThreeSite.Models;

namespace MarsThree.Test.Model
{
    [TestClass]
    public class HomeControllerShould
    {
        [TestInitialize]
        public void Setup()
        {

        }
        [TestMethod]
        public void ReturnAViewResultWithPage()
        {
            var mockRepo = new Mock<PageRepository>();
            var mockLog = new Mock<ILogger<HomeController>>();

            mockRepo.Setup( x => x.GetPage()).Returns(() => new PageModel()
                            { PageId=0, PageName="", PageNumber=1, Chapiter_Id=new ChapiterData(), PageAddress="images/photo/golden.jpg", Published=DateTime.Today, isDeleted=false } );

            var sut = new HomeController(mockLog.Object, mockRepo.Object);

            IActionResult result = sut.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewRslt = (ViewResult)result;
            Assert.IsInstanceOfType(viewRslt.Model, typeof(PageModel));            
        }
        [TestMethod]
        public void GetPageNumberFromTheURLParameters()
        {

        }
        [TestMethod]
        public void HandleExceptionSentByRepository()
        {

        }

    }
}
