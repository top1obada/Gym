using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_DTO.Login.Session
{
    public class clsSessionDTO
    {

        public int? SessionID { get; set; }

        public string? HashedRefreshToken { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public DateTime? RevokedDate { get; set; }

        public string? DeviceName { get; set; }

    }
}
