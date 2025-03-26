﻿
using mvcproj.Models;

namespace mvcproj.Reporisatory
{
    public class RoomReporisatory : IRoomReporisatory
    {
        Reservecotexet context;
        public RoomReporisatory (Reservecotexet context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            Room room = GetById (id);
            context.Remove(room);
        }

        public List<Room> GetAll()
        {
           List<Room> rooms= context.Rooms.ToList();
            return rooms;
        }

        public Room GetById(int id)
        {
            Room room = context.Rooms.FirstOrDefault(r => r.RoomID == id);
            return room;
        }

        //public IEnumerable<Room> GetRoomStatus()
        //{
        //   List<string> roomStatus = context.Rooms.Select(r=>r.Status).ToList();
        //    return roomStatus
        //}

        public void Insert(Room obj)
        {
            context.Add(obj);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Room obj)
        {
            context.Update(obj);
            Save();
        }
    }
}
