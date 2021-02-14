using CatiaProductTreeMap.Model;
using CatiaProductTreeMap.Services;
using PLMModelerBaseIDL;
using ProductStructureClientIDL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MainWinVM mainWinVM { get; set;}

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CatiaService.InitializeCatia();
            mainWinVM = new MainWinVM();
            GetTreeData(mainWinVM);
            DataContext = mainWinVM;
        }
        
        private void GetTreeData(MainWinVM mainWinVM)
        {
            PLMProductService service = (PLMProductService)CatiaService.catia.ActiveEditor.GetService("PLMProductService");
            VPMRootOccurrence vpmRootOcc = service.RootOccurrence;
            VPMReference vpmRefOnRoot = vpmRootOcc.ReferenceRootOccurrenceOf;
            // get all children of the root
            VPMInstances vpmInstsL1 = vpmRefOnRoot.Instances;
            DefinitionNode rootNode = new DefinitionNode();
            rootNode.Name = vpmRefOnRoot.GetAttributeValue("V_Name");
            mainWinVM.DefinitionNodes = new ObservableCollection<DefinitionNode>();
            mainWinVM.DefinitionNodes.Add(rootNode);
            Recursion(vpmInstsL1, rootNode);
        }

        private void Recursion(PLMEntities vpmInsts, DefinitionNode node)
        {
            ObservableCollection<DefinitionNode> definitionNodes = new ObservableCollection<DefinitionNode>();
            for ( int i = 1; i < vpmInsts.Count + 1; i++ )
            {
                DefinitionNode definitionNode = new DefinitionNode();

                VPMInstance vpmInstL1 = vpmInsts.Item(i) as VPMInstance;

                VPMReference vpmRefInstL1 = vpmInstL1.ReferenceInstanceOf;

                definitionNode.Name = vpmRefInstL1.GetAttributeValue("V_Name");

                definitionNodes.Add(definitionNode);

                VPMInstances vpmInstsL2 = vpmRefInstL1.Instances;

                if (vpmInstsL2.Count > 0)
                {
                    Recursion(vpmInstsL2, definitionNode);
                }
                else
                {
                    VPMRepInstances vpmRefInstsL3 = vpmRefInstL1.RepInstances;

                    ObservableCollection<DefinitionNode> nodes = new ObservableCollection<DefinitionNode>();
                    for (int k = i; k < vpmRefInstsL3.Count + 1; k++)
                    {
                        VPMRepInstance vpmRepInstL3 = vpmRefInstsL3.Item(k) as VPMRepInstance;
                        VPMRepReference vpmRepRefL3 = vpmRepInstL3.ReferenceInstanceOf;
                        DefinitionNode oneNode = new DefinitionNode();
                        oneNode.Name = vpmRepRefL3.GetAttributeValue("V_Name");
                        nodes.Add(oneNode);
                    }
                    definitionNode.Children = nodes;
                }
                
            }
            node.Children = definitionNodes;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            GetTreeData(mainWinVM);
        }
    }
}
