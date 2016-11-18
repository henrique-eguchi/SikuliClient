using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NETSikuliClient.Sikuli_REST;
using System.Drawing;

namespace NETSikuliClientTests
{
    [TestFixture]
    public class UnitTests
    {
		Pattern pattern_ChromeIcon = new Pattern(@"..\..\..\NETSikuliClientTests\ChromeIcon.png", 0.8);
		Pattern pattern_CloseChrome = new Pattern(@"..\..\..\NETSikuliClientTests\CloseChrome.png", new Point(0,-16));
        Pattern pattern_BrowserBar = new Pattern(@"..\..\..\NETSikuliClientTests\BrowserBar.png", new Point(30, 11));
        Pattern pattern_SikuliFavoriteIcon = new Pattern(@"..\..\..\NETSikuliClientTests\SikuliFavoriteIcon.png");
        Pattern pattern_SikuliIcon = new Pattern(@"..\..\..\NETSikuliClientTests\SikuliIcon.png");
		Pattern pattern_ChromeJumpList = new Pattern(@"..\..\..\NETSikuliClientTests\ChromeJumpList.png", 0.4);
		
        [Test]
        public void _01_TestFind()
        {
            Screen scrn = new Screen();
            scrn.Find(pattern_ChromeIcon);
        }

        [Test]
        public void _02_TestClick()
        {
            Screen scrn = new Screen();
            scrn.Click(pattern_ChromeIcon);
            scrn.Wait(pattern_CloseChrome);
            scrn.Click(pattern_CloseChrome);
        }

        [Test]
        public void _03_TestWait()
        {
            Screen scrn = new Screen();
            scrn.Wait(pattern_ChromeIcon, 10);
        }

        [Test]
        public void _04_TestWaitVanish()
        {
            Screen scrn = new Screen();
            bool vanished = scrn.WaitVanish(pattern_ChromeIcon, 10);
            Console.WriteLine("Pattern Vanished: " + vanished);
        }

        [Test]
        public void _05_TestExists()
        {
            Screen scrn = new Screen();
            bool exists = scrn.Exists(pattern_ChromeIcon, 10);
            Console.WriteLine("Pattern Exists: " + exists);
        }

        [Test]
        public void _06_TestKeyModifiedClick()
        {
            Screen scrn = new Screen();
            scrn.Click(pattern_ChromeIcon, KeyModifier.CTRL);
            scrn.Wait(pattern_CloseChrome);
            scrn.Click(pattern_CloseChrome);
        }

        [Test]
        public void _07_TestDoubleClick()
        {
            Screen scrn = new Screen();
            scrn.DoubleClick(pattern_ChromeIcon);
            scrn.Wait(pattern_CloseChrome);
            scrn.Click(pattern_CloseChrome);
        }

        [Test]
        public void _08_TestType()
        {
            Screen scrn = new Screen();
            scrn.Click(pattern_ChromeIcon);
            scrn.Wait(pattern_BrowserBar);
            scrn.Type(pattern_BrowserBar, "http://www.sikuli.org" + Key.ENTER);
            scrn.Wait(pattern_SikuliIcon);
            scrn.Click(pattern_CloseChrome);
        }

        [Test]
        public void _09_TestDragDrop()
        {
            Screen scrn = new Screen();
            scrn.Click(pattern_ChromeIcon);
            scrn.Wait(pattern_BrowserBar);
            scrn.DragDrop(pattern_SikuliFavoriteIcon, pattern_BrowserBar);
            scrn.Wait(pattern_SikuliIcon);
            scrn.Click(pattern_CloseChrome);
        }

        [Test]
        public void _10_TestHighlight()
        {
            Screen scrn = new Screen();
            scrn.Find(pattern_ChromeIcon, true);
            scrn.Click(pattern_ChromeIcon, true);
            scrn.Wait(pattern_CloseChrome);
            scrn.Click(pattern_CloseChrome, true);
        }
		
		[Test]
		public void _11_TestRightClick()
		{
			Screen scrn = new Screen();
			scrn.RightClick(pattern_ChromeIcon, true);
			scrn.Find(pattern_ChromeJumpList,true);
		}
    }

    [SetUpFixture]
    public class UnitTestSetup
    {

        [SetUp]
        public void RunBeforeAnyTests()
        {
            
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            
        }
    }
}
