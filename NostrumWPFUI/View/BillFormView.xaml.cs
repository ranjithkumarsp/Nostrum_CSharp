using NostrumWPFUI.ViewModel;
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
using System.Windows.Shapes;

using Entity;
using NostrumWPFUI.Helpers;

namespace NostrumWPFUI.View
{
    /// <summary>
    /// Interaction logic for BillFormView.xaml
    /// </summary>
    public partial class BillFormView : Window,IClosable
    {
        public BillFormView(Order order, List<LineItem> lineItems)
        {
            InitializeComponent();
            this.DataContext = new BillFormViewModel(order, lineItems);
        }
        public void ClosePopupWindow()
        {
            this.Close();
        }
        public void HidePopupWindow()
        {
            throw new NotImplementedException();
        }

        //tomake scroll over DataGrid

        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent?.RaiseEvent(eventArg);
            }
        }       

        public void Print_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //Double _RowHeight = 30;
            //if (DiscountTxtBox.Text.Equals("0"))
            //  _RowHeight = 35;
            //else            
            // _RowHeight = 30;

            //RowDefinition r1 = new RowDefinition();
            //RowDefinition r2 = new RowDefinition(); 
            //RowDefinition r3 = new RowDefinition();
            //RowDefinition r4 = new RowDefinition(); 
            //RowDefinition r5 = new RowDefinition();
            //RowDefinition r6 = new RowDefinition();
            //RowDefinition r7 = new RowDefinition();


            //Value_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            //if (DiscountTxtBox.Text.Equals("0"))
            //    Discount_row.Height = new GridLength(0, GridUnitType.Pixel);
            //else
            //    Discount_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            //Net_Value_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            //CGST_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            //SGST_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            //Total_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            //InvoiceAmount_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);

            SetRowDefinitions(false);

        }

        public void SetRowDefinitions(bool _canshowDiscount)
        {            
            Double _RowHeight = 30;
            if (DiscountTxtBox.Text.Equals("0") && !_canshowDiscount)
                _RowHeight = 35;
            else
                _RowHeight = 30;  

            Value_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            if (DiscountTxtBox.Text.Equals("0") && !_canshowDiscount)
                Discount_row.Height = new GridLength(0, GridUnitType.Pixel);
            else
                Discount_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            Net_Value_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            CGST_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            SGST_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            Total_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
            InvoiceAmount_row.Height = new GridLength(_RowHeight, GridUnitType.Pixel);
        }


    }
}
