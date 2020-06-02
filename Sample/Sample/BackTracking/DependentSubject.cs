using System;
using System.Collections.Generic;

namespace Sample.BackTracking
{
    public class DependentSubject
    {
        public static DependentSubject Instance = new DependentSubject();

        int numofcourse;
        int[][] dependencies;

        private void Read()
        {
            numofcourse = 3;
            dependencies = Utility.Convert2DArray<int>("[[0,1],[0,2],[1,2],[2,1]]", 2);
        }

        public void Do()
        {
            Read();
            CanFinish(numofcourse, dependencies);
        }

        private bool CanFinish(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, List<int>> dependency = new Dictionary<int, List<int>>();
            bool[] visited = new bool[numCourses];

            foreach(var item in prerequisites)
            {
                if(!dependency.ContainsKey(item[0]))
                    dependency[item[0]] = new List<int>(); 
                
                dependency[item[0]].Add(item[1]);
            }

            for(int i=0; i<numCourses; i++)
            {
                if(!visited[i] && dependency.ContainsKey(i))
                {
                    if(!Check(i, dependency, new HashSet<int>(), visited))
                        return false;
                }
            }
            
            return true;
        }

        private bool Check(int course, Dictionary<int, List<int>> dict, HashSet<int> courses, bool[] visited)
        {
            if(dict.ContainsKey(course))
            {
                var list = dict[course];
                for(int i=0; i<list.Count; i++)
                {
                    int c1 = list[i];
                    if(!visited[c1] && courses.Contains(c1))
                        return false;
                    
                    courses.Add(c1);
                    if(!Check(c1, dict, courses, visited))
                        return false;
                }
            }

            visited[course] = true;
            return true;
        }
    }
}