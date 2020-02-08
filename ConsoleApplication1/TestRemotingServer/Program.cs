using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Tcp;

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
            //IpcChannel channel_ipc = new IpcChannel("localhost:8226");
            //HttpChannel channel_http = new HttpChannel(8226);
            /*创建HTTP通道*/
            TcpChannel channel_tcp = new TcpChannel(8226);
            /*注册通道服务端*/
            ChannelServices.RegisterChannel(channel_tcp, false);
            /*服务端注册,使用Singletong激活*/
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(MessageMarshal.TestMessageMarshal), "test", WellKnownObjectMode.Singleton);
            /*设置模式为 SingleCall */
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(MessageMarshal.TestMessageMarshal),"test", WellKnownObjectMode.SingleCall);  
            
            RemotingConfiguration.ApplicationName = "test";
            RemotingConfiguration.RegisterActivatedServiceType(typeof(MessageMarshal.TestMessageMarshal));   
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