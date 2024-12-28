using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Selection
{
  internal partial class Filter : ISelectionFilter
  {
    public bool AllowElement (Element elem)
    {
        return (BuiltInCategory)(elem?.Category?.Id?.IntegerValue ?? -1) == (BuiltInCategory)Enum.Parse(typeof(BuiltInCategory), UISelection.BTC); 
    }

    public bool AllowReference (Reference reference, XYZ position)
    {
      return false;
    }
 

  }
}
