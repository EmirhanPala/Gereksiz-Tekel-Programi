namespace RuzgarOguz
{
    partial class magazalistele
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.magazaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.magazaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ruzgarDataSet1 = new RuzgarOguz.ruzgarDataSet1();
            this.magazaTableAdapter = new RuzgarOguz.ruzgarDataSet1TableAdapters.magazaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ruzgarDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.magazaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.magazaBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(301, 385);
            this.dataGridView1.TabIndex = 0;
            // 
            // magazaDataGridViewTextBoxColumn
            // 
            this.magazaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.magazaDataGridViewTextBoxColumn.DataPropertyName = "magaza";
            this.magazaDataGridViewTextBoxColumn.HeaderText = "magaza";
            this.magazaDataGridViewTextBoxColumn.Name = "magazaDataGridViewTextBoxColumn";
            this.magazaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // magazaBindingSource
            // 
            this.magazaBindingSource.DataMember = "magaza";
            this.magazaBindingSource.DataSource = this.ruzgarDataSet1;
            // 
            // ruzgarDataSet1
            // 
            this.ruzgarDataSet1.DataSetName = "ruzgarDataSet1";
            this.ruzgarDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // magazaTableAdapter
            // 
            this.magazaTableAdapter.ClearBeforeFill = true;
            // 
            // magazalistele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 385);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "magazalistele";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Mağaza Listesi";
            this.Load += new System.EventHandler(this.magazalistele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.magazaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ruzgarDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ruzgarDataSet1 ruzgarDataSet1;
        private System.Windows.Forms.BindingSource magazaBindingSource;
        private ruzgarDataSet1TableAdapters.magazaTableAdapter magazaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn magazaDataGridViewTextBoxColumn;
    }
}