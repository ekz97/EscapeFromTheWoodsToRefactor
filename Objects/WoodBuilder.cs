using EscapeFromTheWoods.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeFromTheWoods
{
    public static class WoodBuilder
    {
        public static Wood GetWood(int size, Map map, string path, DBwriter db)
        {
            Random r = new Random(100);
            List<Tree> trees = new List<Tree>();
            int n = 0;
            while (n < size)
            {
                Tree t = new Tree(IDgenerator.GetTreeID(), r.Next(map.xmin, map.xmax), r.Next(map.ymin, map.ymax));
                if (!trees.Contains(t)) { trees.Add(t); n++; }
            }
            Wood w = new Wood(IDgenerator.GetWoodID(), trees, map, path, db);
            return w;
        }

        public static void AssignTreesToGrid(Wood wood, Grid grid)
        {
            foreach (Tree tree in wood.trees)
            {
                grid.AssignTreeToGrid(tree);
            }
        }



    }
}
