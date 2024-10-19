using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoomInformationService
    {
        private static RoomInformationService instance;
        private RoomInformationService() { }
        public static RoomInformationService GetInstance()
        {
            if (instance == null)
            {
                instance = new RoomInformationService();
            }
            return instance;
        }

        private UnitOfWork unitOfWork = new UnitOfWork();

        public IEnumerable<RoomInformation> GetAllRooms()
        {
            return unitOfWork.RoomInformationRepository.Get();
        }

        public void UpdateRoom(RoomInformation roomInformation)
        {
            unitOfWork.RoomInformationRepository.Update(roomInformation);
            unitOfWork.SaveChanges();
        }

        public void AddNewRoom(RoomInformation roomInformation)
        {
            unitOfWork.RoomInformationRepository.Insert(roomInformation);
            unitOfWork.SaveChanges();
        }

        public void DeleteRoom(RoomInformation roomInformation)
        {
            int bookingNums = roomInformation.BookingDetails.ToList().Count();
            if (bookingNums > 0)
            {
                roomInformation.RoomStatus = 0;
                unitOfWork.RoomInformationRepository.Update(roomInformation);
            }
            else
            {
                unitOfWork.RoomInformationRepository.Delete(roomInformation);
            }
            unitOfWork.SaveChanges();
        }
    }
}
