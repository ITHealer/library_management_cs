using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLTV
{
    public class DTO_MuonSach
    {
        private string _MaSach;
        private string _MaDG;
        private DateTime? _NgayMuon;
        private DateTime? _NgayTra;

        public DTO_MuonSach() { }

        public DTO_MuonSach(string maSach, string maDG, DateTime? nm, DateTime? nt)
        {
            this.MaSach = maSach;
            this.MaDG = maDG;
            this.NgayMuon = nm;
            this.NgayTra = nt;
        }

        public string MaSach { get => _MaSach; set => _MaSach = value; }
        public string MaDG { get => _MaDG; set => _MaDG = value; }
        public DateTime? NgayMuon { get => _NgayMuon; set => _NgayMuon = value; }
        public DateTime? NgayTra { get => _NgayTra; set => _NgayTra = value; }
    }
}
