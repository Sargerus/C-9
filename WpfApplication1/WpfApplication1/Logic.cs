using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    public class Logic
    {
      
        public List<int> FontSizes { get; private set; }
        public List<string> Colors { get; private set; }
        public GeneralCommand OpenCommand { get; set; }
        public GeneralCommand CutCommand { get; set; }
        public string RichBoxText { get; set; }
        
        public Logic ()
	{
            RichBoxText = "asd";
            FontSizes = new List<int>();
            Colors = new List<string>() { "Red", "Green", "Blue" };
            for (int i = 0; i < 50; i++)
                FontSizes.Add(i);

            OpenCommand = new GeneralCommand(Open, null);
            CutCommand = new GeneralCommand(Cut, null);
	}

        public void Cut()
        {

        }
        public void Open()
        {
            string buf;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = "*.txt";
                ofd.Filter = "TXT File|*.txt";
                ofd.Title = "Opening";
                ofd.ShowDialog();
                buf = System.IO.File.ReadAllText(ofd.FileName);
                RichBoxText = String.Empty;
                        
            }
            catch { }

           
           

            
        }
    }  
      
    
}
