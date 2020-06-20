using Nostrum.UIEntity;
using Nostrum.ViewModel;
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

namespace Nostrum.View
{
    /// <summary>
    /// Interaction logic for StockDisplayPopupView.xaml
    /// </summary>
    public partial class StockDisplayPopupView : Window
    {
        //List<object> myList = new List<object>();
        List<StockDisplay> myList = new List<StockDisplay>();
        
        public StockDisplayPopupView(string prod, DateTime from, DateTime to) 
        {
            InitializeComponent();
            StockDisplayPopupViewModel vm = new StockDisplayPopupViewModel(prod, from, to);
            myList = vm.StockDisplayCollection.ToList(); 
            this.DataContext = vm;           
            _Initialize();

        }

        #region Paging

        int pageIndex = 1;
        private int numberOfRecPerPage;
        //To check the paging direction according to use selection.
        private enum PagingMode { First = 1, Next = 2, Previous = 3, Last = 4, PageCountChange = 5 };

        public void _Initialize()
        {
            cbNumberOfRecords.Items.Add("15");
            cbNumberOfRecords.Items.Add("30");
            cbNumberOfRecords.Items.Add("45");
            cbNumberOfRecords.Items.Add("60");
            cbNumberOfRecords.Items.Add("75");
            cbNumberOfRecords.Items.Add("90");
            cbNumberOfRecords.Items.Add("100");
            cbNumberOfRecords.SelectedItem = 15;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Loaded += StockDisplayPopupView_Loaded;
        }

        private void StockDisplayPopupView_Loaded(object sender, RoutedEventArgs e)
        {
            //myList = GetData();
            OutstandingPaymentGrid.ItemsSource = myList.Take(numberOfRecPerPage);
            int count = myList.Take(numberOfRecPerPage).Count();
            lblpageInformation.Content = count + " of " + myList.Count;
        }

        #region Button Actions

        private void btnFirst_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.First);
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Next);

        }

        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Previous);

        }

        private void btnLast_Click(object sender, System.EventArgs e)
        {
            Navigate((int)PagingMode.Last);
        }

        private void cbNumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigate((int)PagingMode.PageCountChange);
        }

        #endregion

        private void Navigate(int mode)
        {
            int count;
            switch (mode)
            {
                case (int)PagingMode.Next:
                    btnPrev.IsEnabled = true;
                    btnFirst.IsEnabled = true;
                    if (myList.Count >= (pageIndex * numberOfRecPerPage))
                    {
                        if (myList.Skip(pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage).Count() == 0)
                        {
                            OutstandingPaymentGrid.ItemsSource = null;
                            OutstandingPaymentGrid.ItemsSource = myList.Skip((pageIndex * numberOfRecPerPage) - numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = (pageIndex * numberOfRecPerPage) + (myList.Skip(pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage)).Count();
                        }
                        else
                        {
                            OutstandingPaymentGrid.ItemsSource = null;
                            OutstandingPaymentGrid.ItemsSource = myList.Skip(pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = (pageIndex * numberOfRecPerPage) + (myList.Skip(pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage)).Count();
                            pageIndex++;
                        }

                        lblpageInformation.Content = count + " of " + myList.Count;
                    }

                    else
                    {
                        btnNext.IsEnabled = false;
                        btnLast.IsEnabled = false;
                    }

                    break;
                case (int)PagingMode.Previous:
                    btnNext.IsEnabled = true;
                    btnLast.IsEnabled = true;
                    if (pageIndex > 1)
                    {
                        pageIndex -= 1;
                        OutstandingPaymentGrid.ItemsSource = null;
                        if (pageIndex == 1)
                        {
                            OutstandingPaymentGrid.ItemsSource = myList.Take(numberOfRecPerPage);
                            count = myList.Take(numberOfRecPerPage).Count();
                            lblpageInformation.Content = count + " of " + myList.Count;
                        }
                        else
                        {
                            OutstandingPaymentGrid.ItemsSource = myList.Skip(pageIndex * numberOfRecPerPage).Take(numberOfRecPerPage);
                            count = Math.Min(pageIndex * numberOfRecPerPage, myList.Count);
                            lblpageInformation.Content = count + " of " + myList.Count;
                        }
                    }
                    else
                    {
                        btnPrev.IsEnabled = false;
                        btnFirst.IsEnabled = false;
                    }
                    break;

                case (int)PagingMode.First:
                    pageIndex = 2;
                    Navigate((int)PagingMode.Previous);
                    break;
                case (int)PagingMode.Last:
                    pageIndex = (myList.Count / numberOfRecPerPage);
                    Navigate((int)PagingMode.Next);
                    break;

                case (int)PagingMode.PageCountChange:
                    pageIndex = 1;
                    numberOfRecPerPage = Convert.ToInt32(cbNumberOfRecords.SelectedItem);
                    OutstandingPaymentGrid.ItemsSource = null;
                    OutstandingPaymentGrid.ItemsSource = myList.Take(numberOfRecPerPage);
                    count = (myList.Take(numberOfRecPerPage)).Count();
                    lblpageInformation.Content = count + " of " + myList.Count;
                    btnNext.IsEnabled = true;
                    btnLast.IsEnabled = true;
                    btnPrev.IsEnabled = true;
                    btnFirst.IsEnabled = true;
                    break;
            }
        }


        #endregion

    }
}
