using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Resources;
using System.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        static int WindowsCount;
        private bool isblack;
        private string stringnumberofchars;
        public List<int> FontSizes { get; set; }
        ComboBox siz;
        public List<string> Colors { get; private set; }
        public GeneralCommand OpenCommand { get; set; }
        public GeneralCommand SaveCommand { get; set; }
        public GeneralCommand CutCommand { get; set; }
        public GeneralCommand CopyCommand { get; set; }
        public GeneralCommand PasteCommand { get; set; }
        public GeneralCommand NewCommand { get; set; }
        public GeneralCommand CloseCommand { get; set; }
        public GeneralCommand ChangeLangCommand { get; set; }
        public GeneralCommand ChangeStyleCommand { get; set; }
        public GeneralCommand UndoCommand { get; set; }
        public GeneralCommand RedoCommand { get; set; }
        public string StringNumberOfChars
        {
            get
            {
                return stringnumberofchars;
            }
            set
            {
                TextBox tb = (TextBox)this.FindName("StatusChars");
                stringnumberofchars = value;
                tb.Text = value;
            }
        }
        public string RichBoxText { get; set; }
        static MainWindow()
        {
            WindowsCount = 0;
        }
        public MainWindow()
        {

            isblack = false;
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            
            siz = (ComboBox)this.FindName("Sizes");

            FontSizes = new List<int>();
            Colors = new List<string>() { "Red", "Green", "Blue" };
            for (int i = 1; i < 50; i++)
                FontSizes.Add(i);
            


            OpenCommand = new GeneralCommand(Open, null);
            CutCommand = new GeneralCommand(Cut, null);
            CopyCommand = new GeneralCommand(Copy, null);
            PasteCommand = new GeneralCommand(Paste, null);
            SaveCommand = new GeneralCommand(Save, null);
            NewCommand = new GeneralCommand(New, null);
            CloseCommand = new GeneralCommand(CloseW, null);
            ChangeLangCommand = new GeneralCommand(ChangeLang, null);
            ChangeStyleCommand = new GeneralCommand(ChangeStyle, null);
            UndoCommand = new GeneralCommand(U, null);
            RedoCommand = new GeneralCommand(R, null);
            
            DataContext = this;
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ru-RU");
            InitializeComponent();

            string[] linesformenu = System.IO.File.ReadAllLines(@"lastopened.txt");

            foreach(var s in linesformenu)
            {
                MenuItem mi = new MenuItem();
                mi.Header = s;
                mi.Click += mi_Click;
                MainMenu.Items.Add(mi);
            }
            
            this.Title = "NewWindow" + ++WindowsCount;
           
            StreamResourceInfo sriCurs = Application.GetResourceStream(new Uri("cur.cur", UriKind.Relative));
            this.Cursor = new Cursor(sriCurs.Stream);
            
        }
        //-----------------------------------------------------------------
        void mi_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
           string buf = System.IO.File.ReadAllText(((MenuItem)sender).Header.ToString());

           rch.Document.Blocks.Clear();
           rch.Document.Blocks.Add(new Paragraph(new Run(buf)));

           this.Title = ((MenuItem)sender).Header.ToString();

        }

        //---------------------------------------------------------

        public void U()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.Undo();
        }
        public void R()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.Redo();
        }
        public void ChangeStyle()
        {
            if (!isblack)
            {
                var uri = new Uri("Resources/BlackTheme.xaml", UriKind.Relative);
                ResourceDictionary rd = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(rd);
                isblack = true;
            }
            else
            {
                var uri = new Uri("Resources/WhiteTheme.xaml", UriKind.Relative);
                ResourceDictionary rd = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(rd);
                isblack = false;
            }
        }
        public void ChangeLang()
        {
            MessageBox.Show(System.Globalization.CultureInfo.CurrentCulture.ToString());
           

        }
        public void CloseW()
        {
            Close();
        }
        public void New()
        {
            var newWindow = new MainWindow();
            newWindow.Show();
        }
        public void Save()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            try
            {
                SaveFileDialog ofd = new SaveFileDialog();
                ofd.FileName = "*.txt";
                ofd.Filter = "TXT File|*.txt";
                ofd.Title = "Opening";
                ofd.ShowDialog();
                System.IO.File.WriteAllText(ofd.FileName, new TextRange(rch.Document.ContentStart, rch.Document.ContentEnd).Text);


            }
            catch { }
        }
        public void Paste()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.Paste();

            //rch.AppendText(Clipboard.GetText());
        }
        public void Copy()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.Copy();
            //Clipboard.SetText(rch.Selection.Text);
        }
        public void Cut()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.Cut();
            //    Clipboard.SetText(rch.Selection.Text);
            //    rch.Selection.Text = "";
        }
        public void Open()
        {
            string buf;
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = "*.txt";
                ofd.Filter = "TXT File|*.txt";
                ofd.Title = "Opening";
                ofd.ShowDialog();
                buf = System.IO.File.ReadAllText(ofd.FileName);

                System.IO.File.AppendAllText("lastopened.txt", ofd.FileName);


                rch.Document.Blocks.Clear();
                rch.Document.Blocks.Add(new Paragraph(new Run(buf)));

                this.Title = ofd.FileName;

            }
            catch { }

            



        }

        private void Sizes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            TextSelection selectedText = rch.Selection;
            var k = (int)(sender as ComboBox).SelectedValue;

            if (selectedText.Text != "")
            {
                selectedText.ApplyPropertyValue(RichTextBox.FontSizeProperty, (double)k);
                return;
            }

            rch.FontSize = (double)k;
            rch.Focus();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            TextSelection selectedText = rch.Selection;
            var k = (sender as ComboBox).SelectedItem.ToString();

            if (selectedText.Text != "")
            {
                switch (k)
                {
                    case "Red": { selectedText.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Red); return; }
                    case "Green": { selectedText.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Green); return; }
                    case "Blue": { selectedText.ApplyPropertyValue(RichTextBox.ForegroundProperty, Brushes.Blue); return; }
                }
            }
            rch.Focus();
        }

        private void Bold_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.FontWeight = FontWeights.Bold;
        }

        private void Bold_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.FontWeight = FontWeights.Normal;
        }

        private void Underline_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
        }
        private void Underline_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");

        }
        private void Italic_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.FontStyle = FontStyles.Italic;
        }
        private void Italic_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.FontStyle = FontStyles.Normal;
        }

        private void mainbox_KeyDown(object sender, KeyEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            string richText = new TextRange(rch.Document.ContentStart, rch.Document.ContentEnd).Text;
            StringNumberOfChars = "Number of words: " + richText.Length;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string str)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(str));
        }

        private void mainbox_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            e.Handled = true;
        }

      

       
       
       
    }

    }

