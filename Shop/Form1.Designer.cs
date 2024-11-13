namespace Shop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ShopContainer = new FlowLayoutPanel();
            panel1 = new Panel();
            Btn_Dental_Products = new Button();
            Btn_Meat_Products = new Button();
            Btn_Dairy_Products = new Button();
            Btn_Soft_Drinks = new Button();
            Btn_Shower_Products = new Button();
            Btn_Vegetables = new Button();
            Btn_Coffee_Products = new Button();
            Btn_Save = new Button();
            Btn_Load = new Button();
            Btn_All_Items = new Button();
            Panel_Cart_Small = new Panel();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            TotalPricePanel = new Panel();
            TotalPriceLabel = new Label();
            Btn_ClearOrder = new Button();
            panel1.SuspendLayout();
            Panel_Cart_Small.SuspendLayout();
            TotalPricePanel.SuspendLayout();
            SuspendLayout();
            // 
            // ShopContainer
            // 
            resources.ApplyResources(ShopContainer, "ShopContainer");
            ShopContainer.BackColor = Color.White;
            ShopContainer.Name = "ShopContainer";
            ShopContainer.Paint += ShopContainer_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(Btn_Dental_Products);
            panel1.Controls.Add(Btn_Meat_Products);
            panel1.Controls.Add(Btn_Dairy_Products);
            panel1.Controls.Add(Btn_Soft_Drinks);
            panel1.Controls.Add(Btn_Shower_Products);
            panel1.Controls.Add(Btn_Vegetables);
            panel1.Controls.Add(Btn_Coffee_Products);
            panel1.Controls.Add(Btn_Save);
            panel1.Controls.Add(Btn_Load);
            panel1.Controls.Add(Btn_All_Items);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // Btn_Dental_Products
            // 
            resources.ApplyResources(Btn_Dental_Products, "Btn_Dental_Products");
            Btn_Dental_Products.Name = "Btn_Dental_Products";
            Btn_Dental_Products.UseVisualStyleBackColor = true;
            Btn_Dental_Products.Click += Btn_Dental_Products_Click;
            // 
            // Btn_Meat_Products
            // 
            resources.ApplyResources(Btn_Meat_Products, "Btn_Meat_Products");
            Btn_Meat_Products.Name = "Btn_Meat_Products";
            Btn_Meat_Products.UseVisualStyleBackColor = true;
            Btn_Meat_Products.Click += Btn_Meat_Products_Click;
            // 
            // Btn_Dairy_Products
            // 
            resources.ApplyResources(Btn_Dairy_Products, "Btn_Dairy_Products");
            Btn_Dairy_Products.Name = "Btn_Dairy_Products";
            Btn_Dairy_Products.UseVisualStyleBackColor = true;
            Btn_Dairy_Products.Click += Btn_Dairy_Products_Click;
            // 
            // Btn_Soft_Drinks
            // 
            resources.ApplyResources(Btn_Soft_Drinks, "Btn_Soft_Drinks");
            Btn_Soft_Drinks.Name = "Btn_Soft_Drinks";
            Btn_Soft_Drinks.UseVisualStyleBackColor = true;
            Btn_Soft_Drinks.Click += Btn_Soft_Drinks_Click;
            // 
            // Btn_Shower_Products
            // 
            resources.ApplyResources(Btn_Shower_Products, "Btn_Shower_Products");
            Btn_Shower_Products.Name = "Btn_Shower_Products";
            Btn_Shower_Products.UseVisualStyleBackColor = true;
            Btn_Shower_Products.Click += Btn_Hygenic_Products_Click;
            // 
            // Btn_Vegetables
            // 
            resources.ApplyResources(Btn_Vegetables, "Btn_Vegetables");
            Btn_Vegetables.Name = "Btn_Vegetables";
            Btn_Vegetables.UseVisualStyleBackColor = true;
            Btn_Vegetables.Click += Btn_Vegetables_Click;
            // 
            // Btn_Coffee_Products
            // 
            resources.ApplyResources(Btn_Coffee_Products, "Btn_Coffee_Products");
            Btn_Coffee_Products.Name = "Btn_Coffee_Products";
            Btn_Coffee_Products.UseVisualStyleBackColor = true;
            Btn_Coffee_Products.Click += Btn_Coffee_Products_Click;
            // 
            // Btn_Save
            // 
            resources.ApplyResources(Btn_Save, "Btn_Save");
            Btn_Save.Name = "Btn_Save";
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += Btn_Save_Click_1;
            // 
            // Btn_Load
            // 
            resources.ApplyResources(Btn_Load, "Btn_Load");
            Btn_Load.Name = "Btn_Load";
            Btn_Load.UseVisualStyleBackColor = true;
            Btn_Load.Click += Btn_Load_Click_1;
            // 
            // Btn_All_Items
            // 
            resources.ApplyResources(Btn_All_Items, "Btn_All_Items");
            Btn_All_Items.Name = "Btn_All_Items";
            Btn_All_Items.UseVisualStyleBackColor = true;
            Btn_All_Items.Click += button1_Click_1;
            // 
            // Panel_Cart_Small
            // 
            resources.ApplyResources(Panel_Cart_Small, "Panel_Cart_Small");
            Panel_Cart_Small.BorderStyle = BorderStyle.Fixed3D;
            Panel_Cart_Small.Controls.Add(button1);
            Panel_Cart_Small.Controls.Add(label2);
            Panel_Cart_Small.Controls.Add(label1);
            Panel_Cart_Small.Name = "Panel_Cart_Small";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // TotalPricePanel
            // 
            TotalPricePanel.BorderStyle = BorderStyle.FixedSingle;
            TotalPricePanel.Controls.Add(TotalPriceLabel);
            resources.ApplyResources(TotalPricePanel, "TotalPricePanel");
            TotalPricePanel.Name = "TotalPricePanel";
            TotalPricePanel.Paint += TotalPricePanel_Paint;
            // 
            // TotalPriceLabel
            // 
            resources.ApplyResources(TotalPriceLabel, "TotalPriceLabel");
            TotalPriceLabel.Name = "TotalPriceLabel";
            // 
            // Btn_ClearOrder
            // 
            resources.ApplyResources(Btn_ClearOrder, "Btn_ClearOrder");
            Btn_ClearOrder.Name = "Btn_ClearOrder";
            Btn_ClearOrder.UseVisualStyleBackColor = true;
            Btn_ClearOrder.Click += Btn_ClearOrder_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(Btn_ClearOrder);
            Controls.Add(TotalPricePanel);
            Controls.Add(Panel_Cart_Small);
            Controls.Add(panel1);
            Controls.Add(ShopContainer);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            Panel_Cart_Small.ResumeLayout(false);
            Panel_Cart_Small.PerformLayout();
            TotalPricePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel ShopContainer;
        private Panel panel1;
        private Button Btn_Meat_Products;
        private Button Btn_Dairy_Products;
        private Button Btn_Soft_Drinks;
        private Button Btn_Shower_Products;
        private Button Btn_Vegetables;
        private Button Btn_Coffee_Products;
        private Button Btn_Save;
        private Button Btn_Load;
        private Button Btn_All_Items;
        private Button Btn_Dental_Products;
        private Panel Panel_Cart_Small;
        private Label label2;
        private Label label1;
        private Panel TotalPricePanel;
        private Label TotalPriceLabel;
        private Button button1;
        private Button Btn_ClearOrder;
    }
}