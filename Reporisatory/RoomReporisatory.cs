﻿
using Microsoft.EntityFrameworkCore;
using mvcproj.Models;
using mvcproj.View_Models;

namespace mvcproj.Reporisatory
{
    public class RoomReporisatory :IGenericReporisatory<Room>, IRoomReporisatory
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
            return context.Rooms
                .Include(r => r.RoomType) 
                .ToList();
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
        }


        //i make it to use in update Room Action in Room Page 
        public Room GetRoomDetailsById(int id)
        {
            return context.Rooms
                .Where(r => r.RoomID == id)
                .Include(r => r.Hotel)
                .Include(r => r.RoomType)
                .FirstOrDefault();
        }
        
     
    }
}
