using LeetCodeWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}

