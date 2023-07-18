using LeetCodeWeb.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }

    /// <summary>
    /// 自定义类构建
    /// </summary>

    //ListNode自定义
    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }
        public ListNode()
        {
            // 默认无参数构造函数，与反序列化相关
        }
        public ListNode(int nodevalue, ListNode nodenext = null)
        {
            val = nodevalue;
            next = nodenext;
        }
    }

    //TreeNode自定义
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode()
        {
            // 默认无参数构造函数，与反序列化相关
        }
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    //双数组输入
    public class TwoArrays
    {
        public int?[] array1 { get; set; }
        public int?[] array2 { get; set; }
    }

    public class ThreeArrays
    {
        public int?[] array1 { get; set; }
        public int?[] array2 { get; set; }
        public int?[] array3 { get; set; }
    }
}
