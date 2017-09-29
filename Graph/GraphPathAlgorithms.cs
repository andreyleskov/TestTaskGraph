using System.Collections.Generic;
using System.Linq;

namespace Graph {
    static class GraphPathAlgorithms
    {
        //INTENTIONALLY NOT PERFORMANT!!!!
        public static IEnumerable<Path> FindAllPathsBetween(Vertex current, Vertex end, Path path)
        {
            if(path.Contains(current)) yield break;
            path.Add(current);

            if(current == end) yield return path;

            foreach(var outEdge in current.Connected)
            foreach(var recPath in FindAllPathsBetween(outEdge, end, path.Copy()))
                yield return recPath;
        }

        //INTENTIONALLY NOT PERFORMANT!!!!
        public static Path FindShortestPath(Vertex current, Vertex end)
        {
            return FindAllPathsBetween(current, end, new Path())
                            .OrderBy(p => p.Length())
                            .FirstOrDefault();
        }
    }
}