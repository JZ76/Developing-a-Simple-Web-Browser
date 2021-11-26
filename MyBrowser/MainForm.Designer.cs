
namespace MyBrowser
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.historyList = new System.Windows.Forms.ListBox();
            this.addToFavorites = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.FavoritesList = new System.Windows.Forms.ListBox();
            this.Bulk = new System.Windows.Forms.Button();
            this.history = new System.Windows.Forms.Button();
            this.Favorites = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.URL = new System.Windows.Forms.TextBox();
            this.homePage = new System.Windows.Forms.Button();
            this.reload = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFavorite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkDownload = new System.Windows.Forms.OpenFileDialog();
            this.panel2.SuspendLayout();
            this.contextMenuHistory.SuspendLayout();
            this.contextMenuFavorite.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 533);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 0);
            this.panel1.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(795, 113);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(49, 25);
            this.button6.TabIndex = 8;
            this.button6.Text = "···";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.historyList);
            this.panel2.Controls.Add(this.addToFavorites);
            this.panel2.Controls.Add(this.delete);
            this.panel2.Controls.Add(this.FavoritesList);
            this.panel2.Controls.Add(this.Bulk);
            this.panel2.Controls.Add(this.history);
            this.panel2.Controls.Add(this.Favorites);
            this.panel2.Controls.Add(this.add);
            this.panel2.Controls.Add(this.URL);
            this.panel2.Controls.Add(this.homePage);
            this.panel2.Controls.Add(this.reload);
            this.panel2.Controls.Add(this.next);
            this.panel2.Controls.Add(this.previous);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(969, 533);
            this.panel2.TabIndex = 9;
            // 
            // historyList
            // 
            this.historyList.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.historyList.BackColor = System.Drawing.SystemColors.Menu;
            this.historyList.FormattingEnabled = true;
            this.historyList.ItemHeight = 12;
            this.historyList.Location = new System.Drawing.Point(555, 38);
            this.historyList.Name = "historyList";
            this.historyList.Size = new System.Drawing.Size(350, 400);
            this.historyList.TabIndex = 17;
            this.historyList.Visible = false;
            this.historyList.SelectedIndexChanged += new System.EventHandler(this.historyList_SelectedIndexChanged);
            this.historyList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.historyList_MouseUp_1);
            // 
            // addToFavorites
            // 
            this.addToFavorites.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addToFavorites.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addToFavorites.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.addToFavorites.ForeColor = System.Drawing.Color.Black;
            this.addToFavorites.Location = new System.Drawing.Point(531, 13);
            this.addToFavorites.Name = "addToFavorites";
            this.addToFavorites.Size = new System.Drawing.Size(79, 25);
            this.addToFavorites.TabIndex = 16;
            this.addToFavorites.Text = "AddToFav";
            this.addToFavorites.UseVisualStyleBackColor = true;
            this.addToFavorites.Click += new System.EventHandler(this.addToFavorites_Click);
            // 
            // delete
            // 
            this.delete.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.delete.ForeColor = System.Drawing.Color.Black;
            this.delete.Location = new System.Drawing.Point(658, 13);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(57, 25);
            this.delete.TabIndex = 15;
            this.delete.Text = "Remove";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // FavoritesList
            // 
            this.FavoritesList.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.FavoritesList.BackColor = System.Drawing.SystemColors.Menu;
            this.FavoritesList.FormattingEnabled = true;
            this.FavoritesList.ItemHeight = 12;
            this.FavoritesList.Location = new System.Drawing.Point(490, 38);
            this.FavoritesList.Name = "FavoritesList";
            this.FavoritesList.Size = new System.Drawing.Size(350, 400);
            this.FavoritesList.TabIndex = 13;
            this.FavoritesList.Visible = false;
            this.FavoritesList.SelectedIndexChanged += new System.EventHandler(this.FavoritesList_SelectedIndexChanged);
            this.FavoritesList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FavoritesList_MouseUp);
            // 
            // Bulk
            // 
            this.Bulk.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bulk.Location = new System.Drawing.Point(918, 13);
            this.Bulk.Name = "Bulk";
            this.Bulk.Size = new System.Drawing.Size(40, 25);
            this.Bulk.TabIndex = 12;
            this.Bulk.Text = "Bulk";
            this.Bulk.UseVisualStyleBackColor = true;
            this.Bulk.Click += new System.EventHandler(this.Bulk_Click);
            // 
            // history
            // 
            this.history.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.history.Location = new System.Drawing.Point(857, 13);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(55, 25);
            this.history.TabIndex = 11;
            this.history.Text = "History";
            this.history.UseVisualStyleBackColor = true;
            this.history.Click += new System.EventHandler(this.history_Click);
            // 
            // Favorites
            // 
            this.Favorites.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Favorites.Location = new System.Drawing.Point(772, 13);
            this.Favorites.Name = "Favorites";
            this.Favorites.Size = new System.Drawing.Size(79, 25);
            this.Favorites.TabIndex = 10;
            this.Favorites.Text = "Favourites";
            this.Favorites.UseVisualStyleBackColor = true;
            this.Favorites.Click += new System.EventHandler(this.Favorites_Click);
            // 
            // add
            // 
            this.add.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.add.ForeColor = System.Drawing.Color.Black;
            this.add.Location = new System.Drawing.Point(616, 13);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(36, 25);
            this.add.TabIndex = 9;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // URL
            // 
            this.URL.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.URL.Location = new System.Drawing.Point(152, 16);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(373, 21);
            this.URL.TabIndex = 5;
            this.URL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.URL_KeyDown);
            // 
            // homePage
            // 
            this.homePage.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.homePage.Location = new System.Drawing.Point(721, 13);
            this.homePage.Name = "homePage";
            this.homePage.Size = new System.Drawing.Size(45, 25);
            this.homePage.TabIndex = 4;
            this.homePage.Text = "Home";
            this.homePage.UseVisualStyleBackColor = true;
            this.homePage.Click += new System.EventHandler(this.homePage_Click);
            this.homePage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.homePage_MouseUp);
            // 
            // reload
            // 
            this.reload.Location = new System.Drawing.Point(96, 12);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(50, 25);
            this.reload.TabIndex = 3;
            this.reload.Text = "Reload";
            this.reload.UseVisualStyleBackColor = true;
            this.reload.Click += new System.EventHandler(this.reload_Click);
            this.reload.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reload_KeyDown_1);
            // 
            // next
            // 
            this.next.Location = new System.Drawing.Point(50, 12);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(40, 25);
            this.next.TabIndex = 2;
            this.next.Text = "==>";
            this.next.UseVisualStyleBackColor = true;
            this.next.Visible = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // previous
            // 
            this.previous.Location = new System.Drawing.Point(4, 12);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(40, 25);
            this.previous.TabIndex = 1;
            this.previous.Text = "<==";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Visible = false;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(0, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(969, 489);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // contextMenuHistory
            // 
            this.contextMenuHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.deleteToolStripMenuItem1});
            this.contextMenuHistory.Name = "contextMenuHistory";
            this.contextMenuHistory.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // contextMenuFavorite
            // 
            this.contextMenuFavorite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.editToolStripMenuItem, this.deleteToolStripMenuItem});
            this.contextMenuFavorite.Name = "contextMenuStrip1";
            this.contextMenuFavorite.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // bulkDownload
            // 
            this.bulkDownload.Filter = "*.txt|";
            this.bulkDownload.Title = "Select a txt file";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(969, 533);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuHistory.ResumeLayout(false);
            this.contextMenuFavorite.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button Favorites;

        private System.Windows.Forms.ContextMenuStrip contextMenuFavorite;

        private System.Windows.Forms.ListBox FavoritesList;

        private System.Windows.Forms.Button addToFavorites;

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox URL;
        private System.Windows.Forms.Button homePage;
        private System.Windows.Forms.Button reload;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.Button add;
        //private System.Windows.Forms.ContextMenuStrip contextMenuFavouriate;
        private System.Windows.Forms.Button history;
        //private System.Windows.Forms.Button Favorites;
        private System.Windows.Forms.Button Bulk;
        private System.Windows.Forms.OpenFileDialog bulkDownload;
        //private System.Windows.Forms.ListBox FavoritesList;
        private System.Windows.Forms.Button delete;
        //private System.Windows.Forms.Button addToFavouriates;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuHistory;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox historyList;
    }
}

