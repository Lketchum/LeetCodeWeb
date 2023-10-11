using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.Versioning;
using System.Threading;

namespace LeetCodeWeb.Services
{
    public class CustomStructure
    {
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

        //TrieNode自定义
        public class Trie
        {
            private Trie[] children;
            private bool isEnd;

            public Trie()
            {
                children = new Trie[26];
                isEnd = false;
            }

            public void insert(string word)
            {
                Trie node = this;
                for (int i = 0; i < word.Length; i++)
                {
                    char ch = word[i];
                    int index = ch - 'a';
                    if (node.children[index] == null)
                        node.children[index] = new Trie();
                    node = node.children[index];
                }
                node.isEnd = true;
            }

            public bool search(string word)
            {
                Trie node = searchPrefix(word);
                return node != null && node.isEnd;
            }

            public bool startWith(string prefix)
            {
                return searchPrefix(prefix) != null;
            }

            public Trie searchPrefix(string prefix)
            {
                Trie node = this;
                for (int i = 0; i < prefix.Length; i++)
                {
                    char ch = prefix[i];
                    int index = ch - 'a';
                    if (node.children[index] == null)
                        return null;
                    node = node.children[index];
                }
                return node;
            }
        }

        // 区间集合
        public class Interval
        {
            public int Start { get; set; }
            public int End { get; set; }

            public Interval(int start, int end)
            {
                Start = start;
                End = end;
            }
        }

        //LRU缓存
        public class LRUCache
        {
            Dictionary<int, int> dict;
            LinkedList<int> nums;
            Dictionary<int, LinkedListNode<int>> nodes;
            int capacity;

            public LRUCache(int capacity)
            {
                this.capacity = capacity;
                dict = new Dictionary<int, int>();
                nums = new LinkedList<int>();
                nodes = new Dictionary<int, LinkedListNode<int>>();
            }

            public int Get(int key)
            {
                if (dict.ContainsKey(key))
                {
                    nums.Remove(nodes[key]);
                    var node = nums.AddLast(key);
                    nodes[key] = node;
                    return dict[key];
                }
                return -1;
            }

            public void Put(int key, int value)
            {
                if (dict.ContainsKey(key))
                {
                    nums.Remove(nodes[key]);
                    var node = nums.AddLast(key);
                    nodes[key] = node;
                    dict[key] = value;
                }
                else
                {
                    if (nums.Count == capacity)
                    {
                        dict.Remove(nums.First.Value);
                        nodes.Remove(nums.First.Value);
                        nums.RemoveFirst();
                        var node = nums.AddLast(key);
                        dict.Add(key, value);
                        nodes.Add(key, node);
                    }
                    else
                    {
                        var node = nums.AddLast(key);
                        dict.Add(key, value);
                        nodes.Add(key, node);
                    }
                }
            }
        }

        //队列实现栈
        public class MyStack
        {
            private Queue<int> queue1;
            private Queue<int> queue2;

            public MyStack()
            {
                queue1= new Queue<int>();
                queue2= new Queue<int>();
            }

            public void Push(int x)
            {
                if (queue1.Count == 0)
                {
                    queue1.Enqueue(x);
                    while (queue2.Count > 0)
                        queue1.Enqueue(queue2.Dequeue());
                }
                else
                {
                    queue2.Enqueue(x);
                    while (queue1.Count > 0)
                        queue2.Enqueue(queue1.Dequeue());
                }
            }

            public int Pop()
            {
                if (queue1.Count > 0)
                    return queue1.Dequeue();
                else
                    return queue2.Dequeue();
            }

            public int Top()
            {
                if (queue1.Count > 0)
                    return queue1.Peek();
                else
                    return queue2.Peek();
            }

            public bool Empty()
            {
                return queue1.Count == 0 && queue2.Count == 0;
            }
        }

        //停车系统
        public class ParkingSystem
        {
            private int[] parkingLots = new int[] { 0, 0, 0 };
            public ParkingSystem(int big, int medium, int small)
            {
                parkingLots = new int[] { big, medium, small };
            }

            public bool AddCar(int carType)
            {
                int temp = parkingLots[carType - 1] - 1;
                if (temp < 0)
                    return false;
                else
                {
                    parkingLots[carType - 1]--;
                    return true;
                }
            }
        }

        //哈希映射
        public class MyHashMap
        {
            private class Pair_MyHashMap
            {
                private int key;
                private int value;

                public Pair_MyHashMap(int key, int value)
                {
                    this.key = key;
                    this.value = value;
                }

                public int GetKey()
                {
                    return key;
                }

                public int GetValue()
                {
                    return value;
                }

                public void SetValue(int value)
                {
                    this.value = value;
                }
            }

            private const int BASE = 769;
            private LinkedList<Pair_MyHashMap>[] data;

            public MyHashMap()
            {
                data = new LinkedList<Pair_MyHashMap>[BASE];
                for (int i = 0; i < BASE; i++)
                {
                    data[i] = new LinkedList<Pair_MyHashMap>();
                }
            }

