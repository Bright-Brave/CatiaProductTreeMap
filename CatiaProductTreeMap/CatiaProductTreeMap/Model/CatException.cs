using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatiaProductTreeMap.Model
{
    public class CatException : Exception
    {
        public ErrorTypeEnum errorType { get; set; }
        public string errorMsg { get; set; }
        public CatException(ErrorTypeEnum catErrorType, string catErrorMsg)
        {
            errorMsg = string.Format("{0}\r\n{1}", this.Message, catErrorMsg);
            errorType = catErrorType;
        }
    }

    public enum ErrorTypeEnum
    {
        PROGRAME_GO_ON = 0,// 不影响运行

        PROGRAME_WAIT = 1,// 等待用户输入

        PROGRAME_STOP = 2,// 程序停止
    }
}
