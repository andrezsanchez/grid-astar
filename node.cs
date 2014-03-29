using System;
using System.Collections;
using System.Collections.Generic;

namespace Hi {
  class Node {
    public List<Node> links {get;set;}
    public int x {get;set;}
    public int y {get;set;}
    public bool passable {get;set;}

    public Node(int X, int Y, bool Passable) {
      x = X;
      y = Y;
      passable = Passable;
      links = new List<Node>();
    }

    public int getH(Node n) {
      int xdist = Math.Abs(n.x - x);
      int ydist = Math.Abs(n.y - y);
      return xdist + ydist;
    }

    public void link(Node node) {
      links.Add(node);
      node.links.Add(this);
    }

    public List<Node> getNeighbors() {
      List<Node> valid = new List<Node>();
      foreach(Node link in links) {
        if (link.passable) {
          valid.Add(link);
        }
      }
      return valid;
    }
  }
}

