using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class SurveyControllerTests
    {
        [TestMethod()]
        public void SurveyController_SubmitAction_ReturnSubmitView()
        {
            //string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=npgeek;User ID=te_student;Password=sqlserver1";
            //Arrange
            //ParkListSqlDAL parkDal = new ParkListSqlDAL(conn);
            SurveyController controller = new SurveyController(null);

            //Act
            ViewResult result = controller.Submit() as ViewResult;
                  
            //Assert
            
            Assert.AreEqual("Submit", result.ViewName);
        }
    }
}