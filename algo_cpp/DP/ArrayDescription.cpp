#include <iostream>
#include <vector>
#include <string>

using namespace std;

int main()
{
    vector<string> m;
    m.push_back("hello");
    m.push_back("world");
    int n;
    cin >> n;
    for (const string& word : m)
    {
        cout << word << n;
    }
    cout << endl;
}
