using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace library_management_tracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int bookCount = 0;
        private const int maxBooks = 18;
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
           if (bookCount >= maxBooks)
            {
                await ShowMessage("You've reached the maximum limit");
                return;
            }
           bookCount++;
            txtBookCount.Text = $"Books Added: {bookCount}";
            await ShowMessage("Book added successfully");
        }
        private async void CopyInfo_Click(object sender, RoutedEventArgs e)
        {
            string info = $"Title: {txtTitle.Text}\n" +
                $"Author: {txtAuthor.Text}\n" +
                $"Year: {txtYear.Text}\n" +
                $"Total Books: {bookCount}";
            await ShowMessage(info);
        }

        private async void ResetForm_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtYear.Text = "";
            bookCount = 0;
            txtBookCount.Text = $"Books Added: {bookCount}";
            await ShowMessage("Form reset successfully");
        }

        private async System.Threading.Tasks.Task ShowMessage(string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Library Management Tracker",
                Content = message,
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }
    }
}
