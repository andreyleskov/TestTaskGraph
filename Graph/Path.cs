using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph {
    class Path
    {
        public Edge Begin => _points.FirstOrDefault();
        public Edge End => _points.LastOrDefault();
        private List<Edge> _points = new List<Edge>();

        public void Add(Edge e)
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
        public bool Contains(Edge e)
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