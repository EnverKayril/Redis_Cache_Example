﻿using StackExchange.Redis;

ConnectionMultiplexer connection = await ConnectionMultiplexer.ConnectAsync("localhost:6379");
ISubscriber subscriber = connection.GetSubscriber();

while (true)
{
    Console.WriteLine("Mesaj : ");
    string message = Console.ReadLine();
    await subscriber.PublishAsync("mychannel", message);
}