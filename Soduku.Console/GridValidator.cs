using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soduku.Console
{
    public class GridValidator 
    {
        private const int BoardSize = 9;

        public bool IsValid(int[][] board)
        {
            if (board.Length != 9)
                return false;

            for (int i = 0; i < 9; i++)
            {
                if (board[i].Length != 9)
                    return false;

                for (int j = 0; j < 9; j++)
                {
                    int num = board[i][j];
                    if (num < 0 || num > 9)
                        return false;
                }
            }
            return true;
        }
    }
}
