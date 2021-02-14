using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatiaProductTreeMap.Model
{
    public class DefinitionNode : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private ObservableCollection<DefinitionNode> children;
        public ObservableCollection<DefinitionNode> Children
        {
            get { return children; }
            set
            {
                children = value;
                OnPropertyChanged("Children");
            }
        }

        public DefinitionNode()
        {
            Children = new ObservableCollection<DefinitionNode>();
        }
        public DefinitionNode(string name, ObservableCollection<DefinitionNode> children)
        {
            Name = name;
            Children = children;
        }
    }

}
