using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XDICTGRB;//金山词霸组件

namespace HmongDict
{
    class GetWord : IXDictGrabSink
    {
        GrabProxy m_GrabProxy = null;
        int m_nCookie = -1;

        //定义事件
        public event GetWordEventHadler OnGetWord;

        public GetWord()
        {
            m_GrabProxy = new GrabProxy();
            m_GrabProxy.GrabInterval = 1;                               //指抓取时间间隔
            m_GrabProxy.GrabMode = XDictGrabModeEnum.XDictGrabMouse;    //设定取词的属性
        }

        /*
        ~GetWord()
        {
            if (-1 != m_nCookie)
                StopGetWord();
        }
        */

        /// <summary>
        /// <para>Start Get Screen Word</para>
        /// <returns>Returns The success or failure of the state of Start Get Screen Word</returns>
        /// </summary>
        public bool StartGetWord()
        {
            m_GrabProxy.GrabEnabled = true;             //开始取词的属性
            m_nCookie = m_GrabProxy.AdviseGrab(this);

            return (-1 != m_nCookie);
        }

        /// <summary>
        /// <para>Stop Get Screen Word</para>
        /// <returns>Returns true (Note: if not call StartGetWord function first, this function will throw a Exception)</returns>
        /// </summary>
        public bool StopGetWord()
        {
            if (-1 == m_nCookie)
                throw new Exception("not call StartGetWord function first");

            m_GrabProxy.GrabEnabled = false;            //停止取词的属性
            m_GrabProxy.UnadviseGrab(m_nCookie);
            m_nCookie = -1;

            return true;
        }

        //定义托管
        public delegate void GetWordEventHadler(object sender, GetWordEventArgs e);

        //接口的实现
        int IXDictGrabSink.QueryWord(string WordString, int lCursorX, int lCursorY, string SentenceString, ref int lLoc, ref int lStart)
        {
            //this.textBox1.Text = SentenceString;                          //鼠标所在语句
            //this.textBox1.Text = SentenceString.Substring(lLoc + 1,1);    //鼠标所在字符

            //可在此处处理分析出单词，前后

            OnGetWord(this, new GetWordEventArgs(SentenceString));

            return 1;
        }
    }
}
