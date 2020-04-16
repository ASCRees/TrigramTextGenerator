namespace TrigramTextGenerator.Tests.Controllers
{
    using System.Web.Mvc;
    using FluentAssertions;
    using NUnit.Framework;
    using TomSwiftUnderMilkWood;
    using TrigramTextGenerator.Controllers;
    using TrigramTextGenerator.Models;

    [TestFixture]
    public class HomeControllerTest
    {
        HomeController controller;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
           controller = new HomeController(new TextGenerator(), new TrigramGenerator());
        }

        [Test]
        public void Test_Index_Return_Result_IsNot_Null()
        {

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Test_Search_Return_Result_IsNot_Null()
        {
            // Arrange

            TextTrigramModel textTrigramModel = new TextTrigramModel();
            string sampleText = "Sample my text";
            textTrigramModel.SourceText = sampleText;

            // Act
            ViewResult result = controller.GenerateText(textTrigramModel).GetAwaiter().GetResult() as ViewResult;

            // Assert

            ((TextTrigramModel)result.Model).GeneratedText.Should().Be(sampleText);
           
        }

    }
}
