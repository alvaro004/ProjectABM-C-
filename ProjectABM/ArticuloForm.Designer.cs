﻿
namespace ProjectABM
{
    partial class ArticuloForm
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
            this.labelArticuleTitle = new System.Windows.Forms.Label();
            this.labelDataText = new System.Windows.Forms.Label();
            this.dateTimePickerArticulo = new System.Windows.Forms.DateTimePicker();
            this.oracleCommandBuilder1 = new Oracle.ManagedDataAccess.Client.OracleCommandBuilder();
            this.CreateNewArticule = new System.Windows.Forms.Button();
            this.dataGridViewArticulos = new System.Windows.Forms.DataGridView();
            this.returnToWelcomeButton = new System.Windows.Forms.Button();
            this.buttonDeleteArticulo = new System.Windows.Forms.Button();
            this.buttonUpdateArticulo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // labelArticuleTitle
            // 
            this.labelArticuleTitle.AutoSize = true;
            this.labelArticuleTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArticuleTitle.Location = new System.Drawing.Point(28, 20);
            this.labelArticuleTitle.Name = "labelArticuleTitle";
            this.labelArticuleTitle.Size = new System.Drawing.Size(222, 25);
            this.labelArticuleTitle.TabIndex = 0;
            this.labelArticuleTitle.Text = "Create a New Articulo";
            // 
            // labelDataText
            // 
            this.labelDataText.AutoSize = true;
            this.labelDataText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataText.Location = new System.Drawing.Point(29, 69);
            this.labelDataText.Name = "labelDataText";
            this.labelDataText.Size = new System.Drawing.Size(107, 17);
            this.labelDataText.TabIndex = 1;
            this.labelDataText.Text = "Articulo Date:";
            // 
            // dateTimePickerArticulo
            // 
            this.dateTimePickerArticulo.Location = new System.Drawing.Point(156, 68);
            this.dateTimePickerArticulo.Name = "dateTimePickerArticulo";
            this.dateTimePickerArticulo.Size = new System.Drawing.Size(215, 20);
            this.dateTimePickerArticulo.TabIndex = 2;
            // 
            // oracleCommandBuilder1
            // 
            this.oracleCommandBuilder1.CatalogLocation = System.Data.Common.CatalogLocation.End;
            this.oracleCommandBuilder1.CatalogSeparator = "@";
            // 
            // CreateNewArticule
            // 
            this.CreateNewArticule.Location = new System.Drawing.Point(28, 101);
            this.CreateNewArticule.Name = "CreateNewArticule";
            this.CreateNewArticule.Size = new System.Drawing.Size(110, 31);
            this.CreateNewArticule.TabIndex = 3;
            this.CreateNewArticule.Text = "Create Articulo";
            this.CreateNewArticule.UseVisualStyleBackColor = true;
            this.CreateNewArticule.Click += new System.EventHandler(this.CreateNewArticule_Click);
            // 
            // dataGridViewArticulos
            // 
            this.dataGridViewArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArticulos.Location = new System.Drawing.Point(28, 156);
            this.dataGridViewArticulos.Name = "dataGridViewArticulos";
            this.dataGridViewArticulos.Size = new System.Drawing.Size(413, 244);
            this.dataGridViewArticulos.TabIndex = 4;
            // 
            // returnToWelcomeButton
            // 
            this.returnToWelcomeButton.Location = new System.Drawing.Point(28, 492);
            this.returnToWelcomeButton.Name = "returnToWelcomeButton";
            this.returnToWelcomeButton.Size = new System.Drawing.Size(81, 38);
            this.returnToWelcomeButton.TabIndex = 16;
            this.returnToWelcomeButton.Text = "Go Back";
            this.returnToWelcomeButton.UseVisualStyleBackColor = true;
            this.returnToWelcomeButton.Click += new System.EventHandler(this.returnToWelcomeButton_Click);
            // 
            // buttonDeleteArticulo
            // 
            this.buttonDeleteArticulo.Location = new System.Drawing.Point(26, 418);
            this.buttonDeleteArticulo.Name = "buttonDeleteArticulo";
            this.buttonDeleteArticulo.Size = new System.Drawing.Size(110, 31);
            this.buttonDeleteArticulo.TabIndex = 17;
            this.buttonDeleteArticulo.Text = "Delete Articulo";
            this.buttonDeleteArticulo.UseVisualStyleBackColor = true;
            this.buttonDeleteArticulo.Click += new System.EventHandler(this.buttonDeleteArticulo_Click);
            // 
            // buttonUpdateArticulo
            // 
            this.buttonUpdateArticulo.Location = new System.Drawing.Point(157, 418);
            this.buttonUpdateArticulo.Name = "buttonUpdateArticulo";
            this.buttonUpdateArticulo.Size = new System.Drawing.Size(110, 31);
            this.buttonUpdateArticulo.TabIndex = 18;
            this.buttonUpdateArticulo.Text = "Update Articulo";
            this.buttonUpdateArticulo.UseVisualStyleBackColor = true;
            this.buttonUpdateArticulo.Click += new System.EventHandler(this.buttonUpdateArticulo_Click);
            // 
            // ArticuloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 544);
            this.Controls.Add(this.buttonUpdateArticulo);
            this.Controls.Add(this.buttonDeleteArticulo);
            this.Controls.Add(this.returnToWelcomeButton);
            this.Controls.Add(this.dataGridViewArticulos);
            this.Controls.Add(this.CreateNewArticule);
            this.Controls.Add(this.dateTimePickerArticulo);
            this.Controls.Add(this.labelDataText);
            this.Controls.Add(this.labelArticuleTitle);
            this.Name = "ArticuloForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArticuloForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ArticuloForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelArticuleTitle;
        private System.Windows.Forms.Label labelDataText;
        private System.Windows.Forms.DateTimePicker dateTimePickerArticulo;
        private Oracle.ManagedDataAccess.Client.OracleCommandBuilder oracleCommandBuilder1;
        private System.Windows.Forms.Button CreateNewArticule;
        private System.Windows.Forms.DataGridView dataGridViewArticulos;
        private System.Windows.Forms.Button returnToWelcomeButton;
        private System.Windows.Forms.Button buttonDeleteArticulo;
        private System.Windows.Forms.Button buttonUpdateArticulo;
    }
}