using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;

namespace WPF_Selection
{
  [Transaction(TransactionMode.Manual)]
  public class MainSelection : IExternalCommand
  {
    public Result Execute (ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIDocument uidoc = commandData.Application.ActiveUIDocument;
        Document doc = uidoc.Document;
      try
      {
        Filter filter = new Filter();
        UISelection uiSelection = new UISelection(doc);
        uiSelection.ShowDialog();
        IList<Reference> eleReferences = uidoc.Selection.PickObjects(ObjectType.Element, filter, "Please Pick Some Object");
        StringBuilder prompt = new StringBuilder();
        int selectedNumber = 0;
        foreach(Reference ele in eleReferences)
        {
        doc.GetElement(ele);
          selectedNumber++;
          prompt.Append($"Element Number{selectedNumber} Name => " + doc.GetElement(ele).Name + Environment.NewLine);
        }
        TaskDialog.Show("Revit", "You have selected \n " + prompt.ToString());

        return Result.Succeeded;
      }
      catch(Exception ex)
      {
        message = ex.Message;
        return Result.Failed;
      }
    }
  }
}
