
namespace S2_Lab02
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AirYearReleaseDatePicker = new System.Windows.Forms.DateTimePicker();
            this.AirYearReleaseLabel = new System.Windows.Forms.Label();
            this.AirTypeCargo = new System.Windows.Forms.RadioButton();
            this.AirTypePassenger = new System.Windows.Forms.RadioButton();
            this.AirTypeMilitary = new System.Windows.Forms.RadioButton();
            this.AirModelList = new System.Windows.Forms.ComboBox();
            this.AirModelLabel = new System.Windows.Forms.Label();
            this.AirTypeGroup = new System.Windows.Forms.GroupBox();
            this.AirLoadCapacitySetter = new System.Windows.Forms.NumericUpDown();
            this.AirLoadCapacityLabel = new System.Windows.Forms.Label();
            this.AirAddGroup = new System.Windows.Forms.GroupBox();
            this.AirIdInput = new System.Windows.Forms.TextBox();
            this.AirIdLabel = new System.Windows.Forms.Label();
            this.AirPassengersSeatsLabel = new System.Windows.Forms.Label();
            this.AirPassengersSeatsSetter = new System.Windows.Forms.NumericUpDown();
            this.CrewAddGroup = new System.Windows.Forms.GroupBox();
            this.CrewMemberPositionList = new System.Windows.Forms.ComboBox();
            this.CrewMemberWorkExperienceLabel = new System.Windows.Forms.Label();
            this.CrewMemberPositionLabel = new System.Windows.Forms.Label();
            this.CrewMemberWorkExperienceSetter = new System.Windows.Forms.NumericUpDown();
            this.CrewMemberAgeLabel = new System.Windows.Forms.Label();
            this.CrewDeleteButton = new System.Windows.Forms.Button();
            this.CrewMemberDeleteButton = new System.Windows.Forms.Button();
            this.CrewMemberAgeSetter = new System.Windows.Forms.NumericUpDown();
            this.CrewMemberAddButton = new System.Windows.Forms.Button();
            this.CrewMemberNameLabel = new System.Windows.Forms.Label();
            this.CrewMemberNameInput = new System.Windows.Forms.TextBox();
            this.CrewMemberIdLabel = new System.Windows.Forms.Label();
            this.DataReadButton = new System.Windows.Forms.Button();
            this.DataSaveButton = new System.Windows.Forms.Button();
            this.DataGroup = new System.Windows.Forms.GroupBox();
            this.DataViewClearButton = new System.Windows.Forms.Button();
            this.AirAddButton = new System.Windows.Forms.Button();
            this.DataView = new System.Windows.Forms.TreeView();
            this.AirSearchButton = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGeneration = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusItemObjectsAmountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusItemObjectsSetAmountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusItemTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusItemTimeSetLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AirTypeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AirLoadCapacitySetter)).BeginInit();
            this.AirAddGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AirPassengersSeatsSetter)).BeginInit();
            this.CrewAddGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CrewMemberWorkExperienceSetter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrewMemberAgeSetter)).BeginInit();
            this.DataGroup.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AirYearReleaseDatePicker
            // 
            this.AirYearReleaseDatePicker.Location = new System.Drawing.Point(6, 257);
            this.AirYearReleaseDatePicker.Name = "AirYearReleaseDatePicker";
            this.AirYearReleaseDatePicker.Size = new System.Drawing.Size(213, 22);
            this.AirYearReleaseDatePicker.TabIndex = 2;
            this.AirYearReleaseDatePicker.ValueChanged += new System.EventHandler(this.AirYearReleaseDatePicker_ValueChanged);
            // 
            // AirYearReleaseLabel
            // 
            this.AirYearReleaseLabel.Location = new System.Drawing.Point(6, 235);
            this.AirYearReleaseLabel.Name = "AirYearReleaseLabel";
            this.AirYearReleaseLabel.Size = new System.Drawing.Size(100, 19);
            this.AirYearReleaseLabel.TabIndex = 3;
            this.AirYearReleaseLabel.Text = "Год выпуска";
            // 
            // AirTypeCargo
            // 
            this.AirTypeCargo.Location = new System.Drawing.Point(6, 19);
            this.AirTypeCargo.Name = "AirTypeCargo";
            this.AirTypeCargo.Size = new System.Drawing.Size(104, 24);
            this.AirTypeCargo.TabIndex = 5;
            this.AirTypeCargo.TabStop = true;
            this.AirTypeCargo.Text = "Грузовой";
            this.AirTypeCargo.UseVisualStyleBackColor = true;
            // 
            // AirTypePassenger
            // 
            this.AirTypePassenger.Location = new System.Drawing.Point(6, 49);
            this.AirTypePassenger.Name = "AirTypePassenger";
            this.AirTypePassenger.Size = new System.Drawing.Size(207, 24);
            this.AirTypePassenger.TabIndex = 6;
            this.AirTypePassenger.TabStop = true;
            this.AirTypePassenger.Text = "Пассажирский";
            this.AirTypePassenger.UseVisualStyleBackColor = true;
            // 
            // AirTypeMilitary
            // 
            this.AirTypeMilitary.Location = new System.Drawing.Point(6, 79);
            this.AirTypeMilitary.Name = "AirTypeMilitary";
            this.AirTypeMilitary.Size = new System.Drawing.Size(104, 24);
            this.AirTypeMilitary.TabIndex = 7;
            this.AirTypeMilitary.TabStop = true;
            this.AirTypeMilitary.Text = "Военный";
            this.AirTypeMilitary.UseVisualStyleBackColor = true;
            // 
            // AirModelList
            // 
            this.AirModelList.FormattingEnabled = true;
            this.AirModelList.Items.AddRange(new object[] {
            "AirBus",
            "Albatros",
            "Boeing",
            "Turbay",
            "Vought",
            "Ан-26"});
            this.AirModelList.Location = new System.Drawing.Point(6, 96);
            this.AirModelList.Name = "AirModelList";
            this.AirModelList.Size = new System.Drawing.Size(180, 24);
            this.AirModelList.TabIndex = 8;
            // 
            // AirModelLabel
            // 
            this.AirModelLabel.Location = new System.Drawing.Point(6, 75);
            this.AirModelLabel.Name = "AirModelLabel";
            this.AirModelLabel.Size = new System.Drawing.Size(164, 14);
            this.AirModelLabel.TabIndex = 9;
            this.AirModelLabel.Text = "Модель самолёта";
            // 
            // AirTypeGroup
            // 
            this.AirTypeGroup.Controls.Add(this.AirTypeCargo);
            this.AirTypeGroup.Controls.Add(this.AirTypePassenger);
            this.AirTypeGroup.Controls.Add(this.AirTypeMilitary);
            this.AirTypeGroup.Location = new System.Drawing.Point(6, 126);
            this.AirTypeGroup.Name = "AirTypeGroup";
            this.AirTypeGroup.Size = new System.Drawing.Size(285, 106);
            this.AirTypeGroup.TabIndex = 10;
            this.AirTypeGroup.TabStop = false;
            this.AirTypeGroup.Text = "Тип самолёта";
            // 
            // AirLoadCapacitySetter
            // 
            this.AirLoadCapacitySetter.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.AirLoadCapacitySetter.Location = new System.Drawing.Point(6, 304);
            this.AirLoadCapacitySetter.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.AirLoadCapacitySetter.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AirLoadCapacitySetter.Name = "AirLoadCapacitySetter";
            this.AirLoadCapacitySetter.Size = new System.Drawing.Size(120, 22);
            this.AirLoadCapacitySetter.TabIndex = 11;
            this.AirLoadCapacitySetter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // AirLoadCapacityLabel
            // 
            this.AirLoadCapacityLabel.Location = new System.Drawing.Point(6, 282);
            this.AirLoadCapacityLabel.Name = "AirLoadCapacityLabel";
            this.AirLoadCapacityLabel.Size = new System.Drawing.Size(213, 19);
            this.AirLoadCapacityLabel.TabIndex = 12;
            this.AirLoadCapacityLabel.Text = "Грузоподъёмность (т)";
            // 
            // AirAddGroup
            // 
            this.AirAddGroup.Controls.Add(this.AirIdInput);
            this.AirAddGroup.Controls.Add(this.AirIdLabel);
            this.AirAddGroup.Controls.Add(this.AirModelList);
            this.AirAddGroup.Controls.Add(this.AirPassengersSeatsLabel);
            this.AirAddGroup.Controls.Add(this.AirPassengersSeatsSetter);
            this.AirAddGroup.Controls.Add(this.AirTypeGroup);
            this.AirAddGroup.Controls.Add(this.AirYearReleaseDatePicker);
            this.AirAddGroup.Controls.Add(this.AirYearReleaseLabel);
            this.AirAddGroup.Controls.Add(this.AirLoadCapacityLabel);
            this.AirAddGroup.Controls.Add(this.AirModelLabel);
            this.AirAddGroup.Controls.Add(this.AirLoadCapacitySetter);
            this.AirAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AirAddGroup.Location = new System.Drawing.Point(12, 31);
            this.AirAddGroup.Name = "AirAddGroup";
            this.AirAddGroup.Size = new System.Drawing.Size(285, 420);
            this.AirAddGroup.TabIndex = 15;
            this.AirAddGroup.TabStop = false;
            this.AirAddGroup.Text = "Данные самолета";
            // 
            // AirIdInput
            // 
            this.AirIdInput.Location = new System.Drawing.Point(6, 50);
            this.AirIdInput.Name = "AirIdInput";
            this.AirIdInput.Size = new System.Drawing.Size(180, 22);
            this.AirIdInput.TabIndex = 26;
            // 
            // AirIdLabel
            // 
            this.AirIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AirIdLabel.Location = new System.Drawing.Point(6, 28);
            this.AirIdLabel.Name = "AirIdLabel";
            this.AirIdLabel.Size = new System.Drawing.Size(255, 28);
            this.AirIdLabel.TabIndex = 21;
            this.AirIdLabel.Text = "ID Самолёта";
            // 
            // AirPassengersSeatsLabel
            // 
            this.AirPassengersSeatsLabel.Location = new System.Drawing.Point(6, 336);
            this.AirPassengersSeatsLabel.Name = "AirPassengersSeatsLabel";
            this.AirPassengersSeatsLabel.Size = new System.Drawing.Size(261, 19);
            this.AirPassengersSeatsLabel.TabIndex = 17;
            this.AirPassengersSeatsLabel.Text = "Количество пассажирских мест";
            // 
            // AirPassengersSeatsSetter
            // 
            this.AirPassengersSeatsSetter.Location = new System.Drawing.Point(6, 356);
            this.AirPassengersSeatsSetter.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.AirPassengersSeatsSetter.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AirPassengersSeatsSetter.Name = "AirPassengersSeatsSetter";
            this.AirPassengersSeatsSetter.Size = new System.Drawing.Size(120, 22);
            this.AirPassengersSeatsSetter.TabIndex = 16;
            this.AirPassengersSeatsSetter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // CrewAddGroup
            // 
            this.CrewAddGroup.Controls.Add(this.CrewMemberPositionList);
            this.CrewAddGroup.Controls.Add(this.CrewMemberWorkExperienceLabel);
            this.CrewAddGroup.Controls.Add(this.CrewMemberPositionLabel);
            this.CrewAddGroup.Controls.Add(this.CrewMemberWorkExperienceSetter);
            this.CrewAddGroup.Controls.Add(this.CrewMemberAgeLabel);
            this.CrewAddGroup.Controls.Add(this.CrewDeleteButton);
            this.CrewAddGroup.Controls.Add(this.CrewMemberDeleteButton);
            this.CrewAddGroup.Controls.Add(this.CrewMemberAgeSetter);
            this.CrewAddGroup.Controls.Add(this.CrewMemberAddButton);
            this.CrewAddGroup.Controls.Add(this.CrewMemberNameLabel);
            this.CrewAddGroup.Controls.Add(this.CrewMemberNameInput);
            this.CrewAddGroup.Controls.Add(this.CrewMemberIdLabel);
            this.CrewAddGroup.Location = new System.Drawing.Point(730, 35);
            this.CrewAddGroup.Name = "CrewAddGroup";
            this.CrewAddGroup.Size = new System.Drawing.Size(285, 416);
            this.CrewAddGroup.TabIndex = 16;
            this.CrewAddGroup.TabStop = false;
            this.CrewAddGroup.Text = "Добавление экипажа";
            this.CrewAddGroup.Enter += new System.EventHandler(this.CrewAddGroup_Enter);
            // 
            // CrewMemberPositionList
            // 
            this.CrewMemberPositionList.FormattingEnabled = true;
            this.CrewMemberPositionList.Items.AddRange(new object[] {
            "Стюардесса",
            "Пилот",
            "Второй пилот",
            "Инженер"});
            this.CrewMemberPositionList.Location = new System.Drawing.Point(9, 195);
            this.CrewMemberPositionList.Name = "CrewMemberPositionList";
            this.CrewMemberPositionList.Size = new System.Drawing.Size(180, 24);
            this.CrewMemberPositionList.TabIndex = 18;
            // 
            // CrewMemberWorkExperienceLabel
            // 
            this.CrewMemberWorkExperienceLabel.Location = new System.Drawing.Point(8, 122);
            this.CrewMemberWorkExperienceLabel.Name = "CrewMemberWorkExperienceLabel";
            this.CrewMemberWorkExperienceLabel.Size = new System.Drawing.Size(261, 19);
            this.CrewMemberWorkExperienceLabel.TabIndex = 25;
            this.CrewMemberWorkExperienceLabel.Text = "Стаж работы";
            // 
            // CrewMemberPositionLabel
            // 
            this.CrewMemberPositionLabel.Location = new System.Drawing.Point(8, 169);
            this.CrewMemberPositionLabel.Name = "CrewMemberPositionLabel";
            this.CrewMemberPositionLabel.Size = new System.Drawing.Size(164, 23);
            this.CrewMemberPositionLabel.TabIndex = 19;
            this.CrewMemberPositionLabel.Text = "Должность";
            // 
            // CrewMemberWorkExperienceSetter
            // 
            this.CrewMemberWorkExperienceSetter.Location = new System.Drawing.Point(9, 144);
            this.CrewMemberWorkExperienceSetter.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.CrewMemberWorkExperienceSetter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CrewMemberWorkExperienceSetter.Name = "CrewMemberWorkExperienceSetter";
            this.CrewMemberWorkExperienceSetter.Size = new System.Drawing.Size(123, 22);
            this.CrewMemberWorkExperienceSetter.TabIndex = 24;
            this.CrewMemberWorkExperienceSetter.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // CrewMemberAgeLabel
            // 
            this.CrewMemberAgeLabel.Location = new System.Drawing.Point(8, 73);
            this.CrewMemberAgeLabel.Name = "CrewMemberAgeLabel";
            this.CrewMemberAgeLabel.Size = new System.Drawing.Size(261, 19);
            this.CrewMemberAgeLabel.TabIndex = 19;
            this.CrewMemberAgeLabel.Text = "Возраст";
            // 
            // CrewDeleteButton
            // 
            this.CrewDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CrewDeleteButton.Location = new System.Drawing.Point(148, 327);
            this.CrewDeleteButton.Name = "CrewDeleteButton";
            this.CrewDeleteButton.Size = new System.Drawing.Size(121, 59);
            this.CrewDeleteButton.TabIndex = 24;
            this.CrewDeleteButton.Text = "Удалить Экипаж";
            this.CrewDeleteButton.UseVisualStyleBackColor = true;
            this.CrewDeleteButton.Click += new System.EventHandler(this.CrewDeleteButton_Click);
            // 
            // CrewMemberDeleteButton
            // 
            this.CrewMemberDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CrewMemberDeleteButton.Location = new System.Drawing.Point(11, 327);
            this.CrewMemberDeleteButton.Name = "CrewMemberDeleteButton";
            this.CrewMemberDeleteButton.Size = new System.Drawing.Size(121, 59);
            this.CrewMemberDeleteButton.TabIndex = 25;
            this.CrewMemberDeleteButton.Text = "Удалить Члена";
            this.CrewMemberDeleteButton.UseVisualStyleBackColor = true;
            this.CrewMemberDeleteButton.Click += new System.EventHandler(this.CrewMemberDeleteButton_Click);
            // 
            // CrewMemberAgeSetter
            // 
            this.CrewMemberAgeSetter.Location = new System.Drawing.Point(9, 95);
            this.CrewMemberAgeSetter.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.CrewMemberAgeSetter.Minimum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.CrewMemberAgeSetter.Name = "CrewMemberAgeSetter";
            this.CrewMemberAgeSetter.Size = new System.Drawing.Size(123, 22);
            this.CrewMemberAgeSetter.TabIndex = 18;
            this.CrewMemberAgeSetter.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // CrewMemberAddButton
            // 
            this.CrewMemberAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.CrewMemberAddButton.Location = new System.Drawing.Point(9, 232);
            this.CrewMemberAddButton.MaximumSize = new System.Drawing.Size(260, 73);
            this.CrewMemberAddButton.MinimumSize = new System.Drawing.Size(260, 73);
            this.CrewMemberAddButton.Name = "CrewMemberAddButton";
            this.CrewMemberAddButton.Size = new System.Drawing.Size(260, 73);
            this.CrewMemberAddButton.TabIndex = 17;
            this.CrewMemberAddButton.Text = "Добавить члена экипажа";
            this.CrewMemberAddButton.UseVisualStyleBackColor = true;
            this.CrewMemberAddButton.Click += new System.EventHandler(this.CrewMemberAddButton_Click);
            // 
            // CrewMemberNameLabel
            // 
            this.CrewMemberNameLabel.Location = new System.Drawing.Point(8, 24);
            this.CrewMemberNameLabel.Name = "CrewMemberNameLabel";
            this.CrewMemberNameLabel.Size = new System.Drawing.Size(164, 14);
            this.CrewMemberNameLabel.TabIndex = 18;
            this.CrewMemberNameLabel.Text = "Имя";
            // 
            // CrewMemberNameInput
            // 
            this.CrewMemberNameInput.Location = new System.Drawing.Point(9, 46);
            this.CrewMemberNameInput.Name = "CrewMemberNameInput";
            this.CrewMemberNameInput.Size = new System.Drawing.Size(180, 22);
            this.CrewMemberNameInput.TabIndex = 19;
            // 
            // CrewMemberIdLabel
            // 
            this.CrewMemberIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CrewMemberIdLabel.Location = new System.Drawing.Point(89, 308);
            this.CrewMemberIdLabel.Name = "CrewMemberIdLabel";
            this.CrewMemberIdLabel.Size = new System.Drawing.Size(113, 19);
            this.CrewMemberIdLabel.TabIndex = 18;
            this.CrewMemberIdLabel.Text = "Добавлено: 0";
            // 
            // DataReadButton
            // 
            this.DataReadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataReadButton.Location = new System.Drawing.Point(136, 21);
            this.DataReadButton.Name = "DataReadButton";
            this.DataReadButton.Size = new System.Drawing.Size(124, 69);
            this.DataReadButton.TabIndex = 18;
            this.DataReadButton.Text = "Считать данные";
            this.DataReadButton.UseVisualStyleBackColor = true;
            this.DataReadButton.Click += new System.EventHandler(this.DataReadButton_Click);
            // 
            // DataSaveButton
            // 
            this.DataSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataSaveButton.Location = new System.Drawing.Point(6, 21);
            this.DataSaveButton.Name = "DataSaveButton";
            this.DataSaveButton.Size = new System.Drawing.Size(124, 69);
            this.DataSaveButton.TabIndex = 19;
            this.DataSaveButton.Text = "Сохранить данные";
            this.DataSaveButton.UseVisualStyleBackColor = true;
            this.DataSaveButton.Click += new System.EventHandler(this.DataSaveButton_Click);
            // 
            // DataGroup
            // 
            this.DataGroup.Controls.Add(this.DataViewClearButton);
            this.DataGroup.Controls.Add(this.DataReadButton);
            this.DataGroup.Controls.Add(this.DataSaveButton);
            this.DataGroup.Location = new System.Drawing.Point(309, 457);
            this.DataGroup.Name = "DataGroup";
            this.DataGroup.Size = new System.Drawing.Size(409, 101);
            this.DataGroup.TabIndex = 21;
            this.DataGroup.TabStop = false;
            this.DataGroup.Text = "Данные";
            this.DataGroup.Enter += new System.EventHandler(this.DataGroup_Enter);
            // 
            // DataViewClearButton
            // 
            this.DataViewClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DataViewClearButton.Location = new System.Drawing.Point(290, 21);
            this.DataViewClearButton.Name = "DataViewClearButton";
            this.DataViewClearButton.Size = new System.Drawing.Size(113, 69);
            this.DataViewClearButton.TabIndex = 30;
            this.DataViewClearButton.Text = "Очистить Данные";
            this.DataViewClearButton.UseVisualStyleBackColor = true;
            this.DataViewClearButton.Click += new System.EventHandler(this.DataViewClearButton_Click);
            // 
            // AirAddButton
            // 
            this.AirAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AirAddButton.Location = new System.Drawing.Point(12, 464);
            this.AirAddButton.Name = "AirAddButton";
            this.AirAddButton.Size = new System.Drawing.Size(285, 96);
            this.AirAddButton.TabIndex = 23;
            this.AirAddButton.Text = "Добавить Самолет";
            this.AirAddButton.UseVisualStyleBackColor = true;
            this.AirAddButton.Click += new System.EventHandler(this.AirAddButton_Click);
            // 
            // DataView
            // 
            this.DataView.Location = new System.Drawing.Point(309, 35);
            this.DataView.Name = "DataView";
            this.DataView.Size = new System.Drawing.Size(409, 416);
            this.DataView.TabIndex = 28;
            this.DataView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DataView_AfterSelect);
            // 
            // AirSearchButton
            // 
            this.AirSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AirSearchButton.Location = new System.Drawing.Point(730, 464);
            this.AirSearchButton.Name = "AirSearchButton";
            this.AirSearchButton.Size = new System.Drawing.Size(285, 94);
            this.AirSearchButton.TabIndex = 29;
            this.AirSearchButton.Text = "Поиск/Сортировка";
            this.AirSearchButton.UseVisualStyleBackColor = true;
            this.AirSearchButton.Click += new System.EventHandler(this.AirSearchButton_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSearch,
            this.MenuItemGeneration,
            this.MenuItemAboutProgram});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1026, 28);
            this.MenuStrip.TabIndex = 31;
            this.MenuStrip.Text = "menuStrip1";
            this.MenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip_ItemClicked);
            // 
            // MenuItemSearch
            // 
            this.MenuItemSearch.Name = "MenuItemSearch";
            this.MenuItemSearch.Size = new System.Drawing.Size(155, 24);
            this.MenuItemSearch.Text = "Поиск/Сортировка";
            this.MenuItemSearch.Click += new System.EventHandler(this.AirSearchButton_Click);
            // 
            // MenuItemGeneration
            // 
            this.MenuItemGeneration.Name = "MenuItemGeneration";
            this.MenuItemGeneration.Size = new System.Drawing.Size(98, 24);
            this.MenuItemGeneration.Text = "Генерация";
            this.MenuItemGeneration.Click += new System.EventHandler(this.MenuItemGeneration_Click);
            // 
            // MenuItemAboutProgram
            // 
            this.MenuItemAboutProgram.Name = "MenuItemAboutProgram";
            this.MenuItemAboutProgram.Size = new System.Drawing.Size(118, 24);
            this.MenuItemAboutProgram.Text = "О программе";
            this.MenuItemAboutProgram.Click += new System.EventHandler(this.MenuItemAboutProgram_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusItemObjectsAmountLabel,
            this.StatusItemObjectsSetAmountLabel,
            this.StatusItemTimeLabel,
            this.StatusItemTimeSetLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 570);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1026, 30);
            this.StatusStrip.TabIndex = 33;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // StatusItemObjectsAmountLabel
            // 
            this.StatusItemObjectsAmountLabel.Name = "StatusItemObjectsAmountLabel";
            this.StatusItemObjectsAmountLabel.Size = new System.Drawing.Size(190, 24);
            this.StatusItemObjectsAmountLabel.Text = "Текущее кол-во объектов:";
            this.StatusItemObjectsAmountLabel.Click += new System.EventHandler(this.StatusItemObjectsAmountLabel_Click);
            // 
            // StatusItemObjectsSetAmountLabel
            // 
            this.StatusItemObjectsSetAmountLabel.Name = "StatusItemObjectsSetAmountLabel";
            this.StatusItemObjectsSetAmountLabel.Size = new System.Drawing.Size(17, 24);
            this.StatusItemObjectsSetAmountLabel.Text = "0";
            // 
            // StatusItemTimeLabel
            // 
            this.StatusItemTimeLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.StatusItemTimeLabel.Name = "StatusItemTimeLabel";
            this.StatusItemTimeLabel.Size = new System.Drawing.Size(65, 24);
            this.StatusItemTimeLabel.Text = "Время: ";
            this.StatusItemTimeLabel.Click += new System.EventHandler(this.StatusItemTimeLabel_Click);
            // 
            // StatusItemTimeSetLabel
            // 
            this.StatusItemTimeSetLabel.Name = "StatusItemTimeSetLabel";
            this.StatusItemTimeSetLabel.Size = new System.Drawing.Size(13, 24);
            this.StatusItemTimeSetLabel.Text = " ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 600);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.AirAddButton);
            this.Controls.Add(this.AirSearchButton);
            this.Controls.Add(this.DataView);
            this.Controls.Add(this.DataGroup);
            this.Controls.Add(this.CrewAddGroup);
            this.Controls.Add(this.AirAddGroup);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.MaximumSize = new System.Drawing.Size(1044, 647);
            this.MinimumSize = new System.Drawing.Size(1044, 647);
            this.Name = "MainForm";
            this.Text = "Form Input";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.AirTypeGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AirLoadCapacitySetter)).EndInit();
            this.AirAddGroup.ResumeLayout(false);
            this.AirAddGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AirPassengersSeatsSetter)).EndInit();
            this.CrewAddGroup.ResumeLayout(false);
            this.CrewAddGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CrewMemberWorkExperienceSetter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrewMemberAgeSetter)).EndInit();
            this.DataGroup.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripStatusLabel StatusItemTimeSetLabel;

        private System.Windows.Forms.ToolStripStatusLabel StatusItemTimeLabel;

        private System.Windows.Forms.ToolStripStatusLabel StatusItemObjectsSetAmountLabel;

        private System.Windows.Forms.ToolStripStatusLabel StatusItemObjectsAmountLabel;

        private System.Windows.Forms.ToolStripMenuItem MenuItemAboutProgram;

        private System.Windows.Forms.ToolStripMenuItem MenuItemSearch;

        private System.Windows.Forms.StatusStrip StatusStrip;

        private System.Windows.Forms.MenuStrip MenuStrip;

        private System.Windows.Forms.Button DataViewClearButton;

        private System.Windows.Forms.Button AirSearchButton;

        private System.Windows.Forms.TreeView DataView;

        private System.Windows.Forms.Button AirAddButton;
        private System.Windows.Forms.Button CrewDeleteButton;
        private System.Windows.Forms.Button CrewMemberDeleteButton;

        private System.Windows.Forms.Label AirIdLabel;
        private System.Windows.Forms.TextBox AirIdInput;

        private System.Windows.Forms.GroupBox DataGroup;

        private System.Windows.Forms.Button CrewMemberAddButton;
        private System.Windows.Forms.Button DataReadButton;
        private System.Windows.Forms.Button DataSaveButton;

        private System.Windows.Forms.ComboBox CrewMemberPositionList;
        private System.Windows.Forms.Label CrewMemberPositionLabel;

        private System.Windows.Forms.Label CrewMemberWorkExperienceLabel;
        private System.Windows.Forms.NumericUpDown CrewMemberWorkExperienceSetter;

        private System.Windows.Forms.Label CrewMemberAgeLabel;
        private System.Windows.Forms.NumericUpDown CrewMemberAgeSetter;

        private System.Windows.Forms.Label CrewMemberNameLabel;

        private System.Windows.Forms.TextBox CrewMemberNameInput;

        private System.Windows.Forms.Label CrewMemberIdLabel;

        private System.Windows.Forms.GroupBox CrewAddGroup;

        private System.Windows.Forms.Label AirPassengersSeatsLabel;
        private System.Windows.Forms.NumericUpDown AirPassengersSeatsSetter;

        private System.Windows.Forms.GroupBox AirAddGroup;

        private System.Windows.Forms.Label AirLoadCapacityLabel;
        private System.Windows.Forms.NumericUpDown AirLoadCapacitySetter;

        private System.Windows.Forms.GroupBox AirTypeGroup;

        private System.Windows.Forms.ComboBox AirModelList;
        private System.Windows.Forms.Label AirModelLabel;

        private System.Windows.Forms.RadioButton AirTypeMilitary;

        private System.Windows.Forms.RadioButton AirTypeCargo;
        private System.Windows.Forms.RadioButton AirTypePassenger;

        private System.Windows.Forms.DateTimePicker AirYearReleaseDatePicker;
        private System.Windows.Forms.Label AirYearReleaseLabel;

        #endregion

        private System.Windows.Forms.ToolStripMenuItem MenuItemGeneration;
    }
}

