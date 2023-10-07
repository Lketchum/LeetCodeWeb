using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

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

            public BrowserHistory(string homepage)
            {

            }

            public void Visit(string url)
            {

            }

            public string Back(int steps)
            {

            }

            public string Forward(int steps)
            {

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
        #endregion
    }
}
