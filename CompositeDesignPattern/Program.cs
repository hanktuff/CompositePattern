using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignPattern {
    class Program {
        static void Main(string[] args) {

            var root = new Composite();

            root.Leaves.Add(new Leaf());
            root.Leaves.Add(new Leaf());

            var subroot = new Composite();
            root.Leaves.Add(subroot);

            subroot.Leaves.Add(new Leaf());

            root.Operation();
        }
    }


    abstract class Component {
        public abstract void Operation();
    }

    class Composite : Component {
        public List<Component> Leaves = new List<Component>();
        public override void Operation() {
            Console.WriteLine("Operation() in Composite class.");
            foreach (var item in this.Leaves) {
                item.Operation();
            }
        }
    }

    class Leaf : Component {
        public override void Operation() {
            Console.WriteLine("Operation() in Leaf class.");
        }
    }
}
