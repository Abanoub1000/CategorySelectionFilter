using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI.Selection;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace WPF_Selection
{
  /// <summary>
  /// Interaction logic for UISelection.xaml
  /// </summary>
  public partial class UISelection : Window
  {
    public static string BTC { get; set; }
    
    public UISelection (Autodesk.Revit.DB.Document doc)
    {
      InitializeComponent();
      UIDocument uidoc = new UIDocument(doc);
    
      ICollection<ElementId> selectedElemIds = uidoc.Selection.GetElementIds();
      HashSet<BuiltInCategory> builtInCategories = new HashSet<BuiltInCategory>();
      
      foreach (var eleId in selectedElemIds)
      {
        
        BuiltInCategory collection = (BuiltInCategory)(doc.GetElement(eleId).Category.Id.IntegerValue);
        builtInCategories.Add(collection);
      }
      foreach (var builtInCategory in builtInCategories)
      {
        
        RadioButton radioButton = new RadioButton
        {
          Name = builtInCategory.ToString(),
          Content = builtInCategory.ToString().Substring(4),
          Margin = new Thickness(10),
          Tag = new {builtInCategory}
          
        };
        RadioButtonPanel.Children.Add(radioButton);
      }
    }

    private void CheckSelectedButtion_Click (object sender, RoutedEventArgs e)
    {
        foreach(var chaild in RadioButtonPanel.Children)
      {
        if (chaild is RadioButton radioButton)
        {
          if (radioButton.IsChecked == true)
          {
            if(radioButton.Tag != null)
            {
            BTC = radioButton.Name;

            }
            else
            {
              MessageBox.Show("Tag is null");
            }
            
            MessageBox.Show($"Selected = {radioButton.Name}");
          }
        }
      }
      this.Close();
    }
  }
}
