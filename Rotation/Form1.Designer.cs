namespace Rotation
{
    partial class Form1
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Loading = new System.Windows.Forms.Button();
            this.NamePicture = new System.Windows.Forms.Label();
            this.NamePic = new System.Windows.Forms.GroupBox();
            this.panelPic = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Angle = new System.Windows.Forms.NumericUpDown();
            this.AngleGroup = new System.Windows.Forms.GroupBox();
            this.apply_angle = new System.Windows.Forms.Button();
            this.NamePic.SuspendLayout();
            this.panelPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle)).BeginInit();
            this.AngleGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Loading
            // 
            this.Loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Loading.Location = new System.Drawing.Point(615, 16);
            this.Loading.Name = "Loading";
            this.Loading.Size = new System.Drawing.Size(131, 50);
            this.Loading.TabIndex = 1;
            this.Loading.Text = "Загрузить";
            this.Loading.UseVisualStyleBackColor = true;
            this.Loading.Click += new System.EventHandler(this.Loading_Click);
            // 
            // NamePicture
            // 
            this.NamePicture.AutoSize = true;
            this.NamePicture.Location = new System.Drawing.Point(18, 33);
            this.NamePicture.Name = "NamePicture";
            this.NamePicture.Size = new System.Drawing.Size(55, 16);
            this.NamePicture.TabIndex = 2;
            this.NamePicture.Text = "Ничего";
            // 
            // NamePic
            // 
            this.NamePic.Controls.Add(this.NamePicture);
            this.NamePic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NamePic.Location = new System.Drawing.Point(594, 104);
            this.NamePic.Name = "NamePic";
            this.NamePic.Size = new System.Drawing.Size(201, 70);
            this.NamePic.TabIndex = 3;
            this.NamePic.TabStop = false;
            this.NamePic.Text = "Имя файла";
            // 
            // panelPic
            // 
            this.panelPic.AutoScroll = true;
            this.panelPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPic.Controls.Add(this.pictureBox1);
            this.panelPic.Location = new System.Drawing.Point(12, 12);
            this.panelPic.Name = "panelPic";
            this.panelPic.Size = new System.Drawing.Size(531, 656);
            this.panelPic.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(523, 648);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Angle
            // 
            this.Angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Angle.Location = new System.Drawing.Point(6, 30);
            this.Angle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.Angle.Name = "Angle";
            this.Angle.Size = new System.Drawing.Size(120, 22);
            this.Angle.TabIndex = 5;
            // 
            // AngleGroup
            // 
            this.AngleGroup.Controls.Add(this.apply_angle);
            this.AngleGroup.Controls.Add(this.Angle);
            this.AngleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AngleGroup.Location = new System.Drawing.Point(594, 215);
            this.AngleGroup.Name = "AngleGroup";
            this.AngleGroup.Size = new System.Drawing.Size(201, 119);
            this.AngleGroup.TabIndex = 6;
            this.AngleGroup.TabStop = false;
            this.AngleGroup.Text = "Угол поворота";
            // 
            // apply_angle
            // 
            this.apply_angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.apply_angle.Location = new System.Drawing.Point(6, 67);
            this.apply_angle.Name = "apply_angle";
            this.apply_angle.Size = new System.Drawing.Size(119, 36);
            this.apply_angle.TabIndex = 6;
            this.apply_angle.Text = "Применить";
            this.apply_angle.UseVisualStyleBackColor = true;
            this.apply_angle.Click += new System.EventHandler(this.apply_angle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 680);
            this.Controls.Add(this.AngleGroup);
            this.Controls.Add(this.panelPic);
            this.Controls.Add(this.NamePic);
            this.Controls.Add(this.Loading);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(870, 719);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(870, 719);
            this.Name = "Form1";
            this.Text = "Rotation";
            this.NamePic.ResumeLayout(false);
            this.NamePic.PerformLayout();
            this.panelPic.ResumeLayout(false);
            this.panelPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle)).EndInit();
            this.AngleGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Loading;
        private System.Windows.Forms.Label NamePicture;
        private System.Windows.Forms.GroupBox NamePic;
        private System.Windows.Forms.Panel panelPic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown Angle;
        private System.Windows.Forms.GroupBox AngleGroup;
        private System.Windows.Forms.Button apply_angle;
    }
}

