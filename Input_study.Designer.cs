namespace course_work
{
    partial class Input_study
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
            this.components = new System.ComponentModel.Container();
            this.button_add_progress = new System.Windows.Forms.Button();
            this.numeric_mark1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox_teacher = new System.Windows.Forms.ComboBox();
            this.comboBox_subject = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_mark1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_add_progress
            // 
            this.button_add_progress.Font = new System.Drawing.Font("Constantia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add_progress.ForeColor = System.Drawing.Color.DarkRed;
            this.button_add_progress.Location = new System.Drawing.Point(78, 242);
            this.button_add_progress.Margin = new System.Windows.Forms.Padding(4);
            this.button_add_progress.Name = "button_add_progress";
            this.button_add_progress.Size = new System.Drawing.Size(196, 66);
            this.button_add_progress.TabIndex = 37;
            this.button_add_progress.Text = "Добавить предмет";
            this.button_add_progress.UseVisualStyleBackColor = true;
            this.button_add_progress.Click += new System.EventHandler(this.button_add_progress_Click);
            // 
            // numeric_mark1
            // 
            this.numeric_mark1.Location = new System.Drawing.Point(291, 152);
            this.numeric_mark1.Margin = new System.Windows.Forms.Padding(4);
            this.numeric_mark1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numeric_mark1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_mark1.Name = "numeric_mark1";
            this.numeric_mark1.Size = new System.Drawing.Size(360, 32);
            this.numeric_mark1.TabIndex = 36;
            this.numeric_mark1.ThousandsSeparator = true;
            this.numeric_mark1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_mark1.ValueChanged += new System.EventHandler(this.numeric_mark1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Constantia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(50, 154);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 24);
            this.label7.TabIndex = 35;
            this.label7.Text = "Оценка";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Constantia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(50, 96);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 24);
            this.label6.TabIndex = 34;
            this.label6.Text = "Преподаватель";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(50, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 24);
            this.label5.TabIndex = 32;
            this.label5.Text = "Предмет";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("Constantia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Cancel.ForeColor = System.Drawing.Color.DarkRed;
            this.button_Cancel.Location = new System.Drawing.Point(376, 242);
            this.button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(189, 66);
            this.button_Cancel.TabIndex = 38;
            this.button_Cancel.Text = "Отмена";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // comboBox_teacher
            // 
            this.comboBox_teacher.FormattingEnabled = true;
            this.comboBox_teacher.Items.AddRange(new object[] {
            "Сперанский В.А.",
            "Буряк Д.В.",
            "Маслов О.В.",
            "Ершова Ю.А.",
            "Яколев И.В.",
            "Тостановская И.Б.",
            "Порпулит А.Н.",
            "Мартинюк А.Н.",
            "Мелейко Т.Н.",
            "Евсеев А.В.",
            "Фомин А.А.",
            "Панасюк И.В.",
            "Богданова Е.Н.",
            "Федорова А.Ю.",
            "Скворцов Г.А.",
            "Шоколадкин С.Ю.",
            "Тряпкина Е.Ф.",
            "Новиков Н.В.",
            "Морозов А.К.",
            "Павлов П.П.",
            "Абрамова С.И."});
            this.comboBox_teacher.Location = new System.Drawing.Point(291, 96);
            this.comboBox_teacher.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_teacher.Name = "comboBox_teacher";
            this.comboBox_teacher.Size = new System.Drawing.Size(358, 32);
            this.comboBox_teacher.TabIndex = 39;
            this.comboBox_teacher.SelectedIndexChanged += new System.EventHandler(this.comboBox_teacher_SelectedIndexChanged_1);
            this.comboBox_teacher.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComboBox_subject_KeyPress);
            // 
            // comboBox_subject
            // 
            this.comboBox_subject.FormattingEnabled = true;
            this.comboBox_subject.Items.AddRange(new object[] {
            "Высшая математика",
            "Программирование и теория алгоритмов",
            "Английский язык",
            "Основы технологий .Net",
            "Физика",
            "Основы компютерно-геометричного программирования",
            "Пакеты прикладных програм",
            "Налоговое право",
            "История Украины и украинской культуры",
            "Культорология",
            "Психология",
            "Социология",
            "Медиакультура ",
            "Архитектура",
            "Маркетинг ",
            "Менеджмент ",
            "Бухгалтерский учет ",
            "Ботаника",
            "Исследования в области дизайна",
            "Философия",
            "Журналистика",
            "Экономика",
            "Биотехнологи"});
            this.comboBox_subject.Location = new System.Drawing.Point(291, 31);
            this.comboBox_subject.Name = "comboBox_subject";
            this.comboBox_subject.Size = new System.Drawing.Size(358, 32);
            this.comboBox_subject.TabIndex = 40;
            this.comboBox_subject.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Input_study
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(693, 354);
            this.Controls.Add(this.comboBox_subject);
            this.Controls.Add(this.comboBox_teacher);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_add_progress);
            this.Controls.Add(this.numeric_mark1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Constantia", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(711, 401);
            this.MinimumSize = new System.Drawing.Size(711, 401);
            this.Name = "Input_study";
            this.Text = "Input_study";
            this.Load += new System.EventHandler(this.Input_study_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_mark1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_add_progress;
        private System.Windows.Forms.NumericUpDown numeric_mark1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.ComboBox comboBox_teacher;
        private System.Windows.Forms.ComboBox comboBox_subject;
    }
}