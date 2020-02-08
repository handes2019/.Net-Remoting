using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace TestRemotingServer
{
    /// <summary>
    /// 服务端
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("创建HTTP通道");
            /*创建HTTP通道*/
            HttpChannel channel = new HttpChannel(816);
            /*注册通道服务端*/
            ChannelServices.RegisterChannel(channel, false);
            /*服务端注册,使用Singletong激活*/
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(MessageMarshal.TestMessageMarshal), "test", WellKnownObjectMode.Singleton);
            Console.WriteLine("started ..."); 

            /*接收客户端事件*/
            MessageMarshal.TestMessageMarshal.SendMessageEvent += new MessageMarshal.SendMessageHandler(TestMessageMarshal_SendMessageEvent);

            Console.Read(); 
        }
        
        static void TestMessageMarshal_SendMessageEvent(string messge)
        {
            Console.WriteLine(messge);
        } 
    }
}