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
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.buttonDeleteClient = new System.Windows.Forms.Button();
            this.dataGridViewClientesCellValueChanged = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.clientNameTextBox = new System.Windows.Forms.TextBox();
            this.clientLastNameTextBox = new System.Windows.Forms.TextBox();
            this.createNewClientButton_Click = new System.Windows.Forms.Button();
            this.labelClientName = new System.Windows.Forms.Label();
            this.labelClientLastName = new System.Windows.Forms.Label();
            this.returnToWelcomeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Location = new System.Drawing.Point(379, 66);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.Size = new System.Drawing.Size(379, 296);
            this.dataGridViewClientes.TabIndex = 2;
            // 
            // buttonDeleteClient
            // 
            this.buttonDeleteClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteClient.Location = new System.Drawing.Point(379, 386);
            this.buttonDeleteClient.Name = "buttonDeleteClient";
            this.buttonDeleteClient.Size = new System.Drawing.Size(96, 38);
            this.buttonDeleteClient.TabIndex = 3;
            this.buttonDeleteClient.Text = "Delete Client";
            this.buttonDeleteClient.UseVisualStyleBackColor = true;
            this.buttonDeleteClient.Click += new System.EventHandler(this.buttonDeleteClient_Click);
            // 
            // dataGridViewClientesCellValueChanged
            // 
            this.dataGridViewClientesCellValueChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewClientesCellValueChanged.Location = new System.Drawing.Point(502, 385);
            this.dataGridViewClientesCellValueChanged.Name = "dataGridViewClientesCellValueChanged";
            this.dataGridViewClientesCellValueChanged.Size = new System.Drawing.Size(94, 39);
            this.dataGridViewClientesCellValueChanged.TabIndex = 4;
            this.dataGridViewClientesCellValueChanged.Text = "Update";
            this.dataGridViewClientesCellValueChanged.UseVisualStyleBackColor = true;
            this.dataGridViewClientesCellValueChanged.Click += new System.EventHandler(this.dataGridViewClientesCellValueChanged_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(34, 19);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(141, 25);
            this.name.TabIndex = 5;
            this.name.Text = "Manage User";
            this.name.Click += new System.EventHandler(this.name_Click);
            // 
            // clientNameTextBox
            // 
            this.clientNameTextBox.Location = new System.Drawing.Point(198, 66);
            this.clientNameTextBox.Name = "clientNameTextBox";
            this.clientNameTextBox.Size = new System.Drawing.Size(138, 20);
            this.clientNameTextBox.TabIndex = 6;
            // 
            // clientLastNameTextBox
            // 
            this.clientLastNameTextBox.Location = new System.Drawing.Point(198, 113);
            this.clientLastNameTextBox.Name = "clientLastNameTextBox";
            this.clientLastNameTextBox.Size = new System.Drawing.Size(138, 20);
            this.clientLastNameTextBox.TabIndex = 10;
            // 
            // createNewClientButton_Click
            // 
            this.createNewClientButton_Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewClientButton_Click.Location = new System.Drawing.Point(38, 163);
            this.createNewClientButton_Click.Name = "createNewClientButton_Click";
            this.createNewClientButton_Click.Size = new System.Drawing.Size(94, 35);
            this.createNewClientButton_Click.TabIndex = 12;
            this.createNewClientButton_Click.Text = "Create User";
            this.createNewClientButton_Click.UseVisualStyleBackColor = true;
            this.createNewClientButton_Click.Click += new System.EventHandler(this.createNewClientButton_Click_Click);
            // 
            // labelClientName
            // 
            this.labelClientName.AutoSize = true;
            this.labelClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientName.Location = new System.Drawing.Point(36, 70);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(100, 17);
            this.labelClientName.TabIndex = 13;
            this.labelClientName.Text = "Client Name:";
            this.labelClientName.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelClientLastName
            // 
            this.labelClientLastName.AutoSize = true;
            this.labelClientLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientLastName.Location = new System.Drawing.Point(36, 116);
            this.labelClientLastName.Name = "labelClientLastName";
            this.labelClientLastName.Size = new System.Drawing.Size(131, 17);
            this.labelClientLastName.TabIndex = 14;
            this.labelClientLastName.Text = "Client Las Name:";
            // 
            // returnToWelcomeButton
            // 
            this.returnToWelcomeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnToWelcomeButton.Location = new System.Drawing.Point(38, 386);
            this.returnToWelcomeButton.Name = "returnToWelcomeButton";
            this.returnToWelcomeButton.Size = new System.Drawing.Size(92, 38);
            this.returnToWelcomeButton.TabIndex = 15;
            this.returnToWelcomeButton.Text = "Go Back";
            this.returnToWelcomeButton.UseVisualStyleBackColor = true;
            this.returnToWelcomeButton.Click += new System.EventHandler(this.returnToWelcomeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 450);
            this.Controls.Add(this.returnToWelcomeButton);
            this.Controls.Add(this.labelClientLastName);
            this.Controls.Add(this.labelClientName);
            this.Controls.Add(this.createNewClientButton_Click);
            this.Controls.Add(this.clientLastNameTextBox);
            this.Controls.Add(this.clientNameTextBox);
            this.Controls.Add(this.name);
            this.Controls.Add(this.dataGridViewClientesCellValueChanged);
            this.Controls.Add(this.buttonDeleteClient);
            this.Controls.Add(this.dataGridViewClientes);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.Button buttonDeleteClient;
        private System.Windows.Forms.Button dataGridViewClientesCellValueChanged;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox clientNameTextBox;
        private System.Windows.Forms.TextBox clientLastNameTextBox;
        private System.Windows.Forms.Button createNewClientButton_Click;
        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.Label labelClientLastName;
        private System.Windows.Forms.Button returnToWelcomeButton;
    }
}

