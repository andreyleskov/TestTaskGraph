using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Graph
{
    public class FindAllPathsBetweenEdgesTests
    {
        private readonly ITestOutputHelper _output;

        public FindAllPathsBetweenEdgesTests(ITestOutputHelper output)
        {
            _output = output;
        }
       
        [Fact]
        public void FindAllPathsBetween()
        {
            var edgeA = new Edge("A");
            var edgeB = new Edge("B");
            var edgeC = new Edge("C");
            var edgeD = new Edge("D");
            var edgeE = new Edge("E");
            var edgeF = new Edge("F");
            var edgeG = new Edge("G");
            var edgeH = new Edge("H");

            edgeA.CreateVertexTo(edgeB,edgeC,edgeD);
            edgeB.CreateVertexTo(edgeA,edgeC,edgeF,edgeE);
            edgeC.CreateVertexTo(edgeA,edgeB,edgeF);
            edgeD.CreateVertexTo(edgeA,edgeG);
            edgeE.CreateVertexTo(edgeB,edgeG);
            edgeF.CreateVertexTo(edgeB,edgeC,edgeG);
            edgeG.CreateVertexTo(edgeE,edgeD,edgeF,edgeH);
            edgeH.CreateVertexTo(edgeG);

            var start = edgeA;
            var end = edgeH;
            foreach(var path in GraphPathAlgorithms.FindAllPaths(start, end, new Path())
                                    .Where(p => p.End == end)
                                    .OrderBy(p => p.Length()))
                _output.WriteLine(path.ToString());
        }


  
    }
}
