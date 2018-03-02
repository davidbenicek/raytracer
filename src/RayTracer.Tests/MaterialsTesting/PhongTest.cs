using System;
using System.Collections.Generic;
using NUnit.Framework;
using RayTracer.Models.Elements;
using RayTracer.Models.Geometric;
using RayTracer.Models.Lights;
using RayTracer.Models.Materials;
using RayTracer.Models.SceneElements;
using RayTracer.Models.Util;

namespace RayTracer.Tests.MaterialsTesting
{
    [TestFixture]
    public class PhongTest
    {
        HitInfo hitInfo;
        Phong testPhong;
        Scene scene;
        AmbientLight ambLight;

        [TestFixtureSetUp]
        public void Init()
        {
            hitInfo = new HitInfo();
            hitInfo.hasHit = true;
            hitInfo.hitObject = new Sphere(new Point3D(-50, 0, 60), 30, new Metal(new ColorRGB(1,0, 0)));
            testPhong = new Phong();
            ambLight = new AmbientLight(new ColorRGB(0, 1, 0));
        }

        [Test]
        public void TestCalculateShadeWithEmptyLightsListAndNoAmbientLight()
        {
            //Arrange
            scene = new Scene(new WindowFrame(2000, 2000, 1.0));
            //Act
            ColorRGB colorResult = testPhong.CalculateShade(hitInfo,scene);
            //Assert
            Assert.IsNotNull(colorResult);
        }

        [Test]
        public void TestCalculateShadeWithEmptyLightsListAndAmbientLight()
        {
            //Arrange
            scene = new Scene(new WindowFrame(2000, 2000, 1.0));
            scene.SetAmbientLight(ambLight);
            //Act
            ColorRGB colorResult = testPhong.CalculateShade(hitInfo, scene);
            //Assert
            Assert.IsNotNull(colorResult);
        }

        [Test]
        public void TestCalculateShadeWithLightsListAndNoAmbientLight()
        {
            //Arrange
            scene = new Scene(new WindowFrame(2000, 2000, 1.0));
            Point3D lightPos = new Point3D(100);
            ColorRGB lightColor = new ColorRGB(1,0,0);
            scene.AddLight(new Light(lightPos, lightColor));
            //Act
            ColorRGB colorResult = testPhong.CalculateShade(hitInfo, scene);
            //Assert
            Assert.IsNotNull(colorResult);
        }

        [Test]
        public void TestCalculateShadeWithLightsListAndWithAmbientLight()
        {
            //Arrange
            scene = new Scene(new WindowFrame(2000, 2000, 1.0));
            scene.SetAmbientLight(ambLight);
            Point3D lightPos = new Point3D(100);
            ColorRGB lightColor = new ColorRGB(1, 0, 0);
            scene.AddLight(new Light(lightPos, lightColor));
            //Act
            ColorRGB colorResult = testPhong.CalculateShade(hitInfo, scene);
            //Assert
            Assert.IsNotNull(colorResult);
        }

    }
}
