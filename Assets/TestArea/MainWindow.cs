using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

namespace Prim
{
    public class MainWindow : MonoBehaviour
    {
        public int size = 10;
        private Point[] Positions;
        private float[,] Network;
        private System.Random R = new System.Random();

        public int SIZE = 64;

        public Lined LL;
        public GameObject basll;

        private Dictionary<Vector2, SData> connections;

        private int NUMS = 0;
        private int MaxAttemp = 10;
        private int NumAttemps = 0;

        private class SData
        {
            public Vector2 POS;
            public List<SData> Connections;

            public SData( Vector2 pos )
            {
                POS = pos;
                Connections = new List<SData>();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
                //Gen();
                print(ProceduralGeneration.ConstellationGenerator.Gen("ff", 15).SolarSystems.Count);
        }

        private void Gen()
        {
            NUMS = 0;
            NumAttemps = 0;

            while (NUMS < 3 && NumAttemps <= 10)
            {
                NUMS = 0;
                NumAttemps++;

                connections = new Dictionary<Vector2, SData>();

                foreach (Transform item in transform)
                {
                    Destroy(item.gameObject);
                }

                Positions = new Point[size];
                Network = new float[size, size];

                setnet(Network, Positions);

                prims();

                CreateLoop();
            }

            print( "Tried: " + NumAttemps + " times." );
        }

        private void setnet(float[,] Net, Point[] Pos)
        {
            int maxlength = (int)(Math.Min(SIZE, SIZE) * 0.9);
            int minlength = maxlength / size;
            for (int i = 0; i < size; i++)
            {
                Pos[i].X = R.Next(minlength, maxlength);
                Pos[i].Y = R.Next(minlength, maxlength);
                for (int j = 0; j <= i; j++)
                {
                    Net[i, j] = distance(Pos[i], Pos[j]);
                    Net[j, i] = Net[i, j];
                    if (i == j) Net[i, j] = 0;
                }
            }
        }

        private float distance(Point a, Point b)
        {
            return (float)Math.Sqrt((a.X - b.X) *
                                        (a.X - b.X) +
                                         (a.Y - b.Y) *
                                          (a.Y - b.Y));
        }

        private void shownet(float[,] Net)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Net[i, j] != 0)
                    {
                        DrawLine(Positions[i].X, Positions[i].Y, Positions[j].X, Positions[j].Y);

                        Vector2 from = new Vector2(Positions[i].X, Positions[i].Y);
                        Vector2 to = new Vector2(Positions[j].X, Positions[j].Y);

                        if ( connections.ContainsKey(from) )
                        {
                            connections[from].Connections.Add(new SData(to));
                        }else
                        {
                            connections.Add( from, new SData(from) );
                            connections[from].Connections.Add( new SData(to) );
                        }

                        if (connections.ContainsKey(to))
                        {
                            connections[to].Connections.Add(new SData(from));
                        }
                        else
                        {
                            connections.Add(to, new SData(to));
                            connections[to].Connections.Add(new SData(from));
                        }

                        //print(Positions[i].X + " : " + Positions[i].Y + " -> " + Positions[j].X + " : " + Positions[j].Y);
                    }
                }
            }

            foreach (KeyValuePair<Vector2, SData> con in connections)
            {
                //if (con.Value.Connections.Count >= 3)
                //    NUMS++;
                //print( con.Value.Connections.Count );
                //print(con.Key + " ");
                //foreach (var c in con.Value.Connections)
                //{
                //    print(" -> " + c.POS);
                //}
            }

            for (int i = 0; i < size; i++)
            {
                var bl = Instantiate( basll );
                bl.transform.SetParent(transform, false);
                bl.transform.position = new Vector3( Positions[i].X, Positions[i].Y, 0f );
            }
        }

        private void DrawLine( int startx, int starty, int endx, int endy )
        {
            Lined l = Instantiate( LL );
            l.transform.SetParent(transform, false);

            l.Init(startx, starty, endx, endy);
        }

        void prims()
        {
            int[] included = new int[size];
            int[] excluded = new int[size];
            float[,] finished = new float[size, size];
            int start = 0;
            int finish = 0;
            for (int i = 0; i < size; i++)
            {
                excluded[i] = i;
                included[i] = -1;
            }
            included[0] = excluded[R.Next(size)];
            excluded[included[0]] = -1;
            for (int n = 1; n < size; n++)
            {
                closest(n, ref start, ref finish, included, excluded);
                included[n] = excluded[finish];
                excluded[finish] = -1;
                finished[included[n], included[start]] = Network[included[n], included[start]];
                finished[included[start], included[n]] = Network[included[start], included[n]];
            }

            shownet(finished);

        }

        private void closest(int n, ref int start, ref int finish, int[] included, int[] excluded)
        {
            float smallest = -1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < size; j++)
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

        private void CreateLoop()
        {
            Vector2 startPos = new Vector2(Positions[0].X, Positions[0].Y);
            SData start = connections[startPos];

            foreach (var con in connections)
            {
                if (con.Value == start) continue;

                //if (ContainsCompate(connections[startPos].Connections, con.Value.Connections)) continue;

                if (start.Connections.Contains(con.Value)) continue;

                DrawLine((int)startPos.x, (int)startPos.y, (int)con.Value.POS.x, (int)con.Value.POS.y );
                print("wops");
                break;
            }
        }

        private bool ContainsCompate(List<SData> f, List<SData> s)
        {
            foreach (var g in f)
            {
                if (s.Contains(g)) return true;
            }

            return false;
        }
    }
}