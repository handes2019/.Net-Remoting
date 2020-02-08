using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;

namespace TestRemotingClient
{
    /// <summary>
    /// 客户端
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*创建通道*/
            //IpcChannel channel = new IpcChannel();
            //HttpChannel channel_http = new HttpChannel();
            TcpChannel channel_tcp = new TcpChannel();
            /*注册通道*/
            ChannelServices.RegisterChannel(channel_tcp, false); 
            /*注册通道 的 远程处理类型*/
            //RemotingConfiguration.RegisterWellKnownClientType(typeof(MessageMarshal.TestMessageMarshal), "http://localhost:8226/test");  
            /*注册通道 的 远程处理类型*/
            //RemotingConfiguration.RegisterActivatedClientType(typeof(MessageMarshal.TestMessageMarshal), "http://localhost:8226/test");
            //RemotingConfiguration.RegisterActivatedClientType(typeof(MessageMarshal.TestMessageMarshal), "ipc://localhost:8226/test");
            RemotingConfiguration.RegisterActivatedClientType(typeof(MessageMarshal.TestMessageMarshal), "tcp://localhost:8226/test");
            /*创建消息实体*/
            MessageMarshal.TestMessageMarshal TestMessage = new MessageMarshal.TestMessageMarshal();

            while (true)
            {
                
                TestMessage.SendMessage("DateTime.Now:" + System.DateTime.Now.ToString());
                Console.WriteLine("send message...");
                Thread.Sleep(2000);
            }
        }
    }
}