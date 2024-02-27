
namespace ProjectABM
{
    partial class VentaForm
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
            this.labelVentaFecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerVenta = new System.Windows.Forms.DateTimePicker();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.buttonCreateVenta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelVentaFecha
            // 
            this.labelVentaFecha.AutoSize = true;
            this.labelVentaFecha.Location = new System.Drawing.Point(24, 51);
            this.labelVentaFecha.Name = "labelVentaFecha";
            this.labelVentaFecha.Size = new System.Drawing.Size(30, 13);
            this.labelVentaFecha.TabIndex = 0;
            this.labelVentaFecha.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client";
            // 
            // dateTimePickerVenta
            // 
            this.dateTimePickerVenta.Location = new System.Drawing.Point(72, 51);
            this.dateTimePickerVenta.Name = "dateTimePickerVenta";
            this.dateTimePickerVenta.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerVenta.TabIndex = 2;
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(72, 82);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(121, 21);
            this.comboBoxClient.TabIndex = 3;
            // 
            // buttonCreateVenta
            // 
            this.buttonCreateVenta.Location = new System.Drawing.Point(27, 126);
            this.buttonCreateVenta.Name = "buttonCreateVenta";
            this.buttonCreateVenta.Size = new System.Drawing.Size(135, 23);
            this.buttonCreateVenta.TabIndex = 4;
            this.buttonCreateVenta.Text = "Create Venta";
            this.buttonCreateVenta.UseVisualStyleBackColor = true;
            this.buttonCreateVenta.Click += new System.EventHandler(this.buttonCreateVenta_Click);
            // 
            // VentaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCreateVenta);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.dateTimePickerVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelVentaFecha);
            this.Name = "VentaForm";
            this.Text = "VentaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVentaFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerVenta;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Button buttonCreateVenta;
    }
}