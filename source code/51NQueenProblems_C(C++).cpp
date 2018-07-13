// 51NQueenProblems_C(C++).cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>
#include <vector>
using namespace std;

/*
Leetcode 51: N-Queens problem 

source code reference:

http://yucoding.blogspot.ca/2013/01/leetcode-question-59-n-queens.html

Analysis from the above blog: 


The classic recursive problem.
1. Use a int vector to store the current state,  A[i]=j refers that 
the ith row and jth column is placed a queen.
2. Valid state:  not in the same column, which is A[i]!=A[current], 
not in the same diagonal direction: abs(A[i]-A[current]) != r-i

3. Recursion: 
       Start:   placeQueen(0,n)
        if current ==n then print result
        else
            for each place less than n,
                 place queen
                if current state is valid, then place next queen   place Queen(cur+1,n)
           end for
        end if

Julia's comment on January 13, 2016:
1. Start to practice leetcode solution using C++, prepare to write C++ code in the development
2. 
*/
class Solution {
public:
 
    vector<vector<string> > res;
    
	/*
	Julia's comment: 
	1. read vector class web page: 
	   http://www.cplusplus.com/reference/vector/vector/
	2. read string class web page:

	*/
    void printResult(vector<int> A, int n){
        vector<string> r;
        for(int i=0;i<n;i++){
            string str(n,'.');
            str[A[i]]='Q';
            r.push_back(str);
        }
        res.push_back(r);
    }
     
    /*
	Julia's comment: 
	1: abs function 
	  read the website about abs function
	  http://www.cplusplus.com/reference/cstdlib/abs/
	  C and C++ two versions
	2. 
	*/
    bool isValid(vector<int> A, int r){
        for (int i=0; i<r; i++){
            if ( (A[i]==A[r])||
				(abs(A[i]-A[r])==(r-i)))			
                return false;            
        }

        return true;
    }
    
	/*
	Julia's comment: 
	1. How to design the recursive function?
	  3 arguments:
	  1. one is one dimension array - vector to store queen status 
	  2. second one is the current row in the recursive function 
	  3. count of total rows. 

	*/
    void nQueens(vector<int> A, int cur, int n){
        if (cur == n)
			printResult(A,n);
        else
		{
            for (int i=0; i<n; i++){
                A[cur]=i;

                if (isValid(A,cur))
                    nQueens(A,cur+1,n);                
            }
        }
    }
    
	/*
	Julia's comment: 

	*/
    vector<vector<string> > solveNQueens(int n) {
        
        res.clear();

        vector<int> A(n,-1);
        nQueens(A,0,n);

        return res;
    }
};

int _tmain(int argc, _TCHAR* argv[])
{
	return 0;
}

