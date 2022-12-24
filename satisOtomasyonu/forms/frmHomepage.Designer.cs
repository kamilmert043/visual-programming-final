namespace satisOtomasyonu
{
    partial class frmHomepage
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnListProductGroup = new System.Windows.Forms.Button();
            this.btnAddProductGroup = new System.Windows.Forms.Button();
            this.btnListSales = new System.Windows.Forms.Button();
            this.btnSaleOrder = new System.Windows.Forms.Button();
            this.btnListCustomers = new System.Windows.Forms.Button();
            this.btnAddCostumers = new System.Windows.Forms.Button();
            this.btnListUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnListProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.panelPages = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnListProductGroup);
            this.panel1.Controls.Add(this.btnAddProductGroup);
            this.panel1.Controls.Add(this.btnListSales);
            this.panel1.Controls.Add(this.btnSaleOrder);
            this.panel1.Controls.Add(this.btnListCustomers);
            this.panel1.Controls.Add(this.btnAddCostumers);
            this.panel1.Controls.Add(this.btnListUser);
            this.panel1.Controls.Add(this.btnAddUser);
            this.panel1.Controls.Add(this.btnListProduct);
            this.panel1.Controls.Add(this.btnAddProduct);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 187);
            this.panel1.TabIndex = 0;
            // 
            // btnListProductGroup
            // 
            this.btnListProductGroup.Location = new System.Drawing.Point(125, 79);
            this.btnListProductGroup.Name = "btnListProductGroup";
            this.btnListProductGroup.Size = new System.Drawing.Size(106, 55);
            this.btnListProductGroup.TabIndex = 10;
            this.btnListProductGroup.Text = "Ürün Grubu Güncelle";
            this.btnListProductGroup.UseVisualStyleBackColor = true;
            this.btnListProductGroup.Click += new System.EventHandler(this.btnListProductGroup_Click);
            // 
            // btnAddProductGroup
            // 
            this.btnAddProductGroup.Location = new System.Drawing.Point(5, 79);
            this.btnAddProductGroup.Name = "btnAddProductGroup";
            this.btnAddProductGroup.Size = new System.Drawing.Size(106, 55);
            this.btnAddProductGroup.TabIndex = 9;
            this.btnAddProductGroup.Text = "Ürün Grubu Ekle";
            this.btnAddProductGroup.UseVisualStyleBackColor = true;
            this.btnAddProductGroup.Click += new System.EventHandler(this.btnAddProductGroup_Click);
            // 
            // btnListSales
            // 
            this.btnListSales.Location = new System.Drawing.Point(845, 18);
            this.btnListSales.Name = "btnListSales";
            this.btnListSales.Size = new System.Drawing.Size(106, 55);
            this.btnListSales.TabIndex = 8;
            this.btnListSales.Text = "Satışları Listele";
            this.btnListSales.UseVisualStyleBackColor = true;
            this.btnListSales.Click += new System.EventHandler(this.btnListSales_Click);
            // 
            // btnSaleOrder
            // 
            this.btnSaleOrder.Location = new System.Drawing.Point(725, 18);
            this.btnSaleOrder.Name = "btnSaleOrder";
            this.btnSaleOrder.Size = new System.Drawing.Size(106, 55);
            this.btnSaleOrder.TabIndex = 7;
            this.btnSaleOrder.Text = "Satış Yap";
            this.btnSaleOrder.UseVisualStyleBackColor = true;
            this.btnSaleOrder.Click += new System.EventHandler(this.btnSaleOrder_Click);
            // 
            // btnListCustomers
            // 
            this.btnListCustomers.Location = new System.Drawing.Point(605, 18);
            this.btnListCustomers.Name = "btnListCustomers";
            this.btnListCustomers.Size = new System.Drawing.Size(106, 55);
            this.btnListCustomers.TabIndex = 6;
            this.btnListCustomers.Text = "Müşteri Güncelle";
            this.btnListCustomers.UseVisualStyleBackColor = true;
            this.btnListCustomers.Click += new System.EventHandler(this.btnListCustomers_Click);
            // 
            // btnAddCostumers
            // 
            this.btnAddCostumers.Location = new System.Drawing.Point(485, 18);
            this.btnAddCostumers.Name = "btnAddCostumers";
            this.btnAddCostumers.Size = new System.Drawing.Size(106, 55);
            this.btnAddCostumers.TabIndex = 5;
            this.btnAddCostumers.Text = "Müşteri Ekle";
            this.btnAddCostumers.UseVisualStyleBackColor = true;
            this.btnAddCostumers.Click += new System.EventHandler(this.btnAddCostumers_Click);
            // 
            // btnListUser
            // 
            this.btnListUser.Location = new System.Drawing.Point(365, 18);
            this.btnListUser.Name = "btnListUser";
            this.btnListUser.Size = new System.Drawing.Size(106, 55);
            this.btnListUser.TabIndex = 4;
            this.btnListUser.Text = "Kullanıcı Güncelle";
            this.btnListUser.UseVisualStyleBackColor = true;
            this.btnListUser.Click += new System.EventHandler(this.btnListUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(245, 18);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(106, 55);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "Kullanıcı Ekle";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnListProduct
            // 
            this.btnListProduct.Location = new System.Drawing.Point(125, 18);
            this.btnListProduct.Name = "btnListProduct";
            this.btnListProduct.Size = new System.Drawing.Size(106, 55);
            this.btnListProduct.TabIndex = 1;
            this.btnListProduct.Text = "Ürün Güncelle";
            this.btnListProduct.UseVisualStyleBackColor = true;
            this.btnListProduct.Click += new System.EventHandler(this.btnListProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(5, 18);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(106, 55);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Ürün Ekle";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // panelPages
            // 
            this.panelPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPages.Location = new System.Drawing.Point(0, 187);
            this.panelPages.Name = "panelPages";
            this.panelPages.Size = new System.Drawing.Size(957, 462);
            this.panelPages.TabIndex = 2;
            // 
            // frmHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(957, 649);
            this.Controls.Add(this.panelPages);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "frmHomepage";
            this.Text = "Manav Satış Otomasyonu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHomepage_FormClosed);
            this.Load += new System.EventHandler(this.frmHomepage_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnListSales;
        private System.Windows.Forms.Button btnSaleOrder;
        private System.Windows.Forms.Button btnListCustomers;
        private System.Windows.Forms.Button btnAddCostumers;
        private System.Windows.Forms.Button btnListUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnListProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Panel panelPages;
        private System.Windows.Forms.Button btnAddProductGroup;
        private System.Windows.Forms.Button btnListProductGroup;
    }
}

