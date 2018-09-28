It is an easy level hashtable algorithm. I have a lot of fun to practice this algorithm. 

I also like to look into [grand yang blog](https://www.cnblogs.com/grandyang/p/4606334.html)<br>

[Here](http://www.cnblogs.com/grandyang/p/7817011.html) is the discussion of the algorithm. 

这道题给了我们一个字典，是个字符串数组，然后问我们从单个字符开始拼，最长能组成啥单词，注意中间生成的字符串也要在字典中存在，而且当组成的单词长度相等时，返回字母顺序小的那个。好，看到这么多前缀一样多字符串，是不是很容易想到用前缀树来做，其实我们并不需要真正的建立前缀树结点，可以借鉴查找的思想来做。那么为了快速的查找某个单词是否在字典中存在，我们将所有单词放到哈希集合中，在查找的时候，可以采用BFS或者DFS都行。先来看BFS的做法，使用一个queue来辅助，我们先把所有长度为1的单词找出排入queue中，当作种子选手，然后我们进行循环，每次从队首取一个元素出来，如果其长度大于我们维护的最大值mxLen，则更新mxLen和结果res，如果正好相等，也要更新结果res，取字母顺序小的那个。然后我们试着增加长度，做法就是遍历26个字母，将每个字母都加到单词后面，然后看是否在字典中存在，存在的话，就加入queue中等待下一次遍历，完了以后记得要恢复状态

I wrote the solution using queue. [Here](https://github.com/jianminchen/Leetcode_Julia/blob/master/By%20Algorithms/Leetcode%20720%20Find%20longest%20word%20in%20dictionary/720%20longest%20word%20in%20dictionary%20-%20using%20queue.cs) is the solution. <br>
