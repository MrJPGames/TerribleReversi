namespace WindowsFormsApp2 {
	partial class Form1 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.gameField = new System.Windows.Forms.PictureBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.boardSizeInput = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.blackScoreLabel = new System.Windows.Forms.Label();
			this.whiteScoreLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.helpSettingInput = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.gameField)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.boardSizeInput)).BeginInit();
			this.SuspendLayout();
			// 
			// gameField
			// 
			this.gameField.Location = new System.Drawing.Point(12, 13);
			this.gameField.Name = "gameField";
			this.gameField.Size = new System.Drawing.Size(399, 399);
			this.gameField.TabIndex = 0;
			this.gameField.TabStop = false;
			this.gameField.Click += new System.EventHandler(this.gameField_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(421, 357);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(100, 17);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Play Agains A.I.";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(498, 393);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(102, 20);
			this.button1.TabIndex = 4;
			this.button1.Text = "Restart Game";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// boardSizeInput
			// 
			this.boardSizeInput.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.boardSizeInput.Location = new System.Drawing.Point(421, 393);
			this.boardSizeInput.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
			this.boardSizeInput.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.boardSizeInput.Name = "boardSizeInput";
			this.boardSizeInput.Size = new System.Drawing.Size(71, 20);
			this.boardSizeInput.TabIndex = 5;
			this.boardSizeInput.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(418, 377);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Bord groote";
			// 
			// blackScoreLabel
			// 
			this.blackScoreLabel.AutoSize = true;
			this.blackScoreLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blackScoreLabel.Location = new System.Drawing.Point(417, 13);
			this.blackScoreLabel.Name = "blackScoreLabel";
			this.blackScoreLabel.Size = new System.Drawing.Size(147, 22);
			this.blackScoreLabel.TabIndex = 7;
			this.blackScoreLabel.Text = "blackScoreLabel";
			// 
			// whiteScoreLabel
			// 
			this.whiteScoreLabel.AutoSize = true;
			this.whiteScoreLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.whiteScoreLabel.Location = new System.Drawing.Point(417, 35);
			this.whiteScoreLabel.Name = "whiteScoreLabel";
			this.whiteScoreLabel.Size = new System.Drawing.Size(149, 22);
			this.whiteScoreLabel.TabIndex = 8;
			this.whiteScoreLabel.Text = "whiteScoreLabel";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.Location = new System.Drawing.Point(417, 57);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(108, 22);
			this.statusLabel.TabIndex = 9;
			this.statusLabel.Text = "statusLabel";
			// 
			// helpSettingInput
			// 
			this.helpSettingInput.AutoSize = true;
			this.helpSettingInput.Checked = true;
			this.helpSettingInput.CheckState = System.Windows.Forms.CheckState.Checked;
			this.helpSettingInput.Location = new System.Drawing.Point(418, 334);
			this.helpSettingInput.Name = "helpSettingInput";
			this.helpSettingInput.Size = new System.Drawing.Size(48, 17);
			this.helpSettingInput.TabIndex = 10;
			this.helpSettingInput.Text = "Help";
			this.helpSettingInput.UseVisualStyleBackColor = true;
			this.helpSettingInput.CheckedChanged += new System.EventHandler(this.helpSettingInput_CheckedChanged);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(604, 425);
			this.Controls.Add(this.helpSettingInput);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.whiteScoreLabel);
			this.Controls.Add(this.blackScoreLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.boardSizeInput);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.gameField);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Reversi";
			((System.ComponentModel.ISupportInitialize)(this.gameField)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.boardSizeInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox gameField;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown boardSizeInput;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label blackScoreLabel;
		private System.Windows.Forms.Label whiteScoreLabel;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.CheckBox helpSettingInput;
	}
}

