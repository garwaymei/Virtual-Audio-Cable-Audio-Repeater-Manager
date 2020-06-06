using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VACARM
{
    class BipartiteDeviceGraph
    {
        private Dictionary<DeviceControl, HashSet<DeviceControl>> edges;

        public BipartiteDeviceGraph()
        {
            edges = new Dictionary<DeviceControl, HashSet<DeviceControl>>();
        }

        public void AddVertex(DeviceControl d)
        {
            if (!edges.ContainsKey(d)) edges[d] = new HashSet<DeviceControl>();
        }

        public void RemoveVertex(DeviceControl d)
        {
            if (!edges.ContainsKey(d)) return;

            foreach (DeviceControl adj in edges[d]) edges[adj].Remove(d);
            edges.Remove(d);
        }

        public void AddEdge(DeviceControl d1, DeviceControl d2)
        {
            if (!edges.ContainsKey(d1)) edges[d1] = new HashSet<DeviceControl>();
            if (!edges.ContainsKey(d2)) edges[d2] = new HashSet<DeviceControl>();

            edges[d1].Add(d2);
            edges[d2].Add(d1);
        }

        public void RemoveEdge(DeviceControl d1, DeviceControl d2)
        {
            if (!edges.ContainsKey(d1) || !edges.ContainsKey(d2)) return;

            edges[d1].Remove(d2);
            edges[d2].Remove(d1);
        }

        public HashSet<DeviceControl> GetAdjacent(DeviceControl d) => edges[d];
    }
}
