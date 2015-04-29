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
        private int[,] grid{get; set;}

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
            if (grid[x, y] == 0)
            {
                grid[x, y] = color;
                if (MW.Field != null)
                {
                    MW.Field.Add(new Stone { Color = (StoneColor)color, Column = x, Row = y });
                }
            }
        }

        //反転可能な石を探す
        //反転する石の座標とひっくり反転後の色を返す
        private List<Stone> checkTurn(int color,int x,int y)
        {
            var list_stone = new List<Stone>();
            //上方向の検索
            for (int i = y; 0 <= i ; i--)
            {
                if (grid[x,i] != color && grid[x,i] != 0)
                {
                    list_stone.Add(new Stone {Color = (StoneColor)color,Column = x,Row = i});
                }
                else
                {
                    break;
                }
            }
            //下方向の探索
            for (int i = y; y <=row_max; i++)
            {
                if (grid[x, i] != color && grid[x, i] != 0)
                {
                    list_stone.Add(new Stone { Color = (StoneColor)color, Column = x, Row = i });
                }
                else
                {
                    break;
                }
            }
            //右方向の探索


            return list_stone;
        }

        private void turnColor(){
            
        }
    }
}
