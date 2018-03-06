using RayTracer.Models.SceneElements;
using RayTracer.Models.Elements;
using System.IO;
using NUnit.Framework;
using RayTracer.Models.Util;
using RayTracer.Models.Geometric;
using System.Collections.Generic;
using Moq;

namespace RayTracer.Tests.SceneTesting
{
    [TestFixture]
    public class SceneTests
    {
        Scene scene;

        [TestFixtureSetUp]
        public void Init()
        {
            scene = new Scene(new WindowFrame(500, 500, 1.0));
        }

        [Test]
        public void TestFinalPicture()
        {
            scene = new Scene(new WindowFrame(500, 500, 1.0));
            scene.SetFileName("bitmapPic");
            scene.CreateScene();
            scene.Render();
            Assert.IsTrue(File.Exists(@"./bitmapPic.jpg"));
        }

        [Test]
        public void TestGetHitInfo_Object_inIgnoreList()
        {
            //Arrange
            scene = new Scene(new WindowFrame(500, 500, 1.0));

            List<GeometryObject> ignoreObjects = new List<GeometryObject>();
            Mock<GeometryObject> geoMock = new Mock<GeometryObject>();
            ignoreObjects.Add(geoMock.Object);
            scene.AddObject(geoMock.Object);
            //Act
            HitInfo actualHitInfo = scene.GetHitInfo(new Ray(), ignoreObjects);
            //Assert
            Assert.IsFalse(actualHitInfo.hasHit);
        }

        [Test]
        public void TestGetHitInfo_Object_OneinIgnoreList_AndOneNot()
        {
            //Arrange
            scene = new Scene(new WindowFrame(500, 500, 1.0));
            List<GeometryObject> ignoreObjects = new List<GeometryObject>();
            Mock<GeometryObject> geoMock = new Mock<GeometryObject>();
            ignoreObjects.Add(geoMock.Object);
            scene.AddObject(geoMock.Object);
            Mock<GeometryObject> geoMock2 = new Mock<GeometryObject>();
            geoMock2.Setup(_ => _.Intersect(It.IsAny<Ray>())).Returns(new HitInfo());
            scene.AddObject(geoMock2.Object);
            //Act
            HitInfo actualHitInfo = scene.GetHitInfo(new Ray(), ignoreObjects);
            //Assert
            Assert.IsFalse(actualHitInfo.hasHit);
        }

        [Test]
        public void TestGetHitInfo_Object_OneinIgnoreList_AndOneNot_AndOneHit()
        {
            //Arrange
            scene = new Scene(new WindowFrame(500, 500, 1.0));
            List<GeometryObject> ignoreObjects = new List<GeometryObject>();
            Mock<GeometryObject> geoMock = new Mock<GeometryObject>();
            ignoreObjects.Add(geoMock.Object);
            scene.AddObject(geoMock.Object);
            Mock<GeometryObject> geoMock2 = new Mock<GeometryObject>();

            HitInfo hitInfo = new HitInfo();
            hitInfo.hasHit = true;
            hitInfo.tMin = 0.5;

            geoMock2.Setup(_ => _.Intersect(It.IsAny<Ray>())).Returns(hitInfo);
            scene.AddObject(geoMock2.Object);
            //Act
            HitInfo actualHitInfo = scene.GetHitInfo(new Ray(), ignoreObjects);
            //Assert
            Assert.IsTrue(actualHitInfo.hasHit && 
                          actualHitInfo.tMin.Equals(hitInfo.tMin));
        }

        [Test]
        public void TestGetHitInfo_Object_BothObjectsHit_Take_Minimum()
        {
            //Arrange
            scene = new Scene(new WindowFrame(500, 500, 1.0));
            List<GeometryObject> ignoreObjects = new List<GeometryObject>();
            Mock<GeometryObject> geoMock = new Mock<GeometryObject>();
            HitInfo hitInfo = new HitInfo();
            hitInfo.hasHit = true;
            hitInfo.tMin = 0.5;

            geoMock.Setup(_ => _.Intersect(It.IsAny<Ray>())).Returns(hitInfo);
            scene.AddObject(geoMock.Object);
            scene.AddObject(geoMock.Object);
            Mock<GeometryObject> geoMock2 = new Mock<GeometryObject>();

            HitInfo hitInfo2 = new HitInfo();
            hitInfo2.hasHit = true;
            hitInfo2.tMin = 0.9;

            geoMock2.Setup(_ => _.Intersect(It.IsAny<Ray>())).Returns(hitInfo);
            scene.AddObject(geoMock2.Object);
            //Act
            HitInfo actualHitInfo = scene.GetHitInfo(new Ray(), ignoreObjects);
            //Assert
            Assert.IsTrue(actualHitInfo.hasHit &&
                          actualHitInfo.tMin.Equals(hitInfo.tMin));
        }

        [Test]
        public void TestGetHitInfo_Object_BothObjectsHit_Take_Minimum_GreaterThanZero()
        {
            //Arrange
            scene = new Scene(new WindowFrame(500, 500, 1.0));
            List<GeometryObject> ignoreObjects = new List<GeometryObject>();
            Mock<GeometryObject> geoMock = new Mock<GeometryObject>();
            HitInfo hitInfo = new HitInfo();
            hitInfo.hasHit = true;
            hitInfo.tMin = 0.5;

            geoMock.Setup(_ => _.Intersect(It.IsAny<Ray>())).Returns(hitInfo);
            scene.AddObject(geoMock.Object);
            scene.AddObject(geoMock.Object);
            Mock<GeometryObject> geoMock2 = new Mock<GeometryObject>();

            HitInfo hitInfo2 = new HitInfo();
            hitInfo2.hasHit = true;
            hitInfo2.tMin = -0.9;

            geoMock2.Setup(_ => _.Intersect(It.IsAny<Ray>())).Returns(hitInfo);
            scene.AddObject(geoMock2.Object);
            //Act
            HitInfo actualHitInfo = scene.GetHitInfo(new Ray(), ignoreObjects);
            //Assert
            Assert.IsTrue(actualHitInfo.hasHit &&
                          actualHitInfo.tMin.Equals(hitInfo.tMin));
        }

        [Test]
        public void TestDisplayPixel_Valid_Color_White()
        {
            ColorRGB color = new ColorRGB(1.0, 1.0, 1.0);
            scene.DisplayPixel(1, 1, color);
            ColorRGB [, ]finalPixel = scene.GetFinalPixels();

            Assert.IsTrue(finalPixel[1,1].Equals(color));
        }

        [Test]
        public void TestDisplayPixel_InValid_Color()
        {
            ColorRGB color = new ColorRGB(1.5, 1.5, 1.5);
            scene.DisplayPixel(1, 1, color);
            ColorRGB[,] finalPixel = scene.GetFinalPixels();

            Assert.IsTrue(finalPixel[1, 1].Equals(Config.WHITE));
        }

        [Test]
        public void TestDisplayPixel_Valid_Color_Minimum_Black()
        {
            ColorRGB color = new ColorRGB(0);
            scene.DisplayPixel(1, 1, color);
            ColorRGB[,] finalPixel = scene.GetFinalPixels();

            Assert.IsTrue(finalPixel[1, 1].Equals(color));
        }

    }
}