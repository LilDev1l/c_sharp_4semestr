
namespace S2_Lab02
{
    partial class GenerationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.QuantityPlanesLabel = new System.Windows.Forms.Label();
            this.QuantityPlanesNumricUpDown = new System.Windows.Forms.NumericUpDown();
            this.AirTypeGroup = new System.Windows.Forms.GroupBox();
            this.AirTypeCargo = new System.Windows.Forms.RadioButton();
            this.AirTypePassenger = new System.Windows.Forms.RadioButton();
            this.AirTypeWar = new System.Windows.Forms.RadioButton();
            this.GenerationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityPlanesNumricUpDown)).BeginInit();
            this.AirTypeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuantityPlanesLabel
            // 
            this.QuantityPlanesLabel.AutoSize = true;
            this.QuantityPlanesLabel.Location = new System.Drawing.Point(9, 9);
            this.QuantityPlanesLabel.Name = "QuantityPlanesLabel";
            this.QuantityPlanesLabel.Size = new System.Drawing.Size(160, 17);
            this.QuantityPlanesLabel.TabIndex = 0;
            this.QuantityPlanesLabel.Text = "Количество самолетов";
            // 
            // QuantityPlanesNumricUpDown
            // 
            this.QuantityPlanesNumricUpDown.Location = new System.Drawing.Point(12, 29);
            this.QuantityPlanesNumricUpDown.Name = "QuantityPlanesNumricUpDown";
            this.QuantityPlanesNumricUpDown.Size = new System.Drawing.Size(120, 22);
            this.QuantityPlanesNumricUpDown.TabIndex = 1;
            // 
            // AirTypeGroup
            // 
            this.AirTypeGroup.Controls.Add(this.AirTypeCargo);
            this.AirTypeGroup.Controls.Add(this.AirTypePassenger);
            this.AirTypeGroup.Controls.Add(this.AirTypeWar);
            this.AirTypeGroup.Location = new System.Drawing.Point(12, 57);
            this.AirTypeGroup.Name = "AirTypeGroup";
            this.AirTypeGroup.Size = new System.Drawing.Size(285, 106);
            this.AirTypeGroup.TabIndex = 11;
            this.AirTypeGroup.TabStop = false;
            this.AirTypeGroup.Text = "Тип самолёта";
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
            // AirTypeWar
            // 
            this.AirTypeWar.Location = new System.Drawing.Point(6, 79);
            this.AirTypeWar.Name = "AirTypeWar";
            this.AirTypeWar.Size = new System.Drawing.Size(104, 24);
            this.AirTypeWar.TabIndex = 7;
            this.AirTypeWar.TabStop = true;
            this.AirTypeWar.Text = "Военный";
            this.AirTypeWar.UseVisualStyleBackColor = true;
            // 
            // GenerationButton
            // 
            this.GenerationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.GenerationButton.Location = new System.Drawing.Point(12, 178);
            this.GenerationButton.Name = "GenerationButton";
            this.GenerationButton.Size = new System.Drawing.Size(280, 46);
            this.GenerationButton.TabIndex = 12;
            this.GenerationButton.Text = "Сгенерировать";
            this.GenerationButton.UseVisualStyleBackColor = true;
            this.GenerationButton.Click += new System.EventHandler(this.GenerationButton_Click);
            // 
            // GenerationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 236);
            this.Controls.Add(this.GenerationButton);
            this.Controls.Add(this.AirTypeGroup);
            this.Controls.Add(this.QuantityPlanesNumricUpDown);
            this.Controls.Add(this.QuantityPlanesLabel);
            this.Name = "GenerationForm";
            this.Text = "GenerationForm";
            ((System.ComponentModel.ISupportInitialize)(this.QuantityPlanesNumricUpDown)).EndInit();
            this.AirTypeGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuantityPlanesLabel;
        private System.Windows.Forms.NumericUpDown QuantityPlanesNumricUpDown;
        private System.Windows.Forms.GroupBox AirTypeGroup;
        private System.Windows.Forms.RadioButton AirTypeCargo;
        private System.Windows.Forms.RadioButton AirTypePassenger;
        private System.Windows.Forms.RadioButton AirTypeWar;
        private System.Windows.Forms.Button GenerationButton;
    }
}