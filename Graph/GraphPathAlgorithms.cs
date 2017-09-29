using System.Collections.Generic;
using System.Linq;

namespace Graph {
    static class GraphPathAlgorithms
    {
        //NOT PERFORMANT!!!!
        public static IEnumerable<Path> FindAllPaths(Edge current, Edge end, Path path)
        {
            if(path.Contains(current)) yield break;
            path.Add(current);

            if(current == end) yield return path;

            foreach(var outEdge in current.Connected)
            foreach(var recPath in FindAllPaths(outEdge, end, path.Copy()))
                yield return recPath;
        }

        //NOT PERFORMANT!!!!
        public static Path FindShortestPath(Edge current, Edge end)
        {
            return FindAllPaths(current, end, new Path())
                            .OrderBy(p => p.Length())
                            .FirstOrDefault();
        }
    }
}