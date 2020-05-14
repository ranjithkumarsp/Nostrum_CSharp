using Entity;
using Nostrum.Helpers;
using Nostrum.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nostrum.View
{
    /// <summary>
    /// Interaction logic for BillFormView.xaml
    /// </summary>
    public partial class BillFormView : Window, IClosable
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
