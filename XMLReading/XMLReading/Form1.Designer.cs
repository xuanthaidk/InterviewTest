namespace XMLReading
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
            loadFileButton = new Button();
            treeView = new TreeView();
            saveNodesButton = new Button();
            selectedSave = new Button();
            SuspendLayout();
            // 
            // loadFileButton
            // 
            loadFileButton.Location = new Point(12, 12);
            loadFileButton.Name = "loadFileButton";
            loadFileButton.Size = new Size(75, 23);
            loadFileButton.TabIndex = 0;
            loadFileButton.Text = "Load file";
            loadFileButton.UseVisualStyleBackColor = true;
            loadFileButton.Click += loadFileButton_Click;
            // 
            // treeView
            // 
            treeView.FullRowSelect = true;
            treeView.Location = new Point(12, 41);
            treeView.Name = "treeView";
            treeView.Size = new Size(460, 380);
            treeView.TabIndex = 1;
            // 
            // saveNodesButton
            // 
            saveNodesButton.Location = new Point(382, 12);
            saveNodesButton.Name = "saveNodesButton";
            saveNodesButton.Size = new Size(90, 23);
            saveNodesButton.TabIndex = 2;
            saveNodesButton.Text = "Save Nodes";
            saveNodesButton.UseVisualStyleBackColor = true;
            saveNodesButton.Visible = false;
            saveNodesButton.Click += saveNodesButton_Click;
            // 
            // selectedSave
            // 
            selectedSave.Location = new Point(249, 12);
            selectedSave.Name = "selectedSave";
            selectedSave.Size = new Size(127, 23);
            selectedSave.TabIndex = 3;
            selectedSave.Text = "Save selected nodes";
            selectedSave.UseVisualStyleBackColor = true;
            selectedSave.Click += selectedSaveNodesButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 433);
            Controls.Add(selectedSave);
            Controls.Add(saveNodesButton);
            Controls.Add(treeView);
            Controls.Add(loadFileButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(500, 400);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XML Reading ";
            ResumeLayout(false);
        }

        #endregion

        private Button loadFileButton;
        private TreeView treeView;
        private Button saveNodesButton;
        private Button selectedSave;
    }
}