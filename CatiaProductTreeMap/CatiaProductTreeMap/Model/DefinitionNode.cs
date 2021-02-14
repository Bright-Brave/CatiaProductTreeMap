using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatiaProductTreeMap.Model
{
    public class DefinitionNode
    {
        public string Name { get; set; }
        public IList<DefinitionNode> Children { get; set; }

        public DefinitionNode()
        {
        }
        public DefinitionNode(string name, IList<DefinitionNode> children)
        {
            Name = name;
            Children = children;
        }
    }

}
