using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Company
{
    internal struct Certificate
    {
        public int CertificateID { get; set; }
        public string CertificateName { get; set; }
        public string CertificateRank { get; set; }
        public DateOnly CertificateDate { get; set; }
    }
}
