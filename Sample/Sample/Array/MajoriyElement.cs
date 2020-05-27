using System;
using System.Collections.Generic;

public class MajorityElement
{
    public static MajorityElement Instance = new MajorityElement();
    private int[] arr;

    private void Read()
    {
        arr = new int[]{2,2,2,2,1,1,2,2};
    }
    public void Do()
    {
        Read();
        FindElement(arr);
    }

    private int FindElement(int[] nums)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int value = -1;

        for(int i=0; i<nums.Length; i++)
        {
            if(map.ContainsKey(nums[i]))
                map[nums[i]]++;
            else
                map[nums[i]] = 1;
        }

        foreach(var item in map)
        {
            if(item.Value >= nums.Length/2 && item.Value > value)
                value = item.Key;
        }

        return value;
    }
}
