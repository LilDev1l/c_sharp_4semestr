using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using lab10.ViewModels.Base;
using lab10.Model;
using lab10.Infrastructure.Commands;
using System.Data.SqlClient;
using lab10.db.model;
using System.Configuration;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;

namespace lab10.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _pathIcon = null;

        #region Model

        #region Products
        private ObservableCollection<ProductInfo> _products;
        public ObservableCollection<ProductInfo> Products
        {
            get => _products;
            set => Set(ref _products, value);
        }
        #endregion

        #region Name
        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        #endregion

        #region Qty
        private int _qty;
        public int Qty
        {
            get => _qty;
            set => Set(ref _qty, value);
        }
        #endregion

        #region Weight
        private int _weight;
        public int Weight
        {
            get => _weight;
            set => Set(ref _weight, value);
        }
        #endregion

        #region SelectedProduct
        private ProductInfo _selectedProduct;
        public ProductInfo SelectedProduct
        {
            get => _selectedProduct;
            set => Set(ref _selectedProduct, value);
        }
        #endregion

        #endregion

        #region Команды

        #region LoadedCommand
        public ICommand LoadedCommand { get; }
        private bool CanLoadedCommandExecute(object p) => true;
        private void OnLoadedCommandExecuted(object p)
        {
            ObservableCollection<ProductInfo> products = new ObservableCollection<ProductInfo>();

            string sqlExpression = "sp_GetProductsInfo";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connect"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            byte[] photoByteArray = (byte[])reader.GetValue(5);
                            BitmapFrame bitmapImage;
                            using (var ms = new MemoryStream(photoByteArray))
                            {
                                bitmapImage = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                            }

                            ProductInfo product = new ProductInfo()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Weight = reader.GetInt32(2),
                                Qty = reader.GetInt32(3),
                                IconId = reader.GetInt32(4),
                                Photo = bitmapImage
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            Products = products;
        }
        #endregion

        #region ChoosePhotoCommand
        public ICommand ChoosePhotoCommand { get; }
        private bool CanChoosePhotoCommandExecute(object p) => true;
        private void OnChoosePhotoCommandExecuted(object p)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"D:\";

            if (openFileDialog.ShowDialog() == true)
            {
                _pathIcon = openFileDialog.FileName;
            }
        }
        #endregion
        #region AddProductCommand
        public ICommand AddProductCommand { get; }
        private bool CanAddProductCommandExecute(object p)
        {
            return Name?.Length != 0 && Qty != 0 && Weight != 0 && _pathIcon?.Length != null;
        }
        private void OnAddProductCommandExecuted(object p)
        {
            BitmapFrame bitmapImage = null;
            byte[] photoByteArray = null;
            if (_pathIcon != null)
            {
                photoByteArray = File.ReadAllBytes(_pathIcon);
                using (var ms = new MemoryStream(photoByteArray))
                {
                    bitmapImage = BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            }

            Product product = new Product()
            {
                Name = Name,
                Qty = Qty,
                Weight = Weight
            };
            ProductService productService = new ProductService();
            int id = productService.Add(product);

            db.model.Icon icon = new db.model.Icon()
            {
                ProductId = id,
                Photo = photoByteArray
            };
            IconService iconService = new IconService();
            int iconId = iconService.Add(icon);

            ProductInfo productInfo = new ProductInfo()
            {
                Id = id,
                IconId = iconId,
                Name = Name,
                Qty = Qty,
                Weight = Weight,
                Photo = bitmapImage
            };
            Products.Add(productInfo);

            Name = "";
            Qty = 0;
            Weight = 0;
            _pathIcon = null;
        }
        #endregion
        #region RemoveProductCommand
        public ICommand RemoveProductCommand { get; }
        private bool CanRemoveProductCommandExecute(object p) => SelectedProduct != null;
        private void OnRemoveProductCommandExecuted(object p)
        {
            IconService iconService = new IconService();
            iconService.RemoveById(SelectedProduct.IconId);

            ProductService productService = new ProductService();
            productService.RemoveById(SelectedProduct.Id);

            Products.Remove(SelectedProduct);
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            LoadedCommand = new LambdaCommand(OnLoadedCommandExecuted, CanLoadedCommandExecute);

            ChoosePhotoCommand = new LambdaCommand(OnChoosePhotoCommandExecuted, CanChoosePhotoCommandExecute);
            AddProductCommand = new LambdaCommand(OnAddProductCommandExecuted, CanAddProductCommandExecute);
            RemoveProductCommand = new LambdaCommand(OnRemoveProductCommandExecuted, CanRemoveProductCommandExecute);
            #endregion
        }
    }
}
    