#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Media.Imaging;

#endregion

namespace ProSwift_DataExtractor
{
    internal class App : IExternalApplication
    {
        
        string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().Location;

        private BitmapImage LoadImage(string resourceName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    return image;
                }
                return null;
            }
        }

        public Result OnStartup(UIControlledApplication a)
        {
            string nameTab = "ProSwift";
            try
            {
                a.CreateRibbonTab(nameTab);
            }
            catch 
            {

            }

            RibbonPanel barra = null;
            string namePanel = "DataExtractor";
            List<RibbonPanel> listPanel = a.GetRibbonPanels(nameTab);
            foreach(RibbonPanel rpanel in listPanel)
            {
                if (rpanel.Name == namePanel)
                {
                    barra = rpanel; break;
                }
            }
            if (barra == null) { barra = a.CreateRibbonPanel(nameTab, namePanel); }

            PushButtonData btnDataWF = new PushButtonData("WallFloorData", "WallFloorData", AssemblyName, "ProSwift_DataExtractor.WallFloorData");
            PushButtonData btnDataPipe = new PushButtonData("PipeData", "PipeData", AssemblyName, "ProSwift_DataExtractor.PipeData");

            PushButton btnWFD = barra.AddItem(btnDataWF) as PushButton;
            PushButton btnPipe = barra.AddItem(btnDataPipe) as PushButton;
            btnWFD.ToolTip = "Extract the data from the selected walls, floors, ceilings, and roofs.";
            btnPipe.ToolTip = "Extract the data from the selected Pipes and FlexPipes";

            btnWFD.LargeImage = LoadImage("ProSwift_DataExtractor.IconWallExtractor.png");
            btnPipe.LargeImage = LoadImage("ProSwift_DataExtractor.IconPipeD.png");
            //btnWFD.LargeImage = new BitmapImage(new Uri(@"C:\Users\Marlon\source\repos\ProSwift_DataExtractor\Icono WallExtractor.png"));
            //btnPipe.LargeImage = new BitmapImage(new Uri(@"C:\Users\Marlon\source\repos\ProSwift_DataExtractor\IconPipeD.png"));

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
