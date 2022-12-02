namespace PreyPredatorModel.Froms
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_pd = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button_start = new System.Windows.Forms.Button();
            this.textBox_pd = new System.Windows.Forms.TextBox();
            this.comboBox_ntype = new System.Windows.Forms.ComboBox();
            this.label_pb = new System.Windows.Forms.Label();
            this.textBox_pb = new System.Windows.Forms.TextBox();
            this.label_hd = new System.Windows.Forms.Label();
            this.textBox_hd = new System.Windows.Forms.TextBox();
            this.label_hb = new System.Windows.Forms.Label();
            this.textBox_hb = new System.Windows.Forms.TextBox();
            this.label_ntype = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button_save = new System.Windows.Forms.Button();
            this.label_vr = new System.Windows.Forms.Label();
            this.textBox_vr = new System.Windows.Forms.TextBox();
            this.phasechart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phasechart)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.63916F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.36084F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1728, 1512);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea3.AxisX.Title = "time step";
            chartArea3.AxisY.Title = "population";
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(4, 4);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            series4.Legend = "Legend1";
            series4.Name = "Preys";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "Predators";
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(1720, 727);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.27664F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.72337F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.phasechart, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 739);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1720, 769);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label_pd, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBox_pd, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_ntype, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label_pb, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox_pb, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label_hd, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_hd, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label_hb, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.textBox_hb, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label_ntype, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label_vr, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBox_vr, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(495, 761);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label_pd
            // 
            this.label_pd.AutoSize = true;
            this.label_pd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_pd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_pd.Location = new System.Drawing.Point(4, 0);
            this.label_pd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_pd.Name = "label_pd";
            this.label_pd.Size = new System.Drawing.Size(239, 108);
            this.label_pd.TabIndex = 1;
            this.label_pd.Text = "prey dealth rate";
            this.label_pd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel4.Controls.Add(this.button_start, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 652);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(239, 105);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.GreenYellow;
            this.button_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_start.Location = new System.Drawing.Point(15, 9);
            this.button_start.Margin = new System.Windows.Forms.Padding(4);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(207, 86);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // textBox_pd
            // 
            this.textBox_pd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_pd.Location = new System.Drawing.Point(4, 112);
            this.textBox_pd.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_pd.Name = "textBox_pd";
            this.textBox_pd.Size = new System.Drawing.Size(239, 40);
            this.textBox_pd.TabIndex = 5;
            // 
            // comboBox_ntype
            // 
            this.comboBox_ntype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_ntype.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_ntype.FormattingEnabled = true;
            this.comboBox_ntype.Items.AddRange(new object[] {
            "Von Neumann",
            "Moore",
            "Extended von Neumann"});
            this.comboBox_ntype.Location = new System.Drawing.Point(4, 544);
            this.comboBox_ntype.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_ntype.Name = "comboBox_ntype";
            this.comboBox_ntype.Size = new System.Drawing.Size(239, 41);
            this.comboBox_ntype.TabIndex = 10;
            // 
            // label_pb
            // 
            this.label_pb.AutoSize = true;
            this.label_pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_pb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_pb.Location = new System.Drawing.Point(4, 216);
            this.label_pb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_pb.Name = "label_pb";
            this.label_pb.Size = new System.Drawing.Size(239, 108);
            this.label_pb.TabIndex = 2;
            this.label_pb.Text = "prey birth rate";
            this.label_pb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_pb
            // 
            this.textBox_pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_pb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_pb.Location = new System.Drawing.Point(4, 328);
            this.textBox_pb.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_pb.Name = "textBox_pb";
            this.textBox_pb.Size = new System.Drawing.Size(239, 40);
            this.textBox_pb.TabIndex = 6;
            // 
            // label_hd
            // 
            this.label_hd.AutoSize = true;
            this.label_hd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_hd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_hd.Location = new System.Drawing.Point(251, 0);
            this.label_hd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_hd.Name = "label_hd";
            this.label_hd.Size = new System.Drawing.Size(240, 108);
            this.label_hd.TabIndex = 3;
            this.label_hd.Text = "predator death rate";
            this.label_hd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_hd
            // 
            this.textBox_hd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_hd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_hd.Location = new System.Drawing.Point(251, 112);
            this.textBox_hd.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_hd.Name = "textBox_hd";
            this.textBox_hd.Size = new System.Drawing.Size(240, 40);
            this.textBox_hd.TabIndex = 7;
            // 
            // label_hb
            // 
            this.label_hb.AutoSize = true;
            this.label_hb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_hb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_hb.Location = new System.Drawing.Point(251, 216);
            this.label_hb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_hb.Name = "label_hb";
            this.label_hb.Size = new System.Drawing.Size(240, 108);
            this.label_hb.TabIndex = 0;
            this.label_hb.Text = "predator birth rate";
            this.label_hb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_hb
            // 
            this.textBox_hb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_hb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_hb.Location = new System.Drawing.Point(251, 328);
            this.textBox_hb.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_hb.Name = "textBox_hb";
            this.textBox_hb.Size = new System.Drawing.Size(240, 40);
            this.textBox_hb.TabIndex = 8;
            // 
            // label_ntype
            // 
            this.label_ntype.AutoSize = true;
            this.label_ntype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ntype.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ntype.Location = new System.Drawing.Point(4, 432);
            this.label_ntype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ntype.Name = "label_ntype";
            this.label_ntype.Size = new System.Drawing.Size(239, 108);
            this.label_ntype.TabIndex = 4;
            this.label_ntype.Text = "neighborhood type";
            this.label_ntype.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel5.Controls.Add(this.button_save, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(251, 652);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(240, 105);
            this.tableLayoutPanel5.TabIndex = 11;
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.Location = new System.Drawing.Point(16, 9);
            this.button_save.Margin = new System.Windows.Forms.Padding(4);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(208, 86);
            this.button_save.TabIndex = 0;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_vr
            // 
            this.label_vr.AutoSize = true;
            this.label_vr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_vr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_vr.Location = new System.Drawing.Point(250, 432);
            this.label_vr.Name = "label_vr";
            this.label_vr.Size = new System.Drawing.Size(242, 108);
            this.label_vr.TabIndex = 12;
            this.label_vr.Text = "visibility radius";
            this.label_vr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_vr
            // 
            this.textBox_vr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_vr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_vr.Location = new System.Drawing.Point(250, 543);
            this.textBox_vr.Name = "textBox_vr";
            this.textBox_vr.Size = new System.Drawing.Size(242, 38);
            this.textBox_vr.TabIndex = 13;
            // 
            // phasechart
            // 
            chartArea4.AxisX.Title = "preys";
            chartArea4.AxisY.Title = "predators";
            chartArea4.Name = "ChartArea1";
            this.phasechart.ChartAreas.Add(chartArea4);
            this.phasechart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.phasechart.Legends.Add(legend4);
            this.phasechart.Location = new System.Drawing.Point(507, 4);
            this.phasechart.Margin = new System.Windows.Forms.Padding(4);
            this.phasechart.Name = "phasechart";
            series6.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series6.Legend = "Legend1";
            series6.Name = "Phase Diagram";
            this.phasechart.Series.Add(series6);
            this.phasechart.Size = new System.Drawing.Size(1209, 761);
            this.phasechart.TabIndex = 2;
            this.phasechart.Text = "chart2";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1728, 1512);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.phasechart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_ntype;
        private System.Windows.Forms.Label label_hd;
        private System.Windows.Forms.Label label_pb;
        private System.Windows.Forms.Label label_pd;
        private System.Windows.Forms.Label label_hb;
        private System.Windows.Forms.TextBox textBox_pd;
        private System.Windows.Forms.TextBox textBox_pb;
        private System.Windows.Forms.TextBox textBox_hd;
        private System.Windows.Forms.TextBox textBox_hb;
        private System.Windows.Forms.ComboBox comboBox_ntype;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.DataVisualization.Charting.Chart phasechart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label_vr;
        private System.Windows.Forms.TextBox textBox_vr;
    }
}