using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph {
    class Path
    {
        public Vertex Begin => _points.FirstOrDefault();
        public Vertex End => _points.LastOrDefault();
        private List<Vertex> _points = new List<Vertex>();

        public void Add(Vertex e)
        {
            _points.Add(e);
        }

        public Path Copy()
        {
            return new Path() { _points = this._points.ToList() };
        }

        public int Length()
        {
            return _points.Count;
        }
        public bool Contains(Vertex e)
        {
            return _points.Contains(e);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var point in _points)
            {
                sb.Append(point.Name);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}