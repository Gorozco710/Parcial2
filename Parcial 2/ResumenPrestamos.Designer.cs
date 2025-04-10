namespace Parcial_2
{
    partial class ResumenPrestamos
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
            this.labelTotalPrestamos = new System.Windows.Forms.Label();
            this.dataGridViewResumen = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResumen)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotalPrestamos
            // 
            this.labelTotalPrestamos.AutoSize = true;
            this.labelTotalPrestamos.Location = new System.Drawing.Point(19, 81);
            this.labelTotalPrestamos.Name = "labelTotalPrestamos";
            this.labelTotalPrestamos.Size = new System.Drawing.Size(0, 16);
            this.labelTotalPrestamos.TabIndex = 0;
            // 
            // dataGridViewResumen
            // 
            this.dataGridViewResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResumen.Location = new System.Drawing.Point(22, 120);
            this.dataGridViewResumen.Name = "dataGridViewResumen";
            this.dataGridViewResumen.RowHeadersWidth = 51;
            this.dataGridViewResumen.RowTemplate.Height = 24;
            this.dataGridViewResumen.Size = new System.Drawing.Size(343, 205);
            this.dataGridViewResumen.TabIndex = 1;
            // 
            // labelPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewResumen);
            this.Controls.Add(this.labelTotalPrestamos);
            this.Name = "labelPrestamos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResumen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotalPrestamos;
        private System.Windows.Forms.DataGridView dataGridViewResumen;
    }
}