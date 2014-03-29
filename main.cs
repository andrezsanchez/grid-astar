using System;
using System.Collections.Generic;
using System.Linq;

namespace Hi {
  class AStar {
    static void Main(string[] args) {
      Grid g = new Grid(15);
      List<Item> open = new List<Item>();
      List<Item> closed = new List<Item>();

      //render(g, open, closed, start, end);

      string line;

      // DRY - Definitely Repeat Yourself

      Console.WriteLine("start x?");
      line = Console.ReadLine();
      int startX;
      if (!int.TryParse(line, out startX)) {
        Console.WriteLine("Not a number");
        return;
      }

      Console.WriteLine("start y?");
      line = Console.ReadLine();
      int startY;
      if (!int.TryParse(line, out startY)) {
        Console.WriteLine("Not a number");
        return;
      }

      Console.WriteLine("end x?");
      line = Console.ReadLine();
      int endX;
      if (!int.TryParse(line, out endX)) {
        Console.WriteLine("Not a number");
        return;
      }

      Console.WriteLine("end y?");
      line = Console.ReadLine();
      int endY;
      if (!int.TryParse(line, out endY)) {
        Console.WriteLine("Not a number");
        return;
      }

      Node start = g.tiles[startX, startY];
      Node end = g.tiles[endX, endY];

      // Make sure the start and end nodes are passable
      start.passable = true;
      end.passable = true;

      open.Add(new Item(start, null, end, 0));


      while (true) {
        if (open.Count == 0) {
          Console.WriteLine("No solution");
          return;
        }

        open = open.OrderBy(o => o.f).ToList();
        Item best = open[0];
        open.Remove(best);
        closed.Add(best);

        if (best.node == end) {
          Console.WriteLine("Solution found!");
          return;
        }

        List<Node> neighbors = best.node.getNeighbors();
        foreach(Node item in neighbors) {
          int newG = best.g;

          // Get the distance in x and y to see if it's diagnal or not
          // yes, i'm lazy for putting this here
          int diff = Math.Abs(best.node.x - item.x) + Math.Abs(best.node.y - item.y);
          if (diff == 2) {
            newG += 14;
          }
          else {
            newG += 10;
          }

          int c = closed.FindIndex(q => q.node == item);
          int o = open.FindIndex(q => q.node == item);
          if (c != -1) {
            //dont re-add closed list items

            if (newG < closed[c].g) {
              // eh
            }
          }
          else if (o != -1) {
            //dont re-add open list items
          }
          else {
            open.Add(new Item(item, null, end, newG));
          }
        }

        render(g, open, closed, start, end);
        Console.WriteLine();

        System.Threading.Thread.Sleep(300);
      }
    }
    public static void render(Grid grid, List<Item> open, List<Item> closed, Node start, Node end) {

      grid.iterate( (x, y, tile) => {
        Console.ResetColor();

        String s = "";

        Render.passable(ref s, tile);
        Render.open(ref s, tile, open);
        Render.closed(ref s, tile, closed);
        Render.start(ref s, tile, start);
        Render.end(ref s, tile, end);

        Console.Write(s);
        Console.ResetColor();

        Render.newLine(grid, tile);
      });

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
    public void drawStart() {
    }
  }
}

