using LeetCodeWeb.Services;
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
    }
}
