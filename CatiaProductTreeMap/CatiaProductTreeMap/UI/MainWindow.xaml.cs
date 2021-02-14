using CatiaProductTreeMap.Model;
using CatiaProductTreeMap.Services;
using MECMOD;
using PLMModelerBaseIDL;
using ProductStructureClientIDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VPMEditorContextIDL;

namespace CatiaProductTreeMap.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<DefinitionNode> DefinitionNodes { get; set; }
        public MainWinVM mainWinVM { get; set; }
        //private string treeMsg = "";
        //private string space = "";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CatiaService.InitializeCatia();

            PLMProductService service = (PLMProductService)CatiaService.catia.ActiveEditor.GetService("PLMProductService");
            VPMRootOccurrence vpmRootOcc = service.RootOccurrence;
            VPMReference vpmRefOnRoot = vpmRootOcc.ReferenceRootOccurrenceOf;
            // get all children of the root
            VPMInstances vpmInstsL1 = vpmRefOnRoot.Instances;
            DefinitionNode rootNode = new DefinitionNode();
            DefinitionNodes.Add( rootNode );
            rootNode.Name = vpmRefOnRoot.GetAttributeValue("V_Name");
            //treeMsg += vpmRefOnRoot.GetAttributeValue("V_Name");
            Recursion(vpmInstsL1, rootNode);
        }
        
        private void Recursion(PLMEntities vpmInsts, DefinitionNode node)
        {
            List<DefinitionNode> definitionNodes = new List<DefinitionNode>();
            //space += "----";
            for ( int i = 1; i < vpmInsts.Count + 1; i++ )
            {
                DefinitionNode definitionNode = new DefinitionNode();

                VPMInstance vpmInstL1 = vpmInsts.Item(i) as VPMInstance;

                // 拿到reference才能拿到instances
                VPMReference vpmRefInstL1 = vpmInstL1.ReferenceInstanceOf;

                definitionNode.Name = vpmRefInstL1.GetAttributeValue("V_Name");

                definitionNodes.Add(definitionNode);
                //treeMsg += space;
                //string n = vpmRefInstL1.GetAttributeValue("V_Name");
                //treeMsg += n;
                //treeMsg += "\r\n";
                VPMInstances vpmInstsL2 = vpmRefInstL1.Instances;

                if (vpmInstsL2.Count > 0)
                {
                    //node.Children = definitionNodes;
                    Recursion(vpmInstsL2, definitionNode);
                }
                else
                {
                    VPMRepInstances vpmRefInstsL3 = vpmRefInstL1.RepInstances;

                    List<DefinitionNode> nodes = new List<DefinitionNode>();
                    //space += "----";
                    for (int k = i; k < vpmRefInstsL3.Count + 1; k++)
                    {
                        VPMRepInstance vpmRepInstL3 = vpmRefInstsL3.Item(k) as VPMRepInstance;
                        VPMRepReference vpmRepRefL3 = vpmRepInstL3.ReferenceInstanceOf;
                        DefinitionNode oneNode = new DefinitionNode();
                        oneNode.Name = vpmRepRefL3.GetAttributeValue("V_Name");
                        nodes.Add(oneNode);

                        //n = vpmRepRefL3.GetAttributeValue("V_Name");
                        //treeMsg += space;
                        //treeMsg += n;
                        //treeMsg += "\r\n";
                    }
                    definitionNode.Children = nodes;
                }
                
            }
            node.Children = definitionNodes;
        }
    }
}
