using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VACARM
{
    public class BipartiteDeviceGraph
    {
        private Dictionary<DeviceControl, Dictionary<DeviceControl, RepeaterInfo>> Edge;

        public BipartiteDeviceGraph()
        {
            Edge = new Dictionary<DeviceControl, Dictionary<DeviceControl, RepeaterInfo>>();
        }

        public void AddVertex(DeviceControl device)
        {
            //if vertex does not exist, add vertex
            if (!Edge.ContainsKey(device)) Edge[device] = new Dictionary<DeviceControl, RepeaterInfo>();
        }

        public void RemoveVertex(DeviceControl device)
        {
            /* remove vertex along with any edges the vertex is an endpoint to */

            //remove device from adjacent devices' dictionaries
            foreach (DeviceControl adj in Edge[device].Keys)
            {
                Edge[adj].Remove(device);
                MainWindow.GraphMap.Children.Remove(Edge[device][adj].Link);
            }

            //remove adjacent devices from device dictionary
            Edge.Remove(device);
            MainWindow.GraphMap.Children.Remove(device);
        }

        private void AddEdge(DeviceControl device1, DeviceControl device2, RepeaterInfo info)
        {
            Edge[device1].Add(device2, info);
            Edge[device2].Add(device1, info);

            MainWindow.GraphMap.Children.Add(info.Link);
        }

        public void AddEdge(DeviceControl device1, DeviceControl device2)
        {
            //makes sure the edge is valid and does not already exist
            if (Edge[device1].ContainsKey(device2) || device1.DataFlow == device2.DataFlow) return;

            //create a "repeater" for the edge
            DeviceControl capture;
            DeviceControl render;

            if (device1.DataFlow == DataFlow.Capture)
            {
                capture = device1;
                render = device2;
            }
            else
            {
                capture = device2;
                render = device1;
            }

            RepeaterInfo repeater = new RepeaterInfo(capture, render);

            AddEdge(device1, device2, repeater);
        }

        public void RemoveEdge(DeviceControl device1, DeviceControl device2)
        {
            //removes adjacent vertex from vertex's dictionary
            MainWindow.GraphMap.Children.Remove(Edge[device1][device2].Link);
            Edge[device1].Remove(device2);
            Edge[device2].Remove(device1);
        }

        public Dictionary<DeviceControl, RepeaterInfo> GetAdjacent(DeviceControl device)
        {
            return Edge[device];
        }

        public void SaveGraph(string filename)
        {
            if (!filename.EndsWith(".vac")) filename += ".vac";
            StreamWriter writer = new StreamWriter($@"{Directory.GetCurrentDirectory()}\save\{filename}");

            List<DeviceControl> verteces = Edge.Keys.ToList();

            //first line contains N, the number of verteces
            writer.WriteLine(verteces.Count.ToString());

            Dictionary<DeviceControl, int> IndexLookup = new Dictionary<DeviceControl, int>();

            int M = 0;
            int i = 0;
            //next N*2 lines contain each vertex's device ID and position
            //also counts number of edges * 2
            foreach (DeviceControl vertex in verteces)
            {
                writer.WriteLine(vertex.ID);
                writer.WriteLine($"{vertex.Left} {vertex.Top}");
                IndexLookup[vertex] = i++;
                M += Edge[vertex].Count;
            }

            //next line contains M, the number of edges
            writer.WriteLine(M / 2);

            //next M*9 lines are edge information
            foreach (RepeaterInfo edge in GetEdges())
            {
                //first line of each edge is the index of the devices
                writer.WriteLine($"{IndexLookup[edge.Capture]} {IndexLookup[edge.Render]}");
                //next 8 lines are for the repeater information
                writer.WriteLine(edge.ToSaveData());
            }

            writer.Close();
        }

        public HashSet<RepeaterInfo> GetEdges()
        {
            HashSet<RepeaterInfo> edges = new HashSet<RepeaterInfo>();
            
            foreach (DeviceControl vertex in Edge.Keys)
            {
                foreach (DeviceControl adj in Edge[vertex].Keys)
                {
                    edges.Add(Edge[vertex][adj]);
                }
            }

            return edges;
        }

        public static BipartiteDeviceGraph LoadGraph(string filename)
        {
            BipartiteDeviceGraph graph = new BipartiteDeviceGraph();

            StreamReader reader = new StreamReader(filename);

            Dictionary<string, MMDevice> deviceFromID = new Dictionary<string, MMDevice>();

            //create ID dictionary to get the correct MMDevice
            foreach (MMDevice device in new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.All, DeviceState.All))
                deviceFromID[device.ID] = device;

            if (!int.TryParse(reader.ReadLine(), out int N)) return new BipartiteDeviceGraph();

            DeviceControl[] devices = new DeviceControl[N];

            //get array of verteces
            for (int i = 0; i < N; i++)
            {
                try
                {
                    MMDevice device = deviceFromID[reader.ReadLine()];
                    double[] pos = reader.ReadLine().Split().Select(x => double.Parse(x)).ToArray();
                    
                    DeviceControl control = new DeviceControl(device, graph);
                    control.Left = pos[0];
                    control.Top = pos[1];
                    MainWindow.GraphMap.Children.Add(control);
                    graph.AddVertex(control);
                    devices[i] = control;
                }
                catch
                {
                    devices[i] = null;
                }
            }

            if (!int.TryParse(reader.ReadLine(), out int M)) return new BipartiteDeviceGraph();

            //add edges to graph
            for (int i = 0; i < M; i++)
            {
                int[] adj = reader.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                List<string> data = new List<string>();
                for (int j = 0; j < 8; j++) data.Add(reader.ReadLine());

                DeviceControl capture = devices[adj[0]];
                DeviceControl render = devices[adj[1]];

                if (capture == null || render == null) continue;

                RepeaterInfo repeater = new RepeaterInfo(capture, render);
                repeater.SetData(data);

                graph.AddEdge(capture, render, repeater);
            }

            reader.Close();

            return graph;
        }
    }
}
