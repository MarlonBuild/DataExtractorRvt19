using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace UTILITARIOS
{
	class FiltrosSeleccion
	{
		public class GenericSelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			static string CategoryName = "";

			public GenericSelectionFilter(string name)
			{
				CategoryName = name;
			}
			public bool AllowElement(Element element)
			{
				if (element.Category == null) { return false; }
				if (element.Category.Name == CategoryName)
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class RvtLinkSelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category.Name == "RVT Links")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}
		
		// Clase que implementa el filtro para múltiples categorías
		public class MultiCategorySelectionFilter : ISelectionFilter
		{
		    private HashSet<BuiltInCategory> _allowedCategories;
		
		    public MultiCategorySelectionFilter(IEnumerable<BuiltInCategory> allowedCategories)
		    {
		        _allowedCategories = new HashSet<BuiltInCategory>(allowedCategories);
		    }
		
		    // Este método determina si un elemento es seleccionable según su categoría
		    public bool AllowElement(Element elem)
		    {
		        if (elem.Category != null && _allowedCategories.Contains((BuiltInCategory)elem.Category.Id.IntegerValue))
		        {
		            return true;
		        }
		        return false;
		    }
		
		    // No permitimos la selección de referencias, solo de elementos completos
		    public bool AllowReference(Reference reference, XYZ position)
		    {
		        return false;
		    }
		}


		public class ColumnSelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category.Name == "Structural Columns")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}
		
		public class CeilingSelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if(element.Category.Id.IntegerValue ==(int)BuiltInCategory.OST_Ceilings)//UNIVERSAL
//				if (element.Category.Name == "Walls" || element.Category.Name == "Stacked Walls")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class FramingSelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category.Name == "Structural Framing")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class WallSelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if(element.Category.Id.IntegerValue ==(int)BuiltInCategory.OST_Walls)//UNIVERSAL
//				if (element.Category.Name == "Walls" || element.Category.Name == "Stacked Walls")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class FloorSelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if(element.Category.Id.IntegerValue ==(int)BuiltInCategory.OST_Floors)//UNIVERSAL
				//if (element.Category.Name == "Floors")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class FoundationSelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category.Name == "Structural Foundations")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class RoomSelectionFilter : ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category == null) { return false; }
				if (element.Category.Name == "Rooms")
				{
					FamilyInstance viga_fi = element as FamilyInstance;
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class PipeSelectionFilter : ISelectionFilter
		{
			public bool AllowElement(Element element)
			{

				if (element.Category.Name == "Pipes" || element.Category.Name == "Tuberías")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class PipeFittingSelectionFilter : ISelectionFilter
		{
			public bool AllowElement(Element element)
			{

				if (element.Category.Name == "Pipe Fittings")//|| element.Category.Name == "Conector Tuberia")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class PipeConduitSelectionFilter : ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category.Name == "Pipes" || element.Category.Name == "Conduits")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class ConduitSelectionFilter : ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category.Name == "Conduits")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class FamilyInstFilter : ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element is FamilyInstance)
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class PlumbingFixtureSelectionFilter : ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element is FamilyInstance && element.Category.Name == "Plumbing Fixtures")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class DoorWindowFilter : ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category.Name == "Doors" || element.Category.Name == "Windows")
				{
					return true;
				}
				return false;
			}

			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}
		public class SprinklerFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element is FamilyInstance && element.Category.Name == "Sprinklers")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

		public class RailingFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category.Name == "Railings")
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}


		public class CategoryModelFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
		{
			public bool AllowElement(Element element)
			{
				if (element.Category.CategoryType == CategoryType.Model && element.Category.CanAddSubcategory == true)
				{
					return true;
				}
				return false;
			}
			public bool AllowReference(Reference refer, XYZ point)
			{
				return false;
			}
		}

	}

}