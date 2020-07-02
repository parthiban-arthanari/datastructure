// using System;
// using System.Collections.Generic;

// class Solution {
//   // origin -> list of destinations
//   Dictionary<String, List<String>> flightMap = new Dictionary<String, List<String>>();
//   Dictionary<String, bool[]> visitBitmap = new Dictionary<String, bool[]>();
//   int flights = 0;
//   List<String> result = null;


//   public List<String> findItinerary(List<List<String>> tickets) {
//     // Step 1). build the graph first
//     foreach(var ticket in tickets) {
//       String origin = ticket[0];
//       String dest = ticket[1];
//       if (this.flightMap.ContainsKey(origin)) {
//         this.flightMap[origin].Add(dest);
//       } else {
//         List<String> destList = new List<String>();
//         destList.Add(dest);
//         this.flightMap[origin] = destList;
//       }
//     }

//     // Step 2). order the destinations and init the visit bitmap
//     foreach(var entry in flightMap) {
//       this.visitBitmap[entry.Key] = new bool[entry.Value.Count];
//     }

//     this.flights = tickets.Count;
//     List<String> route = new List<String>();
//     route.Add("JFK");

//     // Step 3). backtracking
//     this.backtracking("JFK", route);
//     return this.result;
//   }

//   protected bool backtracking(String origin, List<String> route) {
//     if (route.Count == this.flights + 1) {
//       this.result = route;
//       return true;
//     }

//     if (!this.flightMap.ContainsKey(origin))
//       return false;

//     int i = 0;
//     bool[] bitmap = this.visitBitmap[origin];

//     foreach (String dest in this.flightMap[origin] {
//       if (!bitmap[i]) {
//         bitmap[i] = true;
//         route.Add(dest);
//         bool ret = this.backtracking(dest, route);
//         bitmap[i] = false;

//         if (ret)
//           return true;
//       }
//       ++i;
//     }

//     return false;
//   }
// }