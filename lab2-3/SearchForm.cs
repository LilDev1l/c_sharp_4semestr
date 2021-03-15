using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace S2_Lab02
{
    public partial class SearchForm : Form
    {
        enum SearchType
        {
            Null,
            Model,
            Type,
            LoadCapacity,
            PassengersSeats
        }
        private MainForm _mainForm;
        private List<Plane> _searchResultPlanes;
        private SearchType _searchType = SearchType.Null;
        private string _regexPattern = @"";
        private const string SearchInputExampleText = "Вид поиска: ";
        
        public SearchForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _searchResultPlanes = new List<Plane>();
            SearchTypeModel.CheckedChanged += radioButtons_CheckedChanged;
            SearchTypeType.CheckedChanged += radioButtons_CheckedChanged;
            SearchTypeLoadCapacity.CheckedChanged += radioButtons_CheckedChanged;
            SearchTypePassengersSeats.CheckedChanged += radioButtons_CheckedChanged;
            Closed += (_, _) => { _mainForm.Enabled = true; };
        }
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is RadioButton radioButton)) 
                return;
            _searchType = radioButton.Text switch
            {
                "Модели" => SearchType.Model,
                "Типу" => SearchType.Type,
                "Грузоподъёмности" => SearchType.LoadCapacity,
                "Кол-ву пасс. мест" => SearchType.PassengersSeats,
                _ => _searchType
            };
            SearchPreparation();
        }
        private void SearchPreparation()
        {
            switch (_searchType)
            {
                case SearchType.Model:
                    _regexPattern = @"AirBus|Albatros|Boeing|Turbay|Vought";
                    SearchInputExample.Text = SearchInputExampleText + "AirBus/Albatros";
                    break;
                case SearchType.Type:
                    _regexPattern = @"Грузовой|Пассажирский|Военный";
                    SearchInputExample.Text = SearchInputExampleText + "Грузовой/Пассажирский";
                    break;
                case SearchType.LoadCapacity:
                    _regexPattern = @"\d{2,3}";
                    SearchInputExample.Text = SearchInputExampleText + "10";
                    break;
                case SearchType.PassengersSeats:
                    _regexPattern = @"\d{2,3}";
                    SearchInputExample.Text = SearchInputExampleText + "10";
                    break;
            }
            SearchInput.Enabled = true;
        }

        private void MakeDataView()
        {
            SearchResultDataView.Text = "";
            foreach (var plane in _searchResultPlanes)
                SearchResultDataView.Text += plane.ToString();
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            var match = Regex.Match(SearchInput.Text, _regexPattern);
            if (match.Success && match.Index == 0 && match.Length == SearchInput.Text.Length)
            {
                _searchResultPlanes.Clear();
                var regex = new Regex(SearchInput.Text);
                switch (_searchType)
                {
                    case SearchType.Model:
                        foreach (var plane in _mainForm.Planes.Where(plane => regex.IsMatch(plane.Model)))
                            _searchResultPlanes.Add(plane);
                        break;
                    case SearchType.Type:
                        foreach (var plane in _mainForm.Planes.Where(plane => regex.IsMatch(plane.Type)))
                            _searchResultPlanes.Add(plane);
                        break;
                    case SearchType.LoadCapacity:
                        foreach (var plane in _mainForm.Planes.Where(plane => plane.LoadCapacity == Convert.ToInt32(SearchInput.Text)))
                            _searchResultPlanes.Add(plane);
                        break;
                    case SearchType.PassengersSeats:
                        foreach (var plane in _mainForm.Planes.Where(plane => plane.PassengersSeatsAmount == Convert.ToInt32(SearchInput.Text)))
                            _searchResultPlanes.Add(plane);
                        break;
                }
                MakeDataView();
            }
            else
            {
                MessageBox.Show("Неверно введённые данные для поиска");
            }

            if(CheckSorting.Checked)
            {
                var orderedResult = from element in _searchResultPlanes
                                    orderby element.DateRelease
                                    select element;

                SearchResultDataView.Text = "";
                foreach (var plane in orderedResult)
                    SearchResultDataView.Text += plane.ToString();
            }
        }

        private void MenuItemDateRelease_Click(object sender, EventArgs e)
        {
            var orderedResult = from element in _searchResultPlanes
                orderby element.DateRelease
                select element;
            
            SearchResultDataView.Text = "";
            foreach (var plane in orderedResult)
                SearchResultDataView.Text += plane.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var json = JsonConvert.SerializeObject(_searchResultPlanes);
                using var streamWriter = new StreamWriter(@"data/querySearch.json");
                streamWriter.Write(json);
                MessageBox.Show("Данные успешно сохранены.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}