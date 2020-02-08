using System;
using System.Runtime.Remoting.Metadata;
namespace MessageMarshal
{
    /// <summary>
    /// 远程处理类
    /// </summary>
    /*创建发送消息委托*/
    public delegate void SendMessageHandler(string message);
    [Serializable]
    public class TestMessageMarshal:MarshalByRefObject
    {
        private Guid ID { get; set; }
        /*新建对象实例时重新创建标识编号*/
        public TestMessageMarshal()
        {
            ID = Guid.NewGuid();
        }
        
        //创建发送消息事件
        public static event SendMessageHandler SendMessageEvent;
        
        //发送消息
        [SoapMethod(XmlNamespace = "MessageMarshal", SoapAction = "MessageMarshal#SendMessage")]
        public void SendMessage(string message)
        {
            if (SendMessageEvent != null)
            {
                SendMessageEvent(ID.ToString()+"\t"+ message);
            }
        }
    }
}