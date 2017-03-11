using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using Apprenda.WatsonChat.BSP;

namespace Apprenda.WatsonChat.BSP_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testbsp()
        {
            var path = @"C:\Users\jtruncale\Desktop\test\directory";//@"C:\Users\jtruncale\Projects\WebapiSampleApp\WebapiSampleApp\Views\Home ";//
            //string currPath = "";//AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var currPath = @"C:\Users\jtruncale\Projects\Apprenda-WatsonChat-BSP\src\WatsonChatBSP-Test\bin\Debug";
            WatsonChatBSP test = new WatsonChatBSP();
            var watsonFiles = test.replaceWatsonChatToken(path, currPath);
            test.copyWatsonContent(currPath, path);
        }
    }
}
