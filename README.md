# .Net-Remoting
.Net-Remoting
（一）
.Net Remoting概念
概念：一种分布式处理方式。从微软的产品角度来看，可以说Remoting就是DCOM (分布式组件对象模式)的一种升级，它改善了很多功能，并极好的融合到.Net平台下。

好处：

1.提供了一种允许对象通过应用程序域与另一对象进行交互的框架。

在Windows操作系统中，是将应用程序分离为单独的进程。这个进程形成了应用程序代码和数据周围的一道边界。如果不采用进程间通信（RPC）机制，则在一个进程中执行的代码就不能访问另一进程。这是一种操作系统对应用程序的保护机制。然而在某些情况下，我们需要跨过应用程序域，与另外的应用程序域进行通信，即穿越边界。

2.可以服务的方式来发布服务器对象：

代码可以运行在服务器上（如服务器激活的对象和客户端激活的对象），然后客户端再通过Remoting连接服务器，获得该服务对象并通过序列化在客户端运行。

3.客户端和服务器端有关对象的松散耦合

在Remoting中，对于要传递的对象，设计者除了需要了解通道的类型和端口号之外，无需再了解数据包的格式。这既保证了客户端和服务器端有关对象的松散耦合，同时也优化了通信的性能。

 

.NET Remoting支持通道与协议
Remoting的通道主要有两种：Tcp和Http，IChannel 包含TcpChannel，HttpChannel
TcpChannel:Tcp通道提供了基于Socket 的传输工具，使用Tcp协议来跨越Remoting边界传输序列化的消息流。默认使用二进制格式序列化消息对象,具有更高的传输性能。适用局域网。

HttpChannel:它提供了一种使用 Http协议，使其能在Internet上穿越防火墙传输序列化消息流。HttpChannel类型使用Soap格式序列化消息对象，因此它具有更好的互操作性。适用万维网。 

 

与WCF、WebService 区别
这里写的比较好：http://kb.cnblogs.com/page/50681/

Remoting可以灵活的定义其所基于的协议，比如http，tcp等，如果定义为HTTP，则与Web Service相同，但是webservice是无状态的，使用remoting一般都喜欢定义为TCP，这样比Web Service稍为高效一些，而且是有状态的。 
Remoting不是标准，而Web Service是标准。 
Remoting一般需要通过一个WinForm或是Windows服务进行启动，也可以使用iis部署，而Web Service则必须在IIS进行启动。 
在VS.net开发环境中，专门对Web Service的调用进行了封装，用起来比Remoting方便。 
net remoting只能应用于MS 的.net framework之下，需要客户端必须安装framework，但是WebService是平台独立的，跨语言（只要能支持XML的语言都可以） 以及穿透企业防火墙。
 

.NET Remoting激活方式
简单的理解：我们知道，在我们的Remoting应用需要远程处理对象，那么这些对象是怎么创建的？又是由谁去创建的呢？… 而激活方式则正是要说明这些疑问。

远程对象的激活分为两大类：服务器端激活(WellKnow)和客户端激活。

服务器端激活有两种模式:SingleTon模式和SingleCall。
 
实现Remoting步骤
1.创建远程处理的类型（由于Remoting传递的对象是以引用的方式，因此所传递的远程对象类必须继承MarshalByRefObject。）

2.创建服务端

3.创建客户端

MarshalByRefObject
MarshalByRefObject 是那些通过使用代理交换消息来跨越应用程序域边界进行通信的对象的基类。

不是从 MarshalByRefObject 继承的对象会以隐式方式按值封送。

当远程应用程序引用一个按值封送的对象时，将跨越远程处理边界传递该对象的副本。

因为您希望使用代理方法而不是副本方法进行通信，因此需要继承MarshallByRefObject。
 
在Remoting中能够传递的远程对象可以是各种类型，包括复杂的DataSet对象，只要它能够被序列化。远程对象也可以包含事件，但服务器端对于事件的处理比较特殊。

(二)
激活方式概念
在访问远程类型的一个对象实例之前，必须通过一个名为Activation的进程创建它并进行初始化。这种客户端通过通道来创建远程对象，称为对象的激活。

激活分为两大类：服务器端激活  客户端激活

 

服务器端激活
又称WellKnow(知名对象)

服务器应用程序在激活对象实例之前会在一个众所周知的统一资源标识符(URI)上来发布这个类型。然后该服务器进程会为此类型配置一个WellKnown对象，并根据指定的端口或地址来发布对象。

服务器端激活分为：SingleTon模式  SingleCall模式

 

SingleTon模式
设置为SingleTon激活方式，则Remoting将为所有客户端建立同一个对象实例。当对象处于活动状态时， SingleTon实例会处理所有后来的客户端访问请求，而不管它们是同一个客户端，还是其他客户端。SingleTon实例将在方法调用中一直维持其状态。举例来说，如果一个远程对象有一个累加方法（i=0；++i），被多个客户端（例如两个）调用。如果设置为SingleTon方式，则第一个客户获得值为1，第二个客户获得值为2，因为他们获得的对象实例是相同的。如果熟悉Asp .Net的状态管理，我们可以认为它是一种Application状态。


