using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Timer = System.Threading.Timer;

namespace S2_Lab02
{
    public partial class MainForm : Form
    {
        public List<Plane> Planes { get; set; }
        private List<CrewMember> _crew;
        private List<int> _planesIdList;
        private Timer _timer;

        public MainForm()
        {
            InitializeComponent();
            Planes = new List<Plane>();
            _crew = new List<CrewMember>();
            _planesIdList = new List<int>();
            DataView.Nodes.Add("Airport","Аэропорт");
            AirYearReleaseDatePicker.Format = DateTimePickerFormat.Custom;
            AirYearReleaseDatePicker.CustomFormat = "dd.MM.yyyy";
            _timer = new Timer(Time, null, 0, 1000);
        }

        private void Time(object obj)
        { 
            StatusItemTimeSetLabel.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }
        private void RefreshCrew()
        {
            _crew = new List<CrewMember>();
        }

        private void RefreshCrewAmount()
        {
            CrewMemberIdLabel.Text = CrewMemberIdLabel.Text.Remove(10);
            CrewMemberIdLabel.Text = CrewMemberIdLabel.Text.Insert(10, Convert.ToString(_crew.Count));
        }

        private void AddPlaneToDataView(Plane plane)
        {
            // Добавляем узел Самолёт в узел Аэропот.
            DataView.Nodes["Airport"].Nodes.Add(plane.Id.ToString(), "Самолёт " + plane.Id);
            // Создаём ветви узла Самолёта.
            var nodeCrew = new TreeNode("Экипаж");
            var idCrewMember = 0;
            foreach (var crewMember in plane.Crew)
            {
                nodeCrew.Nodes.Add( idCrewMember.ToString(),crewMember.Position);
                var crewMemberNode = new TreeNode[]
                {
                    new("Имя: " + crewMember.Name),
                    new("Возраст: " + crewMember.Age),
                    new("Стаж: " + crewMember.WorkExperience)
                };
                nodeCrew.Nodes[idCrewMember.ToString()].Nodes.AddRange(crewMemberNode);
                idCrewMember++;
            }

            var planeNode = new[]
            {
                new("ID: " + plane.Id),
                new("Модель: " + plane.Model),
                new("Тип: " + plane.Type),
                new("Год выпуска: " + plane.DateRelease.ToString("dd.MM.yyyy")),
                new("Грузоподъемность: " + plane.LoadCapacity + " (т)"),
                new("Пассажирских мест: " + plane.PassengersSeatsAmount),
                nodeCrew
            };
            // Добавляем ветви в узел.
            DataView.Nodes["Airport"].Nodes[plane.Id.ToString()].Nodes.AddRange(planeNode);

            StatusItemObjectsSetAmountLabel.Text = Planes.Count.ToString();
        }
        public void GenerateNewDataView()
        {
            DataView.Nodes["Airport"].Nodes.Clear();
            foreach (var plane in Planes)
                AddPlaneToDataView(plane);
        }

        private bool Validate(object plane)
        {
            var results = new List<ValidationResult>();
            var resultString = "";
            if (Validator.TryValidateObject(plane, new ValidationContext(plane), results, true))
            {
                if (plane is Plane tempPlane)
                {
                    resultString = !_planesIdList.Contains(tempPlane.Id) ?
                        "Объет успешно добавлен." :
                        "Самолет с таким ID уже был добавлен";
                }
                else
                    resultString = "Объет успешно добавлен.";
            }
            else
            {
                foreach (var error in results)
                    resultString += error + "\n";
            }
            MessageBox.Show(resultString, "Результат");
            return resultString == "Объет успешно добавлен.";
        }

        private void AirAddButton_Click(object sender, EventArgs e)
        {
            var plane = new Plane(_crew)
            {
                Model = AirModelList.Text,
                DateRelease = AirYearReleaseDatePicker.Value,
                LoadCapacity = Convert.ToInt32(AirLoadCapacitySetter.Text),
                PassengersSeatsAmount =  Convert.ToInt32(AirPassengersSeatsSetter.Text),
            };
            int.TryParse(AirIdInput.Text, out var id);
            plane.Id = id;
            if (AirTypeCargo.Checked)
                plane.Type = AirTypeCargo.Text;
            else if (AirTypePassenger.Checked)
                plane.Type = AirTypePassenger.Text;
            else if (AirTypeMilitary.Checked)
                plane.Type = AirTypeMilitary.Text;

            if (!Validate(plane)) 
                return;
            
            Planes.Add(plane);
            _planesIdList.Add(plane.Id);
            RefreshCrew();
            RefreshCrewAmount();
            AddPlaneToDataView(plane);
        }

        private void CrewMemberAddButton_Click(object sender, EventArgs e)
        {
            var crewMember = new CrewMember()
            {
                Age = Convert.ToInt32(CrewMemberAgeSetter.Text),
                WorkExperience = Convert.ToInt32(CrewMemberWorkExperienceSetter.Text),
                Name = CrewMemberNameInput.Text,
                Position = CrewMemberPositionList.Text
            };

            if (!Validate(crewMember))
                return;
            
            _crew.Add(crewMember);
            RefreshCrewAmount();
        }

        private void CrewMemberDeleteButton_Click(object sender, EventArgs e)
        {
            if (_crew.Count == 0) 
                return;
            _crew.RemoveAt(_crew.Count - 1);
            RefreshCrewAmount();
        }

        private void CrewDeleteButton_Click(object sender, EventArgs e)
        {
            RefreshCrew();
            RefreshCrewAmount();
        }

        private void DataSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var json = JsonConvert.SerializeObject(Planes);
                using var streamWriter = new StreamWriter(@"data/planes.json");
                streamWriter.Write(json);
                MessageBox.Show("Данные успешно сохранены.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DataReadButton_Click(object sender, EventArgs e)
        {
            try
            {
                using var streamReader = new StreamReader(@"data/planes.json");
                var json = streamReader.ReadToEnd();
                Planes = JsonConvert.DeserializeObject<List<Plane>>(json);
                MessageBox.Show("Данные успешно считаны.");
                GenerateNewDataView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DataViewClearButton_Click(object sender, EventArgs e)
        {
            Planes.Clear();
            _crew.Clear();
            _planesIdList.Clear();
            DataView.Nodes["Airport"].Nodes.Clear();
            StatusItemObjectsSetAmountLabel.Text = "0";
        }

        private void AirSearchButton_Click(object sender, EventArgs e)
        {
            var searchForm = new Thread(() => Application.Run(new SearchForm(this)));
            searchForm.Start();
            Enabled = false;
        }

        private void MenuItemAboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия: 1.0\n Разработчик: Ярмолик М.А.");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void DataGroup_Enter(object sender, EventArgs e)
        {

        }

        private void DataView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void CrewAddGroup_Enter(object sender, EventArgs e)
        {

        }

        private void StatusItemTimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void StatusItemObjectsAmountLabel_Click(object sender, EventArgs e)
        {

        }

        private void AirYearReleaseDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MenuItemGeneration_Click(object sender, EventArgs e)
        {
            var generationForm = new Thread(() => Application.Run(new GenerationForm(this)));
            generationForm.Start();
            Enabled = false;
        }
    }
}