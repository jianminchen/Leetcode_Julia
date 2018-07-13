public class Solution
{
    public IList<string> FindWords(char[,] board, String[] words)
    {
        var result = new List<string>();
        var root = TrieNode.BuildTrie(words);

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                searchWordsStoredInTrie(board, root, result, row, col);
            }
        }

        return result;
    }

    /// <summary>    
    /// Add additional note for the design:
    /// function argument TrieNode trie, since trie must be updated if the word is found. 
    /// The word will be removed from Trie in order to avoid adding more than once. 
    /// The depth first search techniques used:
    /// 1. mark the visit node as '#' in order to avoid looping;
    /// 2. back tracking is used;         
    /// </summary>
    /// <param name="board"></param>
    /// <param name="row"></param>
    /// <param name="column"></param>
    /// <param name="trie"></param>
    /// <param name="words"></param>
    private static void searchWordsStoredInTrie(char[,] board, TrieNode trie, List<String> words, int row, int column)
    {
        if (row < 0 || row > (board.GetLength(0) - 1) ||
            column < 0 || column > (board.GetLength(1) - 1))
        {
            return;
        }

        var visit = board[row, column];

        if (visit == '#' || trie.Next[visit - 'a'] == null)
        {
            return;
        }

        trie = trie.Next[visit - 'a'];

        if (trie.Word != null)  // the word is found, need to add to result 
        {
            words.Add(trie.Word);

            // avoid the same word to be added more than once 
            // it is not a good design, update trie without telling
            trie.Word = null;     // deduplicate
        }

        // mark the node value with '#', so it will not match any char
        // avoid dead loop, mark visited in depth first search
        // remember this technique
        board[row, column] = '#';

        searchWordsStoredInTrie(board, trie, words, row - 1, column);
        searchWordsStoredInTrie(board, trie, words, row, column - 1);
        searchWordsStoredInTrie(board, trie, words, row + 1, column);
        searchWordsStoredInTrie(board, trie, words, row, column + 1);

        board[row, column] = visit;  // backtracking with DFS search
    }

    internal class TrieNode
    {
        public TrieNode[] Next = new TrieNode[26];
        public String Word { get; set; }

        /// <summary>        
        /// Trie is designed with 26 children, if it is the leaf node then
        /// the word is added. 
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public static TrieNode BuildTrie(String[] words)
        {
            var root = new TrieNode();

            foreach (var word in words)
            {
                var trie = root;
                foreach (var c in word.ToCharArray())
                {
                    int current = c - 'a';

                    if (trie.Next[current] == null)
                    {
                        trie.Next[current] = new TrieNode();
                    }

                    trie = trie.Next[current];
                }

                // find node of trie to add current word
                trie.Word = word;
            }

            return root;
        }

        /// <summary>
        /// code review July 25, 2017
        /// Understand why trie is much better on time complexity 
        /// every word sharing same prefix will be visited once
        /// a
        /// |
        /// a
        /// |
        /// a          "aaa"
        /// | \  \
        /// a  b  c    "aaaa", "aaab", "aaac"
        /// </summary>
        public static void RunTestcaseBuildTrie()
        {
            string[] words = new string[] { "aaa", "aaaa", "aaab", "aaac" };

            var trie = TrieNode.BuildTrie(words);
        }
    }
}