
2019-03-06<br>

Case study 1: <br>

How to build recurrence formula? <br>

F(n-1) = F(n) - K + 1    <-  we merge K piles to one pile. For exmple, F(n) is the array with length n, then F(n-1) array's length should be n - (K - 1). <br>
F(n-2) = F(n) - K + 1
...
F(1)   = F(2) - K + 1
------------------------------------------------
Add above all formula's left item together, right item together. 
F(1) = F(n) - m * (K - 1), in other words, 1 = n - m * (K - 1). We can conclude that array's length n, (n - 1)/ (K - 1) = m, which means (n - 1)% (K - 1) == 0


Case study 2: <br>
greedy algorithm does not work. <br>
I wrote the code and failed to pass one test case. <br>

One of counter example is [6, 4, 4, 6], greedy algorithm minimum cost > optimal one. <br>


Case study 3: <br>
Work on the algorithm. 





