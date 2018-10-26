using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace ProceduralGeneration
{
    public static class ConstellationGenerator
    {
        private static int NumberOfStars = 10;
        private static int ConstellationWidth = 64;
        private static Point[] Positions;
        private static float[,] Network;
            
        private static Dictionary<Vector2, StargateConnection> StargateConnections;
            
        private static int NUMS = 0;
        private static int MaxAttemp = 10;
        private static int NumAttemps = 0;

        private static Constellation Constellation;

        private class StargateConnection
        {
            public Vector2 Position;
            public List<StargateConnection> Connections;

            public StargateConnection(Vector2 pos)
            {
                Position = pos;
                Connections = new List<StargateConnection>();
            }
        }

        private static void Gen()
        {
            NUMS = 0;
            NumAttemps = 0;

            while (NUMS < 3 && NumAttemps <= 10)
            {
                NUMS = 0;
                NumAttemps++;

                StargateConnections = new Dictionary<Vector2, StargateConnection>();

                Positions = new Point[NumberOfStars];
                Network = new float[NumberOfStars, NumberOfStars];

                SetNet(Network, Positions);

                Prims();
            }
        }

        private static void SetNet(float[,] network, Point[] positions)
        {
            int maxlength = (int)(Math.Min(ConstellationWidth, ConstellationWidth) * 0.9);
            int minlength = maxlength / NumberOfStars;
            for (int i = 0; i < NumberOfStars; i++)
            {
                positions[i].X = Random.Range(minlength, maxlength);
                positions[i].Y = Random.Range(minlength, maxlength);
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
                        Vector2 from = new Vector2(Positions[i].X, Positions[i].Y);
                        Vector2 to = new Vector2(Positions[j].X, Positions[j].Y);

                        if (StargateConnections.ContainsKey(from))
                        {
                            StargateConnections[from].Connections.Add(new StargateConnection(to));
                        }
                        else
                        {
                            StargateConnections.Add(from, new StargateConnection(from));
                            StargateConnections[from].Connections.Add(new StargateConnection(to));
                        }

                        if (StargateConnections.ContainsKey(to))
                        {
                            StargateConnections[to].Connections.Add(new StargateConnection(from));
                        }
                        else
                        {
                            StargateConnections.Add(to, new StargateConnection(to));
                            StargateConnections[to].Connections.Add(new StargateConnection(from));
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
    }
}