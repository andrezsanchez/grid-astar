using System;
using System.Collections;
using System.Linq;

namespace Hi {
  class Item {
    public Node node {get;set;}
    public Item parent {get;set;}
    public bool open {get;set;}
    public int f {get;set;}
    public int g {get;set;}

    public Item(Node node, Item parent, Node dest, int g) {
      open = true;
      this.g = g;
      this.node = node;
      this.parent = parent;
      f = node.getH(dest) + g;
    }
  }
}


