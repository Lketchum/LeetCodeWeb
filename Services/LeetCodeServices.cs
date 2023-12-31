﻿using LeetCodeWeb.Controllers;
using LeetCodeWeb.IServices;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using static LeetCodeWeb.Services.CustomStructure;

namespace LeetCodeWeb.Services
{
    public class LeetCodeServices : ILeetCodeServices
    {
        private readonly ILogger<LeetCodeServices> _logger;

        public LeetCodeServices(ILogger<LeetCodeServices> logger)
        {
            _logger = logger;
        }

        public int EasyAdd(int num1, int num2)
        {
            return num1 + num2;
        }

        public string DecodeString(string s)
        {
            string res = "";
            char[] charS = s.ToCharArray();
            int n = charS.Length;
            int multi = 0;
            Stack<int> stack_multi = new Stack<int>();
            Stack<string> stack_res = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                if (charS[i] >= '0' && charS[i] <= '9')
                {
                    multi = multi * 10 + (int)(charS[i] - '0');
                }
                else if (charS[i] == '[')
                {
                    stack_multi.Push(multi);
                    stack_res.Push(res.ToString());
                    multi = 0;
                    res = "";
                }
                else if (charS[i] == ']')
                {
                    string tmp = "";
                    int cur_multi = stack_multi.Pop();
                    for (int j = 0; j < cur_multi; j++)
                        tmp = String.Concat(tmp, res);
                    res = String.Concat(stack_res.Pop() + tmp);
                }
                else
                    res = String.Concat(res, charS[i]);
            }
            return res.ToString();
        }

        public string PredictPartyVictory(string senate)
        {
            char[] charS = senate.ToCharArray();
            Queue<int> queueR = new Queue<int>();
            Queue<int> queueD = new Queue<int>();
            int n = charS.Length;
            for (int i = 0; i < n; i++)
            {
                if (charS[i] == 'R')
                    queueR.Enqueue(i);
                else
                    queueD.Enqueue(i);
            }

            //轮询对照
            while (queueD.Count > 0 && queueR.Count > 0)
            {
                if (queueD.Peek() < queueR.Peek())
                {
                    int tmp = queueD.Dequeue();
                    queueD.Enqueue(tmp + n);
                    queueR.Dequeue();
                }
                else
                {
                    int tmp = queueR.Dequeue();
                    queueR.Enqueue(tmp + n);
                    queueD.Dequeue();
                }
            }

            //多轮结束判断
            if (queueD.Count == 0)
                return "Radiant";
            else
                return "Dire";
        }

        public List<int> DeleteMiddle(List<int> numsBefore)
        {
            #region 前处理：将数组转换为ListNode类
            ListNode head;

            ListNode dummy = new ListNode(0); // 创建一个虚拟节点作为链表的头节点
            ListNode current = dummy;

            foreach (int num in numsBefore)
            {
                ListNode newNode = new ListNode(num);
                current.next = newNode;
                current = current.next;
            }
            head = dummy.next;
            #endregion

            //逻辑代码内容
            ListNode templistnode = new ListNode(0);
            templistnode.next = head;
            ListNode slow = templistnode;
            ListNode fast = templistnode;
            ListNode temp = templistnode;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                temp = slow;
                slow = slow.next;
            }
            if (fast == null)
            {
                temp.next = slow.next;
            }
            else
            {
                slow.next = slow.next.next;
            }

            ListNode returnNode = templistnode.next;
            //后处理：将ListNode类转换为数组
            List<int> numsAfter = new List<int>();
            while (returnNode != null)
            {
                numsAfter.Add(returnNode.val);
                returnNode = returnNode.next;
            }

