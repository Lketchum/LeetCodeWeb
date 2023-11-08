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

        [HttpPost("CanMakeArithmeticProgression")]
        public bool CanMakeArithmeticProgression(int[] arr)
        {
            var result = _leetCodeServices.CanMakeArithmeticProgression(arr);
            return result;
        }

        [HttpPost("IsMonotonic")]
        public bool IsMonotonic(int[] nums)
        {
            var result = _leetCodeServices.IsMonotonic(nums);
            return result;
        }

        [HttpPost("LengthOfLastWord")]
        public int LengthOfLastWord(string s)
        {
            var result = _leetCodeServices.LengthOfLastWord(s);
            return result;
        }

        [HttpPost("ToLowerCase")]
        public string ToLowerCase(string s)
        {
            var result = _leetCodeServices.ToLowerCase(s);
            return result;
        }

        [HttpPost("CalPoints")]
        public int CalPoints(string[] operations)
        {
            var result = _leetCodeServices.CalPoints(operations);
            return result;
        }

        [HttpPost("JudgeCircle")]
        public bool JudgeCircle(string moves)
        {
            var result = _leetCodeServices.JudgeCircle(moves);
            return result;
        }

        [HttpPost("Tictactoe")]
        public string Tictactoe(int[][] moves)
        {
            var result = _leetCodeServices.Tictactoe(moves);
            return result;
        }

        [HttpPost("IsRobotBounded")]
        public bool IsRobotBounded(string instructions)
        {
            var result = _leetCodeServices.IsRobotBounded(instructions);
            return result;
        }

        [HttpPost("MaximumWealth")]
        public int MaximumWealth(int[][] accounts)
        {
            var result = _leetCodeServices.MaximumWealth(accounts);
            return result;
        }

        [HttpPost("DiagonalSum")]
        public int DiagonalSum(int[][] mat)
        {
            var result = _leetCodeServices.DiagonalSum(mat);
            return result;
        }

        [HttpPost("SpiralOrder")]
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var result = _leetCodeServices.SpiralOrder(matrix);
            return result;
        }

        [HttpPost("SetZeroes")]
        public int[][] SetZeroes(int[][] matrix)
        {
            var result = _leetCodeServices.SetZeroes(matrix);
            return result;
        }

        [HttpPost("CountOdds")]
        public int CountOdds(int low, int high)
        {
            var result = _leetCodeServices.CountOdds(low, high);
            return result;
        }

        [HttpPost("Average")]
        public double Average(int[] salary)
        {
            var result = _leetCodeServices.Average(salary);
            return result;
        }

        [HttpPost("LemonadeChange")]
        public bool LemonadeChange(int[] bills)
        {
            var result = _leetCodeServices.LemonadeChange(bills);
            return result;
        }

        [HttpPost("LargestPerimeter")]
        public int LargestPerimeter(int[] nums)
        {
            var result = _leetCodeServices.LargestPerimeter(nums);
            return result;
        }

        [HttpPost("CheckStraightLine")]
        public bool CheckStraightLine(int[][] coordinates)
        {
            var result = _leetCodeServices.CheckStraightLine(coordinates);
            return result;
        }

        [HttpPost("AddBinary")]
        public string AddBinary(string a, string b)
        {
            var result = _leetCodeServices.AddBinary(a, b);
            return result;
        }

        [HttpPost("Multiply")]
        public string Multiply(string num1, string num2)
        {
            var result = _leetCodeServices.Multiply(num1, num2);
            return result;
        }

        [HttpPost("MyPow")]
        public double MyPow(double x, int n)
        {
            var result = _leetCodeServices.MyPow(x, n);
            return result;
        }

        [HttpPost("MergeTwoLists")]
        public List<int> MergeTwoLists(Input_MergeTwoLists input)
        {
            var result = _leetCodeServices.MergeTwoLists(input.nums1, input.nums2);
            return result;
        }

        [HttpPost("AddTwoNumbers")]
        public List<int> AddTwoNumbers(Input_MergeTwoLists input)
        {
            var result = _leetCodeServices.AddTwoNumbers(input.nums1, input.nums2);
            return result;
        }

        [HttpPost("AddTwoNumbers2")]
        public List<int> AddTwoNumbers2(Input_MergeTwoLists input)
        {
            var result = _leetCodeServices.AddTwoNumbers2(input.nums1, input.nums2);
            return result;
        }

        [HttpPost("InorderTraversal")]
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = _leetCodeServices.InorderTraversal(root);
            return result;
        }

        [HttpPost("BuddyStrings")]
        public bool BuddyStrings(string s, string goal)
        {
            var result = _leetCodeServices.BuddyStrings(s, goal);
            return result;
        }

        [HttpPost("ValidWordSquare")]
        public bool ValidWordSquare(IList<string> words)
        {
            var result = _leetCodeServices.ValidWordSquare(words);
            return result;
        }

        [HttpPost("FindMissingRanges")]
        public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            var result = _leetCodeServices.FindMissingRanges(nums, lower, upper);
            return result;
        }

        [HttpPost("ConfusingNumber")]
        public bool ConfusingNumber(int n)
        {
            var result = _leetCodeServices.ConfusingNumber(n);
            return result;
        }

        [HttpPost("IsNumber")]
        public bool IsNumber(string s)
        {
            var result = _leetCodeServices.IsNumber(s);
            return result;
        }

        [HttpPost("ShortestDistance_NotSoccer")]
        public int ShortestDistance_NotSoccer(Input_Maze input)
        {
            var result = _leetCodeServices.ShortestDistance_NotSoccer(input.maze, input.start, input.destination);
            return result;
        }

        [HttpPost("HasPath")]
        public bool HasPath(Input_Maze input)
        {
            var result = _leetCodeServices.HasPath(input.maze, input.start, input.destination);
            return result;
        }

        [HttpPost("ShortestDistance_IsSoccer")]
        public int ShortestDistance_IsSoccer(Input_Maze input)
        {
            var result = _leetCodeServices.ShortestDistance_IsSoccer(input.maze, input.start, input.destination);
            return result;
        }

        [HttpPost("ConvertToTitle")]
        public string ConvertToTitle(int columnNumber)
        {
            var result = _leetCodeServices.ConvertToTitle(columnNumber);
            return result;
        }

        [HttpPost("TitleToNumber")]
        public int TitleToNumber(string columnTitle)
        {
            var result = _leetCodeServices.TitleToNumber(columnTitle);
            return result;
        }

        [HttpPost("ShortestDistance")]
        public int ShortestDistance(string[] wordsDict, string word1, string word2)
        {
            var result = _leetCodeServices.ShortestDistance(wordsDict, word1, word2);
            return result;
        }

        [HttpPost("IsStrobogrammatic")]
        public bool IsStrobogrammatic(string num)
        {
            var result = _leetCodeServices.IsStrobogrammatic(num);
            return result;
        }

        [HttpPost("CanAttendMeetings")]
        public bool CanAttendMeetings(int[][] intervals)
        {
            var result = _leetCodeServices.CanAttendMeetings(intervals);
            return result;
        }

        [HttpPost("MinMeetingRooms")]
        public int MinMeetingRooms(int[][] intervals)
        {
            var result = _leetCodeServices.MinMeetingRooms(intervals);
            return result;
        }

        [HttpPost("CanPermutePalindrome")]
        public bool CanPermutePalindrome(string s)
        {
            var result = _leetCodeServices.CanPermutePalindrome(s);
            return result;
        }

        [HttpPost("ClosestValue")]
        public int ClosestValue(TreeNode root, double target)
        {
            var result = _leetCodeServices.ClosestValue(root, target);
            return result;
        }

        [HttpPost("GeneratePossibleNextMoves")]
        public IList<string> GeneratePossibleNextMoves(string currentState)
        {
            var result = _leetCodeServices.GeneratePossibleNextMoves(currentState);
            return result;
        }

        [HttpPost("ValidWordAbbreviation")]
        public bool ValidWordAbbreviation(string word, string abbr)
        {
            var result = _leetCodeServices.ValidWordAbbreviation(word, abbr);
            return result;
        }

        [HttpPost("AreSentencesSimilar")]
        public bool AreSentencesSimilar(Input_AreSentencesSimilar input)
        {
            var result = _leetCodeServices.AreSentencesSimilar(input.sentence1, input.sentence2, input.similarPairs);
            return result;
        }

        [HttpPost("AnagramMappings")]
        public int[] AnagramMappings(TwoArrays_NotEmpty input)
        {
            var result = _leetCodeServices.AnagramMappings(input.array1, input.array2);
            return result;
        }

        [HttpPost("SimilarRGB")]
        public string SimilarRGB(string color)
        {
            var result = _leetCodeServices.SimilarRGB(color);
            return result;
        }

        [HttpPost("FixedPoint")]
        public int FixedPoint(int[] arr)
        {
            var result = _leetCodeServices.FixedPoint(arr);
            return result;
        }

        [HttpPost("IndexPairs")]
        public int[][] IndexPairs(string text, string[] words)
        {
            var result = _leetCodeServices.IndexPairs(text, words);
            return result;
        }

        [HttpPost("SumOfDigits")]
        public int SumOfDigits(int[] nums)
        {
            var result = _leetCodeServices.SumOfDigits(nums);
            return result;
        }

        [HttpPost("HighFive")]
        public int[][] HighFive(int[][] items)
        {
            var result = _leetCodeServices.HighFive(items);
            return result;
        }

        [HttpPost("TwoSumLessThanK")]
        public int TwoSumLessThanK(int[] nums, int k)
        {
            var result = _leetCodeServices.TwoSumLessThanK(nums, k);
            return result;
        }

        [HttpPost("NumberOfDays")]
        public int NumberOfDays(int year, int month)
        {
            var result = _leetCodeServices.NumberOfDays(year, month);
            return result;
        }

        [HttpPost("RemoveVowels")]
        public string RemoveVowels(string s)
        {
            var result = _leetCodeServices.RemoveVowels(s);
            return result;
        }

        [HttpPost("LargestUniqueNumber")]
        public int LargestUniqueNumber(int[] nums)
        {
            var result = _leetCodeServices.LargestUniqueNumber(nums);
            return result;
        }

        [HttpPost("IsArmstrong")]
        public bool IsArmstrong(int n)
        {
            var result = _leetCodeServices.IsArmstrong(n);
            return result;
        }

        [HttpPost("IsMajorityElement")]
        public bool IsMajorityElement(int[] nums, int target)
        {
            var result = _leetCodeServices.IsMajorityElement(nums, target);
            return result;
        }

        [HttpPost("CalculateTime")]
        public int CalculateTime(string keyboard, string word)
        {
            var result = _leetCodeServices.CalculateTime(keyboard, word);
            return result;
        }

        [HttpPost("DietPlanPerformance")]
        public int DietPlanPerformance(int[] calories, int k, int lower, int upper)
        {
            var result = _leetCodeServices.DietPlanPerformance(calories, k, lower, upper);
            return result;
        }

        [HttpPost("CountLetters")]
        public int CountLetters(string s)
        {
            var result = _leetCodeServices.CountLetters(s);
            return result;
        }

        [HttpPost("MaxNumberOfApples")]
        public int MaxNumberOfApples(int[] weight)
        {
            var result = _leetCodeServices.MaxNumberOfApples(weight);
            return result;
        }
    }
}

