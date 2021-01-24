namespace PhotoEditorWinF
{
    partial class FMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.ListBoxPhotos = new System.Windows.Forms.ListBox();
            this.ButTurn = new System.Windows.Forms.Button();
            this.ButSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.TextBoxAngle = new System.Windows.Forms.TextBox();
            this.LabBrightness = new System.Windows.Forms.Label();
            this.TrackBarBrightness = new System.Windows.Forms.TrackBar();
            this.LabContrast = new System.Windows.Forms.Label();
            this.TrackBarContrast = new System.Windows.Forms.TrackBar();
            this.ButIncrease = new System.Windows.Forms.Button();
            this.ButDecrease = new System.Windows.Forms.Button();
            this.LabPenSize = new System.Windows.Forms.Label();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.TrackBarPenSize = new System.Windows.Forms.TrackBar();
            this.ButChooseColor = new System.Windows.Forms.Button();
            this.LabRedColor = new System.Windows.Forms.Label();
            this.TrackBarRedColor = new System.Windows.Forms.TrackBar();
            this.LabGreenColor = new System.Windows.Forms.Label();
            this.LabBlueColor = new System.Windows.Forms.Label();
            this.TrackBarGreenColor = new System.Windows.Forms.TrackBar();
            this.TrackBarBlueColor = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPenSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRedColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarGreenColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBlueColor)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBox
            // 
            this.PicBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PicBox.Location = new System.Drawing.Point(258, 23);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(966, 631);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PicBox.TabIndex = 2;
            this.PicBox.TabStop = false;
            this.PicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseDown);
            this.PicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseMove);
            this.PicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PicBox_MouseUp);
            // 
            // ListBoxPhotos
            // 
            this.ListBoxPhotos.FormattingEnabled = true;
            this.ListBoxPhotos.ItemHeight = 20;
            this.ListBoxPhotos.Location = new System.Drawing.Point(22, 23);
            this.ListBoxPhotos.Name = "ListBoxPhotos";
            this.ListBoxPhotos.Size = new System.Drawing.Size(196, 624);
            this.ListBoxPhotos.TabIndex = 0;
            this.ListBoxPhotos.SelectedIndexChanged += new System.EventHandler(this.ListBoxPhotos_SelectedIndexChanged);
            // 
            // ButTurn
            // 
            this.ButTurn.Location = new System.Drawing.Point(1346, 382);
            this.ButTurn.Name = "ButTurn";
            this.ButTurn.Size = new System.Drawing.Size(64, 29);
            this.ButTurn.TabIndex = 3;
            this.ButTurn.Text = "Turn";
            this.ButTurn.UseVisualStyleBackColor = true;
            this.ButTurn.Click += new System.EventHandler(this.ButTurn_Click);
            // 
            // ButSave
            // 
            this.ButSave.Location = new System.Drawing.Point(1261, 610);
            this.ButSave.Name = "ButSave";
            this.ButSave.Size = new System.Drawing.Size(248, 37);
            this.ButSave.TabIndex = 5;
            this.ButSave.Text = "Save";
            this.ButSave.UseVisualStyleBackColor = true;
            this.ButSave.Click += new System.EventHandler(this.ButSave_Click);
            // 
            // TextBoxAngle
            // 
            this.TextBoxAngle.Location = new System.Drawing.Point(1429, 384);
            this.TextBoxAngle.MaxLength = 4;
            this.TextBoxAngle.Name = "TextBoxAngle";
            this.TextBoxAngle.Size = new System.Drawing.Size(50, 27);
            this.TextBoxAngle.TabIndex = 6;
            this.TextBoxAngle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxAngle_KeyPress);
            // 
            // LabBrightness
            // 
            this.LabBrightness.AutoSize = true;
            this.LabBrightness.Location = new System.Drawing.Point(1244, 40);
            this.LabBrightness.Name = "LabBrightness";
            this.LabBrightness.Size = new System.Drawing.Size(77, 20);
            this.LabBrightness.TabIndex = 7;
            this.LabBrightness.Text = "Brightness";
            // 
            // TrackBarBrightness
            // 
            this.TrackBarBrightness.LargeChange = 1;
            this.TrackBarBrightness.Location = new System.Drawing.Point(1332, 40);
            this.TrackBarBrightness.Maximum = 80;
            this.TrackBarBrightness.Minimum = -110;
            this.TrackBarBrightness.Name = "TrackBarBrightness";
            this.TrackBarBrightness.Size = new System.Drawing.Size(177, 56);
            this.TrackBarBrightness.TabIndex = 8;
            this.TrackBarBrightness.TickFrequency = 10;
            this.TrackBarBrightness.Scroll += new System.EventHandler(this.TrackBarBrightness_Scroll);
            // 
            // LabContrast
            // 
            this.LabContrast.AutoSize = true;
            this.LabContrast.Location = new System.Drawing.Point(1244, 103);
            this.LabContrast.Name = "LabContrast";
            this.LabContrast.Size = new System.Drawing.Size(64, 20);
            this.LabContrast.TabIndex = 9;
            this.LabContrast.Text = "Contrast";
            // 
            // TrackBarContrast
            // 
            this.TrackBarContrast.LargeChange = 1;
            this.TrackBarContrast.Location = new System.Drawing.Point(1332, 102);
            this.TrackBarContrast.Maximum = 200;
            this.TrackBarContrast.Minimum = 10;
            this.TrackBarContrast.Name = "TrackBarContrast";
            this.TrackBarContrast.Size = new System.Drawing.Size(177, 56);
            this.TrackBarContrast.TabIndex = 10;
            this.TrackBarContrast.TickFrequency = 10;
            this.TrackBarContrast.Value = 30;
            this.TrackBarContrast.Scroll += new System.EventHandler(this.TrackBarContrast_Scroll);
            // 
            // ButIncrease
            // 
            this.ButIncrease.Location = new System.Drawing.Point(1346, 326);
            this.ButIncrease.Name = "ButIncrease";
            this.ButIncrease.Size = new System.Drawing.Size(53, 29);
            this.ButIncrease.TabIndex = 11;
            this.ButIncrease.Text = "+";
            this.ButIncrease.UseVisualStyleBackColor = true;
            this.ButIncrease.Click += new System.EventHandler(this.ButIncrease_Click);
            // 
            // ButDecrease
            // 
            this.ButDecrease.Location = new System.Drawing.Point(1429, 326);
            this.ButDecrease.Name = "ButDecrease";
            this.ButDecrease.Size = new System.Drawing.Size(50, 29);
            this.ButDecrease.TabIndex = 12;
            this.ButDecrease.Text = "-";
            this.ButDecrease.UseVisualStyleBackColor = true;
            this.ButDecrease.Click += new System.EventHandler(this.ButDecrease_Click);
            // 
            // LabPenSize
            // 
            this.LabPenSize.AutoSize = true;
            this.LabPenSize.Location = new System.Drawing.Point(1261, 457);
            this.LabPenSize.Name = "LabPenSize";
            this.LabPenSize.Size = new System.Drawing.Size(61, 20);
            this.LabPenSize.TabIndex = 13;
            this.LabPenSize.Text = "Pen size";
            // 
            // TrackBarPenSize
            // 
            this.TrackBarPenSize.Location = new System.Drawing.Point(1346, 457);
            this.TrackBarPenSize.Maximum = 100;
            this.TrackBarPenSize.Minimum = 5;
            this.TrackBarPenSize.Name = "TrackBarPenSize";
            this.TrackBarPenSize.Size = new System.Drawing.Size(163, 56);
            this.TrackBarPenSize.TabIndex = 14;
            this.TrackBarPenSize.TickFrequency = 5;
            this.TrackBarPenSize.Value = 15;
            this.TrackBarPenSize.Scroll += new System.EventHandler(this.TrackBarPenSize_Scroll);
            // 
            // ButChooseColor
            // 
            this.ButChooseColor.Location = new System.Drawing.Point(1366, 519);
            this.ButChooseColor.Name = "ButChooseColor";
            this.ButChooseColor.Size = new System.Drawing.Size(113, 57);
            this.ButChooseColor.TabIndex = 15;
            this.ButChooseColor.Text = "Choose color";
            this.ButChooseColor.UseVisualStyleBackColor = true;
            this.ButChooseColor.Click += new System.EventHandler(this.ButChooseColor_Click);
            // 
            // LabRedColor
            // 
            this.LabRedColor.AutoSize = true;
            this.LabRedColor.Location = new System.Drawing.Point(1271, 171);
            this.LabRedColor.Name = "LabRedColor";
            this.LabRedColor.Size = new System.Drawing.Size(18, 20);
            this.LabRedColor.TabIndex = 16;
            this.LabRedColor.Text = "R";
            // 
            // TrackBarRedColor
            // 
            this.TrackBarRedColor.LargeChange = 1;
            this.TrackBarRedColor.Location = new System.Drawing.Point(1332, 171);
            this.TrackBarRedColor.Maximum = 100;
            this.TrackBarRedColor.Name = "TrackBarRedColor";
            this.TrackBarRedColor.Size = new System.Drawing.Size(177, 56);
            this.TrackBarRedColor.TabIndex = 17;
            this.TrackBarRedColor.TickFrequency = 5;
            this.TrackBarRedColor.Value = 10;
            this.TrackBarRedColor.Scroll += new System.EventHandler(this.TrackBarRedColor_Scroll);
            // 
            // LabGreenColor
            // 
            this.LabGreenColor.AutoSize = true;
            this.LabGreenColor.Location = new System.Drawing.Point(1272, 221);
            this.LabGreenColor.Name = "LabGreenColor";
            this.LabGreenColor.Size = new System.Drawing.Size(19, 20);
            this.LabGreenColor.TabIndex = 18;
            this.LabGreenColor.Text = "G";
            // 
            // LabBlueColor
            // 
            this.LabBlueColor.AutoSize = true;
            this.LabBlueColor.Location = new System.Drawing.Point(1273, 264);
            this.LabBlueColor.Name = "LabBlueColor";
            this.LabBlueColor.Size = new System.Drawing.Size(18, 20);
            this.LabBlueColor.TabIndex = 18;
            this.LabBlueColor.Text = "B";
            // 
            // TrackBarGreenColor
            // 
            this.TrackBarGreenColor.LargeChange = 1;
            this.TrackBarGreenColor.Location = new System.Drawing.Point(1332, 221);
            this.TrackBarGreenColor.Maximum = 100;
            this.TrackBarGreenColor.Name = "TrackBarGreenColor";
            this.TrackBarGreenColor.Size = new System.Drawing.Size(177, 56);
            this.TrackBarGreenColor.TabIndex = 19;
            this.TrackBarGreenColor.TickFrequency = 5;
            this.TrackBarGreenColor.Value = 10;
            this.TrackBarGreenColor.Scroll += new System.EventHandler(this.TrackBarGreenColor_Scroll);
            // 
            // TrackBarBlueColor
            // 
            this.TrackBarBlueColor.LargeChange = 1;
            this.TrackBarBlueColor.Location = new System.Drawing.Point(1332, 264);
            this.TrackBarBlueColor.Maximum = 100;
            this.TrackBarBlueColor.Name = "TrackBarBlueColor";
            this.TrackBarBlueColor.Size = new System.Drawing.Size(177, 56);
            this.TrackBarBlueColor.TabIndex = 19;
            this.TrackBarBlueColor.TickFrequency = 5;
            this.TrackBarBlueColor.Value = 10;
            this.TrackBarBlueColor.Scroll += new System.EventHandler(this.TrackBarBlue_Scroll);
            // 
            // FMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 687);
            this.Controls.Add(this.TrackBarBlueColor);
            this.Controls.Add(this.TrackBarGreenColor);
            this.Controls.Add(this.LabBlueColor);
            this.Controls.Add(this.LabGreenColor);
            this.Controls.Add(this.TrackBarRedColor);
            this.Controls.Add(this.LabRedColor);
            this.Controls.Add(this.ButChooseColor);
            this.Controls.Add(this.TrackBarPenSize);
            this.Controls.Add(this.LabPenSize);
            this.Controls.Add(this.ButDecrease);
            this.Controls.Add(this.ButIncrease);
            this.Controls.Add(this.TrackBarContrast);
            this.Controls.Add(this.LabContrast);
            this.Controls.Add(this.TrackBarBrightness);
            this.Controls.Add(this.LabBrightness);
            this.Controls.Add(this.TextBoxAngle);
            this.Controls.Add(this.ButSave);
            this.Controls.Add(this.ButTurn);
            this.Controls.Add(this.ListBoxPhotos);
            this.Controls.Add(this.PicBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FMain";
            this.Text = "Photo Editor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FMain_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarPenSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRedColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarGreenColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBlueColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.ListBox ListBoxPhotos;
        private System.Windows.Forms.Button ButTurn;
        private System.Windows.Forms.Button ButSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox TextBoxAngle;
        private System.Windows.Forms.Label LabBrightness;
        private System.Windows.Forms.TrackBar TrackBarBrightness;
        private System.Windows.Forms.Label LabContrast;
        private System.Windows.Forms.TrackBar TrackBarContrast;
        private System.Windows.Forms.Button ButIncrease;
        private System.Windows.Forms.Button ButDecrease;
        private System.Windows.Forms.Label LabPenSize;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.TrackBar TrackBarPenSize;
        private System.Windows.Forms.Button ButChooseColor;
        private System.Windows.Forms.Label LabRedColor;
        private System.Windows.Forms.TrackBar TrackBarRedColor;
        private System.Windows.Forms.Label LabGreenColor;
        private System.Windows.Forms.Label LabBlueColor;
        private System.Windows.Forms.TrackBar TrackBarGreenColor;
        private System.Windows.Forms.TrackBar TrackBarBlueColor;
    }
}

