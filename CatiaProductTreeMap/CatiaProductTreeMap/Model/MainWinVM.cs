using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;


namespace CatiaProductTreeMap.Model
{
    public class MainWinVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region 属性

        /// <summary>
        /// 
        /// </summary>
        private string multiWD;
        public string MultiWD
        {
            get { return multiWD; }
            set
            {
                multiWD = value;
                OnPropertyChanged("MultiWD");
            }
        }

        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public MainWinVM()
        {

        }
    }
}
