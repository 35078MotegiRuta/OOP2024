using CustomerApp.Objects;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CustomerApp {
    public partial class MainWindow : Window {
        private List<Customer> _customers;
        private string _selectedImagePath;

        public MainWindow() {
            InitializeComponent();
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ReadDatabase();
        }

        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                _customers = connection.Table<Customer>().ToList();
            }
            CustomerListView.ItemsSource = _customers;
        }

        private void ResistButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text)) {
                return;
            }

            byte[] imageData = null;
            if (_selectedImagePath != null) {
                imageData = ConvertImageToByteArray(_selectedImagePath);
            }

            var customer = new Customer {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImageData = imageData
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.Insert(customer);
            }

            ReadDatabase();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer == null) {
                MessageBox.Show("更新する顧客を選択してください");
                return;
            }

            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;

            if (_selectedImagePath != null) {
                byte[] imageBytes = File.ReadAllBytes(_selectedImagePath);
                selectedCustomer.ImageData = imageBytes;
            } else {
                selectedCustomer.ImageData = null;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.Update(selectedCustomer);
            }

            ReadDatabase();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e) {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            AddressTextBox.Clear();

            CustomerImage.Source = null;
            _selectedImagePath = null;

            CustomerListView.SelectedItem = null;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する顧客を選択してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.Delete(item);
            }

            ReadDatabase();
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true) {
                _selectedImagePath = openFileDialog.FileName;
                byte[] imageData = ConvertImageToByteArray(_selectedImagePath);

                CustomerImage.Source = new BitmapImage(new Uri(_selectedImagePath));
            }
        }

        private byte[] ConvertImageToByteArray(string imagePath) {
            return File.ReadAllBytes(imagePath);
        }

        private void ClearImageButton_Click(object sender, RoutedEventArgs e) {
            CustomerImage.Source = null;
            _selectedImagePath = null;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;

                if (selectedCustomer.ImageData != null && selectedCustomer.ImageData.Length > 0) {
                    using (var ms = new MemoryStream(selectedCustomer.ImageData)) {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = ms;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        CustomerImage.Source = bitmap;
                    }
                } else {
                    CustomerImage.Source = null;
                }
            }
        }
    }
}
