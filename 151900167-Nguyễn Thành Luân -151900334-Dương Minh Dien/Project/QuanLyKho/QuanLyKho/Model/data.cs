using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Model
{
    public class data
    {
        private static data _ins;
        public static data Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new data();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public PhanmemQuanLydkEntities DB { get; set; }

        private data()
        {
            DB = new PhanmemQuanLydkEntities();
        }
    }
}
