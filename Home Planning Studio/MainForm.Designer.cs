namespace Home_Planning_Studio
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.miRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPanel = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btCreate = new System.Windows.Forms.ToolStripButton();
            this.btOpen = new System.Windows.Forms.ToolStripButton();
            this.btSave = new System.Windows.Forms.ToolStripButton();
            this.btSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btUndo = new System.Windows.Forms.ToolStripSplitButton();
            this.btRedo = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btLine = new System.Windows.Forms.ToolStripButton();
            this.btPolyLine = new System.Windows.Forms.ToolStripButton();
            this.btCircle = new System.Windows.Forms.ToolStripSplitButton();
            this.btArc = new System.Windows.Forms.ToolStripSplitButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.msMain.SuspendLayout();
            this.tsPanel.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreate,
            this.miOpen,
            this.toolStripSeparator1,
            this.miSave,
            this.miSaveAs,
            this.toolStripSeparator4,
            this.miExit});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // miCreate
            // 
            this.miCreate.Image = ((System.Drawing.Image)(resources.GetObject("miCreate.Image")));
            this.miCreate.Name = "miCreate";
            this.miCreate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miCreate.Size = new System.Drawing.Size(235, 24);
            this.miCreate.Text = "New";
            this.miCreate.Click += new System.EventHandler(this.miCreate_Click);
            // 
            // miOpen
            // 
            this.miOpen.Image = ((System.Drawing.Image)(resources.GetObject("miOpen.Image")));
            this.miOpen.Name = "miOpen";
            this.miOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpen.Size = new System.Drawing.Size(235, 24);
            this.miOpen.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // miSave
            // 
            this.miSave.Image = ((System.Drawing.Image)(resources.GetObject("miSave.Image")));
            this.miSave.Name = "miSave";
            this.miSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSave.Size = new System.Drawing.Size(235, 24);
            this.miSave.Text = "Save";
            // 
            // miSaveAs
            // 
            this.miSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("miSaveAs.Image")));
            this.miSaveAs.Name = "miSaveAs";
            this.miSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.miSaveAs.Size = new System.Drawing.Size(235, 24);
            this.miSaveAs.Text = "Save as...";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(232, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.miExit.Size = new System.Drawing.Size(235, 24);
            this.miExit.Text = "Exit";
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(884, 28);
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUndo,
            this.miRedo});
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // miUndo
            // 
            this.miUndo.Image = ((System.Drawing.Image)(resources.GetObject("miUndo.Image")));
            this.miUndo.Name = "miUndo";
            this.miUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.miUndo.Size = new System.Drawing.Size(168, 24);
            this.miUndo.Text = "Undo";
            this.miUndo.Click += new System.EventHandler(this.miUndo_Click);
            // 
            // miRedo
            // 
            this.miRedo.Image = ((System.Drawing.Image)(resources.GetObject("miRedo.Image")));
            this.miRedo.Name = "miRedo";
            this.miRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.miRedo.Size = new System.Drawing.Size(168, 24);
            this.miRedo.Text = "Redo";
            this.miRedo.Click += new System.EventHandler(this.miRedo_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 24);
            this.toolStripMenuItem1.Text = "Help";
            // 
            // miAbout
            // 
            this.miAbout.Image = ((System.Drawing.Image)(resources.GetObject("miAbout.Image")));
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(123, 24);
            this.miAbout.Text = "About";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // tsPanel
            // 
            this.tsPanel.Controls.Add(this.toolStrip2);
            this.tsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsPanel.Location = new System.Drawing.Point(0, 28);
            this.tsPanel.Name = "tsPanel";
            this.tsPanel.Size = new System.Drawing.Size(884, 30);
            this.tsPanel.TabIndex = 4;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btCreate,
            this.btOpen,
            this.btSave,
            this.btSaveAs,
            this.toolStripSeparator2,
            this.btUndo,
            this.btRedo,
            this.toolStripSeparator3,
            this.btLine,
            this.btPolyLine,
            this.btCircle,
            this.btArc});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(884, 30);
            this.toolStrip2.TabIndex = 4;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btCreate
            // 
            this.btCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btCreate.Image = ((System.Drawing.Image)(resources.GetObject("btCreate.Image")));
            this.btCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCreate.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(23, 24);
            this.btCreate.Text = "Создать";
            this.btCreate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCreate.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btCreate.ToolTipText = "Создать";
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btOpen
            // 
            this.btOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btOpen.Image = ((System.Drawing.Image)(resources.GetObject("btOpen.Image")));
            this.btOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btOpen.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(23, 24);
            this.btOpen.Text = "Открыть";
            this.btOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btOpen.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btOpen.ToolTipText = "Открыть";
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btSave
            // 
            this.btSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSave.Image = ((System.Drawing.Image)(resources.GetObject("btSave.Image")));
            this.btSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSave.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(23, 24);
            this.btSave.Text = "Сохранить";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSave.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btSave.ToolTipText = "Сохранить";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btSaveAs
            // 
            this.btSaveAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btSaveAs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btSaveAs.Image")));
            this.btSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSaveAs.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.btSaveAs.Name = "btSaveAs";
            this.btSaveAs.Size = new System.Drawing.Size(23, 24);
            this.btSaveAs.Text = "Сохранить как...";
            this.btSaveAs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSaveAs.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btSaveAs.ToolTipText = "Сохранить как...";
            this.btSaveAs.Click += new System.EventHandler(this.btSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // btUndo
            // 
            this.btUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btUndo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btUndo.Image = ((System.Drawing.Image)(resources.GetObject("btUndo.Image")));
            this.btUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btUndo.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.btUndo.Name = "btUndo";
            this.btUndo.Size = new System.Drawing.Size(32, 24);
            this.btUndo.Text = "Отменить";
            this.btUndo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btUndo.ButtonClick += new System.EventHandler(this.btUndo_ButtonClick);
            this.btUndo.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.btUndo_DropDownItemClicked);
            // 
            // btRedo
            // 
            this.btRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btRedo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btRedo.Image = ((System.Drawing.Image)(resources.GetObject("btRedo.Image")));
            this.btRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btRedo.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.btRedo.Name = "btRedo";
            this.btRedo.Size = new System.Drawing.Size(32, 24);
            this.btRedo.Text = "Вернуть";
            this.btRedo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRedo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btRedo.ButtonClick += new System.EventHandler(this.btRedo_ButtonClick);
            this.btRedo.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.btRedo_DropDownItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // btLine
            // 
            this.btLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btLine.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btLine.Image = ((System.Drawing.Image)(resources.GetObject("btLine.Image")));
            this.btLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btLine.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.btLine.Name = "btLine";
            this.btLine.Size = new System.Drawing.Size(23, 24);
            this.btLine.Text = "Отрезок";
            this.btLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btLine.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btLine.ToolTipText = "Отрезок";
            this.btLine.Click += new System.EventHandler(this.btLine_Click_1);
            // 
            // btPolyLine
            // 
            this.btPolyLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btPolyLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btPolyLine.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btPolyLine.Image = ((System.Drawing.Image)(resources.GetObject("btPolyLine.Image")));
            this.btPolyLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btPolyLine.Margin = new System.Windows.Forms.Padding(1, 3, 2, 3);
            this.btPolyLine.Name = "btPolyLine";
            this.btPolyLine.Size = new System.Drawing.Size(23, 24);
            this.btPolyLine.Text = "Полилиния";
            this.btPolyLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btPolyLine.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btPolyLine.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btPolyLine.ToolTipText = "Полилиния";
            this.btPolyLine.Click += new System.EventHandler(this.btPolyLine_Click_1);
            // 
            // btCircle
            // 
            this.btCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btCircle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCircle.Image = ((System.Drawing.Image)(resources.GetObject("btCircle.Image")));
            this.btCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btCircle.Margin = new System.Windows.Forms.Padding(1, 3, 2, 3);
            this.btCircle.Name = "btCircle";
            this.btCircle.Size = new System.Drawing.Size(32, 24);
            this.btCircle.Text = "Круг";
            this.btCircle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCircle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btCircle.ButtonClick += new System.EventHandler(this.btCircle_ButtonClick);
            // 
            // btArc
            // 
            this.btArc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btArc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btArc.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btArc.Image = ((System.Drawing.Image)(resources.GetObject("btArc.Image")));
            this.btArc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btArc.Margin = new System.Windows.Forms.Padding(1, 3, 2, 3);
            this.btArc.Name = "btArc";
            this.btArc.Size = new System.Drawing.Size(32, 24);
            this.btArc.Text = "Дуга";
            this.btArc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btArc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btArc.ButtonClick += new System.EventHandler(this.btArc_ButtonClick);
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 503);
            this.panel2.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tsPanel);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "MainForm";
            this.Text = "Home Planning Studio";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsPanel.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.Panel tsPanel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btCreate;
        private System.Windows.Forms.ToolStripButton btOpen;
        private System.Windows.Forms.ToolStripSplitButton btRedo;
        private System.Windows.Forms.ToolStripSplitButton btUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton btSave;
        private System.Windows.Forms.ToolStripButton btSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btLine;
        private System.Windows.Forms.ToolStripButton btPolyLine;
        private System.Windows.Forms.ToolStripSplitButton btCircle;
        private System.Windows.Forms.ToolStripSplitButton btArc;
        private System.Windows.Forms.ToolStripMenuItem miCreate;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miUndo;
        private System.Windows.Forms.ToolStripMenuItem miRedo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
    }
}

