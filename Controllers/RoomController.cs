using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcproj.Models;
using mvcproj.Reporisatory;

namespace mvcproj.Controllers
{
    public class RoomController : Controller
    {
        IRoomReporisatory roomRepo;
        IRoomTypeReporisatory roomTypeRepo;
        private readonly IWebHostEnvironment webHostEnvironment;

        public RoomController(IRoomReporisatory roomRepo, IRoomTypeReporisatory roomTypeRepo, IWebHostEnvironment webHostEnvironment) 
        {
            this.roomRepo = roomRepo;
            this.roomTypeRepo = roomTypeRepo;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Room> roomList = roomRepo.GetAll();
            return View("Index", roomList);
        }
        public IActionResult AddRoom()
        {
            var roomTypes = roomTypeRepo.GetRoomType();
            ViewBag.RoomTypes = new SelectList(roomTypes, "TypeID", "Name"); 
            return View("AddRoom");
        }


        [HttpPost]
        public async Task<IActionResult> SaveRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                if (room.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(room.ImageFile.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await room.ImageFile.CopyToAsync(fileStream);
                    }

                    room.image = "/uploads/" + uniqueFileName;
                }

                roomRepo.Insert(room);
                return RedirectToAction("Index"); 
            }

            var roomTypes = roomTypeRepo.GetRoomType();
            ViewBag.RoomTypes = new SelectList(roomTypes, "TypeID", "TypeName", room.TypeID);
            return View("AddRoom"); // 🔹 إذا كان هناك خطأ، يعيد المستخدم لنفس الصفحة مع الأخطاء
        }

    }
}
