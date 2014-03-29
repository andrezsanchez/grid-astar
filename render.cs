using System;
using System.Collections.Generic;
using System.Linq;

namespace Hi {
  class Render {
    public static void passable(ref string s, Node tile) {
      if (tile.passable) {
        s = " . ";
      }
      else {
        Console.BackgroundColor = ConsoleColor.Red;
        s = " x ";
      }
    }
    public static void open(ref string s, Node tile, List<Item> open) {
      if (open.FindIndex(item => item.node == tile) != -1) {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        s = " o ";
      }
    }
    public static void closed(ref string s, Node tile, List<Item> open) {
      if (open.FindIndex(item => item.node == tile) != -1) {
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        s = " c ";
      }
    }
    public static void start(ref string s, Node start, Node tile) {
      if (start == tile) {
        Console.BackgroundColor = ConsoleColor.Magenta;
        s = " s ";
      }
    }
    public static void end(ref string s, Node end, Node tile) {
      if (end == tile) {
        Console.BackgroundColor = ConsoleColor.Magenta;
        s = " e ";
      }
    }

    public static void newLine(Grid grid, Node tile) {
      if (tile.x == grid.size - 1) {
        Console.Write("\n");
      }
    }
  }
}
