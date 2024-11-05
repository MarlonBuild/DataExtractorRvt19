#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Computos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

#endregion

namespace ProSwift_DataExtractor
{
    [Transaction(TransactionMode.Manual)]
    public class WallFloorData : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            StringBuilder sbuilder = new StringBuilder();

            Units projectUnits = doc.GetUnits();
            FormatOptions FSup = projectUnits.GetFormatOptions(UnitType.UT_Area);
            DisplayUnitType UArea = FSup.DisplayUnits;

            Form1 formulario = new Form1(uidoc, doc, "WallFloor"); //Crea el formulario en el proyecto
            formulario.Show();

            return Result.Succeeded;
        }
    }


    [Transaction(TransactionMode.Manual)]
    public class PipeData : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            StringBuilder sbuilder = new StringBuilder();

            Units projectUnits = doc.GetUnits();
            FormatOptions FSup = projectUnits.GetFormatOptions(UnitType.UT_Area);
            DisplayUnitType UArea = FSup.DisplayUnits;

            Form1 formulario = new Form1(uidoc, doc, "Pipes"); //Crea el formulario en el proyecto
            formulario.Show();

            return Result.Succeeded;
        }
    }

}
