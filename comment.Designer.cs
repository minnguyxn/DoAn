namespace DoAn
{
    partial class comment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(comment));
            this.img = new Bunifu.UI.WinForms.BunifuImageButton();
            this.name = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // img
            // 
            this.img.ActiveImage = null;
            this.img.AllowAnimations = true;
            this.img.AllowBuffering = false;
            this.img.AllowToggling = false;
            this.img.AllowZooming = true;
            this.img.AllowZoomingOnFocus = false;
            this.img.BackColor = System.Drawing.Color.Transparent;
            this.img.DialogResult = System.Windows.Forms.DialogResult.None;
            this.img.ErrorImage = ((System.Drawing.Image)(resources.GetObject("img.ErrorImage")));
            this.img.FadeWhenInactive = false;
            this.img.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.img.Image = global::DoAn.Properties.Resources.Sedan_vector_3;
            this.img.ImageActive = null;
            this.img.ImageLocation = null;
            this.img.ImageMargin = 20;
            this.img.ImageSize = new System.Drawing.Size(56, 46);
            this.img.ImageZoomSize = new System.Drawing.Size(76, 66);
            this.img.InitialImage = ((System.Drawing.Image)(resources.GetObject("img.InitialImage")));
            this.img.Location = new System.Drawing.Point(2, 0);
            this.img.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.img.Name = "img";
            this.img.Rotation = 0;
            this.img.ShowActiveImage = true;
            this.img.ShowCursorChanges = true;
            this.img.ShowImageBorders = true;
            this.img.ShowSizeMarkers = false;
            this.img.Size = new System.Drawing.Size(76, 66);
            this.img.TabIndex = 4;
            this.img.ToolTipText = "";
            this.img.WaitOnLoad = false;
            this.img.Zoom = 20;
            this.img.ZoomSpeed = 10;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(82, 0);
            this.name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(112, 21);
            this.name.TabIndex = 5;
            this.name.Text = "Nguyen Van A";
            // 
            // content
            // 
            this.content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.content.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.content.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.content.Location = new System.Drawing.Point(82, 23);
            this.content.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.content.Name = "content";
            this.content.ReadOnly = true;
            this.content.Size = new System.Drawing.Size(422, 42);
            this.content.TabIndex = 6;
            this.content.Text = "";
            // 
            // comment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.content);
            this.Controls.Add(this.name);
            this.Controls.Add(this.img);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "comment";
            this.Size = new System.Drawing.Size(515, 70);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuImageButton img;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.RichTextBox content;
    }
}
