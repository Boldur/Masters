﻿using System;
using System.Diagnostics.Eventing.Reader;

namespace SerchAlgorthmsPrototypes
{
    public class MapMakerScript
    {
        private int SizeOfMap;        
        private (int, int) StartPostion;
        private (int, int) EndPostion;
        private (int, String) Obstacles;
        private int RoboSize;
        public int[,] MapMatrix;

        public MapMakerScript(int size, (int, int) start, (int, int) end, (int, String) obst, int robotSize)
        {
            SizeOfMap = size;
            StartPostion = start;
            EndPostion = end;   
            Obstacles = obst;
            RoboSize = robotSize;
            MapMatrix = new int[size, size];
            
        }

        public int[,] createMatrix()
        {
            int col = 0;

            for (int i = 0; i < MapMatrix.GetLength(0); i++)
            {
                while (col < MapMatrix.GetLength(0))
                {
                    MapMatrix[i, col] = 0;
                    col++;
                }
                col = 0;
                MapMatrix[i, 0] = 9;
                MapMatrix[i, SizeOfMap - 1] = 9;
            }
            for (int i = 0; i < MapMatrix.GetLength(1); i++)
            {
                MapMatrix[0, i] = 9;
                MapMatrix[SizeOfMap - 1, i] = 9;
            }

            MapMatrix[StartPostion.Item1, StartPostion.Item2] = 1;
            MapMatrix[EndPostion.Item1, EndPostion.Item2] = 2;

            for (int num = 0; num < Obstacles.Item1; num++)
            {
                AddObstacles();
            }

            return MapMatrix;
        }

        private void AddObstacles()
        {
            Random rnd = new Random();
            int ChangeOgj = rnd.Next(1, 4);          
            int RandomRow = rnd.Next(1, SizeOfMap - 2);
            int RandomCol = rnd.Next(1, SizeOfMap - 2);
            int r = 0;
            int c = 0;

            switch (Obstacles.Item2)
            {
                case "Square":
                    AddSqure(r,c,RandomRow, RandomCol);
                    break;
                case "Line":
                    AddLine(r, c, RandomRow, RandomCol);
                    break;
                case "T_Line":
                    AddT_Line(r, c, RandomRow, RandomCol);
                    break;
                default:
                    ChangeOgj = rnd.Next(1, 4);
                    if (ChangeOgj == 1)
                    {
                        AddSqure(r, c, RandomRow, RandomCol);
                    }
                    else if (ChangeOgj == 2)
                    {
                        AddLine(r, c, RandomRow, RandomCol);
                    }
                    else
                    {
                        AddT_Line(r, c, RandomRow, RandomCol);
                    }
                    
                    break;
                   
            }
        }

        private void AddSqure(int r, int c, int RandomRow, int RandomCol)
        {
            r = 0;
            c = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i < 3) c = i;
                else if (i < 6) { r = 1; c = i - 3; }
                else if (i >= 6) { r = 2; c = i - 6; }
                if (MapMatrix[RandomRow + r, RandomCol + c] != 1 ||
                        MapMatrix[RandomRow + r, RandomCol + c] != 2)
                {
                    MapMatrix[RandomRow + r, RandomCol + c] = 9;
                }
            }
        }

        private void AddLine(int r, int c, int RandomRow, int RandomCol)
        {
            Random rnd = new Random();
            r = 0;
            c = 0;
            int collumOrRow = rnd.Next(1, 3);
            int lenght = (int)SizeOfMap / 3;

            for (int i = lenght; i > 0; i--)
            {
                if (collumOrRow == 1)
                {
                    r = SizeOfMap - 1;
                    if (MapMatrix[RandomRow, RandomCol] != 1 ||
                            MapMatrix[RandomRow, RandomCol] != 2)
                    {
                        MapMatrix[r - i, RandomCol] = 9;
                    }
                }
                else
                {
                    c = SizeOfMap - 1;
                    if (MapMatrix[RandomRow, RandomCol] != 1 ||
                        MapMatrix[RandomRow, RandomCol] != 2)
                    {
                        MapMatrix[RandomRow, c - i] = 9;
                    }
                }
            }
        }

        private void AddT_Line(int r, int c, int RandomRow, int RandomCol)
        {
            Random rnd = new Random();
            int HorV = rnd.Next(1, 3);
            for (int i = 0; i < 10; i++)
            {
                if (HorV == 1)
                {
                    if (MapMatrix[RandomRow + r, RandomCol + c] != 1 ||
                            MapMatrix[RandomRow + r, RandomCol + c] != 2)
                    {
                        if (i < 5)
                        {
                            if (RandomRow + i! < SizeOfMap - 1)
                                MapMatrix[RandomRow + i, RandomCol] = 9;
                        }
                        else
                        {
                            if (RandomCol + i - 5! < SizeOfMap - 1)
                                MapMatrix[RandomRow + 2, RandomCol + i - 5] = 9;
                        }
                    }
                }
                else
                {
                    if (true)
                    {
                        if (i < 5)
                        {
                            if (RandomCol + +i! < SizeOfMap - 1)
                                MapMatrix[RandomRow, RandomCol + i] = 9;
                        }
                        else
                        {
                            if (RandomRow + i - 5! < SizeOfMap - 1)
                                MapMatrix[RandomRow + i - 5, RandomCol + 2] = 9;
                        }
                    }
                }
            }
        }
    }
}
