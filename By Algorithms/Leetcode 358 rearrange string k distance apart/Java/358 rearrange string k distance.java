// study code: https://protegejj.gitbook.io/algorithm-practice/leetcode/heap/358-rearrange-string-k-distance-apart
class Solution {
    public String rearrangeString(String s, int k) {
        if (k = 1) {
            return s;
        }

        int[] count = new int[256];
        for (char c  s.toCharArray()) {
            ++count[c];
        }

        PriorityQueueCharInfo maxHeap = new PriorityQueue();

        for (int i = 0; i  256; i++) {
            if (count[i] != 0) {
                maxHeap.add(new CharInfo((char)i, count[i]));
            }
        }

        QueueCharInfo buffer = new LinkedList();
        StringBuilder res = new StringBuilder();

        while (!maxHeap.isEmpty()) {
            CharInfo curChar = maxHeap.remove();
            res.append(curChar.val);
            --curChar.freq;
            buffer.add(curChar);

            if (buffer.size() == k) {
                curChar = buffer.remove();
                if (curChar.freq  0) {
                    maxHeap.add(curChar);
                }
            }
        }
        return res.length() == s.length()  res.toString()  ;
    }

    class CharInfo implements ComparableCharInfo {
        char val;
        int freq;

        public CharInfo(char val, int freq) {
            this.val = val;
            this.freq = freq;
        }

        public int compareTo(CharInfo that) {
            return that.freq - this.freq;
        }
    }
}