namespace ProjektNaGK
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.drawArea = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.methodGroupBox = new System.Windows.Forms.GroupBox();
            this.bresenhamOption = new System.Windows.Forms.RadioButton();
            this.libraryOption = new System.Windows.Forms.RadioButton();
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.generateSceneButton = new System.Windows.Forms.Button();
            this.relationGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteRelButton = new System.Windows.Forms.Button();
            this.parallelRelButton = new System.Windows.Forms.Button();
            this.lengthRelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addPolygonButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.methodGroupBox.SuspendLayout();
            this.actionsGroupBox.SuspendLayout();
            this.relationGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel.Controls.Add(this.drawArea, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(841, 497);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // drawArea
            // 
            this.drawArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawArea.Location = new System.Drawing.Point(2, 2);
            this.drawArea.Margin = new System.Windows.Forms.Padding(2);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(662, 493);
            this.drawArea.TabIndex = 0;
            this.drawArea.TabStop = false;
            this.drawArea.SizeChanged += new System.EventHandler(this.drawArea_SizeChanged);
            this.drawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseDown);
            this.drawArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseMove);
            this.drawArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.methodGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.actionsGroupBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(668, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(171, 493);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // methodGroupBox
            // 
            this.methodGroupBox.Controls.Add(this.bresenhamOption);
            this.methodGroupBox.Controls.Add(this.libraryOption);
            this.methodGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.methodGroupBox.Location = new System.Drawing.Point(2, 2);
            this.methodGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.methodGroupBox.Name = "methodGroupBox";
            this.methodGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.methodGroupBox.Size = new System.Drawing.Size(167, 96);
            this.methodGroupBox.TabIndex = 2;
            this.methodGroupBox.TabStop = false;
            this.methodGroupBox.Text = "Draw method";
            // 
            // bresenhamOption
            // 
            this.bresenhamOption.AutoSize = true;
            this.bresenhamOption.Location = new System.Drawing.Point(13, 48);
            this.bresenhamOption.Margin = new System.Windows.Forms.Padding(2);
            this.bresenhamOption.Name = "bresenhamOption";
            this.bresenhamOption.Size = new System.Drawing.Size(139, 19);
            this.bresenhamOption.TabIndex = 1;
            this.bresenhamOption.TabStop = true;
            this.bresenhamOption.Text = "Bresenham algorithm";
            this.bresenhamOption.UseVisualStyleBackColor = true;
            // 
            // libraryOption
            // 
            this.libraryOption.AutoSize = true;
            this.libraryOption.Location = new System.Drawing.Point(13, 27);
            this.libraryOption.Margin = new System.Windows.Forms.Padding(2);
            this.libraryOption.Name = "libraryOption";
            this.libraryOption.Size = new System.Drawing.Size(116, 19);
            this.libraryOption.TabIndex = 0;
            this.libraryOption.TabStop = true;
            this.libraryOption.Text = "Library algorithm";
            this.libraryOption.UseVisualStyleBackColor = true;
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.Controls.Add(this.generateSceneButton);
            this.actionsGroupBox.Controls.Add(this.relationGroupBox);
            this.actionsGroupBox.Controls.Add(this.label1);
            this.actionsGroupBox.Controls.Add(this.cancelButton);
            this.actionsGroupBox.Controls.Add(this.addPolygonButton);
            this.actionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionsGroupBox.Location = new System.Drawing.Point(2, 102);
            this.actionsGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.actionsGroupBox.Size = new System.Drawing.Size(167, 389);
            this.actionsGroupBox.TabIndex = 3;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Actions";
            // 
            // generateSceneButton
            // 
            this.generateSceneButton.Location = new System.Drawing.Point(23, 306);
            this.generateSceneButton.Name = "generateSceneButton";
            this.generateSceneButton.Size = new System.Drawing.Size(130, 52);
            this.generateSceneButton.TabIndex = 6;
            this.generateSceneButton.Text = "Generate predefined scene";
            this.generateSceneButton.UseVisualStyleBackColor = true;
            this.generateSceneButton.Click += new System.EventHandler(this.generateSceneButton_Click);
            // 
            // relationGroupBox
            // 
            this.relationGroupBox.Controls.Add(this.deleteRelButton);
            this.relationGroupBox.Controls.Add(this.parallelRelButton);
            this.relationGroupBox.Controls.Add(this.lengthRelButton);
            this.relationGroupBox.Location = new System.Drawing.Point(5, 66);
            this.relationGroupBox.Name = "relationGroupBox";
            this.relationGroupBox.Size = new System.Drawing.Size(157, 157);
            this.relationGroupBox.TabIndex = 5;
            this.relationGroupBox.TabStop = false;
            this.relationGroupBox.Text = "Adding edge relations";
            // 
            // deleteRelButton
            // 
            this.deleteRelButton.Location = new System.Drawing.Point(18, 109);
            this.deleteRelButton.Name = "deleteRelButton";
            this.deleteRelButton.Size = new System.Drawing.Size(130, 33);
            this.deleteRelButton.TabIndex = 2;
            this.deleteRelButton.Text = "Delete relation";
            this.deleteRelButton.UseVisualStyleBackColor = true;
            this.deleteRelButton.Click += new System.EventHandler(this.deleteRelButton_Click);
            // 
            // parallelRelButton
            // 
            this.parallelRelButton.Location = new System.Drawing.Point(18, 61);
            this.parallelRelButton.Name = "parallelRelButton";
            this.parallelRelButton.Size = new System.Drawing.Size(130, 33);
            this.parallelRelButton.TabIndex = 1;
            this.parallelRelButton.Text = "Parallelity";
            this.parallelRelButton.UseVisualStyleBackColor = true;
            this.parallelRelButton.Click += new System.EventHandler(this.parallelRelButton_Click);
            // 
            // lengthRelButton
            // 
            this.lengthRelButton.Location = new System.Drawing.Point(18, 22);
            this.lengthRelButton.Name = "lengthRelButton";
            this.lengthRelButton.Size = new System.Drawing.Size(130, 33);
            this.lengthRelButton.TabIndex = 0;
            this.lengthRelButton.Text = "Fixed length";
            this.lengthRelButton.UseVisualStyleBackColor = true;
            this.lengthRelButton.Click += new System.EventHandler(this.lengthRelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(23, 237);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(130, 26);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addPolygonButton
            // 
            this.addPolygonButton.Location = new System.Drawing.Point(23, 26);
            this.addPolygonButton.Margin = new System.Windows.Forms.Padding(2);
            this.addPolygonButton.Name = "addPolygonButton";
            this.addPolygonButton.Size = new System.Drawing.Size(130, 35);
            this.addPolygonButton.TabIndex = 1;
            this.addPolygonButton.Text = "New polygon";
            this.addPolygonButton.UseVisualStyleBackColor = true;
            this.addPolygonButton.Click += new System.EventHandler(this.addPolygonButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 521);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Form1";
            this.Text = "Polygon Editor";
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.methodGroupBox.ResumeLayout(false);
            this.methodGroupBox.PerformLayout();
            this.actionsGroupBox.ResumeLayout(false);
            this.actionsGroupBox.PerformLayout();
            this.relationGroupBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private PictureBox drawArea;
        private TableLayoutPanel tableLayoutPanel1;
        private Button addPolygonButton;
        private GroupBox methodGroupBox;
        private RadioButton bresenhamOption;
        private RadioButton libraryOption;
        private GroupBox actionsGroupBox;
        private Button cancelButton;
        private Label label1;
        private GroupBox relationGroupBox;
        private Button deleteRelButton;
        private Button parallelRelButton;
        private Button lengthRelButton;
        private Button generateSceneButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
    }
}