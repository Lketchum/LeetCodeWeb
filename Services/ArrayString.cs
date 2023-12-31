﻿using LeetCodeWeb.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LeetCodeWeb.Services.CustomStructure;

namespace LeetCodeWeb.Services
{
    public class ArrayString : IArrayString
    {
        private readonly ILogger<ArrayString> _logger;

        public ArrayString(ILogger<ArrayString> logger)
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
            Dictionary<int, int> keyDic = new Dictionary<int, int> { { 0, 1 } };
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
                (int, int) values = sortedListNums[i];
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
    }
}
