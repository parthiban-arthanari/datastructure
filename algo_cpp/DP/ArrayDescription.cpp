#include <bits/stdc++.h>
using namespace std;

const int M = 1e5;
int n, m, arr[M], memo[101][M], mod = 1e9 + 7;

int solve(int prev, int i) {
    if (i == n)
        return 1;

    int &r = memo[prev][i];
    if (r == -1) {
        r = 0;
        if (arr[i] != 0) {

            if (abs(prev - arr[i]) < 2)
                r = solve(arr[i], i + 1);
        } else {
            r = solve(prev, i + 1);
            if (prev - 1 > 0)
                r += solve(prev - 1, i + 1), r %= mod;
            if (prev + 1 <= m)
                r += solve(prev + 1, i + 1), r %= mod;
        }
    }
    return r;
}

int main() {
    ios_base::sync_with_stdio(0);
    cin.tie(0);

    memset(memo, -1, sizeof memo);

    int ans = 0;
    cin >> n >> m;
    for (int i = 0; i < n; i++)
        cin >> arr[i];

    if (arr[0] != 0)
        ans = solve(arr[0], 1);
    else
        for (int x = 1; x <= m; x++)
            ans += solve(x, 1), ans %= mod;
    cout << ans << '\n';
}

/*

0 0 0 0 0

*/