using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern {
    class Program {
        static void Main(string[] args) {

            var root = new Composite("root");

            root.Leaves.Add(new Leaf("leaf 1"));
            root.Leaves.Add(new Leaf("leaf 2"));

            var subroot = new Composite("subroot");
            subroot.Leaves.Add(new Leaf("leaf 3"));

            root.Leaves.Add(subroot);

            var subsubroot = new Composite("sub-subroot");
            subsubroot.Leaves.Add(new Leaf("leaf 4"));
            subsubroot.Leaves.Add(new Leaf("leaf 5"));

            subroot.Leaves.Add(subsubroot);

            root.Operation();
        }
    }


    abstract class Component {
        public abstract void Operation();
    }


    class Composite : Component {

        private string name = string.Empty;
        public Composite(string Name) { name = Name; }

        public List<Component> Leaves = new List<Component>();

        public override void Operation() {
            Console.WriteLine($"Operation() in Composite class {name}.");
            foreach (var item in this.Leaves) {
                item.Operation();
            }
        }
    }


    class Leaf : Component {

        private string name = string.Empty;
        public Leaf(string Name) { name = Name; }

        public override void Operation() { Console.WriteLine($"Operation() in Leaf class {name}."); }
    }
}