            return numsAfter;
        }

        public List<int> OddEvenList(List<int> numsBefore)
        {
            #region 前处理：将数组转换为ListNode类
            ListNode head;

            ListNode dummy = new ListNode(0); // 创建一个虚拟节点作为链表的头节点
            ListNode current = dummy;

            foreach (int num in numsBefore)
            {
                ListNode newNode = new ListNode(num);
                current.next = newNode;
                current = current.next;
            }
            head = dummy.next;
            #endregion

            //逻辑代码内容
            ListNode temp = head;
            ListNode Odd = new ListNode(0);
            ListNode tmpOdd = Odd;
            ListNode Even = new ListNode(0);
            ListNode tmpEven = Even;
            bool isOdd = true;

            while (temp != null)
            {
                if (isOdd)
                {
                    ListNode oddnode = new ListNode(temp.val);
                    tmpOdd.next = oddnode;
                    tmpOdd = tmpOdd.next;
                    isOdd = false;
                }
                else
                {
                    ListNode evennode = new ListNode(temp.val);
                    tmpEven.next = evennode;
                    tmpEven = tmpEven.next;
                    isOdd = true;
                }
                temp = temp.next;
            }

            tmpOdd.next = Even.next;
            ListNode returnNode = Odd.next;
            //后处理：将ListNode类转换为数组
            List<int> numsAfter = new List<int>();
            while (returnNode != null)
            {
                numsAfter.Add(returnNode.val);
                returnNode = returnNode.next;
            }

            return numsAfter;
        }

        public List<int> ReverseList(List<int> numsBefore)
        {
            #region 前处理：将数组转换为ListNode类
            ListNode head;

            ListNode dummy = new ListNode(0); // 创建一个虚拟节点作为链表的头节点
            ListNode current = dummy;

            foreach (int num in numsBefore)
            {
                ListNode newNode = new ListNode(num);
                current.next = newNode;
                current = current.next;
            }
            head = dummy.next;
            #endregion

            //逻辑代码内容
            ListNode temp = head;
            ListNode reverseNode = null;

            while (temp != null)
            {
                //ListNode newNode = new ListNode(temp.val);
                //newNode.next = reverseNode;
                //reverseNode = newNode;
                //temp = temp.next;

                //空间优化答案
                ListNode next = temp.next;
                temp.next = reverseNode;
                reverseNode = temp;
                temp = next;
            }

            ListNode returnNode = reverseNode;
            //后处理：将ListNode类转换为数组
            List<int> numsAfter = new List<int>();
            while (returnNode != null)
            {
                numsAfter.Add(returnNode.val);
                returnNode = returnNode.next;
            }

            return numsAfter;
        }

        public int PairSum(List<int> numsBefore)
        {
            #region 前处理：将数组转换为ListNode类
            ListNode head;

            ListNode dummy = new ListNode(0); // 创建一个虚拟节点作为链表的头节点
            ListNode current = dummy;

            foreach (int num in numsBefore)
            {
                ListNode newNode = new ListNode(num);
                current.next = newNode;
                current = current.next;
            }
            head = dummy.next;
            #endregion

            //逻辑代码内容
            ListNode temp1 = head;
            ListNode temp2 = head;
            ListNode reverseNode = null;
            int MaxNum = 0;

            while (temp1 != null)
            {
                //空间优化答案
                //ListNode next = temp1.next;
                //temp1.next = reverseNode;
                //reverseNode = temp1; 
                //temp1 = next;

                ListNode newNode = new ListNode(temp1.val);
                newNode.next = reverseNode;
                reverseNode = newNode;
                temp1 = temp1.next;
            }

            while (temp2 != null)
            {
                int tempNum = temp2.val + reverseNode.val;
                MaxNum = Math.Max(MaxNum, tempNum);
                temp2 = temp2.next;
                reverseNode = reverseNode.next;
            }

            return MaxNum;
        }

        #region 二叉树树节点转换前处理
        //二叉树转换前处理
        private TreeNode BuildTree(int?[] arr, int index)
        {
            if (index >= arr.Length || arr[index] == null)
                return null;

            TreeNode node = new TreeNode(arr[index].Value);

            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            node.left = BuildTree(arr, leftChildIndex);
            node.right = BuildTree(arr, rightChildIndex);

            return node;
        }
        public TreeNode ArrayToBinaryTree(int?[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;

            return BuildTree(arr, 0);
        }
        #endregion
        #region 二叉树数节点转换后处理
        public int?[] TreeToArray(TreeNode root)
        {
            if (root == null)
            {
                return new int?[0]; // 树为空，返回空数组
            }

            List<int?> nodeList = new List<int?>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                nodeList.Add(node != null ? node.val : (int?)null); // 将当前节点的值添加到结果数组中

                if (node != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }

            return nodeList.ToArray();
        }
        #endregion

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            else
            {
                int leftHeight = MaxDepth(root.left);
                int rightHeight = MaxDepth(root.right);
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> leafNodes1 = new List<int>();
            List<int> leafNodes2 = new List<int>();

            if (root1 != null)
                DFS_LeafSimilar(root1, leafNodes1);
            if (root2 != null)
                DFS_LeafSimilar(root2, leafNodes2);
            return leafNodes1.SequenceEqual(leafNodes2);
        }
        private void DFS_LeafSimilar(TreeNode node, List<int> leafNodes)
        {
            if (node == null)
                return;

            if (node.left == null && node.right == null)
                leafNodes.Add(node.val);

            DFS_LeafSimilar(node.left, leafNodes);
            DFS_LeafSimilar(node.right, leafNodes);
        }

        public int GoodNodes(TreeNode root)
        {
            int res = DFS_GoodNodes(root, root.val);
            return res;
        }
        private int DFS_GoodNodes(TreeNode node, int MaxValue)
        {
            int tmp = 0;
            if (node == null)
                return 0;

            if (MaxValue <= node.val)
            {
                tmp = 1;
                MaxValue = node.val;
            }                

            int leftNum = DFS_GoodNodes(node.left, MaxValue);
            int rigthNum = DFS_GoodNodes(node.right, MaxValue);
            return leftNum + rigthNum + tmp;
        }

        public int PathSum(TreeNode root, int targetSum)
        {
            Dictionary<long, int> prefixDic = new Dictionary<long, int>();
            prefixDic.Add(0, 1);
            return DFS_PathSum(root, prefixDic, 0, targetSum);
        }
        private int DFS_PathSum(TreeNode root, Dictionary<long, int> prefixDic, long currSum, int targetSum)
        {
            if (root == null)
                return 0;
            int res = 0;
            currSum = currSum + root.val;
            prefixDic.TryGetValue(currSum - targetSum, out res);
            if (prefixDic.ContainsKey(currSum))
                prefixDic[currSum]++;
            else
                prefixDic.Add(currSum, 1);
            res = res + DFS_PathSum(root.left, prefixDic, currSum, targetSum);
            res = res + DFS_PathSum(root.right, prefixDic, currSum, targetSum);
            prefixDic[currSum]--;

            return res;
        }

        int longestNum;
        public int LongestZigZag(TreeNode root)
        {
            if (root == null)
                return 0;
            longestNum = 0;
            DFS_LongestZigZag(root, true, 0);
            DFS_LongestZigZag(root, false, 0);
            return longestNum;
        }
        private void DFS_LongestZigZag(TreeNode node, bool direction, int len)
        {
            longestNum = Math.Max(longestNum, len);
            if (direction)
            {
                if (node.left != null)                
                    DFS_LongestZigZag(node.left, false, len + 1);                
                if (node.right != null)                
                    DFS_LongestZigZag(node.right, true, 1);                
            }
            else
            {
                if (node.left != null)                
                    DFS_LongestZigZag(node.left, false, 1);                
                if (node.right != null)                
                    DFS_LongestZigZag(node.right, true, len + 1);                
            }
        }

        TreeNode lowestNode = null; //使用全局变量优化空间复杂度
        bool stopRecursion = false; //使用全局变量优化时间复杂度
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            DFS_LowestCommonAncestor(root, p, q);
            return lowestNode;
        }
        private bool DFS_LowestCommonAncestor(TreeNode node, TreeNode p, TreeNode q)
        {
            if (node == null)
                return false;
            bool leftBool = false;
            bool rightBool = false;
            if (!stopRecursion)
            {
                leftBool = DFS_LowestCommonAncestor(node.left, p, q);
                rightBool = DFS_LowestCommonAncestor(node.right, p, q);
            }
            if ((leftBool && rightBool) || (node.val == p.val || node.val == q.val))
            {
                lowestNode = node;
                if (leftBool && rightBool)
                    stopRecursion = true;
            }
            return leftBool || rightBool || node.val == p.val || node.val == q.val;
        }

        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> res = new List<int>();
            int depth = 1;
            DFS_RightSideView(root, res, depth);
            return res;
        }
        private void DFS_RightSideView(TreeNode node, IList<int> listRes, int depth)
        {
            if (node == null)
                return;
            if (listRes.Count < depth)
                listRes.Add(node.val);
            DFS_RightSideView(node.right, listRes, depth + 1);
            DFS_RightSideView(node.left, listRes, depth + 1);                        
        }
        
        public int MaxLevelSum(TreeNode root)
        {
            int maxSum = int.MinValue;
            int maxDepth = 1;
            int tmpSum = 0;
            int depth = 1;
            Queue<(TreeNode, int)> allQueue = new Queue<(TreeNode, int)>();
            allQueue.Enqueue((root, 1));
            int queueSize = allQueue.Count;

            while (queueSize > 0)
            {
                var (currNode, currDepth) = allQueue.Dequeue();
                queueSize--;
                if (currDepth != depth && tmpSum > maxSum)
                {
                    maxSum = tmpSum;
                    maxDepth = depth;
                }                
                if (currNode == null)
                    continue;
                if (currDepth == depth)                
                    tmpSum += currNode.val;                
                else
                {
                    depth = currDepth;
                    tmpSum = currNode.val;
                }
                allQueue.Enqueue((currNode.left, currDepth + 1));
                allQueue.Enqueue((currNode.right, currDepth + 1));
                queueSize += 2;
            }
            return maxDepth;
        }

        public TreeNode SearchBST(TreeNode root, int val)
        {
            TreeNode targetNode = null;
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);
            while (nodeQueue.Count > 0)
            {
                TreeNode currNode = nodeQueue.Dequeue();
                if (currNode == null)
                    continue;
                int currVal = currNode.val;
                if (currVal == val)
                {
                    targetNode = currNode;
                    break;
                }
                else if (currVal > val)                
                    nodeQueue.Enqueue(currNode.left);                
                else                
                    nodeQueue.Enqueue(currNode.right);
            }
            return targetNode;

            //参考优化
            //if (root == null)           
            //    return null;            
            //if (val == root.val)            
            //    return root;            
            //return SearchBST(val < root.val ? root.left : root.right, val);
        }

        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;

            TreeNode returnNode = new TreeNode(0);
            returnNode.left = root;

            TreeNode parentNode = returnNode;
            TreeNode tmpNode = root;
            while (tmpNode != null)
            {
                if (tmpNode.val > key)
                {
                    parentNode = tmpNode;
                    tmpNode = tmpNode.left;
                }
                else if (tmpNode.val < key)
                {
                    parentNode = tmpNode;
                    tmpNode = tmpNode.right;
                }
                else
                {
                    if (parentNode.left == tmpNode)
                    {
                        if (tmpNode.right == null && tmpNode.left == null)
                            parentNode.left = null;
                        else if (tmpNode.right == null)
                            parentNode.left = tmpNode.left;
                        else if (tmpNode.left == null)
                            parentNode.left = tmpNode.right;
                        else
                        {
                            TreeNode leftNode = tmpNode.left;
                            TreeNode rightNode = tmpNode.right;
                            parentNode.left = rightNode;
                            while (rightNode.left != null)
                                rightNode = rightNode.left;
                            rightNode.left = leftNode;
                        }
                    }
                    else if (parentNode.right == tmpNode)
                    {
                        if (tmpNode.right == null && tmpNode.left == null)
                            parentNode.right = null;
                        else if (tmpNode.right == null)
                            parentNode.right = tmpNode.left;
                        else if (tmpNode.left == null)
                            parentNode.right = tmpNode.right;
                        else
                        {
                            TreeNode leftNode = tmpNode.left;
                            TreeNode rightNode = tmpNode.right;
                            parentNode.right = rightNode;
                            while (rightNode.left != null)
                                rightNode = rightNode.left;
                            rightNode.left = leftNode;
                        }
                    }
                    break;
                }                    
            }

            return returnNode.left;
        }

        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            Dictionary<int, int> keyDic = new Dictionary<int, int> { { 0, 1} };
            Queue<int> keyDeque = new Queue<int>(new[] { 0 });
            while (keyDeque.Count != 0)
            {
                var tmpKey = keyDeque.Dequeue();
                foreach (var key in rooms[tmpKey])
                {
                    if (!keyDic.ContainsKey(key))
                    {
                        keyDic.Add(key, 1);
                        keyDeque.Enqueue(key);
                    }
                }                    
            }
            return keyDic.Count == rooms.Count;
        }


        //全局变量
        int[] parent;
        int[] rank;
        public int FindCircleNum(int[][] isConnected)
        {
            #region 原AC代码
            //int n = isConnected.GetLength(0);
            //List<Dictionary<int, int>> circleList = new List<Dictionary<int, int>>();

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j <= i; j++)
            //    {
            //        int tmpNum = isConnected[i][j];
            //        if (tmpNum == 0)
            //            continue;
            //        bool isInCircle = false;
            //        int dicNum = 0;
            //        for (int k = 0; k < circleList.Count; k++)
            //        {
            //            if (circleList[k].ContainsKey(i) || circleList[k].ContainsKey(j))
            //            {
            //                if (!circleList[k].ContainsKey(i))
            //                    circleList[k].Add(i, 1);
            //                if (!circleList[k].ContainsKey(j))
            //                    circleList[k].Add(j, 1);
            //                if (isInCircle == false)
            //                {
            //                    dicNum = k;
            //                    isInCircle = true;
            //                }
            //                else
            //                {
            //                    foreach (var kvp in circleList[k])
            //                    {
            //                        if (!circleList[dicNum].ContainsKey(kvp.Key))                                    
            //                            circleList[dicNum].Add(kvp.Key, 1);                                    
            //                    }
            //                    circleList.RemoveAt(k);
            //                }
            //            }
            //        }

            //        if (isInCircle == false)
            //        {
            //            Dictionary<int, int> newDic = new Dictionary<int, int>();
            //            if (i != j)
            //            {
            //                newDic.Add(i, 1);
            //                newDic.Add(j, 1);
            //            }
            //            else
            //                newDic.Add(i, 1);                        
            //            circleList.Add(newDic);
            //        }
            //    }
            //}
            //return circleList.Count;
            #endregion

            #region 并查集算法优化
            int n = isConnected.GetLength(0);
            int countProvince = 0;
            parent = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i == j || isConnected[i][j] == 0)
                        continue;
                    merge_FindCircleNum(i, j);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (parent[i] == i)
                    countProvince++;
            }
            return countProvince;

            //Dictionary<int, int> dicParent = new Dictionary<int, int>();
            //for (int m = 0; m < n; m++)
            //{
            //    var parentNode = find_FindCircleNum(m);
            //    if (!dicParent.ContainsKey(find_FindCircleNum(m)))
            //        dicParent.Add(parentNode, 1);
            //}            
            //return dicParent.Count;
            #endregion
        }
        public int find_FindCircleNum(int x)
        {
            if (parent[x] == x)
                return x;
            else
            {
                parent[x] = find_FindCircleNum(parent[x]);
                return parent[x];
            }                
        }
        public void merge_FindCircleNum(int i, int j)
        {
            int x = find_FindCircleNum(i);
            int y = find_FindCircleNum(j);
            if (rank[x] <= rank[y])            
                parent[x] = y;            
            else
                parent[y] = x;
            if (rank[x] == rank[y] && x != y)
                rank[y]++;
        }

        public int MinReorder(int n, int[][] connections)
        {
            List<List<int>> nearNodes = new List<List<int>>();
            for (int i = 0; i < n; i++)
                nearNodes.Add(new List<int>());
            foreach (var pair in connections)
            {
                nearNodes[pair[0]].Add(pair[1]);
                nearNodes[pair[1]].Add(pair[0]);
            }
            int[] levels = new int[n];
            Array.Fill(levels, -1);
            levels[0] = 0;
            Queue<int> orderQueue = new Queue<int>();
            orderQueue.Enqueue(0);
            while (orderQueue.Count > 0)
            {
                int city = orderQueue.Dequeue();
                List<int> cityAround = nearNodes[city];
                foreach (var node in cityAround)
                {
                    if (levels[node] < 0)
                    {
                        levels[node] = levels[city] + 1;
                        orderQueue.Enqueue(node);
                    }
                }    
            }
            int reorderNum = 0;
            foreach (var pair in connections)
            {
                if (levels[pair[0]] < levels[pair[1]])
                    reorderNum++;
            }
            return reorderNum;
        }

        int[] parent_CalcEquation;
        double[] weight_CalcEquation;
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, int> varDic = new Dictionary<string, int>();
            int nE = equations.Count;
            int varOrder = -1;
            for (int i = 0; i < nE; i++)
            {
                if (!varDic.ContainsKey(equations[i][0]))
                    varDic.Add(equations[i][0], ++varOrder);
                if (!varDic.ContainsKey(equations[i][1]))
                    varDic.Add(equations[i][1], ++varOrder);
            }
            parent_CalcEquation = new int[varOrder + 1];
            weight_CalcEquation = new double[varOrder + 1];
            for (int i = 0; i < varOrder + 1; i++)
            {
                parent_CalcEquation[i] = i;
                weight_CalcEquation[i] = 1.0;
            }
            for (int i = 0; i < nE; i++)
            {
                int order_0 = varDic[equations[i][0]];
                int order_1 = varDic[equations[i][1]];
                double order_num = values[i];
                merge_CalcEquation(order_0, order_1, order_num);
            }
            int nQ = queries.Count;
            double[] result = new double[nQ];
            for (int i = 0; i < nQ; i++)
            {
                string variable_0 = queries[i][0];
                string variable_1 = queries[i][1];
                if (varDic.ContainsKey(variable_0) && varDic.ContainsKey(variable_1))
                {
                    int order_0 = varDic[variable_0];
                    int order_1 = varDic[variable_1];
                    if (find_CalcEquation(order_0) == find_CalcEquation(order_1))
                        result[i] = weight_CalcEquation[order_0] / weight_CalcEquation[order_1];
                    else
                        result[i] = -1.0;
                }
                else
                    result[i] = -1.0;
            }
            return result;
        }
        public int find_CalcEquation(int x)
        {
            if (parent_CalcEquation[x] == x)
                return x;
            else
            {
                int tmp = parent_CalcEquation[x];
                parent_CalcEquation[x] = find_CalcEquation(parent_CalcEquation[x]);
                weight_CalcEquation[x] = weight_CalcEquation[x] * weight_CalcEquation[tmp];
                return parent_CalcEquation[x];
            }
        }
        public void merge_CalcEquation(int i, int j, double num)
        {
            int x = find_CalcEquation(i);
            int y = find_CalcEquation(j);

            parent_CalcEquation[x] = y;
            weight_CalcEquation[x] = weight_CalcEquation[j] * num / weight_CalcEquation[i];
        }

        public int NearestExit(char[][] maze, int[] entrance)
        {
            int m = maze.Length;
            int n = maze[0].Length;
            //上下左右四个相邻坐标对应的行列变化量
            List<int> dx = new List<int> { 1, 0, -1, 0 };
            List<int> dy = new List<int> { 0, 1, 0, -1 };
            Queue<(int, int, int)> queueMaze = new Queue<(int, int, int)>();
            //入口加入队列并修改为墙
            queueMaze.Enqueue((entrance[0], entrance[1], 0));
            maze[entrance[0]][entrance[1]] = '+';
            while (queueMaze.Count != 0)
            {
                (int cx, int cy, int d) = queueMaze.Dequeue();
                //遍历四个方向相邻坐标
                for (int k = 0; k < 4; k++)
                {
                    int nx = cx + dx[k];
                    int ny = cy + dy[k];
                    //新坐标合法且不为墙
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && maze[nx][ny] == '.')
                    {
                        if (nx == 0 || nx == m - 1 || ny == 0 || ny == n - 1)
                            //新坐标为出口，返回距离作为答案
                            return d + 1;
                        //新坐标为空格子且不为出口，修改为墙并加入队列
                        maze[nx][ny] = '+';
                        queueMaze.Enqueue((nx, ny, d + 1));
                    }
                }
            }

            //不存在到出口的路径，返回 -1
            return 0;
        }

        public int OrangeRotting(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int fineNum = 0;
            int time = 0;
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { 1, 0, -1, 0 };
            Queue<(int, int)> rotQueue = new Queue<(int, int)>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 2)
                        rotQueue.Enqueue((i, j));
                    else if (grid[i][j] == 1)
                        fineNum++;
                }
            }
            //添加队列一轮标签
            rotQueue.Enqueue((-1, -1));
            while (rotQueue.Count > 0)
            {
                (int ox, int oy) = rotQueue.Dequeue();
                if (ox == -1 && rotQueue.Count != 0)
                {
                    time++;
                    rotQueue.Enqueue((-1, -1));
                    continue;
                }
                for (int k = 0; k < 4; k++)
                {
                    int nx = ox + dx[k];
                    int ny = oy + dy[k];
                    if (nx >= 0 && nx < m && ny >= 0 && ny < n && grid[nx][ny] == 1)
                    {
                        grid[nx][ny] = 2;
                        rotQueue.Enqueue((nx, ny));
                        fineNum--;
                    }
                }
            }
            if (fineNum > 0)
                return -1;
            else
                return time;
        }

        public int FindKthLargest(int[] nums, int k)
        {
            int heapSize = nums.Length;
            buildMaxHeap(nums, heapSize);
            //建堆完毕后，nums[0]为最大元素，逐个删除堆顶元素，直到删除了k-1个
            for (int i = nums.Length - 1; i > nums.Length - k + 1; i--)
            {
                //先将堆的最后一个元素鱼堆顶元素交换，由于此时堆的性质破坏，需要堆节点的性质进行维护更新
                swap(nums, 0, i);
                //相当于删除堆顶元素，此时长度变为nums.length - 2，即下次循环的i
                heapSize--;
                maxHeapify(nums, 0, heapSize);
            }
            return nums[0];
        }
        public void buildMaxHeap(int[] nums, int heapSize)
        {
            //从最后一个父节点位置开始调整每一个节点的子树
            //数组长度为heapsize，因此最后一个节点的位置为heapsize-1，所以父节点的位置为heapsize-1-1/2
            for (int i = (heapSize - 2) / 2; i >= 0; i--)
                maxHeapify(nums, i, heapSize);
        }
        public void maxHeapify(int[] nums, int i, int heapSize)
        {
            //left和right表示当前父节点i的两个左右子节点
            int left = i * 2 + 1, right = i * 2 + 2, largest = i;
            //如果左子节点在数组内，且比当前父节点大，则将最大值的指针指向左子节点
            if (left < heapSize && nums[left] > nums[largest])
                largest = left;
            //如果右子节点在数组内，且比当前父节点大，则将最大值的指针指向右子节点
            if (right < heapSize && nums[right] > nums[largest])
                largest = right;
            //如果最大值的指针不是父节点，则交换父节点和当前最大值指针指向的子节点
            if (largest != i)
            {
                swap(nums, i, largest);
                //由于交换了父节点和子节点，因此可能堆子节点的树造成影响，所以对子节点的树进行调整
                maxHeapify(nums, largest, heapSize);
            }
            
        }
        public void swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

        #region 无限集合最小正整数
        HashSet<int> finiteSet = new HashSet<int>();
        int setMin = 1;
        public void SmallestInfiniteSet()
        {
            finiteSet = new HashSet<int>();
        }
        public int PopSmallest()
        {
            int res = setMin;
            finiteSet.Add(setMin);
            while (finiteSet.Contains(setMin))
                setMin++;
            return res;
        }
        public void AddBack(int num)
        {
            if (finiteSet.Contains(num))
            {
                finiteSet.Remove(num);
                if (num < setMin)
                    setMin = num;
            }               
        }
        #endregion

        public long MaxScore(int[] nums1, int[] nums2, int k)
        {
            long maxScore = 0;
            int n = nums1.Length;
            List<(int, int)> listNums = new List<(int, int)>();
            for (int i = 0; i < n; i++)            
                listNums.Add((nums1[i], nums2[i]));
            var sortedListNums = listNums.OrderByDescending(x => x.Item2).ToList();
            PriorityQueue<int, int> priorityNums1 = new PriorityQueue<int, int>();
            long sum = 0;
            long minimum = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (i >= k)
                {
                    int prev = priorityNums1.Dequeue();
                    sum -= prev;
                }
                (int,int) values = sortedListNums[i];
                priorityNums1.Enqueue(values.Item1, values.Item1);
                sum += values.Item1;
                minimum = values.Item2;
                if (i >= k - 1)
                {
                    long currScore = sum * minimum; 
                    maxScore = Math.Max(currScore, maxScore);
                }
            }
            return maxScore;
        }

        public long TotalCost(int[] costs, int k, int candidates)
        {
            int n = costs.Length;
            int before = candidates;
            int after = n - candidates - 1;
            long sum = 0;
            PriorityQueue<int, int> queueBefore = new PriorityQueue<int, int>();
            PriorityQueue<int, int> queueAfter = new PriorityQueue<int, int>();
            // two priorityQueue
            if (n < 2 * candidates)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i < candidates)
                        queueBefore.Enqueue(costs[i], costs[i]);
                    else
                        queueAfter.Enqueue(costs[i], costs[i]);
                }
            }
            else
            {
                for (int i = 0; i < candidates; i++)
                {
                    queueBefore.Enqueue(costs[i], costs[i]);
                    queueAfter.Enqueue(costs[n - i - 1], costs[n - i - 1]);
                }
            }

            while (k > 0)
            {
                int peekBefore = 100001;
                int peekAfter = 100001;
                if (queueBefore.Count > 0)
                    peekBefore = queueBefore.Peek();
                if (queueAfter.Count > 0)
                    peekAfter = queueAfter.Peek();
                if (peekBefore <= peekAfter)
                {
                    sum += peekBefore;
                    queueBefore.Dequeue();
                    if (before <= after)
                    {
                        queueBefore.Enqueue(costs[before], costs[before]);
                        before++;
                    }
                }
                else
                {
                    sum += peekAfter;
                    queueAfter.Dequeue();
                    if (after >= before)
                    {
                        queueAfter.Enqueue(costs[after], costs[after]);
                        after--;
                    } 
                }
                k--;
            }

            return sum;
        }

        public int GuessNumber(int n,int realNum)
        {
            int guessNum = 0;
            int guessResult = 2;
            int bigNum = n;
            int smallNum = 1;
            while (guessResult != 0)
            {
                guessNum = (bigNum - smallNum) / 2 + smallNum;
                guessResult = guess(guessNum, realNum);
                if (guessResult == 1)
                    smallNum = guessNum + 1;
                else if (guessResult == -1)
                    bigNum = guessNum - 1;
                else
                    continue;
            }
            return guessNum;
        }
        private int guess(int guessNum, int realNum)
        {
            if (guessNum > realNum)
                return -1;
            else if (guessNum < realNum)
                return 1;
            else
                return 0;
        }

        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            // 优化解法为potions数组排序，遍历spells数组内容，对potions使用二分解法
            int m = spells.Length;
            int n = potions.Length;
            int[] result = new int[m];
            List<(int, int)> spellList = new List<(int, int)>();
            for (int i = 0; i < m; i++)
                spellList.Add((spells[i], i));
            var spellSorted = spellList.OrderBy(x => x.Item1).ToList(); //升序排列
            Array.Sort(potions);
            Array.Reverse(potions); //降序排列

            int tmpPotion = 0;
            int tmpSuccess = 0;
            for (int i = 0; i < m; i++)
            {
                while (tmpPotion < n && (long)spellSorted[i].Item1 * (long)potions[tmpPotion] >= success)
                {
                    tmpSuccess++;
                    tmpPotion++;
                }
                result[spellSorted[i].Item2] = tmpSuccess;
            }

            return result;
        }

        public int FindPeakElement(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return 0;
            else
            {
                for (int i = 1; i < n; i++)
                {
                    if (nums[i - 1] < nums[i])
                        continue;
                    else
                        return i - 1;
                }
                return n - 1;
            }            
        }

        public int MinEatingSpeed(int[] piles, int h)
        {
            int left = 1, right = 0;
            foreach (var pile in piles)
                right = Math.Max(right, pile);
            int properSpeed = right;
            while (right > left)
            {
                int speed = (left - right) / 2 + left;
                long currTime = Time_MinEatingSpeed(piles, speed);
                if (currTime <= h)
                {
                    properSpeed = speed;
                    right = speed;
                }
                else
                    left = speed + 1;
            }
            return 0;
        }
        // 弃用，问题被复杂化
        private int[] SpeedModify(int[] nums, int[] piles, int h)
        {         
            int nN = nums.Length;
            int nP = piles.Length;
            int leftNum = 0;
            int rightNum = nN - 1;
            int currentNum = 0;
            // 判断左右端点
            double leftTime = Time_MinEatingSpeed(piles, nums[leftNum]);
            double rightTime = Time_MinEatingSpeed(piles, nums[rightNum]);
            // 左端点小于给定时间
            if (leftTime < h)
            {
                int[] arrayReturnLeft = { -1, 0};
                return arrayReturnLeft;
            }
            // 右端点大于给定时间（不存在该情况）
            // 左右端点等于给定时间
            if (leftTime == h)
            {
                int[] arrayReturnLeft = { 0, 0};
                return arrayReturnLeft;
            }
            if (rightTime == h)
            {
                int[] arrayReturnRight = { nN - 1, nN - 1};
                return arrayReturnRight;
            }

            // 其余情况
            while (rightNum - leftNum > 1)
            {
                currentNum = (leftNum + rightNum) / 2;
                double currTime = Time_MinEatingSpeed(piles, nums[currentNum]);
                if (currTime < h)
                    rightNum = currentNum;
                else if (currTime > h)
                    leftNum = currentNum;
                else
                {
                    int[] arrayReturn1 = { currentNum,currentNum};
                    return arrayReturn1;
                }                    
            }
            int[] arrayReturn2 = { leftNum, rightNum};
            return arrayReturn2;
        }
        private long Time_MinEatingSpeed(int[] piles, long speed)
        {
            int n = piles.Length;
            long timeCost = 0;
            for (int i = 0; i < n; i++)            
                timeCost += (piles[i] + speed - 1)/ speed;            
            return timeCost;
        }

        public IList<string> LetterCombinations(string digits)
        {
            int n = digits.Length;
            IList<string> oldList = new List<string>();
            IList<string> newList = new List<string>();
            if (n == 0)
                return oldList;
            string buttonFirst = Dic_LetterCombinations(digits[0]);
            foreach (char digit in buttonFirst)
                oldList.Add(digit.ToString());
            for (int i = 1; i < n; i++)
            {
                string buttonString = Dic_LetterCombinations(digits[i]);
                foreach (char buttonChar in buttonString)
                {
                    foreach (var oldString in oldList)
                        newList.Add(string.Concat(oldString, buttonChar));
                }
                oldList = newList;
                newList = new List<string>();
            }
            return oldList;
        }
        private string Dic_LetterCombinations(char num)
        {
            Dictionary<char, string> keyValuePairs = new Dictionary<char, string>
            {
                { '2', "abc"},
                { '3', "def" },
                { '4', "ghi"},
                { '5', "jkl"},
                { '6', "mno"},
                { '7', "pqrs"},
                { '8', "tuv"},
                { '9', "wxyz"}
            };
            return keyValuePairs[num];
        }

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            combinationLists = new List<IList<int>>();
            resList = new List<int>();
            for (int i = 0; i < k; i++)
                resList.Add(0);
            Choose_CombinationsSum3(1, 0, k, n);
            return combinationLists;
        }
        private IList<IList<int>> combinationLists;
        private List<int> resList;
        private void Choose_CombinationsSum3(int num, int sum,int k, int n)
        {
            if (k == 0 && sum == n)
            {
                //返回结果
                List<int> currList = new (resList);
                combinationLists.Add(currList);
                return;
            }
            else if (k == 0)
                return;
            else
            {
                for (int i = num; i <= 9; i++)
                {
                    int tmpSum = sum + i;
                    if (tmpSum > n)
                        break;
                    resList[k - 1] = i;
                    Choose_CombinationsSum3(i + 1, tmpSum, k - 1, n);
                }
                return;
            }
        }

        public int Tribonacci(int n)
        {
            //Queue<int> TriQueue = new Queue<int>(new int[] { 0, 1, 1 });
            //int tempOne = 0;
            //int tempThree;
            //int tempSum = 2;
            //for(int i = 0; i < n; i++)
            //{
            //    tempOne = TriQueue.Dequeue();
            //    tempThree = tempSum;
            //    tempSum = tempSum + tempThree - tempOne;
            //    TriQueue.Enqueue(tempThree);
            //}
            //return tempOne;

            // 优化代码如下
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;

            int[] triArray = new int[n + 1];
            triArray[0] = 0;
            triArray[1] = 1;
            triArray[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                triArray[i] = triArray[i - 1] + triArray[i - 2] + triArray[i - 3];
            }

            return triArray[n];
        }

        public int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            int prev = 0; int curr = 0;
            for (int i = 2; i <= n; i++)
            {
                int next = Math.Max(curr + cost[i - 1], prev + cost[i - 2]);
                prev = curr;
                curr = next;
            }
            return curr;
        }

        public int Rob(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            int prev = 0; int curr = nums[0];
            for(int i = 1; i < n; i++)
            {
                int next = Math.Max(curr, prev + nums[i]);
                prev = curr;
                curr = next;
            }
            return curr;
        }

        public int NumTilings(int n)
        {
            // 存在取模操作，防止整数溢出
            long mod = 1000000007;
            long[] resultNums = new long[n + 1];
            resultNums[0] = 1;
            resultNums[1] = 1;
            long tmpSum = 0;
            if (n == 1)
                return (int)resultNums[1];
            for(int i = 2; i < n + 1; i++)
            {
                resultNums[i] = (resultNums[i - 2] + resultNums[i - 1] + tmpSum * 2) % mod;
                tmpSum += resultNums[i - 2];
            }                            
            return (int)resultNums[n];
        }

        public int UniquePaths(int m, int n)
        {
            //int[,] pathNum = new int[m, n];
            //pathNum[0, 0] = 1;
            //for(int i = 0; i < m; i++)
            //{
            //    for(int j = 0; j < n; j++)
            //    {
            //        if (j == 0 || i == 0)
            //            pathNum[i, j] = 1;
            //        else
            //            pathNum[i, j] = pathNum[i, j - 1] + pathNum[i - 1, j];
            //    }
            //}
            //return pathNum[m - 1, n - 1];

            //内存优化
            int[] pathNums = new int[n];
            for(int i = 0; i < n; i++)            
                pathNums[i] = 1;
            for(int i = 1; i < m; i++)
            {
                for(int j = 1; j < n; j++)                
                    pathNums[j] += pathNums[j - 1];                
            }
            return pathNums[n - 1];
        }

        public int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length;
            int n = text2.Length;
            int[,] sequenceNum = new int[m + 1, n + 1];
            for(int i = 1; i <= m; i++)
            {
                char char_text1 = text1[i - 1];
                for(int j = 1; j <= n; j++)
                {
                    char char_text2 = text2[j - 1];
                    if (char_text1 == char_text2)
                        sequenceNum[i, j] = sequenceNum[i - 1, j - 1] + 1;
                    else
                        sequenceNum[i, j] = Math.Max(sequenceNum[i - 1, j], sequenceNum[i, j - 1]);
                }
            }
            return sequenceNum[m, n];
        }

        //收取手续费
        public int MaxProfit(int[] prices, int fee)
        {
            // 未使用动态规划
            int n = prices.Length;
            int min = prices[0];
            int max = prices[0];
            int maxProfit = 0;
            for (int i = 1; i < n; i++)
            {
                int currPrice = prices[i];
                if (currPrice < min || currPrice + fee <= max)
                {
                    maxProfit = Math.Max(maxProfit, maxProfit + max - min - fee);
                    min = currPrice;
                    max = currPrice;
                }
                else if (currPrice > max)
                    max = currPrice;
                else
                    continue;
            }
            if (max - min - fee > 0)
                maxProfit += max - min - fee;
            return maxProfit;
        }

        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            int[,] dp = new int[m + 1, n + 1];
            dp[0, 0] = 0;
            for (int i = 1; i < m + 1; i++)
                dp[i, 0] = i;
            for (int i = 1; i < n + 1; i++)
                dp[0, i] = i;
            for(int i = 1; i< m + 1; i++)
            {
                for(int j = 1; j < n + 1; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;                    
                }
            }
            return dp[m, n];
        }

        public int[] CountBits(int n)
        {
            int[] oneCount = new int[n + 1];
            oneCount[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                    oneCount[i] = oneCount[i / 2];
                else
                    oneCount[i] = oneCount[i - 1] + 1;
            }
            return oneCount;
        }

        public int SingleNumber(int[] nums)
        {
            //计算机中，整数通常以二进制形式进行表示和处理。因此，可以利用异或运算来处理整数
            int result = 0;
            foreach (var num in nums )
                result ^= num;            
            return result;
        }

        public int MinFlips(int a, int b, int c)
        {
            int num = 0;
            for (int i = 0; i < 31; i++)
            {
                int bit_a = (a >> i) & 1;
                int bit_b = (b >> i) & 1;
                int bit_c = (c >> i) & 1;
                if (bit_c == 0)
                    num += bit_a + bit_b;
                else
                    num += Convert.ToInt32(bit_a + bit_b == 0);
            }
            return num;
        }

        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            // 使用自带StartsWith定义方法，可使用二分搜索法进一步优化
            Array.Sort(products);
            IList<IList<string>> returnLists = new List<IList<string>>();
            for (int i = 1; i <= searchWord.Length; i++)
            {
                string subString = searchWord[..i];
                List<string> subList = new List<string>();
                foreach (string product in products)
                {
                    if (product.StartsWith(subString))
                        subList.Add(product);
                    if (subList.Count == 3)
                        break;                        
                }
                returnLists.Add(subList);
            }
            return returnLists;
        }

        public int EraseOverlapIntervals(int[][] intervals) 
        {
            // 修正为先排序，而后保留重合区域中最右端端点更小的，但空间、时间复杂度高，可进一步修正
            //List<Interval> FittedInterval = new List<Interval>();
            //var sortedIntervals = intervals.OrderBy(intervals => intervals[0]).ToArray();
            //foreach (var numSet in sortedIntervals)
            //{
            //    Interval overlappingIntervals = FittedInterval.Find(x =>
            //        (x.Start < numSet[1] && x.End > numSet[0]));
            //    if (overlappingIntervals == null)
            //    {
            //        Interval fitInterval = new Interval(numSet[0], numSet[1]);
            //        FittedInterval.Add(fitInterval);
            //    }
            //    else
            //    {
            //        if (numSet[1] >= overlappingIntervals.End)
            //            continue;
            //        else
            //        {
            //            FittedInterval.Remove(overlappingIntervals);
            //            Interval fitInterval = new Interval(numSet[0], numSet[1]);
            //            FittedInterval.Add(fitInterval);
            //        }
            //    }
            //}
            //return intervals.Length - FittedInterval.Count;

            // 动态规划算法优化
            if (intervals.Length == 0)
            {
                return 0;
            }

            Array.Sort(intervals, (a, b) => a[1] - b[1]);

            int n = intervals.Length;
            int right = intervals[0][1];
            int ans = 1;
            for (int i = 1; i < n; ++i)
            {
                if (intervals[i][0] >= right)
                {
                    ++ans;
                    right = intervals[i][1];
                }
            }

            return n - ans;
        }

        public int FindMinArrowShots(int[][] points)
        {
            if (points.Length == 0)
                return 0;
            Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));
            int pos = points[0][1];
            int ans = 1;
            foreach(var balloon in points)
            {
                if (balloon[0] > pos)
                {
                    pos = balloon[1];
                    ans++;
                }
            }

            return ans;
        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] result = new int[n];
            Stack<int> tmpTemp = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                while (tmpTemp.Count > 0 && temperatures[i] > temperatures[tmpTemp.Peek()])
                {
                    int index = tmpTemp.Pop();
                    result[index] = i - index;
                }
                tmpTemp.Push(i);
            }
            return null;
        }

        private Stack<Tuple<int, int>> stack;
        int idx;
        public void StockSpanner()
        {
            stack = new Stack<Tuple<int, int>>();
            stack.Push(new Tuple<int, int>(-1, int.MaxValue));
            idx = -1;
        }
        public int Next(int price)
        {
            idx++;
            while (price >= stack.Peek().Item2)
                stack.Pop();
            int ret = idx - stack.Peek().Item1;
            stack.Push(new Tuple<int, int>(idx, price));
            return ret;
        }

        public int FindContentChildren(int[] g, int[] s)
        {
            int nG = g.Length;
            int nS = s.Length;
            Array.Sort(g);
            Array.Sort(s);
            int tmpG = 0;
            int tmpS = 0;
            while (tmpG < nG && tmpS < nS)
            {
                if (g[tmpG] <= s[tmpS])
                {
                    tmpG++;
                    tmpS++;
                }
                else
                    tmpS++;
            }
            return tmpG;
        }

        public char[] ReverseString(char[] s)
        {
            int n = s.Length;
            int before = 0;
            int after = n - 1;
            while (before < after)
            {
                char tmp = s[before];
                s[before] = s[after];
                s[after] = tmp;
                before++;
                after--;
            }                
            return s;
        }

        public int MajorityElement(int[] nums)
        {
            //Array.Sort(nums);
            //int n = nums.Length;
            //int currNum = nums[0];
            //int numStart = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    if (currNum == nums[i] && i < n - 1)
            //        continue;
            //    else
            //    {
            //        int numCount = i - numStart;
            //        if (numCount > n / 2)
            //            break;
            //        else
            //        {
            //            currNum = nums[i];
            //            numStart = i - 1;
            //        }
            //    }
            //}
            //return currNum;

            // 代码优化
            Array.Sort(nums);
            int n = nums.Length;
            return nums[n / 2];
        }

        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int longestLength = 0;
            int start = 0;
            HashSet<char> subStringDic = new HashSet<char>();
            for (int i = 0; i < n; i++)
            {
                if (subStringDic.Contains(s[i]))
                {
                    subStringDic.Remove(s[i]);
                    start++;
                }
                subStringDic.Add(s[i]);
                longestLength = Math.Max(longestLength, i - start + 1);
            }           

            return longestLength;
        }

        public int[] Merge(int[] nums1, int m, int[] nums2, int n)
        {
            #region Original Code
            //if (n == 0)
            //    nums1 = nums1;
            //else
            //{
            //    int p1 = 0;
            //    int p2 = 0;
            //    Queue<int> tmpQueue = new Queue<int>();
            //    int minNum = int.MaxValue;
            //    while (p1 < m + n)
            //    {
            //        if (p1 < n)
            //            nums1[p1 + m] = int.MaxValue;

            //        if (p2 < n)
            //        {
            //            if (tmpQueue.Count != 0)
            //                minNum = Math.Min(Math.Min(nums1[p1], nums2[p2]), tmpQueue.Peek());
            //            else
            //                minNum = Math.Min(nums1[p1], nums2[p2]);

            //            if (minNum == nums1[p1])
            //                p1++;
            //            else if (minNum == nums2[p2])
            //            {
            //                tmpQueue.Enqueue(nums1[p1]);
            //                nums1[p1] = nums2[p2];
            //                p1++;
            //                p2++;
            //            }
            //            else
            //            {
            //                tmpQueue.Enqueue(nums1[p1]);
            //                nums1[p1] = tmpQueue.Dequeue();
            //                p1++;
            //            }
            //        }
            //        else
            //        {
            //            while (p1 < m + n)
            //            {
            //                tmpQueue.Enqueue(nums1[p1]);
            //                nums1[p1] = tmpQueue.Dequeue();
            //                p1++;
            //            }
            //        }
            //    }
            //}
            //return nums1;
            #endregion

            // Code Optimization: Start from the end of the array
            int p1 = m - 1; // Pointer for nums1
            int p2 = n - 1; // Pointer for nums2
            int p = m + n - 1; // Pointer for merged array

            while (p1 >= 0 && p2 >= 0)
            {
                if (nums1[p1] > nums2[p2])
                {
                    nums1[p] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[p] = nums2[p2];
                    p2--;
                }
                p--;
            }

            // If there are remaining elements in nums2
            while (p2 >= 0)
            {
                nums1[p] = nums2[p2];
                p2--;
                p--;
            }

            return nums1;
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;
            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);
            bool even = false;
            while (nodeQueue.Count > 0)
            {
                List<int> levelLlist = new List<int>();
                int queueCount = nodeQueue.Count;
                for (int i = 0; i < queueCount; i++)
                {
                    TreeNode tmpNode = nodeQueue.Dequeue();
                    levelLlist.Add(tmpNode.val);
                    if (tmpNode.left != null)
                        nodeQueue.Enqueue(tmpNode.left);
                    if (tmpNode.right != null)
                        nodeQueue.Enqueue(tmpNode.right);
                }
                if (even)
                    levelLlist.Reverse(); // Reverse the list in-place
                result.Add(levelLlist);
                even = !even;
            }
            return result;
        }

        public int Search(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                if (nums[middle] == target)
                    return middle;
                else if (nums[start] <= nums[middle])
                {
                    //左半边有序
                    if (target >= nums[start] && target <= nums[middle])
                        end = middle - 1;
                    else
                    {
                        start = middle + 1;
                    }
                }
                else
                {
                    //右半边有序
                    if (target > nums[middle] && target <= nums[end])
                    {
                        start = middle + 1;
                    }
                    else
                        end = middle - 1;
                }
            }
            return -1;           
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            //超时
            #region 暴力代码
            //Array.Sort(nums);
            //IList<IList<int>> sumLists = new List<IList<int>>();
            //HashSet<Tuple<int,int,int>> sumSets = new HashSet<Tuple<int, int, int>>();
            //int n = nums.Length;
            //for (int i = 0; i < n - 2; i++)
            //{
            //    for (int j = i + 1; j < n - 1; j++)
            //    {
            //        for (int k = j + 1; k < n; k++)
            //        {
            //            if (nums[i] + nums[j] + nums[k] == 0)
            //            {
            //                var tmpTuple = Tuple.Create(nums[i], nums[j], nums[k]);
            //                if (!sumSets.Contains(tmpTuple))
            //                {
            //                    sumLists.Add(new List<int> { nums[i], nums[j], nums[k] });
            //                    sumSets.Add(tmpTuple);
            //                }

            //            }

            //        }
            //    }
            //}
            //return sumLists;
            #endregion

            //代码优化
            //三数之和可以看作一个数加上一个两数之和，两数之和可以使用双指针
            IList<IList<int>> sumLists = new List<IList<int>>();
            int n = nums.Length;
            Array.Sort(nums);
            for (int i = 0; i < n - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1])) //避免重复
                {
                    int left = i + 1;
                    int right = n - 1;
                    int target = -nums[i];

                    while (left < right)
                    {
                        int sum = nums[left] + nums[right];
                        if (sum == target)
                        {
                            sumLists.Add(new List<int> { nums[i], nums[left], nums[right] });
                            //避免重复
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;
                            left++;
                            right--;
                        }
                        else if (sum< target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }

            return sumLists;
        }

        public List<int> ReverseKGroup(List<int> numsBefore, int k)
        {
            #region 前处理：将数组转换为ListNode类
            ListNode head;

            ListNode dummy = new ListNode(0); // 创建一个虚拟节点作为链表的头节点
            ListNode current = dummy;

            foreach (int num in numsBefore)
            {
                ListNode newNode = new ListNode(num);
                current.next = newNode;
                current = current.next;
            }
            head = dummy.next;
            #endregion

            //逻辑代码内容
            ListNode dummyNode = new ListNode(0);
            dummyNode.next = head;
            ListNode prevNode = dummyNode;
            while (true)
            {
                //检查剩余节点是否有k个，不足则返回
                ListNode last = prevNode;
                for (int i = 0; i < k; i++)
                {
                    last = last.next;
                    if (last == null)
                        goto ExitLoop; //跳出循环
                }

                //翻转k个节点
                ListNode curr = prevNode.next;
                ListNode next;
                for (int i = 0; i < k - 1; i++)
                {
                    next = curr.next;
                    curr.next = next.next;
                    next.next = prevNode.next;
                    prevNode.next = next;
                }
                prevNode = curr;
            }

            ExitLoop: //循环跳出位置

            ListNode returnNode = dummyNode.next;
            //后处理：将ListNode类转换为数组
            List<int> numsAfter = new List<int>();
            while (returnNode != null)
            {
                numsAfter.Add(returnNode.val);
                returnNode = returnNode.next;
            }

            return numsAfter;
        }

        int gridRow = 0;
        int gridColumn = 0;
        public int NumIslands(char[][] grid)
        {
            int countNum = 0;            
            gridRow = grid.Length;
            gridColumn = grid[0].Length;
            for (int i = 0; i < gridRow; i++)
            {
                for (int j = 0; j < gridColumn; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        countNum++;
                        DFS_NumIslands(grid, i, j);
                    }
                }
            }    

            return countNum;
        }
        private void DFS_NumIslands(char[][] grid, int r, int c)
        {
            grid[r][c] = '0';
            if (r + 1 < gridRow && grid[r + 1][c] == '1')
                DFS_NumIslands(grid, r + 1, c);
            if (c + 1 < gridColumn && grid[r][c + 1] == '1')
                DFS_NumIslands(grid, r, c + 1);
            if (r - 1 >= 0 && grid[r - 1][c] == '1')
                DFS_NumIslands(grid, r - 1, c);
            if (c - 1 >= 0 && grid[r][c - 1] == '1')
                DFS_NumIslands(grid, r, c - 1);
        }

        public int[] NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }

            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (j >= 0 && nums[j] <= nums[i])
                {
                    j--;
                }
                Swap_NextPermutation(nums, i, j);
            }

            Reverse_NextPermutation(nums, i + 1, nums.Length - 1);

            return nums;
        }

        private void Swap_NextPermutation(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        private void Reverse_NextPermutation(int[] nums, int start, int end)
        {
            while (start < end)
            {
                Swap_NextPermutation(nums, start, end);
                start++;
                end--;
            }
        }
        #region NextPermutation算法重写
        public int[] NextPermutation_redone(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
                i--;
            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (j >= 0 && nums[j] <= nums[i])
                    j--;
                Swap_redone(nums, i, j);
            }
            Reverse_redone(nums, i + 1, nums.Length - 1);

            return null;
        }

        private void Swap_redone(int[] nums, int m, int n)
        {
            int temp = nums[m];
            nums[m] = nums[n];
            nums[n] = temp;
        }

        private void Reverse_redone(int[] nums, int m, int n)
        {
            while (m < n)
            {
                Swap_redone(nums, m, n);
                m++;
                n--;
            }
        }
        #endregion

        public int PeakIndexInMountainArray(int[] arr)
        {
            #region IsPeak函数添加
            //int start = 0;
            //int end = arr.Length - 1;
            //int middle = start + (end - start) / 2;
            //while (start < end)
            //{
            //    int isPeak = IsPeak(arr, middle);
            //    if (isPeak == -1)
            //        start = middle;
            //    else if (isPeak == 1)
            //        end = middle;
            //    else
            //        break;
            //    middle = start  + (end - start) / 2;
            //}
            //return middle;
            #endregion

            // 二分查找法，直接比较中间与右边数值
            int start = 0;
            int end = arr.Length - 1;

            while (start < end)
            {
                int middle = start + (end - start) / 2;
                if (arr[middle] < arr[middle + 1])
                    start = middle + 1;
                else
                    end = middle;
            }

            return start;
        }
        private int IsPeak(int[] arr, int n)
        {
            //0为peak，-1为peak在右边，1为peak在左边
            int left = (n > 0) ? arr[n - 1] : int.MinValue;
            int right = (n < arr.Length - 1) ? arr[n + 1] : int.MinValue;

            if (left < arr[n] && right < arr[n])
                return 0;
            else if (left < arr[n] && right > arr[n])
                return -1;
            else // (left > arr[n] && right < arr[n])
                return 1;
        }

        public List<int> ReverseBetween(List<int> nums, int left, int right)
        {
            #region 前处理：将数组转换为ListNode类
            ListNode head;

            ListNode dummy = new ListNode(0); // 创建一个虚拟节点作为链表的头节点
            ListNode current = dummy;

            foreach (int num in nums)
            {
                ListNode newNode = new ListNode(num);
                current.next = newNode;
                current = current.next;
            }
            head = dummy.next;
            #endregion

            ListNode dummyNode = new ListNode(0);
            dummyNode.next = head;
            ListNode prev = dummyNode;

            for (int i = 0; i < left - 1; i++)
                prev = prev.next;

            ListNode currNode = prev.next;
            ListNode next;
            for (int i = 0; i < right - left; i++)
            {
                if (currNode == null || currNode.next == null)
                    break;

                next = currNode.next;
                currNode.next = next.next;
                next.next = prev.next;
                prev.next = next;
            }

            ListNode returnNode = dummyNode.next;          
            //后处理：将ListNode类转换为数组
            List<int> numsAfter = new List<int>();
            while (returnNode != null)
            {
                numsAfter.Add(returnNode.val);
                returnNode = returnNode.next;
            }

            return numsAfter;
        }

        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            #region 暴力搜索

            //List<int>[] path = new List<int>[n];
            //for (int i = 0; i < n; i++)
            //    path[i] = new List<int>();
            //for (int i = 0; i < edges.Length; i++)
            //{
            //    path[edges[i][0]].Add(edges[i][1]);
            //    path[edges[i][1]].Add(edges[i][0]);
            //}
            //int minDepth = n + 5;
            //List<int> ans = new List<int>();
            //for (int i = 0; i < n; i++)
            //{
            //    int d = MaxDepth_FineMinHeightTrees(i, new bool[n], path);
            //    if (minDepth == d)
            //        ans.Add(i);
            //    else if (minDepth > d)
            //    {
            //        minDepth = d;
            //        ans = new List<int>();
            //        ans.Add(i);
            //    }
            //}

            #endregion

            //算法优化
            List<int> res = new List<int>();
            if (n == 1)
            {
                res.Add(0);
                return res;
            }

            int[] degree = new int[n];
            List<List<int>> map = new List<List<int>>();
            for (int i = 0; i < n; i++)
                map.Add(new List<int>());
            foreach (int[] edge in edges)
            {
                degree[edge[0]]++;
                degree[edge[1]]++;
                map[edge[0]].Add(edge[1]);
                map[edge[1]].Add(edge[0]);
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (degree[i] == 1)
                    queue.Enqueue(i);
            }
            while (queue.Count != 0)
            {
                res = new List<int>();
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int cur = queue.Dequeue();
                    res.Add(cur);
                    List<int> neighbors = map[cur];
                    foreach (int neighbor in neighbors)
                    {
                        degree[neighbor]--;
                        if (degree[neighbor] == 1)
                            queue.Enqueue(neighbor);
                    }
                }
            }
            return res;
        }
        private int MaxDepth_FineMinHeightTrees(int root, bool[] cameBefore, List<int>[] path)
        {
            if (cameBefore[root])
                return -1;
            cameBefore[root] = true;
            int ans = -1;
            List<int> list = path[root];
            foreach (var neighbor in list)
            {
                ans = Math.Max(ans, MaxDepth_FineMinHeightTrees(neighbor, cameBefore, path));
            }
            return ans + 1;
        }

        //不收取手续费
        public int MaxProfit(int[] prices)
        {
            #region 原始代码
            //int n = prices.Length;
            //if (n == 0) return 0;
            //int maxProfit = 0;
            //int minPrice = prices[0];
            //for (int i = 1; i < n; i++)
            //{
            //    minPrice = Math.Min(minPrice, prices[i - 1]);
            //    maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
            //}

            //return maxProfit > 0 ? maxProfit : 0;
            #endregion

            //优化代码
            int maxProfit = 0;
            int minPrice = int.MaxValue;

            foreach (int price in prices)
            {
                minPrice = Math.Min(minPrice, price);
                maxProfit = Math.Max(maxProfit, price - minPrice);
            }

            return maxProfit;
        }

        public char FindTheDifference(string s, string t)
        {
            #region 原始代码
            //string sortedS = new string(s.OrderBy(c => c).ToArray());
            //string sortedT = new string(t.OrderBy(c => c).ToArray());
            //int n = sortedS.Length;
            //for (int i = 0; i < n; i++)
            //{
            //    if (sortedS[i] == sortedT[i])
            //        continue;
            //    else
            //        return sortedT[i];
            //}

            //return sortedT[n];
            #endregion

            //优化代码
            int[] charSet = new int[26];
            foreach (var ch in s)
            {
                charSet[ch - 'a']++;
            }

            foreach (var ch in t)
            {
                if (charSet[ch - 'a'] == 0)
                    return ch;
                charSet[ch - 'a']--;
            }

            return '0'; //确保所有路径都有返回值
        }

        public int StrStr(string haystack, string needle)
        {
            #region 原始代码
            int nL = haystack.Length;
            int nS = needle.Length;
            for (int i = 0; i < nL - nS + 1; i++)
            {
                int j = 0;
                while (haystack[i + j] == needle[j])
                {
                    if (j + 1 == nS)
                        return i;
                    else
                        j++;
                }
            }
            return -1;
            #endregion

            //优化代码：使用KMP算法，待学习
        }

        public bool IsAnagram(string s, string t)
        {
            //代码优化
            if (s.Length != t.Length)
                return false;

            int[] charSet = new int[26];
            foreach (var ch in s)
            {
                charSet[ch - 'a']++;
            }
            foreach (var ch in t)
            {
                if (charSet[ch - 'a'] == 0)
                    return false;
                charSet[ch - 'a']--;
            }

            return true;
        }

        public bool RepeatedSubstringPattern(string s)
        {
            //枚举法
            int n = s.Length;
            for (int i = 1; i * 2 <= n; i++)
            {
                if (n % i == 0)
                {
                    bool match = true;
                    for (int j = i; j < n; j++)
                    {
                        if (s[j] != s[j - i])
                        {
                            match = false; 
                            break;
                        }
                    }

                    if (match)
                        return true;
                }
            }

            return false;
        }

        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                digits[i]++;
                digits[i] = digits[i] % 10;
                if (digits[i] != 0)
                    return digits;
            }
            digits = new int[n + 1];
            digits[0] = 1;

            return digits;
        }

        public int ArraySign(int[] nums)
        {
            int product = 1;
            foreach (var num in nums)
            {
                if (num == 0)
                    return signFunc_ArraySign(0);
                else if (num > 0)
                    product = product * 1;
                else
                    product = product * -1;
            }
            return signFunc_ArraySign(product);
        }
        private int signFunc_ArraySign(int product)
        {
            if (product > 0)
                return 1;
            else if (product < 0) 
                return -1;
            else 
                return 0;
        }

        public bool CanMakeArithmeticProgression(int[] arr)
        {
            Array.Sort(arr);
            int n = arr.Length;
            int commonDifference = arr[1] - arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] - arr[i - 1] == commonDifference)
                    continue;
                else
                    return false;
            }
            return true;
        }

        public bool IsMonotonic(int[] nums)
        {
            int n = nums.Length;
            if (n == 1 || n == 2) return true;

            int start = 1;
            while (start < n && nums[start] == nums[start - 1])
                start++;
            if (start == n) return true;

            if (nums[start] > nums[start - 1])
            {
                for (int i = start;i < n; i++)
                {
                    if (nums[i] < nums[i - 1])
                        return false;
                }
            }
            else
            {
                for (int i = start;i < n; i++)
                {
                    if (nums[i] > nums[i - 1])
                        return false;
                }
            }

            return true;
        }
        private int IsMonotonic_Judge(int prev, int curr)
        {
            if (curr > prev)
                return 1;
            else if (curr < prev)
                return -1;
            else 
                return 0;
        }

        public int LengthOfLastWord(string s)
        {
            //var myArray = s.Split(" ");
            //string lastElement = myArray[myArray.Length - 1];
            //return lastElement.Length;

            int length = 0;
            int lastWordLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    length++;
                    lastWordLength = length;
                }
                else
                {
                    length = 0;
                }
            }

            return lastWordLength;
        }

        public string ToLowerCase(string s)
        {
            //使用内置函数
            return s.ToLower();
        }

        public int CalPoints(string[] operations)
        {
            Stack<int> stackPoints = new Stack<int>();
            foreach (var str in operations)
            {
                if (str == "+")
                {
                    int top = stackPoints.Pop();
                    int newtop = top + stackPoints.Peek();
                    stackPoints.Push(top);
                    stackPoints.Push(newtop);
                }
                else if (str == "D")
                {
                    int newtop = stackPoints.Peek() * 2;
                    stackPoints.Push(newtop);
                }
                else if (str == "C")
                {
                    stackPoints.Pop();
                }
                else
                {
                    stackPoints.Push(int.Parse(str));
                }
            }

            //int result = 0;
            //while (stackPoints.Count > 0)
            //{
            //    result += stackPoints.Pop();
            //}

            //return result;

            //代码优化
            return stackPoints.Sum();
        }

        public bool JudgeCircle(string moves)
        {
            #region 原始代码
            //int n = moves.Length;
            //if (n % 2 != 0)
            //    return  false;
            //Queue<char> horizontalQueue = new Queue<char>();
            //Queue<char> verticalQueue = new Queue<char>();
            //for (int i = 0; i < n; i++)
            //{
            //    if (moves[i] == 'L' || moves[i] == 'R')
            //    {
            //        if (horizontalQueue.Count == 0)
            //            horizontalQueue.Enqueue(moves[i]);
            //        else
            //        {
            //            if (moves[i] == horizontalQueue.Peek())
            //                horizontalQueue.Enqueue(moves[i]);
            //            else
            //                horizontalQueue.Dequeue();
            //        }                  
            //    }
            //    else
            //    {
            //        if (verticalQueue.Count == 0)
            //            verticalQueue.Enqueue(moves[i]);
            //        else
            //        {
            //            if (moves[i] == verticalQueue.Peek())
            //                verticalQueue.Enqueue(moves[i]);
            //            else
            //                verticalQueue.Dequeue();
            //        }
            //    }
            //}

            //return verticalQueue.Count == 0 && horizontalQueue.Count == 0;
            #endregion

            //优化代码
            int horizontal = 0;
            int vertical = 0;

            foreach (char move in moves)
            {
                if (move == 'L')
                {
                    horizontal--;
                }
                else if (move == 'R')
                {
                    horizontal++;
                }
                else if (move == 'U')
                {
                    vertical++;
                }
                else if (move == 'D')
                {
                    vertical--;
                }
            }

            return horizontal == 0 && vertical == 0;
        }

        public string Tictactoe(int[][] moves)
        {
            int n = moves.Length;
            if (n < 5)
                return "Pending";
            char[,] board = new char[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = 'E'; // 初始化为'E'
                }
            }

            bool IsX = true;
            foreach (var move in moves)
            {
                if (IsX)
                    board[move[0], move[1]] = 'X';                    
                else
                    board[move[0], move[1]] = 'O';
                IsX = !IsX;
            }

            if (Tictactoe_CheckWin(board, 'X'))
                return "A";
            if (Tictactoe_CheckWin(board, 'O'))
                return "B";
            if (n == 9)
                return "Draw";

            return "Pending";
        }
        private bool Tictactoe_CheckWin(char[,] board, char player)
        {
            //检查行
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                    return true;
            }

            //检查列
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
                    return true;
            }

            //检查对角线
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                return true;

            if (board[0, 2] == player && board[1,1] == player && board[2,0] == player)
                return true;

            //其余情况
            return false;
        }

        public bool IsRobotBounded(string instructions)
        {
            //将方向存储在数组中
            int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { 0, 1 } };
            int x = 0;
            int y = 0;
            int currDirIndex = 3;
            foreach (var ch in instructions)
            {
                if (ch == 'G')
                {
                    x += directions[currDirIndex][0];
                    y += directions[currDirIndex][1];
                }
                else if (ch == 'R')
                {
                    currDirIndex++;
                    currDirIndex %= 4;
                }
                else
                {
                    currDirIndex += 3;
                    currDirIndex %= 4;
                }
            }

            return currDirIndex != 3 || (x == 0 && y == 0);
        }

        public int MaximumWealth(int[][] accounts)
        {
            if (accounts == null)
                return 0;
            int max = 0;
            foreach (var account in accounts)
            {
                int temp = account.Sum();
                max = Math.Max(max, temp);
            }
            return max;
        }

        public int DiagonalSum(int[][] mat)
        {
            int n = mat.Length;
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += mat[i][i] + mat[i][n - i - 1];
            if (n % 2 == 0)
                return sum;
            else
                return sum - mat[n / 2][n / 2];
        }

        public IList<int> SpiralOrder(int[][] matrix)
        {
            int nR = matrix.Length;
            int nC = matrix[0].Length;
            IList<int> orderList = new List<int>();

            int x = -1; int y = 0;
            int xLimit = nC;
            int yLimit = nR;

            int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
            int currDire = 0;
            while (xLimit > 0 && yLimit > 0)
            {
                int Limit = (directions[currDire][0] == 0) ? yLimit : xLimit;
                for (int i = 0; i < Limit; i++)
                {
                    x += directions[currDire][0];
                    y += directions[currDire][1];
                    orderList.Add(matrix[y][x]);
                }

                if (directions[currDire][0] == 0)
                {
                    xLimit--;
                }
                else
                {
                    yLimit--;
                }

                currDire = (currDire + 1) % 4;
            }

            return orderList;
        }

        public int[][] SetZeroes(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            Queue<(int,int)> posQueue = new Queue<(int,int)> ();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 0)
                        posQueue.Enqueue((i, j));
                }
            }
            while (posQueue.Count != 0)
            {
                (int, int) temp = posQueue.Dequeue();
                for (int r = 0; r < m; r++)
                    matrix[r][temp.Item2] = 0;
                for (int c = 0; c < n; c++)
                    matrix[temp.Item1][c] = 0;
            }           

            return matrix;
        }

        public int CountOdds(int low, int high)
        {
            if (low % 2 == 0 && high % 2 == 0)
                return (high - low) / 2;
            else if (low % 2 != 0 && high % 2 != 0)
                return ((high - low) / 2) + 1;
            else
                return (high - low + 1) / 2;
        }

        public double Average(int[] salary)
        {
            int maxSalary = 0; int minSalary = int.MaxValue;
            int n = salary.Length;
            double totalSalary = 0;
            for (int i = 0; i < n; i++)
            {
                maxSalary = Math.Max(maxSalary, salary[i]);
                minSalary = Math.Min(minSalary, salary[i]);
                totalSalary += salary[i];
            }
            return (totalSalary - maxSalary - minSalary) / (n - 2);
        }

        public bool LemonadeChange(int[] bills)
        {
            int[] currChanges = new int[] { 0, 0 };
            int n = bills.Length;
            for (int i = 0; i < n; i++)
            {
                if (bills[i] == 20)
                {
                    if (currChanges[1] > 0 && currChanges[0] > 0)
                    {
                        currChanges[1]--;
                        currChanges[0]--;
                    }
                    else if (currChanges[0] > 2)
                        currChanges[0] -= 3;
                    else
                        return false;
                }                    
                else if (bills[i] == 10)
                {
                    currChanges[1]++;
                    if (currChanges[0] > 0)
                        currChanges[0]--;
                    else 
                        return false;
                }
                else
                    currChanges[0]++;
            }
            return true;
        }

        public int LargestPerimeter(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            for (int i = n - 3; i >= 0; i--)
            {
                if (nums[i] + nums[i + 1] > nums[i + 2])
                    return nums[i] + nums[i + 1] + nums[i + 2];
            }
            return 0;
        }

        public bool CheckStraightLine(int[][] coordinates)
        {
            int n = coordinates.Length;
            for (int i = 2; i < n; i++)
            {
                int tempK = (coordinates[i - 1][0] - coordinates[i - 2][0]) * (coordinates[i][1] - coordinates[i - 1][1]) 
                          - (coordinates[i - 1][1] - coordinates[i - 2][1]) * (coordinates[i][0] - coordinates[i - 1][0]);
                if (tempK != 0)
                    return false;
            }

            return true;
        }

        public string AddBinary(string a, string b)
        {
            //for循环多个数值
            string ans = "";
            int ca = 0;
            for (int i = a.Length -1, j = b.Length - 1; i >= 0 || j >= 0; i--, j--)
            {
                int sum = ca;
                sum += i >= 0 ? a[i] - '0' : 0;
                sum += j >= 0 ? b[j] - '0' : 0;
                ans = string.Concat(sum % 2, ans);
                ca = sum / 2;
            }

            ans = string.Concat(ca == 1 ? ca : "", ans);
            return ans;
        }

        public string Multiply(string num1, string num2)
        {
            int L1 = num1.Length;
            int L2 = num2.Length;
            if (num1 == "0" || num2 == "0")
                return "0";

            int[] res = new int[L1 + L2]; //不会超出两数长度相加的范围
            for (int i = L1 -1; i >= 0; i--)
            {
                int n1 = num1[i] - '0';
                for (int j = L2 - 1; j >= 0; j--)
                {
                    int n2 = num2[j] - '0';
                    int sum = (res[i + j + 1] + n1 * n2);
                    res[i + j + 1] = sum % 10;
                    res[i + j] += sum / 10;
                }
            }

            string result = "";
            for (int i = 0; i < res.Length; i++)
            {
                if (i == 0 && res[i] == 0) continue;
                result = string.Concat(result, res[i]);
            }

            return result;
        }

        public double MyPow(double x, int n)
        {
            #region 计算超时
            //if (x == 0.0)
            //    return 0.0;
            //if (x == 1.0)
            //    return 1.0;
            //if (n == 0)
            //    return 1.0;
            //double result = x;
            //for (int i = 1; i < Math.Abs((long)n); i++)
            //{
            //    result *=  x;
            //}
            //if (n > 0)
            //    return result;
            //else
            //    return 1 / result;
            #endregion

            //快速幂 + 迭代
            //降低幂次提高效率
            long N = n;
            return N >= 0 ? MyPow_quickMul(x, N) : 1.0 / MyPow_quickMul(x, -N);
        }
        private double MyPow_quickMul(double x, long N)
        {
            double ans = 1.0;
            double x_contribute = x;

            while (N > 0)
            {
                if (N % 2 == 1)
                {
                    ans *= x_contribute;
                }
                x_contribute *= x_contribute; 
                N /= 2;
            }
            return ans;
        }

        public List<int> MergeTwoLists(List<int> numsBefore1, List<int> numsBefore2)
        {
            #region 前处理：将数组转换为ListNode类
            ListNode list1;
            ListNode list2;

            ListNode dummy1 = new ListNode(0); // 创建一个虚拟节点作为链表的头节点
            ListNode dummy2 = new ListNode(0);
            ListNode current1 = dummy1;
            ListNode current2 = dummy2;

            foreach (int num in numsBefore1)
            {
                ListNode newNode = new ListNode(num);
                current1.next = newNode;
                current1 = current1.next;
            }
            list1 = dummy1.next;
            
            foreach (int num in numsBefore2)
            {
                ListNode newNode = new ListNode(num);
                current2.next = newNode;
                current2 = current2.next;
            }
            list2 = dummy2.next;
            #endregion

            ListNode mergeNode = new ListNode(0);
            ListNode currNode = mergeNode;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    ListNode next = new ListNode(list1.val);
                    currNode.next = next;
                    list1 = list1.next;                
                }
                else
                {
                    ListNode next = new ListNode(list2.val);
                    currNode.next = next;
                    list2 = list2.next;
                }
                currNode = currNode.next;
            } 
            if (list1 != null)
            {
                currNode.next = list1;
            }
            if (list2 != null)
            {
                currNode.next = list2;
            }

            ListNode returnNode = mergeNode.next;
            //后处理：将ListNode类转换为数组
            List<int> numsAfter = new List<int>();
            while (returnNode != null)
            {
                numsAfter.Add(returnNode.val);
                returnNode = returnNode.next;
            }

            return numsAfter;
        }

        public List<int> AddTwoNumbers(List<int> numsBefore1, List<int> numsBefore2)
        {
            #region 前处理：将数组转换为ListNode类
            ListNode l1;
            ListNode l2;

            ListNode dummy1 = new ListNode(0); // 创建一个虚拟节点作为链表的头节点
            ListNode dummy2 = new ListNode(0);
            ListNode current1 = dummy1;
            ListNode current2 = dummy2;

            foreach (int num in numsBefore1)
            {
                ListNode newNode = new ListNode(num);
                current1.next = newNode;
                current1 = current1.next;
            }
            l1 = dummy1.next;

            foreach (int num in numsBefore2)
            {
                ListNode newNode = new ListNode(num);
                current2.next = newNode;
                current2 = current2.next;
            }
            l2 = dummy2.next;
            #endregion

            ListNode AddNode = new ListNode(0);
            ListNode currNode = AddNode;
            int carry = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;
                currNode.next = new ListNode(sum % 10);
                currNode = currNode.next;
            }

            ListNode returnNode = AddNode.next;
            //后处理：将ListNode类转换为数组
            List<int> numsAfter = new List<int>();
            while (returnNode != null)
            {
                numsAfter.Add(returnNode.val);
                returnNode = returnNode.next;
            }

            return numsAfter;
        }

        public List<int> AddTwoNumbers2(List<int> numsBefore1, List<int> numsBefore2)
        {
            #region 前处理：将数组转换为ListNode类
            ListNode l1;
            ListNode l2;

            ListNode dummy1 = new ListNode(0); // 创建一个虚拟节点作为链表的头节点
            ListNode dummy2 = new ListNode(0);
            ListNode current1 = dummy1;
            ListNode current2 = dummy2;

            foreach (int num in numsBefore1)
            {
                ListNode newNode = new ListNode(num);
                current1.next = newNode;
                current1 = current1.next;
            }
            l1 = dummy1.next;

            foreach (int num in numsBefore2)
            {
                ListNode newNode = new ListNode(num);
                current2.next = newNode;
                current2 = current2.next;
            }
            l2 = dummy2.next;
            #endregion

            ListNode AddNode = new ListNode(0);
            ListNode currNode = AddNode;
            ListNode reverseL1 = AddTwoNumbers2_reverse(l1);
            ListNode reverseL2 = AddTwoNumbers2_reverse(l2);

            int carry = 0;
            while (reverseL1 != null || reverseL2 != null || carry != 0)
            {
                int sum = carry;
                if (reverseL1 != null)
                {
                    sum += reverseL1.val;
                    reverseL1 = reverseL1.next;
                }

                if (reverseL2 != null)
                {
                    sum += reverseL2.val;
                    reverseL2 = reverseL2.next;
                }

                carry = sum / 10;
                currNode.next = new ListNode(sum % 10);
                currNode = currNode.next;
            }

            ListNode reverseAdd = AddTwoNumbers2_reverse(AddNode.next);
            ListNode returnNode = reverseAdd;
            //后处理：将ListNode类转换为数组
            List<int> numsAfter = new List<int>();
            while (returnNode != null)
            {
                numsAfter.Add(returnNode.val);
                returnNode = returnNode.next;
            }

            return numsAfter;
        }
        private ListNode AddTwoNumbers2_reverse(ListNode head)
        {
            //逻辑代码内容
            ListNode temp = head;
            ListNode reverseNode = null;

            while (temp != null)
            {
                //空间优化答案
                ListNode next = temp.next;
                temp.next = reverseNode;
                reverseNode = temp;
                temp = next;
            }

            return reverseNode;
        }

        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            else if (root.left == null && root.right == null)
                return 1;
            else
            {
                int leftHeight = root.left != null ? MinDepth(root.left) : int.MaxValue;
                int rightHeight = root.right != null ? MinDepth(root.right) : int.MaxValue;
                return Math.Min(leftHeight, rightHeight) + 1;
            }
        }

        private IList<int> orderList = new List<int>();
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
                return orderList;
            else
            {
                InorderTraversal(root.left);
                orderList.Add(root.val);
                InorderTraversal(root.right);
            }

            return orderList;
        }

        public bool BuddyStrings(string s, string goal)
        {
            #region 原始代码
            //if (s.Length != goal.Length)
            //    return false;

            //List<(char,char)> charDiff = new List<(char, char)> ();
            //Dictionary<char, int> charSet = new Dictionary<char, int>();
            //bool hasDuplicate = false;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (s[i] != goal[i])
            //        charDiff.Add((s[i], goal[i]));

            //    if (charSet.ContainsKey(s[i]))
            //        hasDuplicate = true;
            //    else
            //        charSet.Add(s[i], 1);
            //}

            //if (charDiff.Count == 0 && hasDuplicate)
            //    return true;
            //if (charDiff.Count != 2)
            //    return false;
            //if (charDiff[0].Item1 != charDiff[1].Item2 || charDiff[0].Item2 != charDiff[1].Item1)
            //    return false;

            //return true;
            #endregion

            //代码优化
            if (s.Length != goal.Length)
                return false;

            // 如果 s 和 goal 相等，检查是否存在重复字符
            if (s == goal)
            {
                HashSet<char> charSet = new HashSet<char>(s); //HashSet可快速查找和去重
                return charSet.Count < s.Length;
            }

            // 记录字符不同的位置
            List<int> diffIndices = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != goal[i])
                    diffIndices.Add(i);
            }

            // 如果只有两个字符不同且它们可以交换，返回 true
            return diffIndices.Count == 2 && s[diffIndices[0]] == goal[diffIndices[1]] && s[diffIndices[1]] == goal[diffIndices[0]];
        }

        public bool ValidWordSquare(IList<string> words)
        {
            //需要处理多种越界情况
            var rowNum = words.Count;
            for (int row = 0; row < rowNum; row++)
            {
                for (int col = 0; col < words[row].Length; col++)
                {
                    if(col >= rowNum || row > words[row].Length || words[row][col] != words[col][row])
                        return false;
                }
            }
            return true;
        }

        public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            #region 原始代码
            //int n = nums.Length;
            //var result = new List<IList<int>>();
            //if (n == 0)
            //{
            //    List<int> temp = new List<int> { lower, upper };
            //    result.Add(temp);
            //    return result;
            //}
                       
            //int tempStart = lower;
            //for (int i = 0; i < n; i++)
            //{
            //    if (i == 0 && nums[i] > lower) //判断首位
            //    {
            //        int tempEnd = nums[i] - 1;
            //        List<int> temp = new List<int> { tempStart, tempEnd };
            //        result.Add(temp);
            //        tempStart = nums[i];
            //    }

            //    if (nums[i] == tempStart)
            //    {
            //        tempStart++;
            //    }
            //    else
            //    {
            //        int tempEnd = nums[i] - 1;
            //        List<int> temp = new List<int> { tempStart, tempEnd };
            //        result.Add(temp);
            //        tempStart = nums[i] + 1;
            //    }

            //    if (i == n - 1 && nums[i] < upper) //判断末位
            //    {
            //        int tempEnd = upper;
            //        List<int> temp = new List<int> { tempStart, upper };
            //        result.Add(temp);
            //    }
            //}

            //return result;
            #endregion

            //优化代码
            var result = new List<IList<int>>();
            int n = nums.Length;
            long tempStart = lower;

            for (int i = 0; i <= n; i++)
            {
                long tempEnd = (i < n) ? nums[i] - 1 : upper;

                if (tempStart <= tempEnd)
                    result.Add(new List<int> { (int)tempStart, (int)tempEnd });

                tempStart = (i < n) ? nums[i] + 1 : (long)upper + 1;
            }

            return result;
        }

        public bool ConfusingNumber(int n)
        {
            int num = n;
            int reverseNum = 0;
            while (num > 0)
            {
                int digit = num % 10;
                int reverseDigit = digit;
                if (digit == 2 || digit == 3 || digit == 4 ||  digit == 5 || digit == 7)
                    return false;
                else if (digit != 0 && digit != 1 && digit != 8)
                {
                    if (digit == 6)
                        reverseDigit = 9;
                    else if (digit == 9)
                        reverseDigit = 6;
                }

                num /= 10;
                reverseNum = reverseNum * 10 + reverseDigit;
            }

            return n != reverseNum;
        }

        public bool IsNumber(string s)
        {
            if (s.Length == 1 && (s[0] - '0' < 0 || s[0] - '0' > 9))
                return false;

            foreach (char c in s)
            {
                if (c - '0' > 9 && c != 'e' && c != 'E')
                    return false;
            }

            char[] separatorE = { 'e', 'E' }; // 定义多个分隔符
            string[] strSet = s.Split(separatorE, StringSplitOptions.None);
            if (strSet.Length > 2)
                return false;
            else
            {
                //判断前半部分数字
                char[] separatorPlusMinus = { '+', '-' };
                string[] firstStrSet = strSet[0].Split(separatorPlusMinus, StringSplitOptions.None);
                if (firstStrSet.Length > 2)
                    return false;
                else if (firstStrSet.Length == 2)
                {
                    if (firstStrSet[0] != "")
                        return false;
                }
                string firstNum = firstStrSet[^1]; //索引运算符，从末尾开始取数
                string[] firstNumSet = firstNum.Split('.', StringSplitOptions.None);
                if (firstNumSet.Length > 2 || firstNum == "." || firstNum == "")
                    return false;

                if (strSet.Length == 2)
                {
                    //判断后半部分数字
                    string[] lastStrSet = strSet[1].Split(separatorPlusMinus, StringSplitOptions.None);
                    if (lastStrSet.Length > 2)
                        return false;
                    else if (lastStrSet.Length == 2)
                    {
                        if (lastStrSet[0] != "")
                            return false;
                    }
                    string lastNum = lastStrSet[^1]; //索引运算符，从末尾开始取数
                    string[] lastNumSet = lastNum.Split('.', StringSplitOptions.None);
                    if (lastNumSet.Length > 1 || lastNum == "")
                        return false;
                }

                return true;
            }        
        }

        private static readonly Regex NumberPattern = new Regex(@"^[-+]?(\d+(\.\d*)?|\.\d+)([eE][-+]?\d+)?$", RegexOptions.Compiled);

        public bool IsNumber_RegularExpressions(string s)
        {
            return NumberPattern.IsMatch(s);
        }

        public int ShortestDistance_NotSoccer(int[][] maze, int[] start, int[] destination)
        {
            int row = maze.Length;
            int column = maze[0].Length;
            int countStep = 0;
            int[][] directions = new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } }; //左右上下
            Queue<int[]> mazePos = new Queue<int[]>();
            mazePos.Enqueue(start);
            mazePos.Enqueue(null);
            maze[start[0]][start[1]] = 1;
            while (mazePos.Count > 0)
            {
                var temp = mazePos.Dequeue();
                if (temp == null)
                {
                    countStep++;
                    if (mazePos.Count == 0)
                        break;
                    mazePos.Enqueue(null);
                }
                else
                {
                    foreach (var dir in directions)
                    {
                        int[] changePoint = new int[] { temp[0] + dir[0], temp[1] + dir[1] };
                        if (changePoint[0] > -1 && changePoint[0] < column && changePoint[1] > -1 && changePoint[1] < row && maze[changePoint[0]][changePoint[1]] == 0)
                        {
                            if (changePoint[0] == destination[0] && changePoint[1] == destination[1])
                                return countStep++;
                            mazePos.Enqueue(changePoint);
                            maze[changePoint[0]][changePoint[1]] = 1;
                        }
                    }
                }
            }
            return -1;
        }

        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            int row = maze.Length;
            int column = maze[0].Length;
            int[][] directions = new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } }; //左右上下
            Queue<int[]> mazePos = new Queue<int[]>();
            mazePos.Enqueue(start);
            mazePos.Enqueue(null);
            maze[start[0]][start[1]] = -1; //设定-1为已经路过的位置
            while (mazePos.Count > 0)
            {
                var temp = mazePos.Dequeue();
                if (temp == null)
                {
                    if (mazePos.Count == 0)
                        break;
                    mazePos.Enqueue(null);
                }
                else
                {
                    foreach (var dir in directions)
                    {
                        int temp0 = temp[0];
                        int temp1 = temp[1];
                        while (temp0 < row && temp0 > -1 && temp1 < column && temp1 > -1 && maze[temp0][temp1] != 1)
                        {
                            temp0 += dir[0];
                            temp1 += dir[1];
                        }
                        temp0 -= dir[0];
                        temp1 -= dir[1];

                        if (maze[temp0][temp1] == 0)
                        {
                            if (temp0 == destination[0] && temp1 == destination[1])
                                return true;
                            mazePos.Enqueue(new int[] { temp0, temp1 });
                            maze[temp0][temp1] = -1;
                        }
                    }
                }
            }
            return false;
        }

        public int ShortestDistance_IsSoccer(int[][] maze, int[] start, int[] destination)
        {
            //最少层数并不一定是最小步数
            int row = maze.Length;
            int column = maze[0].Length;
            int[][] directions = new int[][] { new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 1, 0 } }; //左右上下
            Queue<(int[], int[], int)> mazePos = new Queue<(int[], int[], int)>(); //第一个为位置，第二个为方向，第三个为Step统计
            mazePos.Enqueue((start, null, 0));
            maze[start[0]][start[1]] = -1; //设定-1为已经路过的位置
            while (mazePos.Count > 0)
            {
                var tempNode = mazePos.Dequeue();
                var temp = tempNode.Item1;
                int[] currDir = tempNode.Item2;
                int currStep = tempNode.Item3;
                if (currDir != null)
                {
                    int temp0 = temp[0] + currDir[0];
                    int temp1 = temp[1] + currDir[1];
                    if (temp0 < row && temp0 > -1 && temp1 < column && temp1 > -1 && maze[temp0][temp1] == 0)
                    {
                        mazePos.Enqueue((new int[] { temp0, temp1 }, currDir, currStep + 1));
                    }                        
                    else if (temp0 < row && temp0 > -1 && temp1 < column && temp1 > -1 && maze[temp0][temp1] == -1)
                        continue;
                    else
                    {
                        if (temp[0] == destination[0] && temp[1] == destination[1])
                            return currStep;
                        maze[temp[0]][temp[1]] = -1;
                        foreach (var dir in directions)
                        {
                            if (dir[0] == currDir[0] || dir[1] == currDir[1])
                                continue;
                            temp0 = temp[0] + dir[0];
                            temp1 = temp[1] + dir[1];
                            if (temp0 > -1 && temp0 < row && temp1 > -1 && temp1 < column && maze[temp0][temp1] == 0)
                            {                            
                                mazePos.Enqueue((new int[] { temp0, temp1 }, dir, currStep + 1));
                            }
                        }
                    }
                }
                else
                {
                    foreach (var dir in directions)
                    {
                        int temp0 = temp[0] + dir[0];
                        int temp1 = temp[1] + dir[1];
                        if (temp0 > -1 && temp0 < row && temp1 > -1 && temp1 < column && maze[temp0][temp1] == 0)
                        {
                            mazePos.Enqueue((new int[] { temp0, temp1 }, dir, currStep + 1));
                        }
                    }
                }
            }

            return -1;
        }

        public string ConvertToTitle(int columnNumber)
        {
            //从1开始，需后退一位
            string charStr = "";
            while (columnNumber > 0)
            {
                columnNumber--;
                charStr = string.Concat((char)(columnNumber % 26 + 'A'), charStr);
                columnNumber /= 26;
            }

            return charStr;
        }

        public int TitleToNumber(string columnTitle)
        {
            int n = columnTitle.Length;
            int result = 0;
            for (int i = 0; i < n; i++)
            {
                char c = columnTitle[i];
                int temp = c - 'A' + 1;
                result = result * 26 + temp;
            }

            return result;
        }

        public int ShortestDistance(string[] wordsDict, string word1, string word2)
        {
            int n = wordsDict.Length;
            int distance = 40000;
            int tempPos1 = -1;
            int tempPos2 = -1;
            for (int i = 0; i < n; i++)
            {                
                if (wordsDict[i] == word1)
                    tempPos1 = i;
                else if (wordsDict[i] == word2)
                    tempPos2 = i;

                if (tempPos1 != -1 && tempPos2 != -1)
                {
                    int tempDistance = Math.Abs(tempPos1 - tempPos2);
                    distance = Math.Min(distance, tempDistance);
                }
            }
            return distance;
        }

        public bool IsStrobogrammatic(string num)
        {
            string reverseNum = "";
            foreach (var ch in num)
            {
                if (ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '7')
                    return false;
                else
                {
                    char reverseCh = ch;
                    if (ch == '6')
                        reverseCh = '9';
                    else if (ch == '9')
                        reverseCh = '6';
                    reverseNum = string.Concat(reverseCh, reverseNum);
                }
            }
            return reverseNum == num;
        }

        public bool CanAttendMeetings(int[][] intervals)
        {
            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
            int start = -1;
            foreach (var gap in intervals)
            {
                if (gap[0] >= start)
                    start = gap[1];
                else
                    return false;
            }
            return true;
        }

        public int MinMeetingRooms(int[][] intervals) 
        {
            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
            int maxRoom = 1;
            int roomCount = 0;
            int sameTime = intervals[0][1];
            foreach (var gap in intervals)
            {
                if (gap[0] >= sameTime)
                {                    
                    roomCount = 1;
                    sameTime = gap[1];
                }
                else
                    roomCount++;
                maxRoom = Math.Max(maxRoom, roomCount);
            }

            return maxRoom;
        }

        public bool CanPermutePalindrome(string s)
        {
            Dictionary<char, int> charSet = new Dictionary<char, int>();
            foreach (var ch in s)
            {
                if (charSet.ContainsKey(ch))
                    charSet[ch]++;
                else
                    charSet.Add(ch, 1);
            }

            int oddcCount = 0;
            foreach (var set in charSet)
            {
                oddcCount = set.Value % 2 == 0 ? oddcCount : oddcCount + 1;
                if (oddcCount > 1)
                    return false;
            }
            return true;
        }

        public int ClosestValue(TreeNode root, double target)
        {
            Queue<TreeNode> queueNode = new Queue<TreeNode>();
            queueNode.Enqueue(root);
            int closestValue = root.val;
            while (queueNode.Count > 0)
            {
                TreeNode tmpNode = queueNode.Dequeue();
                int tmpValue = tmpNode.val;
                if (Math.Abs(target - tmpValue) < Math.Abs(target - closestValue) ||
                   (Math.Abs(target - tmpValue) == Math.Abs(target - closestValue) && tmpValue < closestValue))
                {
                    closestValue = tmpValue;
                }

                if (tmpNode.left != null)
                    queueNode.Enqueue(tmpNode.left);
                if (tmpNode.right != null)
                    queueNode.Enqueue(tmpNode.right);
            }

            return closestValue;
        }

        public IList<string> GeneratePossibleNextMoves(string currentState)
        {
            List<string> possibleMoves = new List<string>();
            int start = -1;
            for (int i = 0; i < currentState.Length; i++)
            {
                if (currentState[i] == '+')
                {
                    if (i > 0 && start == i - 1)
                    {
                        //替换字符
                        string prevString = currentState.Substring(0, i - 1);
                        string nextString = currentState.Substring(i + 1);
                        possibleMoves.Add(prevString + "--" + nextString);
                    }                        
                    start = i;
                }                    
            }

            return possibleMoves;
        }

        public bool ValidWordAbbreviation(string word, string abbr)
        {
            int n = word.Length;
            int m = 0;
            int i = 0;
            while (i < abbr.Length)
            {
                int num = 0;
                if (!char.IsDigit(abbr[i]))
                {
                    if (m >= n || word[m] != abbr[i])
                        return false;
                    m++;
                    i++;
                }
                else
                {
                    while (i < abbr.Length && char.IsDigit(abbr[i]))
                    {
                        num = num * 10 + abbr[i] - '0';
                        if (num == 0)
                            return false;
                        i++;
                    }
                    m += num;
                }
            }

            return m == n;
        }

        public bool AreSentencesSimilar(string[] sentence1, string[] sentence2, IList<IList<string>> similarPairs)
        {
            int n1 = sentence1.Length;
            int n2 = sentence2.Length;
            if (n1 != n2)
                return false;
            HashSet<string> dicSet = new HashSet<string>();
            foreach (var pair in similarPairs)
            {
                dicSet.Add(pair[0] + "#" + pair[1]);
            }
            for (int i = 0; i < n1; i++)
            {
                string tmp1 = sentence1[i] + "#" + sentence2[i];
                string tmp2 = sentence2[i] + "#" + sentence1[i];
                if (!dicSet.Contains(tmp1) && !dicSet.Contains(tmp2) && sentence1[i] != sentence2[i])
                    return false;
            }

            return true;
        }

        public int[] AnagramMappings(int[] nums1, int[] nums2)
        {
            //原始代码
            //int n = nums1.Length;
            //int[] result = new int[n];
            //int i = 0;
            //while (i < n)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        if (nums2[j] != -1 && nums1[i] == nums2[j])
            //        {
            //            result[i] = j;
            //            nums2[j] = -1;
            //        }    
            //    }
            //}
            //return result;

            //优化代码
            int n = nums1.Length;
            int[] result = new int[n];
            Dictionary<int, List<int>> dicNum = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                if (!dicNum.ContainsKey(nums2[i]))
                {
                    List<int> tmpList = new List<int>();
                    tmpList.Add(i);
                    dicNum.Add(nums2[i], tmpList);
                }
                else
                {
                    dicNum[nums2[i]].Add(i);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (dicNum.ContainsKey(nums1[i]) && dicNum[nums1[i]].Count > 0)
                {
                    result[i] = dicNum[nums1[i]][0];
                    dicNum[nums1[i]].RemoveAt(0);
                }
            }

            return result;
        }

        public string SimilarRGB(string color)
        {
            color = color.TrimStart('#');
            string result = "#";
            for (int i = 0; i < 6; i += 2)
            {
                if (color[i] == color[i + 1])
                {
                    result = string.Concat(result, color[i], color[i + 1]);
                    continue;
                }
                int temp1 = Convert.ToInt32(color[i].ToString(), 16);
                int temp2 = Convert.ToInt32(color[i + 1].ToString(), 16);
                if (Math.Abs(temp1 - temp2) <= 8)
                    result = string.Concat(result, color[i], color[i]);
                else if (temp1 == 15 || temp1 > temp2)
                    result = string.Concat(result, (temp1 - 1).ToString("x"), (temp1 - 1).ToString("x"));
                else
                    result = string.Concat(result, (temp1 + 1).ToString("x"), (temp1 + 1).ToString("x"));
            }
            return result;
        }

        public int FixedPoint(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == i)
                    return i;
                else if (arr[i] > i)
                    return -1;
            }
            return -1;
        }

        public int[][] IndexPairs(string text, string[] words)
        {
            List<int[]> pairList = new List<int[]>();
            for (int i = 0; i < text.Length; i++)
            {
                foreach (var word in words)
                {
                    for (int j = 0; j < word.Length && i + j < text.Length; j++)
                    {
                        if (word[j] != text[i + j])
                            break;
                        if (j == word.Length - 1)
                            pairList.Add(new int[] { i, i + j });
                    }
                }
            }

            return pairList.OrderBy(arr => arr[0]).ThenBy(arr => arr[1]).ToArray();
        }

        public int SumOfDigits(int[] nums)
        {
            int minValue = int.MaxValue;
            int result = 0;
            foreach (var num in nums)
                minValue = Math.Min(minValue, num);

            while (minValue > 9)
            {
                result += minValue % 10;
                minValue /= 10;
            }
            result += minValue;
            return result % 2 == 0 ? 1 : 0;
        }

        public int[][] HighFive(int[][] items)
        {
            int id = 0;
            int count = 0;
            int tempSum = 0;
            List<int[]> avgFive = new List<int[]>();
            var orderItems = items.OrderBy(item => item[0]).ThenByDescending(item => item[1]).ToArray();
            for (int i = 0; i < orderItems.Length; i++)
            {
                if (id != orderItems[i][0])
                {
                    id = orderItems[i][0];
                    tempSum = 0;
                    count = 0;
                }
                if (count < 5)
                {
                    tempSum += orderItems[i][1];
                    count++;
                    if (count == 5)
                        avgFive.Add(new int[] { id, tempSum / 5 });
                }
            }

            return avgFive.ToArray();
        }

        public int TwoSumLessThanK(int[] nums, int k)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int maxSum = 0;
            int start = 0;
            int end = n - 1;
            while (start < end)
            {
                int tempSum = nums[start] + nums[end];
                if (tempSum < k)
                {
                    maxSum = Math.Max(maxSum, tempSum);
                    start++;
                }
                else
                {
                    end--;
                }
            }

            return maxSum == 0 ? -1 : maxSum;
        }

        public int NumberOfDays(int year, int month)
        {
            int[] daysOfMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                daysOfMonth[1] = 29;
            }                

            return daysOfMonth[month - 1];
        }

        public string RemoveVowels(string s)
        {
            string removeChar = "aoieu";
            foreach (char ch in removeChar)
            {
                s = s.Replace(ch.ToString(), "");
            }
            return s;
        }

        public int LargestUniqueNumber(int[] nums)
        {
            //字典方法的时间复杂度更低
            if (nums.Length == 1)
                return nums[0];

            Array.Sort(nums);
            int before = -1;
            int after = -1;
            int result = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    after = nums[i + 1];
                    result = nums[i] == after ? -1 : nums[i];
                }
                else if (i == nums.Length - 1)
                {
                    before = nums[i - 1];
                    result = nums[i] == before ? result : nums[i];
                }
                else
                {
                    before = nums[i - 1];
                    after = nums[i + 1];
                    if (nums[i] != before && nums[i] != after)
                        result = nums[i];
                }
            }
            return result;
        }

        public bool IsArmstrong(int n)
        {
            int a = n.ToString().Length;
            int num = n;
            int result = 0;
            while (num > 9)
            {
                int temp = num % 10;
                num = num / 10;
                result = result + (int)Math.Pow(temp, a);
            }
            result = result + (int)Math.Pow(num, a);

            return result == n;
        }

        public bool IsMajorityElement(int[] nums, int target)
        {
            int n = nums.Length;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == target)
                {
                    count++;
                    if (count > n / 2)
                        return true;
                }                    
            }
            return false;
        }

        public int CalculateTime(string keyboard, string word)
        {
            #region 原始字典方法
            //Dictionary<char, int> keyDic = new Dictionary<char, int>();
            //for (int i = 0; i < 26; i++)
            //    keyDic.Add(keyboard[i], i);
            //int before = 0;
            //int count = 0;
            //for (int i = 0; i < word.Length; i++)
            //{
            //    count += Math.Abs(keyDic[word[i]] - before);
            //    before = keyDic[word[i]];
            //}

            //return count;
            #endregion

            //优化方法
            int before = 0;
            int count = 0;
            for (int i = 0; i < word.Length; i++)
            {
                count += Math.Abs(keyboard.IndexOf(word[i]) - before);
                before = keyboard.IndexOf(word[i]);
            }

            return count;
        }

        public int DietPlanPerformance(int[] calories, int k, int lower, int upper)
        {
            int tempSum = 0;
            int result = 0;
            for (int i = 0; i < k; i++)
                tempSum+= calories[i];
            for (int i = k; i <= calories.Length; i++)
            {                
                if (tempSum > upper)
                    result++;
                else if (tempSum < lower)
                    result--;

                if (i < calories.Length) // 避免数组越界
                    tempSum = tempSum + calories[i] - calories[i - k];
            }

            return result;
        }

        public int CountLetters(string s)
        {
            int allCount = 0;
            int charCount = 0;
            char tmpChar = '#';
            for (int i = 0; i < s.Length; i++)
            {
                if (tmpChar != s[i])
                {
                    allCount += (int)(0.5 * (1 + charCount) * charCount);
                    tmpChar = s[i];
                    charCount = 1;
                }
                else
                    charCount++;
            }
            allCount += (int)(0.5 * (1 + charCount) * charCount);

            return allCount;
        }

        public int MaxNumberOfApples(int[] weight)
        {
            Array.Sort(weight);
            int maxCount = 0;
            int weightCount = 0;
            for (int i = 0; i < weight.Length; i++)
            {
                weightCount += weight[i];
                if (weightCount <= 5000)
                    maxCount++;
                else
                    return maxCount;
            }

            return maxCount;
        }

        public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
        {
            IList<int> sameNum = new List<int>();
            int pos1 = 0, pos2 = 0, pos3 = 0;
            while (pos1 < arr1.Length && pos2 < arr2.Length && pos3 < arr3.Length)
            {
                int smallNum = Math.Min(Math.Min(arr1[pos1], arr2[pos2]), arr3[pos3]);
                if (arr1[pos1] == arr2[pos2] && arr2[pos2] == arr3[pos3])
                {
                    sameNum.Add(arr1[pos1]);
                    pos1++;
                    pos2++;
                    pos3++;
                }
                else
                {
                    if (smallNum == arr1[pos1])
                        pos1++;
                    else if (smallNum == arr2[pos2])
                        pos2++;
                    else
                        pos3++;
                }
            }

            return sameNum;
        }

        public int MissingNumber(int[] arr)
        {
            int n = arr.Length;
            int diff;
            int diffStart = arr[1] - arr[0];
            int diffEnd = arr[n - 1] - arr[n - 2];
            if (diffStart == 0 && diffEnd == 0)
                return arr[0];
            if (Math.Abs(diffStart) < Math.Abs(diffEnd))
                diff = diffStart;
            else
                diff = diffEnd;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[i - 1] + diff)
                    continue;
                else
                    return arr[i - 1] + diff;
            }

            return -1;
        }

        public IList<int> TransformArray(int[] arr)
        {
            int n = arr.Length;
            if (n < 3)
                return arr;
            bool isChanged = true;
            int[] newArr = new int[n];
            while (isChanged == true)
            {
                isChanged = false;
                newArr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    if (i == 0 || i == n - 1)
                        newArr[i] = arr[i];
                    else if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
                    {
                        isChanged = true;
                        newArr[i] = arr[i] - 1;
                    }
                    else if (arr[i] < arr[i - 1] && arr[i] < arr[i + 1])
                    {
                        isChanged = true;
                        newArr[i] = arr[i] + 1;
                    }
                    else
                        newArr[i] = arr[i];
                }
                arr = newArr;
            }

            return newArr.ToList();
        }

        public string ToHexspeak(string num)
        {
            long digitNum = Convert.ToInt64(num);
            string hexNum = Convert.ToString(digitNum, 16).ToUpper();
            string returnNum = "";
            for (int i = 0; i < hexNum.Length; i++)
            {
                if (hexNum[i] >= '2' && hexNum[i] <= '9')
                    return "ERROR";
                else if (hexNum[i] == '0')
                    returnNum = string.Concat(returnNum, 'O');
                else if (hexNum[i] == '1')
                    returnNum = string.Concat(returnNum, 'I');
                else
                    returnNum = string.Concat(returnNum, hexNum[i]);
            }
            return returnNum;
        }

        public TreeNode UpsideDownBinaryTree(TreeNode root)
        {
            //题目中已假设不存在右节点
            TreeNode newNode = null;
            TreeNode tmpNode = null;
            TreeNode tmpRight = null;
            while (root != null)
            {
                newNode = new TreeNode(root.val);                
                newNode.left = tmpRight;
                newNode.right = tmpNode;
                tmpNode = newNode;
                tmpRight = root.right;
                root = root.left;
            }           

            return newNode;
        }

        public int Divide(int a, int b)
        {
            return 0;
        }
    }
}
