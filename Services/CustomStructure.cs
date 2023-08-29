﻿using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System.Collections.Generic;

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
    }
}
