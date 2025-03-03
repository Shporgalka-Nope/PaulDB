using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DBPaulMain.Model
{
    public enum DeviceType
    {
        Printer,
        Computer,
        Server,
        Console,
        Other
    }

    public enum StatusType
    {
        New,
        InProgress,
        Done
    }

    public class Request
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public DeviceType DeviceType { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public StatusType Status { get; set; }
        public User? RepairMan { get; set; }

        public Request(int _id, DateTime _dateTime, DeviceType _deviceType, string _model, string _desc, 
            string _name, string _telep, StatusType _status, User? _repairMan)
        {
            Id = _id;
            DateTime = _dateTime;
            DeviceType = _deviceType;
            Model = _model;
            Description = _desc;
            Name = _name;
            Telephone = _telep;
            Status = _status;
            RepairMan = _repairMan;
        }

        public override string ToString()
        {
            return $"Запрос №{Id}; Автор: {Name}; Дата создания: {DateTime}";
        }
    }
}
