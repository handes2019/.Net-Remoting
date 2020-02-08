using System;
using System.Runtime.Remoting.Metadata;
namespace MessageMarshal
{
    /// <summary>
    /// 远程处理类
    /// </summary>
    /*创建发送消息委托*/
    public delegate void SendMessageHandler(string message);
    public class TestMessageMarshal:MarshalByRefObject
    {
        //创建发送消息事件
        public static event SendMessageHandler SendMessageEvent;
        
        //发送消息
        [SoapMethod(XmlNamespace = "MessageMarshal", SoapAction = "MessageMarshal#SendMessage")]
        public void SendMessage(string message)
        {
            if (SendMessageEvent != null)
            {
                SendMessageEvent(message);
            }
        }
    }
}