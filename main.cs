using System;
using System.Collections.Generic;
using System.Linq;

namespace Hi {
  class AStar {
    static void Main(string[] args) {
      Grid g = new Grid(15);
      Node start = g.tiles[1, 1];
      Node end = g.tiles[14, 14];

      List<Item> open = new List<Item>();
      List<Item> closed = new List<Item>();
      open.Add(new Item(start, end, 0));

      foreach(Node item in open[0].node.getNeighbors()) {
        Console.WriteLine("{0}, {1}", item.x, item.y);
      }
      
      Console.WriteLine(open[0].f);

      while (true) {
        if (open.Count == 0) {
          Console.WriteLine("No solution");
          return;
        }
        render(g, open, closed);

        open = open.OrderBy(o => o.f).ToList();
        Item best = open[0];
        open.Remove(best);
        closed.Add(best);

        List<Node> neighbors = best.node.getNeighbors();
        foreach(Node item in neighbors) {
          open.Add(new Item(item, end, best.g + 10));
        }
        Console.WriteLine();
        System.Threading.Thread.Sleep(1000);
      }
    }
    public static void render(Grid grid, List<Item> open, List<Item> closed) {

      for (int y = 0; y < grid.size; y++) {
        for (int x = 0; x < grid.size; x++) {
          String s = "";
          s = grid.tiles[x,y].passable ? " . " : " x ";
          if (open.FindIndex(item => item.node == grid.tiles[x,y]) != -1) {
            s = " o ";
          }
          if (closed.FindIndex(item => item.node == grid.tiles[x,y]) != -1) {
            s = " c ";
          }
          Console.Write(s);
        }
        Console.Write("\n");
      }
    }
  }
}

