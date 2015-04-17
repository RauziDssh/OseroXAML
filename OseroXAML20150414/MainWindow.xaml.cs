using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private Cursor cursor;
        public MainWindow()
        {
            InitializeComponent();
            List<stone> Field = new List<stone> { 
                new stone{color = Brushes.White,Pos_column = 3,Pos_row = 3},
                new stone{color = Brushes.White,Pos_column = 4,Pos_row = 4},
                new stone{color = Brushes.Black,Pos_column = 3,Pos_row = 4},
                new stone{color = Brushes.Black,Pos_column = 4,Pos_row = 3},
            };
            cursor = new Cursor() { turn = Brushes.Black,Cursor_column = 1,Cursor_row = 1}; 
            this.IC01.DataContext = new
            {
                Field = Field,
            };
            this.grid_cursor.DataContext = cursor;

            Keyboard.Focus(Grid01);
            
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

        private void Grid01_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key) { 
                case Key.Left:
                    cursor.Cursor_column = cursor.Cursor_column - 1;
                    break;
                case Key.Right:
                    cursor.Cursor_column = cursor.Cursor_column + 1;
                    break;
                case Key.Down:
                    cursor.Cursor_row = cursor.Cursor_row + 1;
                    break;
                case Key.Up:
                    cursor.Cursor_row = cursor.Cursor_row - 1 ;
                    break;
                case Key.Enter:

                    break;
            }
        }

    }

    public class Cursor : INotifyPropertyChanged
    {
        public Brush turn { get; set; }

        private int Cursor_column_val;
        public int Cursor_column
        {
            get 
            {
                return Cursor_column_val;
            }
            set
            {
                Cursor_column_val = value;
                NotifyPropertyChanged("Cursor_column");
            }
        }

        private int Cursor_row_val;
        public int Cursor_row
        {
            get
            {
                return Cursor_row_val;
            }
            set
            {
                Cursor_row_val = value;
                NotifyPropertyChanged("Cursor_row");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }

    public class stone
    {
        public Brush color { get; set; }
        public int Pos_column { get; set; }
        public int Pos_row { get; set; }
    } 
}