            public void Put(int key, int value)
            {
                int index = key % BASE;
                LinkedList<Pair_MyHashMap> list = data[index];
                foreach (Pair_MyHashMap pair in list)
                {
                    if (pair.GetKey() == key)
                    {
                        pair.SetValue(value);
                        return;
                    }
                }
                list.AddLast(new Pair_MyHashMap(key, value));
            }

            public int Get(int key)
            {
                int index = key % BASE;
                LinkedList<Pair_MyHashMap> list = data[index];
                foreach (Pair_MyHashMap pair in list)
                {
                    if (pair.GetKey() == key)
                        return pair.GetValue();
                }
                return -1;
            }

            public void Remove(int key)
            {
                int index = key % BASE;
                LinkedList<Pair_MyHashMap> list = data[index];
                foreach (Pair_MyHashMap pair in list)
                {
                    if (pair.GetKey() == key)
                    {
                        list.Remove(pair);
                        break;
                    }
                }
            }
        }

        //地铁系统
        public class UndergroundSystem
        {
            Dictionary<int, (string, int)> checkRecord = new();
            Dictionary<string, (double, int)> timeRecord = new();

            public UndergroundSystem()
            {

            }

            public void CheckIn(int id, string stationName, int t)
            {
                checkRecord[id] = (stationName, t);
            }

            public void CheckOut(int id, string stationName, int t)
            {
                string sectionName = checkRecord[id].Item1 + "," + stationName;
                double tempTime = t - checkRecord[id].Item2;
                if (timeRecord.ContainsKey(sectionName))
                    timeRecord[sectionName] = (timeRecord[sectionName].Item1 + tempTime, timeRecord[sectionName].Item2 + 1);
                else
                    timeRecord.Add(sectionName, (tempTime, 1));
            }

            public double GetAverageTime(string startStation, string endStation)
            {
                string getName = startStation + "," + endStation;
                return timeRecord[getName].Item1 / timeRecord[getName].Item2;
            }
        }

        //浏览器历史记录
        public class BrowserHistory
        {
            Stack<string> backHistory = new();
            Stack<string> forwardHisttory = new();
            string currentUrl = "";

            public BrowserHistory(string homepage)
            {
                currentUrl = homepage;
            }

            public void Visit(string url)
            {
                backHistory.Push(currentUrl);
                currentUrl = url;
                forwardHisttory = new();
            }

            public string Back(int steps)
            {
                while (steps > 0)
                {
                    if (backHistory.Count == 0)
                        return currentUrl;
                    else
                    {
                        forwardHisttory.Push(currentUrl);
                        currentUrl = backHistory.Pop();
                        steps--;
                    }
                }
                return currentUrl;
            }

            public string Forward(int steps)
            {
                while (steps > 0)
                {
                    if (forwardHisttory.Count == 0)
                        return currentUrl;
                    else
                    {
                        backHistory.Push(currentUrl);
                        currentUrl = forwardHisttory.Pop();
                        steps--;
                    }
                }
                return currentUrl;
            }
        }

        //链表设计-基于单向链表
        public class MyLinkedList_Single
        {
            int size;
            ListNode head;

            public MyLinkedList_Single()
            {
                size = 0;
                head = new ListNode(0);
            }

            public int Get(int index)
            {
                if (index < 0 || index >= size)
                    return -1;
                ListNode cur = head;
                for (int i = 0; i <= index; i++)
                    cur = cur.next;
                return cur.val;
            }

            public void AddAtHead(int val)
            {
                AddAtIndex(0, val);
            }

            public void AddAtTail(int val)
            {
                AddAtIndex(size, val);
            }

            public void AddAtIndex(int index, int val)
            {
                if (index > size)
                    return;
                index = Math.Max(0, index);
                size++;
                ListNode pred = head;
                for (int i = 0; i < index; i++)
                    pred = pred.next;
                ListNode toAdd = new ListNode(val);
                toAdd.next = pred.next;
                pred.next = toAdd;
            }

            public void DeleteAtIndex(int index)
            {
                if (index < 0 || index >= size)
                    return;
                size--;
                ListNode pred = head;
                for (int i = 0; i < index; i++)
                    pred = pred.next;
                pred.next = pred.next.next;
            }
        }

        //链表设计-基于双向链表
        public class MyLinkedList_Double
        {
            int size;
            ListNode_Double head;
            ListNode_Double tail;

            public MyLinkedList_Double()
            {
                size = 0;
                head = new ListNode_Double(0);
                tail = new ListNode_Double(0);
                head.next = tail;
                tail.prev = head;
            }

            public int Get(int index)
            {
                if (index < 0 || index >= size)
                    return -1;
                ListNode_Double curr;
                if (index + 1 < size - index)
                {
                    curr = head;
                    for (int i = 0; i <= index; i++)
                        curr = curr.next;
                }
                else
                {
                    curr = tail;
                    for (int i = 0; i < size - index; i++)
                        curr = curr.prev;
                }
                return curr.val;
            }

