using System.Collections.Generic;

namespace Graph {
    static class GraphPathAlgorithms
    {
        public static IEnumerable<Path> FindAllPaths(Edge current, Edge end, Path path)
        {
            if(path.Contains(current)) yield break;
            path.Add(current);

            if(current == end) yield return path;

            foreach(var outEdge in current.Connected)
            foreach(var recPath in FindAllPaths(outEdge, end, path.Copy()))
                yield return recPath;
        }
    }
}