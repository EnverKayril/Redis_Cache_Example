﻿using StackExchange.Redis;

ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:6379");
ISubscriber subscriber = connection.GetSubscriber();

await subscriber.SubscribeAsync("mychannel.*", (channel, message) =>
{
    Console.WriteLine(message);
});

Console.Read();