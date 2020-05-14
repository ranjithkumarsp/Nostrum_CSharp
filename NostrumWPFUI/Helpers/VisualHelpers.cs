using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Nostrum.Helpers
{
    public static class VisualHelpers
    {
        public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null)
            {
                return null;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        //finds all children
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static T GetVisualChild<T>(DependencyObject parent) where T : Visual
        {
            T child = default(T);

            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < numVisuals; i++)
            {
                var visual = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = visual as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(visual);
                }

                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        //Get first parent control of specified type
        public static T GetVisualParent<T>(UIElement element) where T : UIElement
        {
            var parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;

        }

        public static T GetVisualParent01<T>(DependencyObject child) where T : DependencyObject
        {
            T parent = null;
            DependencyObject currParent;

            currParent = VisualTreeHelper.GetParent(child);
            while (currParent != null)
            {
                if (currParent is T)
                {
                    parent = (T)currParent;
                    break;
                }

                // find the next parent
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            return (parent);
        }

        //Get first parent control of specified type
        public static T GetVisualParentByObject<T>(DependencyObject depObj) where T : DependencyObject
        {
            var parent = depObj;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as DependencyObject;
            }
            return null;

        }

        public static List<T> GetLogicalChildrenCollection<T>(object parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }

        private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(parent);

            foreach (object child in children)
            {
                if (child is DependencyObject)
                {
                    DependencyObject depChild = child as DependencyObject;
                    if (child is T)
                    {
                        logicalCollection.Add(child as T);
                    }
                    GetLogicalChildCollection(depChild, logicalCollection);
                }
            }

        }

        #region Usecases
        //FindVisualChildren
        // var buttons = VisualElementHelpers.FindVisualChildren<Button>View
        //var buttons = VisualElementHelpers.FindVisualChildren<Button>(parent);
        //foreach(var btn in buttons)
        //{
        //    btn.Foreground = Brushes.DarkRed;
        //}
        //var TextBlocks = VisualElementHelpers.FindVisualChildren<TextBlock>(parent);
        //foreach (var TextBlock in TextBlocks)
        //{
        //    TextBlock.Foreground = Brushes.DarkRed;
        //}
        //GetVisualChild<T>
        //Window mw = MainWindow as Window;
        //BillingView billviewmw = VisualElementHelpers.GetVisualChild<UserControl>(mw).FindName("BillingViewMainView") as BillingView;
        //ExcelImportView _excelImportView = VisualElementHelpers.GetVisualChild<UserControl>(mw).FindName("ExcelImportMainView") as ExcelImportView;
        //UserControl _paymentMainView = VisualElementHelpers.GetVisualChild<UserControl>(mw).FindName("PaymentMainView") as UserControl;
        //// BillingView billvw = MainWindow.FindName("BillingViewMainView") as BillingView;
        //TextBox finyeartextbox = billviewmw.FindName("FinancialYear") as TextBox;
        ////find parent of TextBox finyeartextbox
        //var parentoftextbox = VisualElementHelpers.GetVisualParent<UserControl>(finyeartextbox);
        //UserControl _paymentMainView1 = VisualElementHelpers.GetVisualParentByObject<UserControl>(mw);
        //get childusercontrols
        //   
        //    var usercontrolsinmainwindow = VisualElementHelpers.GetLogicalChildrenCollection<UserControl>(mw);
        //    ExcelImportView ex1 = usercontrolsinmainwindow.Where(x => x.Name.Equals("ExcelImportMainView")).FirstOrDefault() as ExcelImportView;
        //            if(ex1 != null)
        //            {
        //                //var ex1 = ex.FirstOrDefault() as ExcelImportView;
        //                ex1.CLEAN(true);
        //            }
        //            foreach (var usrctrl in usercontrolsinmainwindow)
        //            {
        //                if (usrctrl.Name.Equals("ExcelImportMainView"))
        //                {
        //                    var excel = usrctrl as ExcelImportView;
        //excel.CLEAN(true);
        //                }
        //            }
        #endregion
    }
}
