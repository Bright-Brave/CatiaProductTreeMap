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
        public MainWinVM mainWinVM { get; set; }
        public MainWindow()
        {
            InitializeComponent();


            CatiaService.InitializeCatia();

            PLMProductService service = (PLMProductService)CatiaService.catia.ActiveEditor.GetService("PLMProductService");
            VPMRootOccurrence vpmRootOcc = service.RootOccurrence;
            //MessageBox.Show(vpmRootOcc.get_Name());
            // 这一步很重要，需要从Occurrence  model 切换为 Reference-instance model
            VPMReference vpmRefOnRoot = vpmRootOcc.ReferenceRootOccurrenceOf;
            //MessageBox.Show(vpmRefOnRoot.get_Name());
            // MessageBox.Show(vpmRefOnRoot.get_Name());
            // 获取根节点下的所有实例
            VPMInstances vpmInstsL1 = vpmRefOnRoot.Instances;
            // 遍历实例
            // 从1开始
            m += vpmRefOnRoot.GetAttributeValue("V_Name");
            m += "\r\n";
            Recursion(vpmInstsL1);

            MessageBox.Show(m);
        }
        string m = "";
        // 层次标识符
        string space = "";
        private void Recursion(PLMEntities vpmInsts)
        {
            space += "----";
            for (int i = 1; i < vpmInsts.Count + 1; i++)
            {
                VPMInstance vpmInstL1 = vpmInsts.Item(i) as VPMInstance;
                // 拿到reference才能拿到instances
                VPMReference vpmRefInstL1 = vpmInstL1.ReferenceInstanceOf;
                m += space;
                string n = vpmRefInstL1.GetAttributeValue("V_Name");
                m += n;
                m += "\r\n";
                VPMInstances vpmInstsL2 = vpmRefInstL1.Instances;

                if (vpmInstsL2.Count > 0)
                {
                    Recursion(vpmInstsL2);
                    
                }
                else
                {
                    VPMRepInstances vpmRefInstsL3 = vpmRefInstL1.RepInstances;
                    space += "----";
                    for (int k = i; k < vpmRefInstsL3.Count + 1; k++)
                    {
                        VPMRepInstance vpmRepInstL3 = vpmRefInstsL3.Item(k) as VPMRepInstance;
                        VPMRepReference vpmRepRefL3 = vpmRepInstL3.ReferenceInstanceOf;
                        n = vpmRepRefL3.GetAttributeValue("V_Name");
                        m += space;
                        m += n;
                        m += "\r\n";
                    }
                    space = "----";
                }
            }
        }
    }
}
