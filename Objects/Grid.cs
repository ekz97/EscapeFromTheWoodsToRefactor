using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeFromTheWoods.Objects
{
    public class Grid
    {
        public int XMin { get; private set; }
        public int XMax { get; private set; }
        public int YMin { get; private set; }
        public int YMax { get; private set; }
        private int _gridSize { get; set; }

        private Dictionary<Tuple<int, int>, List<Tree>> gridTrees; // Een dictionary om bomen te koppelen aan hun grid

        public Grid(int xMin, int xMax, int yMin, int yMax)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
            gridTrees = new Dictionary<Tuple<int, int>, List<Tree>>();
        }

        public List<Tree> GetTreesInGrid(List<Tree> trees, Tree center, decimal radius, HashSet<int> visited)
        {
            return trees.Where(t => IsWithinGrid(t.x, t.y) &&
                                    !visited.Contains(t.treeID) &&
                                    !t.hasMonkey &&
                                    CalculateDistance(t, center) <= (double)radius)
                        .ToList();
        }


        private double CalculateDistance(Tree tree1, Tree tree2)
        {
            return Math.Sqrt(Math.Pow(tree1.x - tree2.x, 2) + Math.Pow(tree1.y - tree2.y, 2));
        }

        private bool IsWithinGrid(int x, int y)
        {
            return x >= XMin && x <= XMax && y >= YMin && y <= YMax;
        }
        public void CreateGrid(int gridSize)
        {
            _gridSize = gridSize;
            int numGridsX = (XMax - XMin) / _gridSize;
            int numGridsY = (YMax - YMin) / _gridSize;

            for (int i = 0; i <= numGridsX; i++)
            {
                for (int j = 0; j <= numGridsY; j++)
                {
                    int gridXMin = XMin + (i * _gridSize);
                    int gridXMax = gridXMin + _gridSize;
                    int gridYMin = YMin + (j * _gridSize);
                    int gridYMax = gridYMin + _gridSize;

                    Tuple<int, int> key = new Tuple<int, int>(i, j);

                    gridTrees[key] = new List<Tree>();
                }
            }
        }

        public void AssignTreeToGrid(Tree tree)
        {
            int gridX = tree.x / _gridSize;
            int gridY = tree.y / _gridSize;

            Tuple<int, int> key = new Tuple<int, int>(gridX, gridY); // Gebruik Tuple als de sleutel

            if (!gridTrees.ContainsKey(key))
            {
                gridTrees[key] = new List<Tree>(); // Maak een nieuwe lijst als de sleutel nog niet bestaat
            }

            gridTrees[key].Add(tree); // Voeg de boom toe aan de lijst die hoort bij het grid
        }

    }
}
