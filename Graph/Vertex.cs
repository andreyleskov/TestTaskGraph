using System.Collections.Generic;

namespace Graph {
    class Vertex
    {
        public string Name { get; }
        public IReadOnlyCollection<Vertex> Connected => _connected;
        private readonly List<Vertex> _connected = new List<Vertex>();
        public Vertex(string name)
        {
            Name = name;
        }

        public void Connect(params Vertex[] vertices)
        {
            foreach(var e in vertices)
            {
                AddVertex(this,e);
                AddVertex(e,this);
            }
        }

        private void AddVertex(Vertex from,Vertex to)
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