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
    }
}
