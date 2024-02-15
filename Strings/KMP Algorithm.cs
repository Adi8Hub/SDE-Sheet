/*
https://www.geeksforgeeks.org/problems/search-pattern0205/1
*/

// Brute Force
// TC: O(m*n)
// For every m in str1, we check for chars in str2
Loop:
  for (int i = 0; i <= N - M; i++) 
  {
      int j;

      /* For current index i, check for pattern
      match */
      for (j = 0; j < M; j++)
          if (txt[i + j] != pat[j])
              break;

      // if pat[0...M-1] = txt[i, i+1, ...i+M-1]
      if (j == M)
          Console.WriteLine("Pattern found at index "
                            + i);
    }




// KMP ALgorithm
// First fill LPS array ie. Longest Prefix which is also suffix using str2
