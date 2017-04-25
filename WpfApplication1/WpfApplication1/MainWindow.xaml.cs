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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<int> FontSizes  { get; set; }
        ComboBox siz;
        public List<string> Colors { get; private set; }
        public GeneralCommand OpenCommand { get; set; }
        public GeneralCommand SaveCommand { get; set; }
        public GeneralCommand CutCommand { get; set; }
        public GeneralCommand CopyCommand { get; set; }
        public GeneralCommand PasteCommand { get; set; }
        public string RichBoxText { get; set; }
        
        public MainWindow()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            
            siz = (ComboBox)this.FindName("Sizes");

            FontSizes = new List<int>();
            Colors = new List<string>() { "Red", "Green", "Blue" };
            for (int i = 0; i < 50; i++)
                FontSizes.Add(i);

            OpenCommand = new GeneralCommand(Open, null);
            CutCommand = new GeneralCommand(Cut, null);
            CopyCommand = new GeneralCommand(Copy, null);
            PasteCommand = new GeneralCommand(Paste, null);
            SaveCommand = new GeneralCommand(Save, null);
            DataContext = this;
            InitializeComponent();

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
                System.IO.File.WriteAllText(ofd.FileName, new TextRange(rch.Document.ContentStart,rch.Document.ContentEnd).Text);

                
            }
            catch { }
        }
        public void Paste()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            rch.AppendText(Clipboard.GetText());
        }
        public void Copy()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            Clipboard.SetText(rch.Selection.Text);
        }
        public void Cut()
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            Clipboard.SetText(rch.Selection.Text);
            rch.Selection.Text = "";
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
                
            
                rch.Document.Blocks.Clear();
                rch.Document.Blocks.Add(new Paragraph(new Run(buf)));
                        
            }
            catch { }

           
           

            
        }

        private void Sizes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RichTextBox rch = (RichTextBox)this.FindName("mainbox");
            TextSelection selectedText = rch.Selection;
            var k = (int)(sender as ComboBox).SelectedValue;

            if (selectedText.Text!="")
            {
                selectedText.ApplyPropertyValue(RichTextBox.FontSizeProperty, (double)k);
                return;
            }
            
            rch.FontSize = (double)k;
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
        }
    }  
    }

