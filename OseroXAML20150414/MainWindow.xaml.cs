using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private GameModel GM;
        public MainWindow()
        {
            InitializeComponent();

            Field = new ObservableCollection<Stone>();
            GridCursor = new Cursor() { Turn = StoneColor.Black,Column = 1,Row = 1};
            GM = new GameModel(this);
            this.DataContext = this;
            Keyboard.Focus(Grid01);

            
        }



        public static readonly DependencyProperty FieldProperty = DependencyProperty.Register("Field", typeof(ObservableCollection<Stone>), typeof(MainWindow));

        public ObservableCollection<Stone> Field
        {
            get { return (ObservableCollection<Stone>)GetValue(FieldProperty); }
            set { SetValue(FieldProperty, value); }
        }

        public static readonly DependencyProperty GridCursorProperty = DependencyProperty.Register("GridCursor", typeof(Cursor), typeof(MainWindow));

        public Cursor GridCursor
        {
            get { return (Cursor)GetValue(GridCursorProperty); }
            set { SetValue(GridCursorProperty, value); }
        }

        private void Grid01_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key) { 
                case Key.Left:
                    GridCursor.Column = GridCursor.Column - 1;
                    break;
                case Key.Right:
                    GridCursor.Column = GridCursor.Column + 1;
                    break;
                case Key.Down:
                    GridCursor.Row = GridCursor.Row + 1;
                    break;
                case Key.Up:
                    GridCursor.Row = GridCursor.Row - 1;
                    break;
                case Key.Enter:
                    GM.setStone((int)StoneColor.Black,GridCursor.Column,GridCursor.Row);
                    break;
            }
        }

    }

    public class Cursor : INotifyPropertyChanged
    {
        private StoneColor turn;
        public StoneColor Turn
        {
            get
            {
                return turn;
            }
            set
            {
                if (turn == value)
                {
                    return;
                }
                turn = value;
                NotifyPropertyChanged("Turn");
            }
        }

        private int column;
        public int Column
        {
            get 
            {
                return column;
            }
            set
            {
                if (column == value)
                {
                    return;
                }
                column = value;
                NotifyPropertyChanged("Column");
            }
        }

        private int row;
        public int Row
        {
            get
            {
                return row;
            }
            set
            {
                if (row == value)
                {
                    return;
                }
                row = value;
                NotifyPropertyChanged("Row");
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

    public enum StoneColor
    {
        White,
        Black
    }

    public class Stone
    {
        public StoneColor Color { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
    } 
}
