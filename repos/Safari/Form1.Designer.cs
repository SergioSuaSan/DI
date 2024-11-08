namespace Safari
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
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            funcionesPrincipalesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            funcionesPrincipalesToolStripMenuItem1 = new ToolStripMenuItem();
            stepToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            playToolStripMenuItem = new ToolStripMenuItem();
            pauseToolStripMenuItem = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem1 = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            buttonStep = new Button();
            buttonReset = new Button();
            buttonPause = new Button();
            buttonStop = new Button();
            buttonPlay = new Button();
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            numeroPlantas = new Label();
            label1 = new Label();
            panel2 = new Panel();
            groupBox4 = new GroupBox();
            numeroLeones = new Label();
            label6 = new Label();
            panel3 = new Panel();
            groupBox3 = new GroupBox();
            numeroGacelas = new Label();
            label4 = new Label();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { funcionesPrincipalesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(220, 28);
            // 
            // funcionesPrincipalesToolStripMenuItem
            // 
            funcionesPrincipalesToolStripMenuItem.Name = "funcionesPrincipalesToolStripMenuItem";
            funcionesPrincipalesToolStripMenuItem.Size = new Size(219, 24);
            funcionesPrincipalesToolStripMenuItem.Text = "Funciones principales";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { funcionesPrincipalesToolStripMenuItem1, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(798, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // funcionesPrincipalesToolStripMenuItem1
            // 
            funcionesPrincipalesToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { stepToolStripMenuItem, resetToolStripMenuItem, playToolStripMenuItem, pauseToolStripMenuItem, stopToolStripMenuItem, exitToolStripMenuItem });
            funcionesPrincipalesToolStripMenuItem1.Name = "funcionesPrincipalesToolStripMenuItem1";
            funcionesPrincipalesToolStripMenuItem1.Size = new Size(163, 24);
            funcionesPrincipalesToolStripMenuItem1.Text = "Funciones Principales";
            // 
            // stepToolStripMenuItem
            // 
            stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            stepToolStripMenuItem.Size = new Size(129, 26);
            stepToolStripMenuItem.Text = "Step";
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(129, 26);
            resetToolStripMenuItem.Text = "Reset";
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.Size = new Size(129, 26);
            playToolStripMenuItem.Text = "Play";
            playToolStripMenuItem.Click += playToolStripMenuItem_Click;
            // 
            // pauseToolStripMenuItem
            // 
            pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            pauseToolStripMenuItem.Size = new Size(129, 26);
            pauseToolStripMenuItem.Text = "Pause";
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(129, 26);
            stopToolStripMenuItem.Text = "Stop";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(224, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ayudaToolStripMenuItem1, acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(65, 24);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // ayudaToolStripMenuItem1
            // 
            ayudaToolStripMenuItem1.Name = "ayudaToolStripMenuItem1";
            ayudaToolStripMenuItem1.Size = new Size(158, 26);
            ayudaToolStripMenuItem1.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(158, 26);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonStep);
            groupBox1.Controls.Add(buttonReset);
            groupBox1.Controls.Add(buttonPause);
            groupBox1.Controls.Add(buttonStop);
            groupBox1.Controls.Add(buttonPlay);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(504, 76);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // buttonStep
            // 
            buttonStep.Location = new Point(407, 26);
            buttonStep.Name = "buttonStep";
            buttonStep.Size = new Size(94, 29);
            buttonStep.TabIndex = 4;
            buttonStep.Text = "STEP";
            buttonStep.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(307, 26);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(94, 29);
            buttonReset.TabIndex = 3;
            buttonReset.Text = "RESET";
            buttonReset.UseVisualStyleBackColor = true;
            // 
            // buttonPause
            // 
            buttonPause.Location = new Point(207, 26);
            buttonPause.Name = "buttonPause";
            buttonPause.Size = new Size(94, 29);
            buttonPause.TabIndex = 2;
            buttonPause.Text = "PAUSE";
            buttonPause.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(107, 26);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(94, 29);
            buttonStop.TabIndex = 1;
            buttonStop.Text = "STOP";
            buttonStop.UseVisualStyleBackColor = true;
            // 
            // buttonPlay
            // 
            buttonPlay.Location = new Point(7, 26);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(94, 29);
            buttonPlay.TabIndex = 0;
            buttonPlay.Text = "PLAY";
            buttonPlay.UseVisualStyleBackColor = true;
            buttonPlay.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(12, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 81);
            panel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(numeroPlantas);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(0, 0);
            groupBox2.Margin = new Padding(0);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(0);
            groupBox2.Size = new Size(163, 63);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            // 
            // numeroPlantas
            // 
            numeroPlantas.AutoSize = true;
            numeroPlantas.Location = new Point(93, 20);
            numeroPlantas.Name = "numeroPlantas";
            numeroPlantas.Size = new Size(17, 20);
            numeroPlantas.TabIndex = 1;
            numeroPlantas.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 0;
            label1.Text = "Plantas:";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(groupBox4);
            panel2.Controls.Add(groupBox2);
            panel2.Location = new Point(12, 118);
            panel2.Name = "panel2";
            panel2.Size = new Size(775, 63);
            panel2.TabIndex = 5;
            panel2.Paint += panel2_Paint;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(numeroLeones);
            groupBox4.Controls.Add(label6);
            groupBox4.Location = new Point(542, 0);
            groupBox4.Margin = new Padding(0);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(0);
            groupBox4.Size = new Size(163, 63);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            // 
            // numeroLeones
            // 
            numeroLeones.AutoSize = true;
            numeroLeones.Location = new Point(90, 17);
            numeroLeones.Name = "numeroLeones";
            numeroLeones.Size = new Size(17, 20);
            numeroLeones.TabIndex = 1;
            numeroLeones.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 17);
            label6.Name = "label6";
            label6.Size = new Size(55, 20);
            label6.TabIndex = 0;
            label6.Text = "Leones";
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Location = new Point(12, 187);
            panel3.Name = "panel3";
            panel3.Size = new Size(776, 475);
            panel3.TabIndex = 6;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.GradientActiveCaption;
            groupBox3.Controls.Add(numeroGacelas);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(242, 118);
            groupBox3.Margin = new Padding(0);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(0);
            groupBox3.Size = new Size(163, 63);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            // 
            // numeroGacelas
            // 
            numeroGacelas.AutoSize = true;
            numeroGacelas.Location = new Point(90, 17);
            numeroGacelas.Name = "numeroGacelas";
            numeroGacelas.Size = new Size(17, 20);
            numeroGacelas.TabIndex = 1;
            numeroGacelas.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 17);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 0;
            label4.Text = "Gacelas:";
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 674);
            Controls.Add(groupBox3);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Safari de Sergio";
            Load += Form1_Load_2;
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem funcionesPrincipalesToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem funcionesPrincipalesToolStripMenuItem1;
        private ToolStripMenuItem stepToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem playToolStripMenuItem;
        private ToolStripMenuItem pauseToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem1;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private GroupBox groupBox1;
        private Button buttonPlay;
        private Button buttonStep;
        private Button buttonReset;
        private Button buttonPause;
        private Button buttonStop;
        private Panel panel1;
        private GroupBox groupBox2;
        private Label numeroPlantas;
        private Label label1;
        private Panel panel2;
        private Panel panel3;
        private GroupBox groupBox4;
        private Label numeroLeones;
        private Label label6;
        private GroupBox groupBox3;
        private Label numeroGacelas;
        private Label label4;
    }
}
