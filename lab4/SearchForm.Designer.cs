using System.ComponentModel;

namespace S2_Lab02
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchByGroup = new System.Windows.Forms.GroupBox();
            this.SearchTypePassengersSeats = new System.Windows.Forms.RadioButton();
            this.SearchTypeLoadCapacity = new System.Windows.Forms.RadioButton();
            this.SearchTypeType = new System.Windows.Forms.RadioButton();
            this.SearchTypeModel = new System.Windows.Forms.RadioButton();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.SearchResultDataView = new System.Windows.Forms.TextBox();
            this.SearchInputExample = new System.Windows.Forms.Label();
            this.SearchInputGroup = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CheckSorting = new System.Windows.Forms.CheckBox();
            this.groupExtraOptions = new System.Windows.Forms.GroupBox();
            this.SearchByGroup.SuspendLayout();
            this.SearchInputGroup.SuspendLayout();
            this.groupExtraOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchByGroup
            // 
            this.SearchByGroup.Controls.Add(this.SearchTypePassengersSeats);
            this.SearchByGroup.Controls.Add(this.SearchTypeLoadCapacity);
            this.SearchByGroup.Controls.Add(this.SearchTypeType);
            this.SearchByGroup.Controls.Add(this.SearchTypeModel);
            this.SearchByGroup.Location = new System.Drawing.Point(12, 12);
            this.SearchByGroup.Name = "SearchByGroup";
            this.SearchByGroup.Size = new System.Drawing.Size(205, 144);
            this.SearchByGroup.TabIndex = 1;
            this.SearchByGroup.TabStop = false;
            this.SearchByGroup.Text = "Поиск по";
            // 
            // SearchTypePassengersSeats
            // 
            this.SearchTypePassengersSeats.Location = new System.Drawing.Point(6, 111);
            this.SearchTypePassengersSeats.Name = "SearchTypePassengersSeats";
            this.SearchTypePassengersSeats.Size = new System.Drawing.Size(178, 24);
            this.SearchTypePassengersSeats.TabIndex = 3;
            this.SearchTypePassengersSeats.TabStop = true;
            this.SearchTypePassengersSeats.Text = "Кол-ву пасс. мест";
            this.SearchTypePassengersSeats.UseVisualStyleBackColor = true;
            // 
            // SearchTypeLoadCapacity
            // 
            this.SearchTypeLoadCapacity.Location = new System.Drawing.Point(6, 81);
            this.SearchTypeLoadCapacity.Name = "SearchTypeLoadCapacity";
            this.SearchTypeLoadCapacity.Size = new System.Drawing.Size(193, 24);
            this.SearchTypeLoadCapacity.TabIndex = 2;
            this.SearchTypeLoadCapacity.TabStop = true;
            this.SearchTypeLoadCapacity.Text = "Грузоподъёмности";
            this.SearchTypeLoadCapacity.UseVisualStyleBackColor = true;
            // 
            // SearchTypeType
            // 
            this.SearchTypeType.Location = new System.Drawing.Point(6, 51);
            this.SearchTypeType.Name = "SearchTypeType";
            this.SearchTypeType.Size = new System.Drawing.Size(104, 24);
            this.SearchTypeType.TabIndex = 1;
            this.SearchTypeType.TabStop = true;
            this.SearchTypeType.Text = "Типу";
            this.SearchTypeType.UseVisualStyleBackColor = true;
            // 
            // SearchTypeModel
            // 
            this.SearchTypeModel.Location = new System.Drawing.Point(6, 21);
            this.SearchTypeModel.Name = "SearchTypeModel";
            this.SearchTypeModel.Size = new System.Drawing.Size(104, 24);
            this.SearchTypeModel.TabIndex = 0;
            this.SearchTypeModel.TabStop = true;
            this.SearchTypeModel.Text = "Модели";
            this.SearchTypeModel.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SearchButton.Location = new System.Drawing.Point(12, 372);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(234, 65);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Выполнить";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchInput
            // 
            this.SearchInput.Enabled = false;
            this.SearchInput.Location = new System.Drawing.Point(6, 21);
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(225, 22);
            this.SearchInput.TabIndex = 5;
            // 
            // SearchResultDataView
            // 
            this.SearchResultDataView.Location = new System.Drawing.Point(12, 235);
            this.SearchResultDataView.Multiline = true;
            this.SearchResultDataView.Name = "SearchResultDataView";
            this.SearchResultDataView.ReadOnly = true;
            this.SearchResultDataView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SearchResultDataView.Size = new System.Drawing.Size(448, 131);
            this.SearchResultDataView.TabIndex = 6;
            // 
            // SearchInputExample
            // 
            this.SearchInputExample.Location = new System.Drawing.Point(6, 46);
            this.SearchInputExample.Name = "SearchInputExample";
            this.SearchInputExample.Size = new System.Drawing.Size(225, 35);
            this.SearchInputExample.TabIndex = 7;
            this.SearchInputExample.Text = "Вид поиска:";
            // 
            // SearchInputGroup
            // 
            this.SearchInputGroup.Controls.Add(this.SearchInput);
            this.SearchInputGroup.Controls.Add(this.SearchInputExample);
            this.SearchInputGroup.Location = new System.Drawing.Point(223, 12);
            this.SearchInputGroup.Name = "SearchInputGroup";
            this.SearchInputGroup.Size = new System.Drawing.Size(237, 144);
            this.SearchInputGroup.TabIndex = 8;
            this.SearchInputGroup.TabStop = false;
            this.SearchInputGroup.Text = "Ввод данных";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.SaveButton.Location = new System.Drawing.Point(297, 372);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(163, 65);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Сохранить результаты";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CheckSorting
            // 
            this.CheckSorting.AutoSize = true;
            this.CheckSorting.Location = new System.Drawing.Point(6, 21);
            this.CheckSorting.Name = "CheckSorting";
            this.CheckSorting.Size = new System.Drawing.Size(228, 21);
            this.CheckSorting.TabIndex = 8;
            this.CheckSorting.Text = "Сортировать по дате выпуска";
            this.CheckSorting.UseVisualStyleBackColor = true;
            // 
            // groupExtraOptions
            // 
            this.groupExtraOptions.Controls.Add(this.CheckSorting);
            this.groupExtraOptions.Location = new System.Drawing.Point(12, 162);
            this.groupExtraOptions.Name = "groupExtraOptions";
            this.groupExtraOptions.Size = new System.Drawing.Size(448, 67);
            this.groupExtraOptions.TabIndex = 10;
            this.groupExtraOptions.TabStop = false;
            this.groupExtraOptions.Text = "Доп параметры";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 464);
            this.Controls.Add(this.groupExtraOptions);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchInputGroup);
            this.Controls.Add(this.SearchResultDataView);
            this.Controls.Add(this.SearchByGroup);
            this.MaximumSize = new System.Drawing.Size(488, 511);
            this.MinimumSize = new System.Drawing.Size(488, 511);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.SearchByGroup.ResumeLayout(false);
            this.SearchInputGroup.ResumeLayout(false);
            this.SearchInputGroup.PerformLayout();
            this.groupExtraOptions.ResumeLayout(false);
            this.groupExtraOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox SearchInputGroup;

        private System.Windows.Forms.Label SearchInputExample;

        private System.Windows.Forms.TextBox SearchResultDataView;

        private System.Windows.Forms.TextBox SearchInput;

        private System.Windows.Forms.RadioButton SearchTypeType;
        private System.Windows.Forms.RadioButton SearchTypeLoadCapacity;
        private System.Windows.Forms.RadioButton SearchTypePassengersSeats;

        private System.Windows.Forms.Button SearchButton;

        private System.Windows.Forms.RadioButton SearchTypeModel;

        private System.Windows.Forms.GroupBox SearchByGroup;

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox CheckSorting;
        private System.Windows.Forms.GroupBox groupExtraOptions;
    }
}