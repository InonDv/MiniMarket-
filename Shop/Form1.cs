using System.Drawing.Imaging;
using Shop.OurClasses;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Shop
{

    public partial class Form1 : Form
    {
        List<My_Cart> FormList = new List<My_Cart>();
        public enum CategoryType
        {
            Meat_Product = 1, Dairy_Product = 2, Soft_Drinks = 3, Coffee = 4, Shower_Products = 5, Dental_Products = 6, Vegetables = 7
        }
        public int Current_category { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string text;
            var files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Pictures");
            List<string[]> data = new List<string[]>();
            List<Image> images = new List<Image>();  // Getting all the groceries via the "Pictures" directory
            foreach (var item in files)
            {
                if (item.EndsWith(".txt")) // if the item is the notepad
                {
                    var a = File.ReadAllText(item);
                    var b = a.Split("\n"); // splitting substrings
                    foreach (var st in b)
                    {
                        var rez = st.Split(",");
                        data.Add(rez);
                    }
                }
                else
                {
                    var image = Image.FromFile(item); // not the notepad
                    var numbers = item.Split(@"\");
                    var number = numbers[numbers.Length - 1].Split(".")[0];
                    image.Tag = number;
                    images.Add(image); // adding the image into the list of images
                }
            }
            for (int i = 0; i < images.Count; i++)
            {
                var currentImage = images[i];
                var ImgTag = currentImage.Tag as string; // casting the image tag to string
                var dataElement = data.Find(a => a[0] == ImgTag);
                if (CategoryClass.ourCategories.Count != 0) // if there is at least one category in the CategoryClass list
                {
                    int currentId = int.Parse(dataElement[6].Trim()); // extracting the id substring from the notepad
                    var element = CategoryClass.ourCategories.Find(a => a.Id == currentId); // checking if the right category for currentId doesn't exists yet
                    if (element == null)
                    {
                        CategoryClass categoryClass = new CategoryClass() // if it doesn't exist - create it
                        {
                            Id = int.Parse(dataElement[6].Trim()),
                            Name = dataElement[5]

                        };
                        CategoryClass.ourCategories.Add(categoryClass); // add the new category to the Categories list
                    }


                }
                else // might be uneccessery
                {
                    CategoryClass categoryClass = new CategoryClass()
                    {
                        Id = int.Parse(dataElement[6].Trim()),
                        Name = dataElement[5]

                    };
                    CategoryClass.ourCategories.Add(categoryClass);

                }
                switch (int.Parse(dataElement[6].Trim())) // POLYMORPHISM - checking the Id section in the notepad, to decide which object to create in the polymorhpic array
                {
                    case (int)CategoryType.Meat_Product:
                        {
                            Meat meat = new Meat(currentImage, dataElement[1], dataElement[2], int.Parse(dataElement[0].Trim()), double.Parse(dataElement[4].Trim()));
                            meat.Grams = double.Parse(dataElement[3].Trim());
                            Groceries.OurCart[i] = meat;
                        }
                        break;
                    case (int)CategoryType.Dairy_Product:
                        {
                            Dairy dairy = new Dairy(currentImage, dataElement[1], dataElement[2], int.Parse(dataElement[0].Trim()), double.Parse(dataElement[4].Trim()));
                            dairy.Grams = double.Parse(dataElement[3].Trim());
                            Groceries.OurCart[i] = dairy;
                        }
                        break;
                    case (int)CategoryType.Soft_Drinks:
                        {

                            SoftDrinks softDrinks = new SoftDrinks(currentImage, dataElement[1], dataElement[2], int.Parse(dataElement[0].Trim()), double.Parse(dataElement[4].Trim()));
                            softDrinks.Liter = int.Parse(dataElement[3].Trim());
                            Groceries.OurCart[i] = softDrinks;
                        }
                        break;
                    case (int)CategoryType.Coffee:
                        {
                            Coffee coffee = new Coffee(currentImage, dataElement[1], dataElement[2], int.Parse(dataElement[0].Trim()), double.Parse(dataElement[4].Trim()));
                            Groceries.OurCart[i] = coffee;
                        }
                        break;
                    case (int)CategoryType.Shower_Products:
                        {
                            ShowerProducts showerProducts = new ShowerProducts(currentImage, dataElement[1], dataElement[2], int.Parse(dataElement[0].Trim()), double.Parse(dataElement[4].Trim()));
                            Groceries.OurCart[i] = showerProducts;
                        }
                        break;
                    case (int)CategoryType.Dental_Products:
                        {
                            DentalProducts dentalProducts = new DentalProducts(currentImage, dataElement[1], dataElement[2], int.Parse(dataElement[0].Trim()), double.Parse(dataElement[4].Trim()));
                            Groceries.OurCart[i] = dentalProducts;
                        }
                        break;
                    case (int)CategoryType.Vegetables:
                        {
                            Vegetables vegetables = new Vegetables(currentImage, dataElement[1], dataElement[2], int.Parse(dataElement[0].Trim()), double.Parse(dataElement[4].Trim()));
                            vegetables.Grams = double.Parse(dataElement[3].Trim());
                            Groceries.OurCart[i] = vegetables;
                        }
                        break;
                    default:
                        break;
                }
                ShopContainer.Controls.Add(CreateItemOfShop(Groceries.OurCart[i])); // for each object created, create a new item in the shop panel
            }
        }

        private Panel CreateItemOfShop(Groceries g)
        {
            My_Cart my_Cart = new My_Cart() // basic constructor
            {
                AmountOfItems = 0,
                OurGroceries = g
            };
            // adding the panel dynamicly
            Panel panel = new Panel();
            panel.Margin = new Padding(5);
            panel.BackColor = Color.White;
            panel.Size = new Size(247, 364);
            panel.Location = new Point(10, 10);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(170, 170);
            pictureBox.Location = new Point(35, 3);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = my_Cart.OurGroceries._ProductImage;
            //ading picture to the panel
            panel.Controls.Add(pictureBox);
            Label name_label = new Label();
            //add label
            name_label.Text = my_Cart.OurGroceries._ProductName;
            name_label.Location = new Point(20, 176);
            name_label.Font = new Font(this.Font, FontStyle.Bold);
            name_label.TextAlign = ContentAlignment.TopLeft;
            name_label.AutoSize = true;
            //ading label to the panel
            panel.Controls.Add(name_label);
            RichTextBox textBox = new RichTextBox();
            textBox.Location = new Point(20, 194);
            textBox.Size = new Size(206, 60);
            textBox.ReadOnly = true;
            textBox.Font = new Font(this.Font, FontStyle.Italic);
            //input description
            textBox.Text = my_Cart.OurGroceries._ProductDescription;
            //adding textBox to the panel
            panel.Controls.Add(textBox);
            Label weigth = new Label();
            bool isGram = false;
            bool isLiter = false;
            if (my_Cart.OurGroceries._CategoryType == (int)CategoryType.Meat_Product || my_Cart.OurGroceries._CategoryType == (int)CategoryType.Vegetables)
                isGram = true;
            if (my_Cart.OurGroceries._CategoryType == (int)CategoryType.Soft_Drinks)
                isLiter = true;
            if (my_Cart.OurGroceries._CategoryType == (int)CategoryType.Dairy_Product)
                isGram = true;
            if (my_Cart.OurGroceries._ProductBarcode == 13)
            {
                isLiter = true;
                isGram = false;
            }

            if (isGram == true && isLiter == false)
            {
                var item = ((g as Groceries) as Consumables) as Food;
                double grams = item.Grams;
                weigth.Text = "Grams:       " + grams + "G";
            }

            if (isLiter == true && isGram == false)
            {
                var item = ((g as Groceries) as Consumables) as SoftDrinks;
                if (item != null)
                {
                    int liter = item.Liter;
                    weigth.Text = "Liter:      " + liter + "L";

                }

            }

            if (isLiter != false || isGram != false)
            {
                weigth.Location = new Point(20, 257);
                weigth.AutoSize = true;
                //adding grams to panel
                panel.Controls.Add(weigth);
            }
            Label price_label = new Label();
            price_label.Text = "Price:";
            price_label.Location = new Point(20, 272);
            price_label.AutoSize = true;
            //ading price label to the panel
            panel.Controls.Add(price_label);
            Label price_value = new Label();
            price_value.Text = my_Cart.OurGroceries._ProductPrice.ToString();
            price_value.Location = new Point(201, 272);
            price_value.AutoSize = true;
            price_value.Font = new Font(this.Font, FontStyle.Bold);
            //adding price_value to the panel
            panel.Controls.Add(price_value);
            Label amount = new Label();
            amount.Text = my_Cart.AmountOfItems.ToString();
            amount.Location = new Point(116, 295);
            amount.AutoSize = true;
            amount.Font = new Font(this.Font, FontStyle.Bold);
            //adding amount_label to the panel
            panel.Controls.Add(amount);
            Button button_plus = new Button();
            button_plus.Location = new Point(20, 290);
            button_plus.Size = new Size(25, 25);
            button_plus.Text = "+";
            button_plus.Tag = new object[] { my_Cart, amount };
            button_plus.Click += Button_plus_Click;   // EVENT
            button_plus.Font = new Font(this.Font, FontStyle.Bold);
            //adding button+ to the panel
            panel.Controls.Add(button_plus);
            Button button_minus = new Button();
            button_minus.Location = new Point(200, 290);
            button_minus.Size = new Size(25, 25);
            button_minus.Text = "-";
            button_minus.Tag = new object[] { my_Cart, amount };
            button_minus.Click += Button_minus_Click; // EVENT
            button_minus.Font = new Font(this.Font, FontStyle.Bold);
            //adding button- to the panel
            panel.Controls.Add(button_minus);
            Button addItem = new Button();
            addItem.Location = new Point(20, 319);
            addItem.Size = new Size(206, 32);
            addItem.Text = "Add Item";
            addItem.Click += AddItem_Click; // EVENT
            addItem.Tag = new object[] { my_Cart, amount };
            //add Add button to the panel
            panel.Controls.Add(addItem);
            return panel;
        }


        private void RefreshTotalPrice() // refreshing the total price label, based on the current total price in My_Cart.TotalPrice
        {
            TotalPricePanel.Controls.Clear();
            var fontName = FontFamily.Families[232];
            double price = My_Cart.TotalPrice;
            price = Math.Round(price, 3);
            Label totalPrice = new Label();
            totalPrice.TextAlign = ContentAlignment.MiddleCenter;
            totalPrice.Location = new Point(4, -2);
            totalPrice.Size = new Size(153, 59);
            totalPrice.AutoSize = false;
            totalPrice.Font = new Font(fontName, 12);
            if (My_Cart.MyCart.Count == 0)
            {
                totalPrice.Text = "Total Price: \t0";
            }
            else
            {
                totalPrice.Text = "Total Price: \t" + price;
            }

            TotalPricePanel.Controls.Add(totalPrice);
        }

        private void RefreshSmallChart() // Refreshing the small recipt in every event
        {
            Panel_Cart_Small.Controls.Clear();
            var fontName = FontFamily.Families[232];
            Label product_Heading = new Label();
            Label product_Pricing = new Label();
            // adding labels
            product_Heading.Font = new Font(fontName, 11);
            product_Heading.Location = new Point(3, 3);
            product_Heading.Size = new Size(119, 20);
            product_Heading.Text = "Product Name: ";
            product_Pricing.Font = new Font(fontName, 11);
            product_Pricing.Location = new Point(128, 3);
            product_Pricing.Size = new Size(51, 20);
            product_Pricing.Text = "Price:";

            Panel_Cart_Small.Controls.Add(product_Heading);
            Panel_Cart_Small.Controls.Add(product_Pricing);

            var zeroElement = My_Cart.MyCart.Find(a => a.AmountOfItems == 0);
            if (zeroElement != null) // if some items have AmountOfItems == 0, remove them from the list automaticlly
            {
                My_Cart.MyCart.Remove(zeroElement);
            }
            double currentPrice = 0;
            for (int i = 0; i < My_Cart.MyCart.Count; i++)
            {

                Button plusItem = new Button();
                Button minusItem = new Button();
                Button deleteItem = new Button();
                plusItem.Click += PlusItem_Click;// EVENT
                minusItem.Click += MinusItem_Click;// EVENT
                deleteItem.Click += DeleteItem_Click;// EVENT
                plusItem.Tag = My_Cart.MyCart[i];
                minusItem.Tag = My_Cart.MyCart[i];
                deleteItem.Tag = My_Cart.MyCart[i];

                //Creating the buttons dynamiclly
                plusItem.Location = new Point(180, (i + 1) * 23);
                minusItem.Location = new Point(207, (i + 1) * 23);
                deleteItem.Location = new Point(234, (i + 1) * 23);
                plusItem.Size = new Size(21, 20);
                minusItem.Size = new Size(21, 20);
                deleteItem.Size = new Size(21, 20);
                plusItem.Text = "+";
                minusItem.Text = "--";
                deleteItem.Text = "X";
                plusItem.TextAlign = ContentAlignment.MiddleCenter;
                minusItem.TextAlign = ContentAlignment.MiddleCenter;
                deleteItem.TextAlign = ContentAlignment.MiddleCenter;
                plusItem.Font = new Font(fontName, 9);
                minusItem.Font = new Font(fontName, 9);
                deleteItem.Font = new Font(fontName, 9);

                // Creating the lables dynamiccly
                Label productname = new Label();
                productname.Text = My_Cart.MyCart[i].OurGroceries._ProductName + "   " + "X  " + My_Cart.MyCart[i].AmountOfItems;
                productname.Location = new Point(3, (i + 1) * 23);
                productname.AutoSize = true;
                productname.Font = new Font(FontFamily.GenericSansSerif, 9);
                Label product_price = new Label();
                currentPrice = Math.Round((My_Cart.MyCart[i].OurGroceries._ProductPrice * My_Cart.MyCart[i].AmountOfItems), 4); // Add 1 more digit after decimal point
                product_price.Text = currentPrice.ToString();
                product_price.Location = new Point(128, (i + 1) * 23);
                product_price.AutoSize = true;
                product_price.Font = new Font(FontFamily.GenericSansSerif, 9);
                Panel_Cart_Small.Controls.Add(productname);
                Panel_Cart_Small.Controls.Add(product_price);
                Panel_Cart_Small.Controls.Add(plusItem);
                Panel_Cart_Small.Controls.Add(minusItem);
                Panel_Cart_Small.Controls.Add(deleteItem);

            }
        }

        private void DeleteItem_Click(object? sender, EventArgs e) // delete an item from the list enteirly
        {
            var item = (sender as Button).Tag as My_Cart; // casting the event "click" as a button, then casting the button.tag as My_cart
            My_Cart.MyCart.Remove(item);
            My_Cart.TotalPrice -= item.CalculatePriceOfProduct();
            item.AmountOfItems = 0;
            RefreshSmallChart();
            RefreshTotalPrice();

        }

        private void MinusItem_Click(object? sender, EventArgs e)
        {
            var item = (sender as Button).Tag as My_Cart; // casting the event "click" as a button, then casting the button.tag as My_cart
            --item.AmountOfItems;
            My_Cart.TotalPrice -= item.OurGroceries._ProductPrice;
            RefreshSmallChart();
            RefreshTotalPrice();
        }

        private void PlusItem_Click(object? sender, EventArgs e)
        {
            var item = (sender as Button).Tag as My_Cart; // casting the event "click" as a button, then casting the button.tag as My_cart
            ++item.AmountOfItems;
            My_Cart.TotalPrice += item.OurGroceries._ProductPrice;
            RefreshSmallChart();
            RefreshTotalPrice();
        }

        private void AddItem_Click(object? sender, EventArgs e)  // adding items into the list
        {
            var button = sender as Button; // reference to the click of the button
            var object2 = button.Tag as object[];
            var my_cart = object2[0] as My_Cart;
            var myLabel = object2[1] as Label;
            if (int.Parse(myLabel.Text) == 0)
                return;
            my_cart.AmountOfItems += int.Parse(myLabel.Text); // increasing the amount of items based on the label
            var elemnt = My_Cart.MyCart.Find(a => a.OurGroceries == my_cart.OurGroceries); // if the list doesn't have any items from this type
            if (elemnt == null) // add a new item to the list
            {
                My_Cart.MyCart.Add(my_cart);
                My_Cart.TotalPrice += my_cart.CalculatePriceOfProduct();
                RefreshSmallChart();
                RefreshTotalPrice();
            }
            else // the item already exists, and need to be updated - amount of items and Total price
            {

                My_Cart.TotalPrice = 0;
                elemnt.AmountOfItems = my_cart.AmountOfItems;
                foreach (var item in My_Cart.MyCart)
                {
                    My_Cart.TotalPrice += item.CalculatePriceOfProduct();
                }

                RefreshSmallChart();
                RefreshTotalPrice();
            }
            myLabel.Text = "0";
        }

        private void Button_minus_Click(object? sender, EventArgs e)
        {
            var button = sender as Button;
            var objects = button.Tag as object[];
            var my_chart = objects[0] as My_Cart;
            var label = objects[1] as Label;
            int parsedText = int.Parse(label.Text);
            if (parsedText <= 0)
            {
                label.Text = "0";
            }
            else
            {
                label.Text = (--parsedText).ToString();
            }



        }

        private void Button_plus_Click(object? sender, EventArgs e)
        {
            var button = sender as Button;
            var objects = button.Tag as object[];
            var my_chart = objects[0] as My_Cart;
            var label = objects[1] as Label;
            label.Text = (int.Parse(label.Text) + 1) + "";

        }


        private void button1_Click_1(object sender, EventArgs e) // all items category
        {
            ShopContainer.Controls.Clear(); // resetting the items in the main panel
            Current_category = 0;
            if (Current_category == 0) // checking if nothing else was selected from the other categories
            {
                foreach (var item in Groceries.OurCart) // adding all the items from the groceries array to the main panel
                {
                    ShopContainer.Controls.Add(CreateItemOfShop(item));
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void ShopContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RefreshInterface() // Sorting the categories by category type
        {
            ShopContainer.Controls.Clear();
            foreach (var item in Groceries.OurCart)
            {
                if (item._CategoryType == Current_category)
                {
                    ShopContainer.Controls.Add(CreateItemOfShop(item));
                }
            }
        }
        private void Btn_Meat_Products_Click(object sender, EventArgs e)
        {
            Current_category = (int)CategoryType.Meat_Product;
            RefreshInterface();
        }

        private void Btn_Dairy_Products_Click(object sender, EventArgs e)
        {
            Current_category = (int)CategoryType.Dairy_Product;
            RefreshInterface();
        }

        private void Btn_Soft_Drinks_Click(object sender, EventArgs e)
        {
            Current_category = (int)CategoryType.Soft_Drinks;
            RefreshInterface();
        }

        private void Btn_Hygenic_Products_Click(object sender, EventArgs e) // Btn_Shower_Products
        {

            Current_category = (int)CategoryType.Shower_Products;
            RefreshInterface();
        }

        private void Btn_Vegetables_Click(object sender, EventArgs e)
        {
            Current_category = (int)CategoryType.Vegetables;
            RefreshInterface();
        }

        private void Btn_Coffee_Products_Click(object sender, EventArgs e)
        {
            Current_category = (int)CategoryType.Coffee;
            RefreshInterface();
        }

        private void Btn_Dental_Products_Click(object sender, EventArgs e)
        {
            Current_category = (int)CategoryType.Dental_Products;
            RefreshInterface();
        }


        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TotalPricePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private object GetFormList()
        {
            return FormList;
        }



        private void Btn_Load_Click(object sender, EventArgs e)
        {


        }

        private void Btn_Save_Click_1(object sender, EventArgs e)
        {
            FormList = My_Cart.MyCart;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            saveFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    //!!!!
                    formatter.Serialize(stream, FormList);
                }
            }
        }

        private void Btn_ClearOrder_Click(object sender, EventArgs e)
        {
            if (My_Cart.MyCart.Count == 0)
                return;
            foreach (var item in My_Cart.MyCart)
            {
                item.AmountOfItems = 0;
            }
            My_Cart.MyCart.Clear();
            My_Cart.TotalPrice = 0;
            RefreshSmallChart();
            RefreshTotalPrice();
        }

        private void Btn_Load_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\mymodels";
            openfiledialog1.Filter = "model files (*.mdl)|*.mdl|all files (*.*)|*.*";
            openfiledialog1.FilterIndex = 1;
            openfiledialog1.RestoreDirectory = true;
            if (openfiledialog1.ShowDialog() == DialogResult.OK)
            {
                Stream stream = File.Open(openfiledialog1.FileName, FileMode.Open);
                var binaryformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //!!!!
                foreach (var item in My_Cart.MyCart)
                {
                    item.AmountOfItems = 0;
                }
                FormList.Clear();
                My_Cart.TotalPrice = 0;
                FormList = (List<My_Cart>)binaryformatter.Deserialize(stream);
                My_Cart.MyCart = FormList;
            }
            foreach (var item in FormList)
            {
                My_Cart.TotalPrice += item.CalculatePriceOfProduct();
            }
            RefreshSmallChart();
            RefreshTotalPrice();
        }
    }
}