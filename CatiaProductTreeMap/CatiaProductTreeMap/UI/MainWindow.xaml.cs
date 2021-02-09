using CatiaProductTreeMap.Model;
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
            for (int i = 1; i < vpmInstsL1.Count + 1; i++)
            {
                VPMInstance vpmInstL1 = vpmInstsL1.Item(i) as VPMInstance;
                // 拿到reference才能拿到instances
                VPMReference vpmRefInstL1 = vpmInstL1.ReferenceInstanceOf;
                VPMInstances vpmInstsL2 = vpmRefInstL1.Instances;

                //string m = vpmInstsL2.Count.ToString();

                for (int j = 1; j < vpmInstsL2.Count + 1; j++)
                {
                    VPMInstance vpmInstL2 = vpmInstsL2.Item(j) as VPMInstance;
                    VPMReference vpmRefInstL2 = vpmInstL2.ReferenceInstanceOf;
                    //MessageBox.Show(vpmInstL2.get_Name());
                    //MessageBox.Show(vpmRefInstL2.GetAttributeValue("V_Name"));

                    VPMRepInstances vpmRefInstsL3 = vpmRefInstL2.RepInstances;

                    for (int k = i; k < vpmRefInstsL3.Count + 1; k++)
                    {
                        VPMRepInstance vpmRepInstL3 = vpmRefInstsL3.Item(k) as VPMRepInstance;
                        VPMRepReference vpmRepRefL3 = vpmRepInstL3.ReferenceInstanceOf;
                        Part part = vpmRepRefL3.GetItem("Part") as Part;
                    }
                }
            }

        }
        private VPMInstances Recursion(VPMInstances vpmInsts)
        {
            for (int i = 1; i < vpmInsts.Count + 1; i++)
            {
                VPMInstance vpmInstL1 = vpmInsts.Item(i) as VPMInstance;
                // 拿到reference才能拿到instances
                VPMReference vpmRefInstL1 = vpmInstL1.ReferenceInstanceOf;
                VPMInstances vpmInstsL2 = vpmRefInstL1.Instances;


            }
        }
        private VPMInstances Recursion(VPMInstances vpmInsts)
        {
            for (int i = 1; i < vpmInsts.Count + 1; i++)
            {
                VPMInstance vpmInstL1 = vpmInsts.Item(i) as VPMInstance;
                // 拿到reference才能拿到instances
                VPMReference vpmRefInstL1 = vpmInstL1.ReferenceInstanceOf;
                VPMInstances vpmInstsL2 = vpmRefInstL1.Instances;


            }
        }
    }
}
