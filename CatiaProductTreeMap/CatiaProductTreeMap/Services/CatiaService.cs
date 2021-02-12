using CATObjectModelerLibrary;
using INFITF;
using MECMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatiaProductTreeMap.Services
{
    public static class CatiaService
    {
        static public INFITF.Application catia = null;
        static public CATGeometry catiaGeometry = null;
        static public Part activePart = null;
        static public Selection sel = null;

        public static bool IsCatiaStart()
        {
            return catia != null;
        }

        public static bool IsPartActive()
        {
            return activePart != null;
        }

        /// <summary>
        /// 获取catia实例和激活的Part
        /// </summary>
        /// <returns></returns>
        public static void InitializeCatia()
        {
            try
            {
                catia = (INFITF.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("CATIA.Application");
                activePart = catia.ActiveEditor.ActiveObject as Part;
                //catiaGeometry = new CATGeometry(catia, activePart);
                sel = catia.ActiveEditor.Selection;
            }
            catch (Exception)
            {
            }
        }

    }
}
