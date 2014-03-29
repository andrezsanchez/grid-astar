using System;
using System.Collections.Generic;
using System.Linq;

namespace Hi {
  class AStar {
    static void Main(string[] args) {
      Grid g = new Grid(30);
      Node start = g.tiles[21, 21];
      Node end = g.tiles[14, 14];

      List<Item> open = new List<Item>();
      List<Item> closed = new List<Item>();
      open.Add(new Item(start, end, 0));


      while (true) {
        if (open.Count == 0) {
          Console.WriteLine("No solution");
          return;
        }
        render(g, open, closed, start, end);

        open = open.OrderBy(o => o.f).ToList();
        Item best = open[0];
        open.Remove(best);
        closed.Add(best);

        List<Node> neighbors = best.node.getNeighbors();
        foreach(Node item in neighbors) {
          int c = closed.FindIndex(q => q.node == item);
          int o = open.FindIndex(q => q.node == item);

          int newG = best.g;

          // Get the distance in x and y to see if it's diagnal or not
          int diff = Math.Abs(best.node.x - item.x) + Math.Abs(best.node.y - item.y);
          if (diff == 2) {
            newG += 14;
          }
          else {
            newG += 10;
          }

          if (c != -1) {
            if (newG < closed[c].g) {
            }
          }
          else if (o != -1) {
          }
          else {
            open.Add(new Item(item, end, newG));
          }
        }


        Console.WriteLine();
        System.Threading.Thread.Sleep(300);
      }
    }
    public static void render(Grid grid, List<Item> open, List<Item> closed, Node start, Node end) {

      for (int y = 0; y < grid.size; y++) {
        for (int x = 0; x < grid.size; x++) {
          Console.ResetColor();

          String s = "";
          if (grid.tiles[x,y].passable) {
            s = " . ";
          }
          else {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            s = " x ";
          }

          if (open.FindIndex(item => item.node == grid.tiles[x,y]) != -1) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            s = " o ";
          }
          if (closed.FindIndex(item => item.node == grid.tiles[x,y]) != -1) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            s = " c ";
          }
          if (start == grid.tiles[x,y]) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Magenta;
            s = " s ";
          }
          if (end == grid.tiles[x,y]) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Magenta;
            s = " d ";
          }
          Console.Write(s);
          Console.ResetColor();
        }
        Console.Write("\n");
      }

      /*
      Console.WriteLine("closed: {0}", closed.Count);
      foreach (Item i in closed) {
        Console.WriteLine("x: {0}, y: {1}, f: {2}, g: {3}", i.node.x, i.node.y, i.f, i.g);
      }

      Console.WriteLine("open: {0}", open.Count);
      foreach (Item i in open) {
        Console.WriteLine("x: {0}, y: {1}, f: {2}, g: {3}", i.node.x, i.node.y, i.f, i.getH(end));
      }
      */
    }
  }
}

