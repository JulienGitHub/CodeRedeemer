namespace CodeRedeemer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.textBoxCodes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.labelPTCGOPos = new System.Windows.Forms.Label();
            this.buttonFindPTCGO = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.labelMS = new System.Windows.Forms.Label();
            this.textSleepMS = new System.Windows.Forms.TextBox();
            this.buttonSleep = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.buttonCode = new System.Windows.Forms.Button();
            this.buttonAddClick = new System.Windows.Forms.Button();
            this.listViewScript = new System.Windows.Forms.ListView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.textBoxCodes);
            this.groupBox.Location = new System.Drawing.Point(14, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(250, 558);
            this.groupBox.TabIndex = 21;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Codes";
            // 
            // textBoxCodes
            // 
            this.textBoxCodes.Location = new System.Drawing.Point(6, 19);
            this.textBoxCodes.Multiline = true;
            this.textBoxCodes.Name = "textBoxCodes";
            this.textBoxCodes.Size = new System.Drawing.Size(238, 533);
            this.textBoxCodes.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTest);
            this.groupBox1.Controls.Add(this.buttonLoad);
            this.groupBox1.Controls.Add(this.labelPTCGOPos);
            this.groupBox1.Controls.Add(this.buttonFindPTCGO);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Controls.Add(this.buttonDown);
            this.groupBox1.Controls.Add(this.buttonUp);
            this.groupBox1.Controls.Add(this.buttonRemove);
            this.groupBox1.Controls.Add(this.labelMS);
            this.groupBox1.Controls.Add(this.textSleepMS);
            this.groupBox1.Controls.Add(this.buttonSleep);
            this.groupBox1.Controls.Add(this.start);
            this.groupBox1.Controls.Add(this.buttonCode);
            this.groupBox1.Controls.Add(this.buttonAddClick);
            this.groupBox1.Controls.Add(this.listViewScript);
            this.groupBox1.Location = new System.Drawing.Point(282, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 558);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(250, 212);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(102, 23);
            this.buttonTest.TabIndex = 38;
            this.buttonTest.Text = "Test Action";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(138, 529);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 37;
            this.buttonLoad.Text = "Load Script";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // labelPTCGOPos
            // 
            this.labelPTCGOPos.AutoSize = true;
            this.labelPTCGOPos.Location = new System.Drawing.Point(87, 24);
            this.labelPTCGOPos.Name = "labelPTCGOPos";
            this.labelPTCGOPos.Size = new System.Drawing.Size(0, 13);
            this.labelPTCGOPos.TabIndex = 36;
            // 
            // buttonFindPTCGO
            // 
            this.buttonFindPTCGO.Location = new System.Drawing.Point(6, 19);
            this.buttonFindPTCGO.Name = "buttonFindPTCGO";
            this.buttonFindPTCGO.Size = new System.Drawing.Size(75, 23);
            this.buttonFindPTCGO.TabIndex = 35;
            this.buttonFindPTCGO.Text = "Find PTCGO App";
            this.buttonFindPTCGO.UseVisualStyleBackColor = true;
            this.buttonFindPTCGO.Click += new System.EventHandler(this.buttonFindPTCGO_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(34, 529);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 24;
            this.buttonSave.Text = "Save Script";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(250, 312);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(102, 23);
            this.buttonDown.TabIndex = 34;
            this.buttonDown.Text = "Down";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(250, 283);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(102, 23);
            this.buttonUp.TabIndex = 33;
            this.buttonUp.Text = "Up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(250, 341);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(102, 23);
            this.buttonRemove.TabIndex = 32;
            this.buttonRemove.Text = "Remove Action";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // labelMS
            // 
            this.labelMS.AutoSize = true;
            this.labelMS.Location = new System.Drawing.Point(311, 137);
            this.labelMS.Name = "labelMS";
            this.labelMS.Size = new System.Drawing.Size(20, 13);
            this.labelMS.TabIndex = 31;
            this.labelMS.Text = "ms";
            // 
            // textSleepMS
            // 
            this.textSleepMS.Location = new System.Drawing.Point(250, 134);
            this.textSleepMS.Name = "textSleepMS";
            this.textSleepMS.Size = new System.Drawing.Size(55, 20);
            this.textSleepMS.TabIndex = 30;
            // 
            // buttonSleep
            // 
            this.buttonSleep.Location = new System.Drawing.Point(250, 105);
            this.buttonSleep.Name = "buttonSleep";
            this.buttonSleep.Size = new System.Drawing.Size(102, 23);
            this.buttonSleep.TabIndex = 29;
            this.buttonSleep.Text = "Add Sleep";
            this.buttonSleep.UseVisualStyleBackColor = true;
            this.buttonSleep.Click += new System.EventHandler(this.buttonSleep_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(250, 469);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(99, 54);
            this.start.TabIndex = 28;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // buttonCode
            // 
            this.buttonCode.Location = new System.Drawing.Point(250, 76);
            this.buttonCode.Name = "buttonCode";
            this.buttonCode.Size = new System.Drawing.Size(102, 23);
            this.buttonCode.TabIndex = 27;
            this.buttonCode.Text = "Copy/Paste Code";
            this.buttonCode.UseVisualStyleBackColor = true;
            this.buttonCode.Click += new System.EventHandler(this.buttonCode_Click);
            // 
            // buttonAddClick
            // 
            this.buttonAddClick.Location = new System.Drawing.Point(250, 47);
            this.buttonAddClick.Name = "buttonAddClick";
            this.buttonAddClick.Size = new System.Drawing.Size(102, 23);
            this.buttonAddClick.TabIndex = 25;
            this.buttonAddClick.Text = "Add Mouse Click";
            this.buttonAddClick.UseVisualStyleBackColor = true;
            this.buttonAddClick.Click += new System.EventHandler(this.buttonAddClick_Click);
            // 
            // listViewScript
            // 
            this.listViewScript.FullRowSelect = true;
            this.listViewScript.HideSelection = false;
            this.listViewScript.Location = new System.Drawing.Point(6, 47);
            this.listViewScript.MultiSelect = false;
            this.listViewScript.Name = "listViewScript";
            this.listViewScript.Size = new System.Drawing.Size(238, 476);
            this.listViewScript.TabIndex = 0;
            this.listViewScript.UseCompatibleStateImageBehavior = false;
            this.listViewScript.View = System.Windows.Forms.View.Details;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 584);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(650, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 23;
            this.statusStrip.Text = "statusStrip1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 606);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PTCGO Codes Redeemer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCode;
        private System.Windows.Forms.Button buttonAddClick;
        private System.Windows.Forms.ListView listViewScript;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label labelMS;
        private System.Windows.Forms.TextBox textSleepMS;
        private System.Windows.Forms.Button buttonSleep;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label labelPTCGOPos;
        private System.Windows.Forms.Button buttonFindPTCGO;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxCodes;
        private System.Windows.Forms.Button buttonTest;
    }
}

