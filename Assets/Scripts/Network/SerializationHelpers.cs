/**
 * Copyright (c) 2019 LG Electronics, Inc.
 *
 * This software contains code licensed as described in LICENSE.
 *
 */

using LiteNetLib.Utils;
using System;
using System.Globalization;

namespace Simulator.Network
{
    public static class SerializationHelpers
    {
        public static void SerializeLoadAgent(NetDataWriter writer, Commands.LoadAgent agent)
        {
            writer.Put(agent.Name);
            writer.Put(agent.Bridge);
            writer.Put(agent.Connection);
            writer.Put(agent.Sensors);
        }

        public static Commands.LoadAgent DeserializeLoadAgent(NetDataReader reader)
        {
            return new Commands.LoadAgent()
            {
                Name = reader.GetString(),
                Bridge = reader.GetString(),
                Connection = reader.GetString(),
                Sensors = reader.GetString(),
            };
        }
    }
}
