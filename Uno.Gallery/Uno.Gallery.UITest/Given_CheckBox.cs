﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Uno.UITest.Helpers.Queries;
using Uno.UITests.Helpers;
using Query = System.Func<Uno.UITest.IAppQuery, Uno.UITest.IAppQuery>;

namespace Uno.Gallery.UITests
{
    public class Given_CheckBox : TestBase
    {
        [Test]
        public void When_ClickMaterial()
        {
            if(AppInitializer.GetLocalPlatform() == Platform.Android)
			{
                Assert.Ignore();
			}

            Query section = q => q.All().Marked("Section_CheckBox");
            QueryEx uncheckedBox = new QueryEx(q => q.All().Marked("Material_Unchecked"));

            App.WaitForElement(section);
            App.Tap(section);

            TakeScreenshot("Opened");

            App.WaitForElement(uncheckedBox);
            App.Tap(uncheckedBox);

            TakeScreenshot("Opened");

            Assert.IsTrue(uncheckedBox.GetDependencyPropertyValue<bool>("IsChecked"));
        }
    }
}
