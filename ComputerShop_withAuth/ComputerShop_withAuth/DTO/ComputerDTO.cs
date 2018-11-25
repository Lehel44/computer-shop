using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop_withAuth.DTO
{
    public class ComputerDTO
    {
        public int? CpuId { get; set; }
        public int? VgaId { get; set; }
        public int? MemoryId { get; set; }
        public int? MotherboardId { get; set; }
        public int? CaseId { get; set; }
        public int? MonitorId { get; set; }

        public ComputerDTO()
        {
        }

        public ComputerDTO(int? _CpuId, int? _VgaId, int? _MemoryId, int? _MotherboardId, int? _CaseId, int? _MonitorId)
        {
            CpuId = _CpuId;
            VgaId = _VgaId;
            MemoryId = _MemoryId;
            MotherboardId = _MotherboardId;
            CaseId = _CaseId;
            MonitorId = _MonitorId;
        }
    }
}
