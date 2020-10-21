#include <bits/stdc++.h>
using namespace std;

class Solution {
  public:
    int a[20002], seg[100000];
 
    void update(int l, int r, int i, int k) {
        if (k < l || k > r)
            return;
        if (l == r)
            seg[i] = a[k];
        else {
            int mid = (l + r) / 2;
            update(l, mid, i * 2 + 1, k);
            update(mid + 1, r, i * 2 + 2, k);
            seg[i] = seg[i * 2 + 1] + seg[i * 2 + 2];
        }
    }
 
    int sum(int l, int r, int i, int L, int R) {
        if (R < l || L > r)
            return 0;
        if (l >= L && r <= R)
            return seg[i];
        int mid = (l + r) / 2;
        return sum(l, mid, i * 2 + 1, L, R) + sum(mid + 1, r, i * 2 + 2, L, R);
    }
 
    vector<int> countSmaller(vector<int> &nums) {
        int n = nums.size();
        vector<int> ans(n);
        for (int i = n - 1; i >= 0; i--) {
            nums[i] += 1e4 + 1;
            ans[i] = sum(0, 20001, 0, 0, nums[i] - 1);
            a[nums[i]]++;
            update(0, 20001, 0, nums[i]);
        }
        return ans;
    }
};

int main() {
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    Solution::countSmaller.countSmaller();
}