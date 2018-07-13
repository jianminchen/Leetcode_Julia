class Solution
{
    public boolean isMatch(String text, String pattern) {//s = acd t = ab*c.
    // 4 x 6
    int tLength = text.length(); 
    int pLength = pattern.length(); 
    
    boolean[][] dp = new boolean[tLength + 1][pLength + 1];
    
    dp[tLength][pLength] = true; //dp[3][5] = true    
    
    //pattern.length = 3
    for(int i = tLength; i >= 0; i--){//1 'c'
      for(int j = pLength - 1; j >= 0; j--){
          //s = "" t = "b*"
          if(i == tLength){ //s is in the end
            if(j + 1 < pLength && pattern.charAt(j + 1) == '*'){ //j = 0 pat[1]
              dp[i][j] = dp[i][j+2]; //dp[5][1] = dp[5][3] = true
            }
          }        
          else{
            //s = ac t = acb*
            if(text.charAt(i)/*c*/ == pattern.charAt(j)/*b*/ || pattern.charAt(j) == '.'){ 
              if(j + 1 < pLength && pattern.charAt(j+1) == '*'){
                dp[i][j] = dp[i][j+2] || dp[i+1][j+2] || dp[i+1][j];
              }
              else{
                dp[i][j] = dp[i+1][j+1]; //dp[2][4] = dp[3][5] = true
              }
            }
            else{
              if(j+1 < pLength && pattern.charAt(j+1) == '*')
                dp[i][j] = dp[i][j+2];
            }
          }
//          System.out.println(dp[i][j]);
      }
    }
    
    return dp[0][0];
    }
}