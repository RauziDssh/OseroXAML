using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OseroXAML20150414
{
    
    class GameModel
    {
        private readonly int row_max = 8;
        private readonly int column_max = 8;
        private int[,] grid;

        private MainWindow MW;

        public GameModel(MainWindow MW){
            this.MW = MW;
            grid = new int[row_max, column_max];

            //石をおく
            this.setStone((int)StoneColor.White, 3, 4);
            this.setStone((int)StoneColor.Black, 3, 3);
            this.setStone((int)StoneColor.White, 4, 3);
            this.setStone((int)StoneColor.Black, 4, 4);

        }

        public void setStone(int color,int x,int y){
            grid[x, y] = color;
            MW.Field.Add(new Stone {Color = (StoneColor)color,Column = x, Row = y});
        }

        private void turnColor(){
        
        }
    }
}
