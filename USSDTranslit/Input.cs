using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USSDTranslit
{
    class Input
    {
        string _rus = String.Empty;
        string _rusEn = String.Empty;
        string _ua = String.Empty;
        string _uaEn = String.Empty;

        public string InRus
        {
            get { return _rus; }
            set
            {
                if (_rus == value)
                    return;
                _rus = value;
            }
        }
        public string InRusEn
        {
            get { return _rusEn; }
            set
            {
                if (_rusEn == value)
                    return;
                _rusEn = value;
            }
        }
        public string InUA
        {
            get { return _ua; }
            set
            {
                if (_ua == value)
                    return;
                _ua = value;
            }
        }
        public string InUaEn
        {
            get { return _uaEn; }
            set
            {
                if (_uaEn == value)
                    return;
                _uaEn = value;
            }
        }
    }
}
