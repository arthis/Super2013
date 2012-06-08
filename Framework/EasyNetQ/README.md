A Nice .NET API for AMQP

**[Documentation](https://github.com/mikehadlow/EasyNetQ/wiki/Introduction)**

**[NuGet](http://nuget.org/List/Packages/EasyNetQ)**

Goals:

1. Zero or at least minimal configuration.
2. Simple API

		/// <summary>
		/// Provides a simple Publish/Subscribe and Request/Response API for a message bus.
		/// </summary>
		public interface IBus : IDisposable
		{
			/// <summary>
			/// Publishes a message.
			/// </summary>
			/// <typeparam name="T">The message type</typeparam>
			/// <param name="message">The message to publish</param>
			void Publish<T>(T message);

			/// <summary>
			/// Subscribes to a stream of messages that match a .NET type.
			/// </summary>
			/// <typeparam name="T">The type to subscribe to</typeparam>
			/// <param name="subscriptionId">
			/// A unique identifier for the subscription. Two subscriptions with the same subscriptionId
			/// and type will get messages delivered in turn. This is useful if you want multiple subscribers
			/// to load balance a subscription in a round-robin fashion.
			/// </param>
			/// <param name="onMessage">
			/// The action to run when a message arrives. When onMessage completes the message
			/// recipt is Ack'd. All onMessage delegates are processed on a single thread so you should
			/// avoid long running blocking IO operations. Consider using SubscribeAsync
			/// </param>
			void Subscribe<T>(string subscriptionId, Action<T> onMessage);

			/// <summary>
			/// Subscribes to a stream of messages that match a .NET type.
			/// Allows the subscriber to complete asynchronously.
			/// </summary>
			/// <typeparam name="T">The type to subscribe to</typeparam>
			/// <param name="subscriptionId">
			/// A unique identifier for the subscription. Two subscriptions with the same subscriptionId
			/// and type will get messages delivered in turn. This is useful if you want multiple subscribers
			/// to load balance a subscription in a round-robin fashion.
			/// </param>
			/// <param name="onMessage">
			/// The action to run when a message arrives. onMessage can immediately return a Task and
			/// then continue processing asynchronously. When the Task completes the message will be
			/// Ack'd.
			/// </param>
			void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage);

			/// <summary>
			/// Makes an RPC style asynchronous request.
			/// </summary>
			/// <typeparam name="TRequest">The request type.</typeparam>
			/// <typeparam name="TResponse">The response type.</typeparam>
			/// <param name="request">The request message.</param>
			/// <param name="onResponse">The action to run when the response is received.</param>
			void Request<TRequest, TResponse>(TRequest request, Action<TResponse> onResponse);

			/// <summary>
			/// Responds to an RPC request.
			/// </summary>
			/// <typeparam name="TRequest">The request type.</typeparam>
			/// <typeparam name="TResponse">The response type.</typeparam>
			/// <param name="responder">
			/// A function to run when the request is received. It should return the response.
			/// </param>
			void Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder);

			/// <summary>
			/// Responds to an RPC request asynchronously.
			/// </summary>
			/// <typeparam name="TRequest">The request type.</typeparam>
			/// <typeparam name="TResponse">The response type</typeparam>
			/// <param name="responder">
			/// A function to run when the request is received.
			/// </param>
			void RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder);

			/// <summary>
			/// Schedule a message to be published at some time in the future.
			/// This required the EasyNetQ.Scheduler service to be running.
			/// </summary>
			/// <typeparam name="T">The message type</typeparam>
			/// <param name="timeToRespond">The time at which the message should be sent</param>
			/// <param name="message">The message to response with</param>
			void FuturePublish<T>(DateTime timeToRespond, T message);

			/// <summary>
			/// Fires once the bus has connected to a RabbitMQ server.
			/// </summary>
			event Action Connected;

			/// <summary>
			/// Fires when the bus disconnects from a RabbitMQ server.
			/// </summary>
			event Action Disconnected;

			/// <summary>
			/// True if the bus is connected, False if it is not.
			/// </summary>
			bool IsConnected { get; }
		}

## Some blog posts about EasyNetQ ...

http://mikehadlow.blogspot.com/2011/05/easynetq-simple-net-api-for-rabbitmq.html

http://mikehadlow.blogspot.com/2011/05/futurepublish-with-easynetq-rabbitmq.html

http://mikehadlow.blogspot.com/2011/06/rabbitmq-subscription-and-bouncing.html

http://mikehadlow.blogspot.com/2011/07/rabbitmq-subscriptions-with-dotnet.html

http://mikehadlow.blogspot.com/2011/07/easynetq-how-should-messaging-client.html

## Getting started

Just open EasyNetQ.sln in VisualStudio 2010 and build.

All the required dependencies for the solution file to build the software are included. To run the explicit tests that send messages you will have to be running the EasyNetQ.Tests.SimpleService application and have a working local RabbitMQ server (see http://www.rabbitmq.com/ for more details).

## Mono specific

If you are building the software in monodevelop under Linux you will have to change the active solution configuration to 'Debug|Mixed platforms' to build all the included projects and set the 'Copy to output directory' property on  the app.config files to something other then 'Do not copy'. Most of the example programs will not run since they utilise the TopShelf assembly to run as a windows service. The basic tests and Tests.SimpleServer seem to behave correctly.
