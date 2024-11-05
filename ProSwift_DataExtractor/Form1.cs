/*
 * Creado por SharpDevelop.
 * Usuario: Marlon
 * Fecha: 11/9/2024
 * Hora: 19:12
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace Computos
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : System.Windows.Forms.Form
	{
		private UIDocument _uidoc;
		private Document _doc;
		private IList <Element> selectedElements = new List<Element>();
		private string _selectionType;
		
		public Form1(UIDocument uidoc, Document doc, string selectionType)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			_uidoc = uidoc;
			_doc = doc;
			_selectionType = selectionType;
			
			StringBuilder sbuilder = new StringBuilder();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Btn_SeleccionarClick(object sender, EventArgs e)
		{
			if (_selectionType == "WallFloor") 
			{
				try
				{
					Units projectUnits = _doc.GetUnits();
					FormatOptions FSup = projectUnits.GetFormatOptions(UnitType.UT_Area);
					FormatOptions FLong = projectUnits.GetFormatOptions(UnitType.UT_Length);
					DisplayUnitType UArea = FSup.DisplayUnits;
					DisplayUnitType ULong = FLong.DisplayUnits;
					
					//string UnitLong = UnitFormatUtils.Format(_doc.GetUnits(), UnitType.UT_Length, 1.0, false, false, FLong);
					//MessageBox.Show(UnitLong);
					
					ISelectionFilter wallFilter = new UTILITARIOS.FiltrosSeleccion.WallSelectionFilter();
					ISelectionFilter floorFilter = new UTILITARIOS.FiltrosSeleccion.FloorSelectionFilter();
					ISelectionFilter ceilingFilter = new UTILITARIOS.FiltrosSeleccion.CeilingSelectionFilter();
					
					IList<BuiltInCategory> allowedCategories = new List<BuiltInCategory>
					{
						BuiltInCategory.OST_Walls,
						BuiltInCategory.OST_Floors,
						BuiltInCategory.OST_Ceilings
					};
					
					UTILITARIOS.FiltrosSeleccion.MultiCategorySelectionFilter filter = new UTILITARIOS.FiltrosSeleccion.MultiCategorySelectionFilter(allowedCategories);
					
					IList <Reference> selectedElementRef = _uidoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, filter, "Selecciona Elementos");
					selectedElements.Clear();
					lbox_Datos.Items.Clear();
					
					double areaTotal = 0;
					Reference firstE = selectedElementRef[0];
					Element ee = _doc.GetElement(firstE);
					Parameter eePSup = ee.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);
					//DisplayUnitType unitTypeSup = eePSup.DisplayUnitType;
					//string unitsymbol = LabelUtils.GetLabelFor(unitTypeSup);
					
					foreach (Reference r in selectedElementRef)
					{
						Element element = _doc.GetElement(r);
						selectedElements.Add(element);
						
						string name = element.Name.ToString();
						Parameter PSup = element.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);
						//DisplayUnitType unitTypeSup = PSup.DisplayUnitType;
						//string unitsymbol = LabelUtils.GetLabelFor(unitTypeSup);
						double area = PSup.AsDouble();
						double supconv = Math.Round(UnitUtils.ConvertFromInternalUnits(area, UArea),2);
						areaTotal += supconv;
						string item = name + " - " + supconv.ToString();
						lbox_Datos.Items.Add(item);
					}
					
					lbl_tagTotal.Text = "Total Sup.";
					lbl_Total.Text = areaTotal.ToString();	
				} 
				
				catch (Autodesk.Revit.Exceptions.OperationCanceledException) 
				{
					MessageBox.Show("Selección Cancelada");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message);
				}
			}
			
			if (_selectionType == "Pipes") 
			{
				try
				{
					Units projectUnits = _doc.GetUnits();
					FormatOptions FSup = projectUnits.GetFormatOptions(UnitType.UT_Area);
					FormatOptions FLong = projectUnits.GetFormatOptions(UnitType.UT_Length);
					DisplayUnitType UArea = FSup.DisplayUnits;
					DisplayUnitType ULong = FLong.DisplayUnits;
					
					//string UnitLong = UnitFormatUtils.Format(_doc.GetUnits(), UnitType.UT_Length, 1.0, false, false, FLong);
					//MessageBox.Show(UnitLong);
					
					
					IList<BuiltInCategory> allowedCategories = new List<BuiltInCategory>
					{
						BuiltInCategory.OST_PipeCurves,
						BuiltInCategory.OST_FlexPipeCurves,
					};
					
					UTILITARIOS.FiltrosSeleccion.MultiCategorySelectionFilter filter = new UTILITARIOS.FiltrosSeleccion.MultiCategorySelectionFilter(allowedCategories);
					
					IList <Reference> selectedElementRef = _uidoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, filter, "Selecciona Elementos");
					selectedElements.Clear();
					lbox_Datos.Items.Clear();
					
					double longTotal = 0;
					Reference firstE = selectedElementRef[0];
					Element ee = _doc.GetElement(firstE);
					Parameter eePSup = ee.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);
					//DisplayUnitType unitTypeSup = eePSup.DisplayUnitType;
					//string unitsymbol = LabelUtils.GetLabelFor(unitTypeSup);
					
					foreach (Reference r in selectedElementRef)
					{
						Element element = _doc.GetElement(r);
						selectedElements.Add(element);
						
						string name = element.Name.ToString();
						Parameter PLenght = element.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
						double lenght = PLenght.AsDouble();
						double lenconv = Math.Round(UnitUtils.ConvertFromInternalUnits(lenght, ULong),2);
						longTotal += lenconv;
						string item = name + " - " + lenconv.ToString();
						lbox_Datos.Items.Add(item);
					}
					
					lbl_tagTotal.Text = "Total Longitud";
					lbl_Total.Text = longTotal.ToString();	
				} 
				
				catch (Autodesk.Revit.Exceptions.OperationCanceledException) 
				{
					MessageBox.Show("Selección Cancelada");
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message);
				}
			}
			
			
			
			
		}
		
		void Btn_CancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
