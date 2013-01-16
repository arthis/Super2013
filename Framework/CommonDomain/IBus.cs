using System;
using System.Threading.Tasks;

namespace CommonDomain
{
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
        void Publish<T>(T message) where T : IMessage;


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
        void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : IMessage;

        /// <summary>
        /// Schedule a message to be published at some time in the future.
        /// This required the EasyNetQ.Scheduler service to be running.
        /// </summary>
        /// <typeparam name="T">The message type</typeparam>
        /// <param name="timeToRespond">The time at which the message should be sent</param>
        /// <param name="message">The message to response with</param>
        void FuturePublish<T>(DateTime timeToRespond, T message) where T : IMessage;

        
    }
}