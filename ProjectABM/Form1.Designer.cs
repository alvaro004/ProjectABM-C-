﻿
namespace ProjectABM
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnGetClientes = new System.Windows.Forms.Button();
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.buttonDeleteClient = new System.Windows.Forms.Button();
            this.dataGridViewClientesCellValueChanged = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open Connection with DB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGetClientes
            // 
            this.btnGetClientes.Location = new System.Drawing.Point(379, 280);
            this.btnGetClientes.Name = "btnGetClientes";
            this.btnGetClientes.Size = new System.Drawing.Size(75, 23);
            this.btnGetClientes.TabIndex = 1;
            this.btnGetClientes.Text = "List Clients";
            this.btnGetClientes.UseVisualStyleBackColor = true;
            this.btnGetClientes.Click += new System.EventHandler(this.buttonGetClientes);
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Location = new System.Drawing.Point(379, 38);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.Size = new System.Drawing.Size(370, 220);
            this.dataGridViewClientes.TabIndex = 2;
            this.dataGridViewClientes.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientes_CellValueChanged_1);
            // 
            // buttonDeleteClient
            // 
            this.buttonDeleteClient.Location = new System.Drawing.Point(460, 280);
            this.buttonDeleteClient.Name = "buttonDeleteClient";
            this.buttonDeleteClient.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteClient.TabIndex = 3;
            this.buttonDeleteClient.Text = "Delete Client";
            this.buttonDeleteClient.UseVisualStyleBackColor = true;
            this.buttonDeleteClient.Click += new System.EventHandler(this.buttonDeleteClient_Click);
            // 
            // dataGridViewClientesCellValueChanged
            // 
            this.dataGridViewClientesCellValueChanged.Location = new System.Drawing.Point(562, 279);
            this.dataGridViewClientesCellValueChanged.Name = "dataGridViewClientesCellValueChanged";
            this.dataGridViewClientesCellValueChanged.Size = new System.Drawing.Size(75, 23);
            this.dataGridViewClientesCellValueChanged.TabIndex = 4;
            this.dataGridViewClientesCellValueChanged.Text = "Update";
            this.dataGridViewClientesCellValueChanged.UseVisualStyleBackColor = true;
            this.dataGridViewClientesCellValueChanged.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewClientesCellValueChanged);
            this.Controls.Add(this.buttonDeleteClient);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.btnGetClientes);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGetClientes;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.Button buttonDeleteClient;
        private System.Windows.Forms.Button dataGridViewClientesCellValueChanged;
    }
}

