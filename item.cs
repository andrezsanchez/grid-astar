using System;
using System.Collections;
using System.Linq;

namespace Hi {
  class Item {
    public Node node {get;set;}
    public bool open {get;set;}
    public int f {get;set;}
    public int g {get;set;}

    public Item(Node node, Node dest, int g) {
      this.node = node;
      open = true;
      this.g = g;
      f = node.getH(dest) + g;
    }
  }
}


