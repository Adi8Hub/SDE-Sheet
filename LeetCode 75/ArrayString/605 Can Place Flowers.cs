// https://leetcode.com/problems/can-place-flowers/description

/*
- Check if leftplot and rightplot is empty
- if yes, then increase the count
- after completion of iteration, check if count>=n

*/


public class Solution {
    public bool CanPlaceFlowers(int[] flowerbed, int n) {
        if(n==0) return true;
        int count = 0;
        for (int i = 0; i < flowerbed.Length; i++) {        
            if (flowerbed[i] == 0) {                
                bool emptyLeftPlot = (i == 0) || (flowerbed[i - 1] == 0);
                bool emptyRightPlot = (i == flowerbed.Length - 1) || (flowerbed[i + 1] == 0);
                
                if (emptyLeftPlot && emptyRightPlot) {
                    flowerbed[i] = 1;
                    count++;
                    if (count >= n) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
