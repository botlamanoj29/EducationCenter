using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using EducationCenter.Controllers;
using Microsoft.Extensions.Primitives;
namespace NUnit.TestCases
{
    [TestFixture]
    public class UserRegistrationTest
    {
        [Test]
        public void Index_WithValidData_ReturnsSuccessView()
        {
            // Arrange
            var controller = new UserRegistrationController();

            // Act
            var result = controller.Index(new FormCollection(new Dictionary<string, StringValues>
        {
            {"UserName", new StringValues("validUserName")},
            {"Password", new StringValues("validPassword12")}
        })) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Success", result.ViewName);
        }

        [Test]
        public void Index_WithInvalidData_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserRegistrationController();

            var result = controller.Index(new FormCollection(new Dictionary<string, StringValues>
        {
            {"UserName", new StringValues("validUserName")},
            {"Password", new StringValues("")}
        })) as ViewResult;


            // Act
          //  var result = controller.Index(new FormCollection(null)) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
         
        }

          }
}