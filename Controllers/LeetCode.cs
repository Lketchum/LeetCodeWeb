using LeetCodeWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LeetCodeWeb.Services.CustomStructure;

namespace LeetCodeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LeetCode : ControllerBase
    {
        private readonly LeetCodeServices _leetCodeServices;

        public LeetCode(LeetCodeServices leetcodeServices)
        {
            _leetCodeServices = leetcodeServices;
        }

        [HttpPost("EasyAdd")]
        public int EasyAdd(int num1, int num2)
        {
            var result = _leetCodeServices.EasyAdd(num1, num2);
            return result;
        }

        [HttpPost("DecodeString")]
        public string DecodeString(string s)
        {
            string result = _leetCodeServices.DecodeString(s);
            return result;
        }

        [HttpPost("PredictPartyVictory")]
        public string PredictPartyVictory(string s)
        {
            string result = _leetCodeServices.PredictPartyVictory(s);
            return result;
        }

        [HttpPost("DeleteMiddle")]
        public List<int> DeleteMiddle(List<int> numsBefore)
        {
            var result = _leetCodeServices.DeleteMiddle(numsBefore);
            return result;
        }

        [HttpPost("OddEvenList")]
        public List<int> OddEvenList(List<int> numsBefore)
        {
            var result = _leetCodeServices.OddEvenList(numsBefore);
            return result;
        }

        [HttpPost("ReverseList")]
        public List<int> ReverseList(List<int> numsBefore)
        {
            var result = _leetCodeServices.ReverseList(numsBefore);
            return result;
        }

        [HttpPost("PairSum")]
        public int PairSum(List<int> numsBefore)
        {
            var result = _leetCodeServices.PairSum(numsBefore);
            return result;
        }

        [HttpPost("MaxDepth")]
        public int MaxDepth(int?[] arr)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(arr);
            var result = _leetCodeServices.MaxDepth(root);
            return result;
        }

        [HttpPost("LeafSimilar")]
        public bool LeafSimilar(TwoArrays twoArrays)
        {
            TreeNode root1 = _leetCodeServices.ArrayToBinaryTree(twoArrays.array1);
            TreeNode root2 = _leetCodeServices.ArrayToBinaryTree(twoArrays.array2);
            var result = _leetCodeServices.LeafSimilar(root1, root2);
            return result;
        }

        [HttpPost("GoodNodes")]
        public int GoodNodes(int?[] arr)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(arr);
            var result = _leetCodeServices.GoodNodes(root);
            return result;
        }

        [HttpPost("PathSum")]
        public int PathSum(int?[] arr, int targetSum)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(arr);
            var result = _leetCodeServices.PathSum(root, targetSum);
            return result;
        }

        [HttpPost("LongestZigZag")]
        public int LongestZigZag(int?[] arr)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(arr);
            var result = _leetCodeServices.LongestZigZag(root);
            return result;
        }

        [HttpPost("LowestCommonAncestor")]
        public TreeNode LowestCommonAncestor(ThreeArrays threeArrays)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(threeArrays.array1);
            TreeNode p = _leetCodeServices.ArrayToBinaryTree(threeArrays.array2);
            TreeNode q = _leetCodeServices.ArrayToBinaryTree(threeArrays.array3);
            var result = _leetCodeServices.LowestCommonAncestor(root, p, q);
            return result;
        }

        [HttpPost("RightSideView")]
        public IList<int> RightSideView(int?[] arr)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(arr);
            var result = _leetCodeServices.RightSideView(root);
            return result;
        }

        [HttpPost("MaxLevelSum")]
        public int MaxLevelSum(int?[] arr)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(arr);
            var result = _leetCodeServices.MaxLevelSum(root);
            return result;
        }

        [HttpPost("SearchBST")]
        public int?[] SearchBST(int?[] arr, int val)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(arr);
            var resultNode = _leetCodeServices.SearchBST(root, val);
            var result = _leetCodeServices.TreeToArray(resultNode);
            return result;
        }

        [HttpPost("DeleteNode")]
        public int?[] DeleteNode(int?[] arr, int key)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(arr);
            var resultNode = _leetCodeServices.DeleteNode(root, key);
            var result = _leetCodeServices.TreeToArray(resultNode);
            return result;
        }

        [HttpPost("CanVisitAllRooms")]
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var result = _leetCodeServices.CanVisitAllRooms(rooms);
            return result;
        }

        [HttpPost("FindCircleNum")]
        public int FindCircleNum(int[][] isConnetcted)
        {
            var result = _leetCodeServices.FindCircleNum(isConnetcted);
            return result;
        }

        [HttpPost("MinReorder")]
        public int MinReorder(int n, int[][] connections)
        {
            var result = _leetCodeServices.MinReorder(n, connections);
            return result;
        }

        [HttpPost("CalcEquation")]
        public double[] CalcEquation(Arrays_CalcEquation inputArrays)
        {
            var equations = inputArrays.array1;
            var values = inputArrays.array2;
            var queries = inputArrays.array3;
            var result = _leetCodeServices.CalcEquation(equations, values, queries);
            return result;
        }

        [HttpPost("NearestExit")]
        public int NearestExit(Input_NearestExit inputArrays)
        {
            var maze = inputArrays.char1;
            var entrance = inputArrays.int2;
            var result = _leetCodeServices.NearestExit(maze, entrance);
            return result;
        }

        [HttpPost("OrangeRotting")]
        public int OrangeRotting(int[][] grid)
        {
            var result = _leetCodeServices.OrangeRotting(grid);
            return result;
        }

        [HttpPost("FindKthLargest")]
        public int FindKthLargest(int[] nums, int k)
        {
            var result = _leetCodeServices.FindKthLargest(nums, k);
            return result;
        }

        [HttpPost("MaxScore")]
        public long MaxScore(Input_MaxScore input_MaxScore)
        {
            var nums1 = input_MaxScore.nums1;
            var nums2 = input_MaxScore.nums2;
            var k = input_MaxScore.num;
            var result = _leetCodeServices.MaxScore(nums1, nums2, k);
            return result;
        }

        [HttpPost("TotalCost")]
        public long TotalCost(int[] costs, int k, int candidates)
        {
            var result = _leetCodeServices.TotalCost(costs, k, candidates);
            return result;
        }

        [HttpPost("GuessNumber")]
        public int GuessNumber(int n, int realNum)
        {
            var result = _leetCodeServices.GuessNumber(n, realNum);
            return result;
        }

        [HttpPost("SuccessfulPairs")]
        public int[] SuccessfulPairs(Input_SuccessfulPairs input_SuccessfulPairs)
        {
            var nums1 = input_SuccessfulPairs.nums1;
            var nums2 = input_SuccessfulPairs.nums2;
            var num = input_SuccessfulPairs.num;
            var result = _leetCodeServices.SuccessfulPairs(nums1, nums2, num);
            return result;
        }

        [HttpPost("FindPeekElement")]
        public int FindPeakElement(int[] nums)
        {
            var result = _leetCodeServices.FindPeakElement(nums);
            return result;
        }

        [HttpPost("MinEatingSpeed")]
        public int MinEatingSpeed(int[] piles, int h)
        {
            var result = _leetCodeServices.MinEatingSpeed(piles, h); ;
            return result;
        }

        [HttpPost("LetterCombinations")]
        public IList<string> LetterCombinations(string digits)
        {
            var result = _leetCodeServices.LetterCombinations(digits);
            return result;
        }

        [HttpPost("CombinationSum3")]
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            var result = _leetCodeServices.CombinationSum3(k, n);
            return result;
        }

        [HttpPost("Tribonacci")]
        public int Tribonacci(int n)
        {
            var result = _leetCodeServices.Tribonacci(n);
            return result;
        }

        [HttpPost("MinCostClimbingStairs")]
        public int MinCostClimbingStairs(int[] cost)
        {
            var result = _leetCodeServices.MinCostClimbingStairs(cost);
            return result;
        }

        [HttpPost("Rob")]
        public int Rob(int[] nums)
        {
            var result = _leetCodeServices.Rob(nums);
            return result;
        }

        [HttpPost("NumTilings")]
        public int NumTilings(int n)
        {
            var result = _leetCodeServices.NumTilings(n);
            return result;
        }

        [HttpPost("UniquePaths")]
        public int UniquePaths(int m, int n)
        {
            var result = _leetCodeServices.UniquePaths(m, n);
            return result;
        }

        [HttpPost("LongestCommonSubsequence")]
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var result = _leetCodeServices.LongestCommonSubsequence(text1, text2);
            return result;
        }

        [HttpPost("MaxProfit")]
        public int MaxProfit(int[] prices, int fee)
        {
            var result = _leetCodeServices.MaxProfit(prices, fee);
            return result;
        }

        [HttpPost("MinDistance")]
        public int MinDistance(string word1, string word2)
        {
            var result = _leetCodeServices.MinDistance(word1, word2);
            return result;
        }

        [HttpPost("CountBits")]
        public int[] CountBits(int n)
        {
            var result = _leetCodeServices.CountBits(n);
            return result;
        }

        [HttpPost("SingleNumber")]
        public int SingleNumber(int[] nums)
        {
            var result = _leetCodeServices.SingleNumber(nums);
            return result;
        }

        [HttpPost("MinFlips")]
        public int MinFlips(int a, int b, int c)
        {
            var result = _leetCodeServices.MinFlips(a, b, c);
            return result;
        }

        [HttpPost("SuggestedProducts")]
        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            var result = _leetCodeServices.SuggestedProducts(products, searchWord);
            return result;
        }

        [HttpPost("EraseOverlapIntervals")]
        public int EraseOverlapIntervals(int[][] intervals)
        {
            var result = _leetCodeServices.EraseOverlapIntervals(intervals);
            return result;
        }

        [HttpPost("FindMinArrowShots")]
        public int FindMinArrowShots(int[][] points)
        {
            var result = _leetCodeServices.FindMinArrowShots(points);
            return result;
        }

        [HttpPost("DailyTemperatures")]
        public int[] DailyTemperatures(int[] temperatures)
        {
            var result = _leetCodeServices.DailyTemperatures(temperatures);
            return result;
        }

        [HttpPost("FindContentChildren")]
        public int FindContentChildren(Input_FindContentChildren input)
        {
            var result = _leetCodeServices.FindContentChildren(input.nums1, input.nums2);
            return result;
        }

        [HttpPost("ReverseString")]
        public char[] ReverseString(char[] s)
        {
            var result = _leetCodeServices.ReverseString(s);
            return result;
        }

        [HttpPost("MajorityElement")]
        public int MajorityElement(int[] nums)
        {
            var result = _leetCodeServices.MajorityElement(nums);
            return result;
        }

        [HttpPost("LengthOfLongestSubstring")]
        public int LengthOfLongestSubstring(string s)
        {
            var result = _leetCodeServices.LengthOfLongestSubstring(s);
            return result;
        }

        [HttpPost("Merge")]
        public int[] Merge(Input_Merge input, int m, int n)
        {
            var result = _leetCodeServices.Merge(input.nums1, m, input.nums2, n);
            return result;
        }

        [HttpPost("ZigzagLevelOrder")]
        public IList<IList<int>> ZigzagLevelOrder(int?[] nums)
        {
            TreeNode root = _leetCodeServices.ArrayToBinaryTree(nums);
            var result = _leetCodeServices.ZigzagLevelOrder(root);
            return result;
        }

        [HttpPost("Search")]
        public int Search(int[] nums, int target)
        {
            var result = _leetCodeServices.Search(nums, target);
            return result;
        }

        [HttpPost("ThreeSum")]
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = _leetCodeServices.ThreeSum(nums);
            return result;
        }

        [HttpPost("ReverseKGroup")]
        public List<int> ReverseKGroup(List<int> numsBefore, int k)
        {
            var result = _leetCodeServices.ReverseKGroup(numsBefore, k);
            return result;
        }

        [HttpPost("NumIslands")]
        public int NumIslands(char[][] grid)
        {
            var result = _leetCodeServices.NumIslands(grid);
            return result;
        }

        [HttpPost("NextPermutation")]
        public int[] NextPermutation(int[] nums)
        {
            var result = _leetCodeServices.NextPermutation(nums);
            return result;
        }

        [HttpPost("PeakIndexInMountainArray")]
        public int PeakIndexInMountainArray(int[] arr)
        {
            var result = _leetCodeServices.PeakIndexInMountainArray(arr);
            return result;
        }

        [HttpPost("ReverseBetween")]
        public List<int> ReverseBetween(List<int> nums, int left, int right)
        {
            var result = _leetCodeServices.ReverseBetween(nums, left, right);
            return result;
        }

        [HttpPost("FindMinHeightTrees")]
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            var result = _leetCodeServices.FindMinHeightTrees(n, edges);
            return result;
        }

        [HttpPost("MaxProfitBuyOne")]
        public int MaxProfit(int[] prices)
        {
            var result = _leetCodeServices.MaxProfit(prices);
            return result;
        }

        [HttpPost("FindTheDifference")]
        public char FindTheDifference(string s, string t)
        {
            var result = _leetCodeServices.FindTheDifference(s, t);
            return result;
        }

        [HttpPost("StrStr")]
        public int StrStr(string haystack, string needle)
        {
            var result = _leetCodeServices.StrStr(haystack, needle);
            return result;
        }

        [HttpPost("IsAnagram")]
        public bool IsAnagram(string s, string t)
        {
            var result = _leetCodeServices.IsAnagram(s, t);
            return result;
        }

        [HttpPost("RepeatedSubstringPattern")]
        public bool RepeatedSubstringPattern(string s)
        {
            var result = _leetCodeServices.RepeatedSubstringPattern(s);
            return result;
        }

        [HttpPost("PlusOne")]
        public int[] PlusOne(int[] digits)
        {
            var result = _leetCodeServices.PlusOne(digits);
            return result;
        }

        [HttpPost("ArraySign")]
        public int ArraySign(int[] nums)
        {
            var result = _leetCodeServices.ArraySign(nums);
            return result;
        }
    }
}

