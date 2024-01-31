// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/


// GEt the overall max
// Iterate and add the extra candy in each iteration and check if it's more than max. If yes, add true
public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        int maxCandies = 0;
        foreach (int candy in candies) {
            maxCandies = Math.Max(candy, maxCandies);
        }
        // For each kid, check if they will have greatest number of candies
        // among all the kids.
        IList<bool> result = new List<bool>();
        foreach (int candy in candies) {
            result.Add(candy + extraCandies >= maxCandies);
        }

        return result;

    }
}
