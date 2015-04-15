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

namespace OseroXAML20150414
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            List<stone> Field = new List<stone> { 
                new stone{color = Brushes.White,Pos_column = 3,Pos_row = 3},
                new stone{color = Brushes.White,Pos_column = 4,Pos_row = 4},
                new stone{color = Brushes.Black,Pos_column = 3,Pos_row = 4},
                new stone{color = Brushes.Black,Pos_column = 4,Pos_row = 3},
            };
            Cursor cursor = new Cursor() { turn = Brushes.Black,Cursor_column = 2,Cursor_row = 2}; 
            this.DataContext = new
            {
                Field = Field,
                Turn = Brushes.Black,
                Cursor_column = cursor.Cursor_column,
                Cursor_row = cursor.Cursor_row,
            };
            
            
        }

        private void Grid_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //getCellIndexfromPosition(e.GetPosition());
        }

        private int[] getCellIndexfromPosition(Point p)
        {
            int[] cell = new int[2];
            return cell;
        }

    }

    public class Cursor
    {
        public Brush turn { get; set; }
        public int Cursor_column { get; set; }
        public int Cursor_row { get; set; }
    }

    public class stone
    {
        public Brush color { get; set; }
        public int Pos_column { get; set; }
        public int Pos_row { get; set; }
    } 
}
