using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using lab11.ViewModels.Base;
using lab11.Infrastructure.Commands;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using lab11.Model;
using lab11.Data;
using lab11.Data.Model;

namespace lab11.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private UnitOfWork _dbWorker = new UnitOfWork();
            
        #region Models

        #region Asks
        private ObservableCollection<Ask> _asks;
        public ObservableCollection<Ask> Asks
        {
            get => _asks;
            set => Set(ref _asks, value);
        }
        #endregion

        #region NameSeller
        private string _nameSeller;
        public string NameSeller
        {
            get => _nameSeller;
            set => Set(ref _nameSeller, value);
        }
        #endregion

        #region NameProduct
        private string _nameProduct;
        public string NameProduct
        {
            get => _nameProduct;
            set => Set(ref _nameProduct, value);
        }
        #endregion

        #region Price
        private int _price;
        public int Price
        {
            get => _price;
            set => Set(ref _price, value);
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

        #region SelectedAsk
        private Ask _selectedAsk;
        public Ask SelectedAsk
        {
            get => _selectedAsk;
            set => Set(ref _selectedAsk, value);
        }
        #endregion

        #endregion

        #region Команды

        #region LoadedCommand
        public ICommand LoadedCommand { get; }
        private bool CanLoadedCommandExecute(object p) => true;
        private async void OnLoadedCommandExecutedAsync(object p)
        {
            ObservableCollection<Ask> asks = new ObservableCollection<Ask>();

            List<Seller> sellers = _dbWorker.Sellers.GetAll().ToList();
            foreach (var seller in sellers)
            {
                Ask ask = new Ask()
                {
                    IdSeller = seller.Id,
                    IdProduct = seller.Products.First().Id,
                    NameSeller = seller.Name,
                    NameProduct = seller.Products.First().Name,
                    Price = seller.Products.First().Price,
                    Weight = seller.Products.First().Weight
                };
                asks.Add(ask);
            }

            Asks = asks;

            await _dbWorker.Sellers.PrintAllAsync();
        }
        #endregion

        #region AddAskCommand
        public ICommand AddAskCommand { get; }
        private bool CanAddAskCommandExecute(object p)
        {
            return NameSeller?.Length != 0 && NameProduct?.Length != 0 && Price != 0 && Weight != 0;
        }
        private void OnAddAskCommandExecuted(object p)
        {
            using (var transaction = _dbWorker.BeginTransaction())
            {
                try
                {
                    Seller seller = new Seller()
                    {
                        Name = NameSeller,
                    };
                    _dbWorker.Sellers.Insert(seller);
                    _dbWorker.Save();

                    Product product = new Product()
                    {
                        Name = NameProduct,
                        Weight = Weight,
                        Price = Price,
                        SellerId = seller.Id
                    };
                    _dbWorker.Products.Insert(product);
                    _dbWorker.Save();

                    Ask ask = new Ask()
                    {
                        IdSeller = seller.Id,
                        IdProduct = product.Id,
                        NameSeller = seller.Name,
                        NameProduct = product.Name,
                        Weight = product.Weight,
                        Price = product.Price
                    };
                    transaction.Commit();
                    Asks.Add(ask);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
        }
        #endregion
        #region RemoveAskCommand
        public ICommand RemoveAskCommand { get; }
        private bool CanRemoveAskCommandExecute(object p) => SelectedAsk != null;
        private void OnRemoveAskCommandExecuted(object p)
        {   
            _dbWorker.Products.Delete(SelectedAsk.IdProduct);
            _dbWorker.Save();
            _dbWorker.Sellers.Delete(SelectedAsk.IdSeller);
            _dbWorker.Save();

            Asks.Remove(SelectedAsk);
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            LoadedCommand = new LambdaCommand(OnLoadedCommandExecutedAsync, CanLoadedCommandExecute);

            AddAskCommand = new LambdaCommand(OnAddAskCommandExecuted, CanAddAskCommandExecute);
            RemoveAskCommand = new LambdaCommand(OnRemoveAskCommandExecuted, CanRemoveAskCommandExecute);
            #endregion
        }
    }
}
    