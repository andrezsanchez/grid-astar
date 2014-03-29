using System;

namespace Hi {
  class Grid {
    public Node[,] tiles {get;set;}
    public int size {get;set;}

    public Grid(int size) {
      Random rnd = new Random();
      this.size = size;
      tiles = new Node[size, size];

      for (int y = 0; y < size; y++) {
        for (int x = 0; x < size; x++) {
          bool passable = rnd.Next(0,10) != 0;
          tiles[x, y] = new Node(x, y, passable);

          if (x > 0) {
            tiles[x, y].link(tiles[x - 1, y]);
          }
          if (y > 0) {
            tiles[x, y].link(tiles[x, y - 1]);
          }
        }
      }
    }
  }
}

