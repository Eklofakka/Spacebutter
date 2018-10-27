using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace ProceduralGeneration
{
    public static class ConstellationGenerator
    {
        private static int NumberOfStars = 10; // TODO: It generates one too many stars.
        private static int ConstellationWidth = 64;
        private static Point[] Positions;
        private static float[,] Network;
            
        private static Dictionary<Vector2Int, SolarSystemConnections> StargateConnections;
            
        private static int NumMultiConnections = 0;
        private static int MaxAttempts = 10;
        private static int NumAttempts = 0;

        private static Constellation Constellation;

        public static Constellation Gen( string name, int numberOfStars )
        {
            NumberOfStars = numberOfStars;

            Constellation = new Constellation( name );

            NumMultiConnections = 0;
            NumAttempts = 0;

            //while (NumMultiConnections < 3 && NumAttempts <= 0)
            //{
                NumMultiConnections = 0;
                NumAttempts++;

                StargateConnections = new Dictionary<Vector2Int, SolarSystemConnections>();

                Positions = new Point[NumberOfStars];
                Network = new float[NumberOfStars, NumberOfStars];

                SetNet(Network, Positions);

                Prims();

                AddStargates();
            //}
            return Constellation;
        }

        private static void SetNet(float[,] network, Point[] positions)
        {
            int maxlength = (int)(Math.Min(ConstellationWidth, ConstellationWidth) * 0.9);
            int minlength = maxlength / NumberOfStars;
            for (int i = 0; i < NumberOfStars; i++)
            {
                int xpos = Random.Range(minlength, maxlength);
                int ypos = Random.Range(minlength, maxlength);

                positions[i].X = xpos;
                positions[i].Y = ypos;

                Constellation.SolarSystems.Add( new SolarSystem(i, new Vector2Int(xpos, ypos)) );

                for (int j = 0; j <= i; j++)
                {
                    network[i, j] = Distance(positions[i], positions[j]);
                    network[j, i] = network[i, j];
                    if (i == j) network[i, j] = 0;
                }
            }
        }

        private static float Distance(Point a, Point b)
        {
            return (float)Math.Sqrt((a.X - b.X) *
                                        (a.X - b.X) +
                                            (a.Y - b.Y) *
                                            (a.Y - b.Y));
        }

        private static void ShowNet(float[,] Net)
        {
            for (int i = 0; i < NumberOfStars; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Net[i, j] != 0)
                    {
                        Vector2Int from = new Vector2Int(Positions[i].X, Positions[i].Y);
                        Vector2Int to = new Vector2Int(Positions[j].X, Positions[j].Y);

                        if (StargateConnections.ContainsKey(from))
                        {
                            StargateConnections[from].Connections.Add(new SolarSystemConnections(to));
                        }
                        else
                        {
                            StargateConnections.Add(from, new SolarSystemConnections(from));
                            StargateConnections[from].Connections.Add(new SolarSystemConnections(to));
                        }

                        if (StargateConnections.ContainsKey(to))
                        {
                            StargateConnections[to].Connections.Add(new SolarSystemConnections(from));
                        }
                        else
                        {
                            StargateConnections.Add(to, new SolarSystemConnections(to));
                            StargateConnections[to].Connections.Add(new SolarSystemConnections(from));
                        }
                    }
                }
            }
        }

        private static void Prims()
        {
            int[] included = new int[NumberOfStars];
            int[] excluded = new int[NumberOfStars];
            float[,] finished = new float[NumberOfStars, NumberOfStars];
            int start = 0;
            int finish = 0;
            for (int i = 0; i < NumberOfStars; i++)
            {
                excluded[i] = i;
                included[i] = -1;
            }
            included[0] = excluded[Random.Range(0, NumberOfStars)];
            excluded[included[0]] = -1;
            for (int n = 1; n < NumberOfStars; n++)
            {
                Closest(n, ref start, ref finish, included, excluded);
                included[n] = excluded[finish];
                excluded[finish] = -1;
                finished[included[n], included[start]] = Network[included[n], included[start]];
                finished[included[start], included[n]] = Network[included[start], included[n]];
            }

            ShowNet(finished);

        }

        private static void Closest(int n, ref int start, ref int finish, int[] included, int[] excluded)
        {
            float smallest = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < NumberOfStars; j++)
                {
                    if (excluded[j] == -1) continue;

                    if (smallest == -1)
                        smallest = Network[included[i], excluded[j]];

                    if (Network[included[i], excluded[j]] > smallest) continue;

                    smallest = Network[included[i], excluded[j]];
                    start = i;
                    finish = j;
                }
            }
        }

        private static void AddStargates()
        {
            Dictionary<Stargate, int> gates = new Dictionary<Stargate, int>();

            foreach (var con in StargateConnections)
            {
                int solarsystemID = Constellation.SolarSystemByPosition(con.Key).SolarsystemID;

                foreach (var stargate in con.Value.Connections)
                {
                    int targetID = Constellation.SolarSystemByPosition(stargate.Position).SolarsystemID;

                    Stargate sgate = new Stargate(Vector2Int.zero, solarsystemID);

                    gates.Add( sgate, targetID);

                    Constellation.SolarSystems[solarsystemID].Stargates.Add( sgate );
                }
            }

            Dictionary<Stargate, int> connectedGates = new Dictionary<Stargate, int>();

            foreach (KeyValuePair<Stargate, int>stargate in gates)
            {
                if (connectedGates.ContainsKey(stargate.Key)) continue;
                connectedGates.Add( stargate.Key, stargate.Value );

                // Grab a gate from the Gate list
                foreach (var targetGate in gates)
                {
                    if (connectedGates.ContainsKey(targetGate.Key)) continue;
                    
                    if (targetGate.Value == stargate.Value) continue;

                    connectedGates.Add( targetGate.Key, targetGate.Value );

                    stargate.Key.Target = targetGate.Key;
                    targetGate.Key.Target = stargate.Key;

                    break;
                }
            }


            foreach (var con in gates)
            {
                //Debug.Log(con.Value);
                //Stargate to = gates.Where(g => g.Key != con.Key)
                //          .Where(g => g.Value == con.Value)
                //          .First(g => g.Key.Target == null).Key;

                //con.Key.Target = to;
                //to.Target = con.Key;

                //Debug.Log("From: " + con.Key.Target.SolarsystemID + " To: " + to.Target.SolarsystemID);
            }


            foreach (var system in Constellation.SolarSystems)
            {
                Debug.Log( "StarSystem: " + system.SolarsystemID + " : "  + system.Name );

                foreach (var gate in system.Stargates)
                {
                    Debug.Log( "     " + gate.Target.SolarsystemID);
                }
            }
        }

        private class SolarSystemConnections
        {
            public Vector2Int Position;
            public List<SolarSystemConnections> Connections;

            public SolarSystemConnections(Vector2Int pos)
            {
                Position = pos;
                Connections = new List<SolarSystemConnections>();
            }
        }
    }
}
