// https://leetcode.com/problems/word-search/

public class Solution {
       
    public bool Exist(char[][] board, string word) {
        int m = board.Length;
        int n = board[0].Length;

        for(int i =0;i<m;i++)
        {
            for(int j =0;j<n;j++)
            {
                if(board[i][j]==word[0] && dfs(board,word,i,j,0,m,n))
                {
                    return true;
                }
            }
        }        
        return false;
    }

    bool dfs(char[][] board, string word, int x, int y, int idx, int m, int n)
    {
        if(idx>=word.Length)
            return true;

        if(x<0 || x>=m || y<0 || y>=n  || board[x][y]!= word[idx])
            return false;

        char temp = board[x][y];
        board[x][y] = '#';

        var result = dfs(board, word, x,y+1,idx+1,m,n) ||
                        dfs(board, word, x+1,y,idx+1,m,n) ||
                        dfs(board, word, x,y-1,idx+1,m,n) ||
                        dfs(board, word, x-1,y,idx+1,m,n);

        board[x][y] = temp;
        return result;
    }
}
