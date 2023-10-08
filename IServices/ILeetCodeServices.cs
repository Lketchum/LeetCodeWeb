﻿using LeetCodeWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LeetCodeWeb.Services.CustomStructure;

namespace LeetCodeWeb.IServices
{
    public interface ILeetCodeServices
    {
        int EasyAdd(int num1, int num2);
        string DecodeString(string s);
        string PredictPartyVictory(string senate);
        List<int> DeleteMiddle(List<int> numsBefore);
        List<int> OddEvenList(List<int> numsBefore);
        List<int> ReverseList(List<int> numsBefore);
        int PairSum(List<int> numsBefore);
        int MaxDepth(TreeNode root);
        bool LeafSimilar(TreeNode root1, TreeNode root2);
        int GoodNodes(TreeNode root);
        int PathSum(TreeNode root, int targetSum);
        int LongestZigZag(TreeNode root);
        TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q);
        IList<int> RightSideView(TreeNode root);
        int MaxLevelSum(TreeNode root);
        TreeNode SearchBST(TreeNode root, int val);
        TreeNode DeleteNode(TreeNode root, int key);
        bool CanVisitAllRooms(IList<IList<int>> rooms);
        int FindCircleNum(int[][] isConnected);
        int MinReorder(int n, int[][] connections);
        double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries);
        int NearestExit(char[][] maze, int[] entrance);
        int OrangeRotting(int[][] grid);
        int FindKthLargest(int[] nums, int k);
        long MaxScore(int[] nums1, int[] nums2, int k);
        long TotalCost(int[] costs, int k, int candidates);
        int GuessNumber(int n, int realNum);
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success);
        public int FindPeakElement(int[] nums);
        public int MinEatingSpeed(int[] piles, int h);
        public IList<string> LetterCombinations(string digits);
        public IList<IList<int>> CombinationSum3(int k, int n);
        public int Tribonacci(int n);
        public int MinCostClimbingStairs(int[] cost);
        public int Rob(int[] nums);
        public int NumTilings(int n);
        public int UniquePaths(int m, int n);
        public int LongestCommonSubsequence(string text1, string text2);
        public int MaxProfit(int[] prices, int fee);
        public int MinDistance(string word1, string word2);
        public int[] CountBits(int n);
        public int SingleNumber(int[] nums);
        public int MinFlips(int a, int b, int c);
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord);
        public int EraseOverlapIntervals(int[][] intervals); 
        public int FindMinArrowShots(int[][] points);
        public int[] DailyTemperatures(int[] temperatures);
        public int FindContentChildren(int[] g, int[] s);
        public char[] ReverseString(char[] s);
        public int MajorityElement(int[] nums);
        public int LengthOfLongestSubstring(string s);
        public int[] Merge(int[] nums1, int m, int[] nums2, int n);
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root);
        public int Search(int[] nums, int target);
        public IList<IList<int>> ThreeSum(int[] nums);
        public bool RepeatedSubstringPattern(string s);
        public List<int> ReverseKGroup(List<int> numsBefore, int k);
        public int NumIslands(char[][] grid);
        public int[] NextPermutation(int[] nums);
        public int PeakIndexInMountainArray(int[] arr);
        public List<int> ReverseBetween(List<int> nums, int left, int right);
        public IList<int> FindMinHeightTrees(int n, int[][] edges);
        public int MaxProfit(int[] prices);
        public char FindTheDifference(string s, string t);
        public int StrStr(string haystack, string needle);
        public bool IsAnagram(string s, string t);
        public int[] PlusOne(int[] digits);
        public int ArraySign(int[] nums);
        public bool CanMakeArithmeticProgression(int[] arr);
        public bool IsMonotonic(int[] nums);
        public int LengthOfLastWord(string s);
        public string ToLowerCase(string s);
        public int CalPoints(string[] operations);
        public bool JudgeCircle(string moves);
        public string Tictactoe(int[][] moves);
        public bool IsRobotBounded(string instructions);
        public int MaximumWealth(int[][] accounts);
        public int DiagonalSum(int[][] mat);
        public IList<int> SpiralOrder(int[][] matrix);
        public int[][] SetZeroes(int[][] matrix);
        public int CountOdds(int low, int high);
        public double Average(int[] salary);
        public bool LemonadeChange(int[] bills);
        public int LargestPerimeter(int[] nums);
        public bool CheckStraightLine(int[][] coordinates);
        public string AddBinary(string a, string b);
        public string Multiply(string num1, string num2);
        public double MyPow(double x, int n);
        public List<int> MergeTwoLists(List<int> numsBefore1, List<int> numsBefore2);
        public List<int> AddTwoNumbers(List<int> numsBefore1, List<int> numsBefore2);
        public List<int> AddTwoNumbers2(List<int> numsBefore1, List<int> numsBefore2);
        public IList<int> InorderTraversal(TreeNode root);
        public bool BuddyStrings(string s, string goal);
        public bool ValidWordSquare(IList<string> words)
    }
}
