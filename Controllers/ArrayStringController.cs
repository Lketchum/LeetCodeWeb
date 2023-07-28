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

    public class ArrayStringController : ControllerBase
    {
        private readonly ArrayString _arrayString;

        public ArrayStringController(ArrayString arrayString)
        {
            _arrayString = arrayString;
        }

        [HttpPost("EasyAdd")]
        public int EasyAdd(int num1, int num2)
        {
            var result = _arrayString.EasyAdd(num1, num2);
            return result;
        }

        [HttpPost("DecodeString")]
        public string DecodeString(string s)
        {
            string result = _arrayString.DecodeString(s);
            return result;
        }

        [HttpPost("PredictPartyVictory")]
        public string PredictPartyVictory(string s)
        {
            string result = _arrayString.PredictPartyVictory(s);
            return result;
        }

        [HttpPost("DeleteMiddle")]
        public List<int> DeleteMiddle(List<int> numsBefore)
        {
            var result = _arrayString.DeleteMiddle(numsBefore);
            return result;
        }

        [HttpPost("OddEvenList")]
        public List<int> OddEvenList(List<int> numsBefore)
        {
            var result = _arrayString.OddEvenList(numsBefore);
            return result;
        }

        [HttpPost("ReverseList")]
        public List<int> ReverseList(List<int> numsBefore)
        {
            var result = _arrayString.ReverseList(numsBefore);
            return result;
        }

        [HttpPost("PairSum")]
        public int PairSum(List<int> numsBefore)
        {
            var result = _arrayString.PairSum(numsBefore);
            return result;
        }

        [HttpPost("MaxDepth")]
        public int MaxDepth(int?[] arr)
        {
            TreeNode root = _arrayString.ArrayToBinaryTree(arr);
            var result = _arrayString.MaxDepth(root);
            return result;
        }

        [HttpPost("LeafSimilar")]
        public bool LeafSimilar(TwoArrays twoArrays)
        {
            TreeNode root1 = _arrayString.ArrayToBinaryTree(twoArrays.array1);
            TreeNode root2 = _arrayString.ArrayToBinaryTree(twoArrays.array2);
            var result = _arrayString.LeafSimilar(root1, root2);
            return result;
        }

        [HttpPost("GoodNodes")]
        public int GoodNodes(int?[] arr)
        {
            TreeNode root = _arrayString.ArrayToBinaryTree(arr);
            var result = _arrayString.GoodNodes(root);
            return result;
        }

        [HttpPost("PathSum")]
        public int PathSum(int?[] arr, int targetSum)
        {
            TreeNode root = _arrayString.ArrayToBinaryTree(arr);
            var result = _arrayString.PathSum(root, targetSum);
            return result;
        }

        [HttpPost("LongestZigZag")]
        public int LongestZigZag(int?[] arr)
        {
            TreeNode root = _arrayString.ArrayToBinaryTree(arr);
            var result = _arrayString.LongestZigZag(root);
            return result;
        }

        [HttpPost("LowestCommonAncestor")]
        public TreeNode LowestCommonAncestor(ThreeArrays threeArrays)
        {
            TreeNode root = _arrayString.ArrayToBinaryTree(threeArrays.array1);
            TreeNode p = _arrayString.ArrayToBinaryTree(threeArrays.array2);
            TreeNode q = _arrayString.ArrayToBinaryTree(threeArrays.array3);
            var result = _arrayString.LowestCommonAncestor(root, p, q);
            return result;
        }

        [HttpPost("RightSideView")]
        public IList<int> RightSideView(int?[] arr)
        {
            TreeNode root = _arrayString.ArrayToBinaryTree(arr);
            var result = _arrayString.RightSideView(root);
            return result;
        }

        [HttpPost("MaxLevelSum")]
        public int MaxLevelSum(int?[] arr)
        {
            TreeNode root = _arrayString.ArrayToBinaryTree(arr);
            var result = _arrayString.MaxLevelSum(root);
            return result;
        }

        [HttpPost("SearchBST")]
        public int?[] SearchBST(int?[] arr, int val)
        {
            TreeNode root = _arrayString.ArrayToBinaryTree(arr);
            var resultNode = _arrayString.SearchBST(root, val);
            var result = _arrayString.TreeToArray(resultNode);
            return result;
        }

        [HttpPost("DeleteNode")]
        public int?[] DeleteNode(int?[] arr, int key)
        {
            TreeNode root = _arrayString.ArrayToBinaryTree(arr);
            var resultNode = _arrayString.DeleteNode(root, key);
            var result = _arrayString.TreeToArray(resultNode);
            return result;
        }

        [HttpPost("CanVisitAllRooms")]
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            var result = _arrayString.CanVisitAllRooms(rooms);
            return result;
        }

        [HttpPost("FindCircleNum")]
        public int FindCircleNum(int[][] isConnetcted)
        {
            var result = _arrayString.FindCircleNum(isConnetcted);
            return result;
        }

        [HttpPost("MinReorder")]
        public int MinReorder(int n, int[][] connections)
        {
            var result = _arrayString.MinReorder(n, connections);
            return result;
        }

        [HttpPost("CalcEquation")]
        public double[] CalcEquation(Arrays_CalcEquation inputArrays)
        {
            var equations = inputArrays.array1;
            var values = inputArrays.array2;
            var queries = inputArrays.array3;
            var result = _arrayString.CalcEquation(equations, values, queries);
            return result;
        }

        [HttpPost("NearestExit")]
        public int NearestExit(Input_NearestExit inputArrays)
        {
            var maze = inputArrays.char1;
            var entrance = inputArrays.int2;
            var result = _arrayString.NearestExit(maze, entrance);
            return result;
        }

        [HttpPost("OrangeRotting")]
        public int OrangeRotting(int[][] grid)
        {
            var result = _arrayString.OrangeRotting(grid);
            return result;
        }

        [HttpPost("FindKthLargest")]
        public int FindKthLargest(int[] nums, int k)
        {
            var result = _arrayString.FindKthLargest(nums, k);
            return result;
        }

        [HttpPost("MaxScore")]
        public long MaxScore(Input_MaxScore input_MaxScore)
        {
            var nums1 = input_MaxScore.nums1;
            var nums2 = input_MaxScore.nums2;
            var k = input_MaxScore.num;
            var result = _arrayString.MaxScore(nums1, nums2, k);
            return result;
        }
    }
}

