namespace Work_Pal
{
    partial class frmMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.date = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.timeTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnWork = new System.Windows.Forms.Button();
            this.timeWeek = new System.Windows.Forms.Label();
            this.timeCurrent = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.ForeColor = System.Drawing.Color.White;
            this.date.Location = new System.Drawing.Point(0, 0);
            this.date.MaximumSize = new System.Drawing.Size(400, 50);
            this.date.MinimumSize = new System.Drawing.Size(400, 50);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(400, 50);
            this.date.TabIndex = 0;
            this.date.Text = "Today\'s date";
            this.date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Location = new System.Drawing.Point(0, 50);
            this.time.MaximumSize = new System.Drawing.Size(400, 50);
            this.time.MinimumSize = new System.Drawing.Size(400, 50);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(400, 50);
            this.time.TabIndex = 1;
            this.time.Text = "0 : 0 : 0";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeTimer
            // 
            this.timeTimer.Tick += new System.EventHandler(this.timeTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.date);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 50);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Controls.Add(this.btnWork);
            this.panel2.Location = new System.Drawing.Point(0, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 60);
            this.panel2.TabIndex = 8;
            // 
            // btnWork
            // 
            this.btnWork.BackColor = System.Drawing.Color.Teal;
            this.btnWork.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnWork.FlatAppearance.BorderSize = 2;
            this.btnWork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnWork.ForeColor = System.Drawing.Color.White;
            this.btnWork.Location = new System.Drawing.Point(125, 10);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(150, 30);
            this.btnWork.TabIndex = 5;
            this.btnWork.Text = "Start Work";
            this.btnWork.UseVisualStyleBackColor = false;
            this.btnWork.Click += new System.EventHandler(this.btnWork_Click);
            // 
            // timeWeek
            // 
            this.timeWeek.AutoSize = true;
            this.timeWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeWeek.Location = new System.Drawing.Point(0, 100);
            this.timeWeek.MaximumSize = new System.Drawing.Size(200, 25);
            this.timeWeek.MinimumSize = new System.Drawing.Size(200, 25);
            this.timeWeek.Name = "timeWeek";
            this.timeWeek.Size = new System.Drawing.Size(200, 25);
            this.timeWeek.TabIndex = 9;
            this.timeWeek.Text = "0 : 0 : 0";
            this.timeWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeCurrent
            // 
            this.timeCurrent.AutoSize = true;
            this.timeCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeCurrent.Location = new System.Drawing.Point(200, 100);
            this.timeCurrent.MaximumSize = new System.Drawing.Size(200, 25);
            this.timeCurrent.MinimumSize = new System.Drawing.Size(200, 25);
            this.timeCurrent.Name = "timeCurrent";
            this.timeCurrent.Size = new System.Drawing.Size(200, 25);
            this.timeCurrent.TabIndex = 10;
            this.timeCurrent.Text = "0:0:0:000";
            this.timeCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.LightGray;
            this.chart.BorderlineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.IsMarksNextToAxis = false;
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX.LineWidth = 0;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX2.IsMarksNextToAxis = false;
            chartArea1.AxisX2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisX2.LineWidth = 0;
            chartArea1.AxisY.LineWidth = 0;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.LineWidth = 0;
            chartArea1.BackColor = System.Drawing.Color.LightGray;
            chartArea1.BorderColor = System.Drawing.Color.Transparent;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(0, 128);
            this.chart.MaximumSize = new System.Drawing.Size(400, 185);
            this.chart.MinimumSize = new System.Drawing.Size(400, 185);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart.Size = new System.Drawing.Size(400, 185);
            this.chart.TabIndex = 11;
            this.chart.Text = "chart1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(400, 361);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.timeCurrent);
            this.Controls.Add(this.timeWeek);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.time);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 400);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Timer timeTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnWork;
        private System.Windows.Forms.Label timeWeek;
        private System.Windows.Forms.Label timeCurrent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}

