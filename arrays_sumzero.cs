using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    
    static string SubarrayToString(int[] arr, int st, int en) {
        string[] strArr = new string[en-st+1];     

        for (int i = st; i <= en; i++) {
            strArr[i-st] = arr[i].ToString();
        }
        
        return String.Join(",", strArr);
    }
    
    static string[] FindZeroSumSubarray(int[] arr) {       
        var subarrays = new List<string>();
        
        // Initialize sum and hashmap
        int sum = 0;
        var hashmap = new Dictionary<int, List<int>>();
        hashmap.Add(sum, new List<int>(){-1});
               
        for (int i = 0; i < arr.Length; i++) {
            sum += arr[i];
            
            // If sum has been seen before, print all subarrays (stored index from hashmap, i)
            if (hashmap.ContainsKey(sum)) {
                foreach (int index in hashmap[sum]) {
                    subarrays.Add(SubarrayToString(arr, index+1, i));
                }
                hashmap[sum].Add(i);
            } 
            
            // If sum is new, add i to hashmap
            else {
                hashmap.Add(sum, new List<int>(){i});
            }
        }
        
        return subarrays.ToArray();  
    }

    static string[] sumZero(int[] intArr) {
        string[] sumZeroSubarrays = FindZeroSumSubarray(intArr);     
        return sumZeroSubarrays;
    }
}