using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Graph
{
    public class GrapthAlgorithmTests
    {
        private readonly ITestOutputHelper _output;

        public GrapthAlgorithmTests(ITestOutputHelper output)
        {
            _output = output;
        }
       
        [Fact]
        public void FindAllPathsBetween()
        {
            InitGrapth(out var start, out var end);
            foreach(var path in GraphPathAlgorithms.FindAllPaths(start, end, new Path())
                                    .Where(p => p.End == end)
                                    .OrderBy(p => p.Length()))
                _output.WriteLine(path.ToString());
        }

        [Fact]
        public void FindShortestPathsBetween()
        {
            InitGrapth(out var start, out var end);
            _output.WriteLine(GraphPathAlgorithms.FindShortestPath(start,end).ToString());
        }

        private static void InitGrapth(out Vertex start, out Vertex end)
        {
            var vertA = new Vertex("A");
            var vertB = new Vertex("B");
            var vertC = new Vertex("C");
            var vertD = new Vertex("D");
            var vertE = new Vertex("E");
            var vertF = new Vertex("F");
            var vertG = new Vertex("G");
            var vertH = new Vertex("H");

            vertA.Connect(vertB, vertC, vertD);
            vertB.Connect(vertA, vertC, vertF, vertE);
            vertC.Connect(vertA, vertB, vertF);
            vertD.Connect(vertA, vertG);
            vertE.Connect(vertB, vertG);
            vertF.Connect(vertB, vertC, vertG);
            vertG.Connect(vertE, vertD, vertF, vertH);
            vertH.Connect(vertG);

            start = vertA;
            end = vertH;
        }
    }
}