            public void AddAtHead(int val)
            {
                AddAtIndex(0, val);
            }

            public void AddAtTail(int val)
            {
                AddAtIndex(size, val);
            }

            public void AddAtIndex(int index, int val)
            {
                if (index > size)
                    return;
                index = Math.Max(0, index);
                ListNode_Double pred, succ;
                if (index < size - index)
                {
                    pred = head;
                    for (int i = 0; i < index; i++)
                        pred = pred.next;
                    succ = pred.next;
                }
                else
                {
                    succ = tail;
                    for (int i = 0; i < size - index; i++)
                        succ = succ.prev;
                    pred = succ.prev;
                }
                size++;
                ListNode_Double toAdd = new ListNode_Double(val);
                toAdd.prev = pred;
                toAdd.next = succ;
                pred.next = toAdd;
                succ.prev = toAdd;
            }

            public void DeleteAtIndex(int index)
            {
                if (index < 0 || index >= size)
                    return;
                ListNode_Double pred, succ;
                if (index < size - index)
                {
                    pred = head;
                    for (int i = 0; i < index; i++)
                        pred = pred.next;
                    succ = pred.next.next;
                }
                else
                {
                    succ = tail;
                    for (int i = 0; i < size - index - 1; i++)
                        succ = succ.prev;
                    pred = succ.prev;
                }
                size--;
                pred.next = succ;
                succ.prev = pred;
            }
        }
        //双向链表
        public class ListNode_Double
        {
            public int val;
            public ListNode_Double prev;
            public ListNode_Double next;

            public ListNode_Double(int val)
            {
                this.val = val;
            }
        }

        //循环队列
        public class MyCircularQueue
        {            
            int size;
            int count;
            ListNode head;
            ListNode tail;

            public MyCircularQueue(int k)
            {
                size = k;
                count= 0;
            }

            public bool EnQueue(int value)
            {
                if (count == size)
                    return false;
                if (head == null)
                {
                    head = new ListNode(value);
                    tail = head;
                }
                else
                {
                    ListNode temp = new ListNode(value);
                    tail.next = temp;
                    tail = tail.next;
                }                
                count++;
                return true;
            }

            public bool DeQueue()
            {
                if (count == 0)
                    return false;

                head = head.next;
                count--;
                return true;
            }

            public int Front()
            {
                if (count == 0)
                    return -1;
                return head.val;
            }

            public int Rear()
            {
                if (count == 0)
                    return -1;
                return tail.val;
            }

            public bool IsEmpty()
            {
                if (count != 0)
                    return false;
                else 
                    return true;
            }

            public bool IsFull()
            {
                if (count == size)
                    return true;
                else
                    return false;
            }
        }

        //数据流平均值
        public class MovingAverage
        {
            Queue<int> moveQueue;
            double sum;
            int maxSize;

            public MovingAverage(int size)
            {
                sum = 0;
                maxSize = size;
                moveQueue = new Queue<int>(size);

            }

            public double Next(int val)
            {
                if (moveQueue.Count == maxSize)
                    sum -= moveQueue.Dequeue();

                sum += val;
                moveQueue.Enqueue(val);

                return sum / moveQueue.Count;
            }
        }

        //两数之和
        public class TwoSum
        {
            List<int> numList;

            public TwoSum()
            {
                numList = new List<int>();
            }

            public void Add(int number)
            {
                numList.Add(number);
            }

            public bool Find(int value)
            {
                numList.Sort();
                int start = 0;
                int end = numList.Count - 1;
                while (start < end)
                {
                    int tempSum = numList[start] + numList[end];
                    if (tempSum < value)
                        start++;
                    else if (tempSum > value)
                        end--;
                    else
                        return true;
                }
                return false;
            }
        }

        #region 输入数据结构定义
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

        public class Arrays_CalcEquation
        {
            public IList<IList<string>> array1 { get; set; }
            public double[] array2 { get; set; }
            public IList<IList<string>> array3 { get; set; }
        }

        public class Input_NearestExit
        {
            public char[][] char1 { get; set; }
            public int[] int2 { get; set; }
        }

        public class Input_MaxScore
        {
            public int[] nums1 { get; set; }
            public int[] nums2 { get; set; }
            public int num { get; set; }
        }

        public class Input_SuccessfulPairs
        {
            public int[] nums1 { get; set; }
            public int[] nums2 { get; set; }
            public long num { get; set; }
        }

        public class Input_FindContentChildren
        {
            public int[] nums1 { get; set; }
            public int[] nums2 { get; set; }
        }

        public class Input_Merge
        {
            public int[] nums1 { get; set; }
            public int[] nums2 { get; set; }
        }

        public class Input_MergeTwoLists
        {
            public List<int> nums1 { get; set; }
            public List<int> nums2 { get; set; }
        }

        public class Input_Maze
        {
            public int[][] maze { get; set; }
            public int[] start { get; set; }
            public int[] destination { get; set; }
        }
        #endregion
    }
}
