using System.Collections.Generic;

namespace Graph {
    class Edge
    {
        public string Name { get; }
        public IReadOnlyCollection<Edge> Connected => _connected;
        private readonly List<Edge> _connected = new List<Edge>();
        public Edge(string name)
        {
            Name = name;
        }

        public void CreateVertexTo(params Edge[] edges)
        {
            foreach(var e in edges)
            {
                AddVertex(this,e);
                AddVertex(e,this);
            }
        }

        private void AddVertex(Edge from,Edge to)
        {
            if (!from._connected.Contains(to))
                from._connected.Add(to);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}