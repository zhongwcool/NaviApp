﻿using Mar.Cheese;

namespace Dummy;

internal abstract class Program
{
    private static void Main(string[] args)
    {
        List<Room> rooms =
        [
            new Room { Name = "房间1" },
            new Room { Name = "房间2" },
            new Room { Name = "房间3" }
        ];

        List<Device> devices =
        [
            new Device { Name = "设备1", Site = "https://livedoc.cgtn.com/500d/prog_index.m3u8" },
            new Device { Name = "设备2", Site = "https://liveru.cgtn.com/1000r/prog_index.m3u8" },
            new Device { Name = "设备3", Site = "https://livefr.cgtn.com/1000f/prog_index.m3u8" },
            new Device { Name = "设备4", Site = "https://livees.cgtn.com/1000e/prog_index.m3u8" },
            new Device { Name = "设备5", Site = "https://livees.cgtn.com/1000e/prog_index.m3u8" },
            new Device { Name = "设备6", Site = "https://livees.cgtn.com/1000e/prog_index.m3u8" },
            new Device { Name = "设备7", Site = "https://livear.cgtn.com/1000a/prog_index.m3u8" },
            new Device { Name = "设备8", Site = "https://livedoc.cgtn.com/500d/prog_index.m3u8" },
            new Device { Name = "设备9", Site = "https://livees.cgtn.com/1000e/prog_index.m3u8" },
            new Device { Name = "设备10", Site = "https://liveru.cgtn.com/1000r/prog_index.m3u8" }
        ];

        rooms[0].Devices = [devices[0].Id, devices[1].Id, devices[2].Id];
        rooms[1].Devices = [devices[3].Id, devices[4].Id, devices[5].Id];
        rooms[2].Devices = [devices[6].Id, devices[7].Id];

        foreach (var room in rooms)
        {
            $"{room.Name} is under processing".PrintGreen();
            foreach (var deviceId in room.Devices)
            {
                var match = devices.FirstOrDefault(d => d.Id == deviceId);
                if (match != null) match.RoomId = room.Id;
            }
        }

        var dummy = new Dummy { rooms = rooms, devices = devices };

        JsonUtil.Save("0_dummy.json", dummy);

        Console.WriteLine("Hello, World!");
    }
}