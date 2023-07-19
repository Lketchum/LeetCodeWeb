using LeetCodeWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
        double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    }
}
