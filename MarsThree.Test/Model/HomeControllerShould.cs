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
        [TestMethod]
        public void GetTheLatestPageWhenIndexIsCalled()
        {
            var mockRepo = new Mock<PageRepository>();
            var mockLog = new Mock<ILogger<HomeController>>();

            mockRepo.Setup( x => x.GetPage()).Returns(() => new PageModel() );

            var sut = new HomeController(mockLog.Object, mockRepo.Object);

            IActionResult result = sut.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
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
