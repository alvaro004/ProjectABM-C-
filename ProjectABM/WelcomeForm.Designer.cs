
namespace ProjectABM
{
    partial class WelcomeForm
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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.manageClientsButton_Click = new System.Windows.Forms.Button();
            this.manageArticulosButton_Click_Click = new System.Windows.Forms.Button();
            this.manageVentasButton_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(117, 62);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(592, 31);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "WELCOME TO THE MANAGMENT SYSTEM";
            // 
            // manageClientsButton_Click
            // 
            this.manageClientsButton_Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageClientsButton_Click.Location = new System.Drawing.Point(336, 140);
            this.manageClientsButton_Click.Name = "manageClientsButton_Click";
            this.manageClientsButton_Click.Size = new System.Drawing.Size(126, 41);
            this.manageClientsButton_Click.TabIndex = 1;
            this.manageClientsButton_Click.Text = "Manage Clients";
            this.manageClientsButton_Click.UseVisualStyleBackColor = true;
            this.manageClientsButton_Click.Click += new System.EventHandler(this.manageClientsButton_Click_Click);
            // 
            // manageArticulosButton_Click_Click
            // 
            this.manageArticulosButton_Click_Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageArticulosButton_Click_Click.Location = new System.Drawing.Point(336, 207);
            this.manageArticulosButton_Click_Click.Name = "manageArticulosButton_Click_Click";
            this.manageArticulosButton_Click_Click.Size = new System.Drawing.Size(126, 41);
            this.manageArticulosButton_Click_Click.TabIndex = 2;
            this.manageArticulosButton_Click_Click.Text = "Manage Articulos";
            this.manageArticulosButton_Click_Click.UseVisualStyleBackColor = true;
            this.manageArticulosButton_Click_Click.Click += new System.EventHandler(this.manageArticulosButton_Click_Click_Click);
            // 
            // manageVentasButton_Click
            // 
            this.manageVentasButton_Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageVentasButton_Click.Location = new System.Drawing.Point(336, 272);
            this.manageVentasButton_Click.Name = "manageVentasButton_Click";
            this.manageVentasButton_Click.Size = new System.Drawing.Size(126, 41);
            this.manageVentasButton_Click.TabIndex = 3;
            this.manageVentasButton_Click.Text = "Manage Ventas";
            this.manageVentasButton_Click.UseVisualStyleBackColor = true;
            this.manageVentasButton_Click.Click += new System.EventHandler(this.manageVentasButton_Click_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.manageVentasButton_Click);
            this.Controls.Add(this.manageArticulosButton_Click_Click);
            this.Controls.Add(this.manageClientsButton_Click);
            this.Controls.Add(this.labelWelcome);
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button manageClientsButton_Click;
        private System.Windows.Forms.Button manageArticulosButton_Click_Click;
        private System.Windows.Forms.Button manageVentasButton_Click;
    }
}