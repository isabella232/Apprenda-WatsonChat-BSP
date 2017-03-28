using System;
using System.Collections.Generic;
using System.Linq;
using Apprenda.API.Extension.Bootstrapping;
using System.IO;
using Apprenda.Services.Logging;
using HtmlAgilityPack;

namespace Apprenda.WatsonChat.BSP
{
    public class WatsonChatBSP : BootstrapperBase
    {
        private static readonly ILogger log = LogManager.Instance().GetLogger(typeof(WatsonChatBSP));

        public override BootstrappingResult Bootstrap(BootstrappingRequest bootstrappingRequest)
        {
            /*Provide the logic for your bootstrap policy. Within this method, you have access to the binaries of the component being deployed
             as well as custom properties, application and team information */


            var appPath = Path.Combine(bootstrappingRequest.ComponentPath, @"root\");
            string currPath = bootstrappingRequest.BootstrapperPath;

            try
            {
                //Insert Watson Chat HTML and add Watson Conversation API URL to Javascript
                List<string> watsonFiles = replaceWatsonChatToken(appPath, currPath);
                copyWatsonContent(currPath, appPath);
            }
            catch (Exception ex)
            {
                var errorMessage = string.Format("WatsonChatBSP Error: {0}\n{1}", ex, ex.StackTrace);
                log.Error(errorMessage);
            }

            return BootstrappingResult.Success();
        }

        public List<string> replaceWatsonChatToken(string appPath, string currPath)
        {
            var files = Directory.EnumerateFiles(appPath, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".html") || s.EndsWith(".cshtml") || s.EndsWith(".aspx"));

            List<string> watsonFiles = new List<string> { };
            HtmlDocument htmlDoc = new HtmlDocument();

            try{

                foreach (var f in files)
                {
                    htmlDoc.Load(f);
                    //find watsonchatidentifier tag within the html/cshtml/aspx
                    var watsonid = htmlDoc.DocumentNode.Descendants()
                                    .Where(n => n.Name == "watsonchatidentifier")
                                    .FirstOrDefault();

                    if (watsonid != null)
                    {
                        watsonFiles.Add(f);
                        var watsonChatHTML = File.ReadAllText(currPath + @"\WatsonContent\html\WatsonChat.html");
                        var parent = watsonid.ParentNode;
                        //Insert watson chat container html
                        parent.InsertAfter(htmlDoc.CreateTextNode(watsonChatHTML), watsonid);
                        //Remove watson tag after inserting WatsonChat.html
                        watsonid.Remove();
                        htmlDoc.Save(f);

                        //Replace API messageEndpoint with Apprenda Watson API 
                        //TODO use addon-token in non hybrid clouds
                        var alias = watsonid.GetAttributeValue("alias", "");
                        var apiPath = currPath + @"\WatsonContent\js\api.js";
                        var oldValue = @"messageEndpoint = """"";
                        var newValue = @"messageEndpoint = ""https://" + alias + @".$#CLOUDHOST#$" + @"/api/message""";
                        replaceText(apiPath, oldValue, newValue);
                    }

                }

            }catch(Exception)
            {
                throw;
            }

            return watsonFiles;
        }

        public void copyWatsonContent(string sourcePath, string targetPath)
        {
            var targetDir = targetPath + @"\WatsonContent";
            var sourceDir = sourcePath + @"\WatsonContent";
            DirectoryCopy(sourceDir, targetDir, true);
        }


        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private static void replaceText(string filePath, string oldValue, string newValue)
        {
            try
            {
                string text = File.ReadAllText(filePath);
                text = text.Replace(oldValue, newValue);
                File.WriteAllText(filePath, text);
            }catch(Exception ex)
            {
                log.Error("Unable to replaceText: " + ex);
                throw;
            }
        }
    }

}


