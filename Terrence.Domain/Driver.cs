using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terrence.Domain
{
    public class Driver : DomainBase
    {

        /// <summary>
        /// 供应商Id
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// 是否分配
        /// </summary>
        public bool IsDistribution { get; set; }

        /// <summary>
        /// 司机姓名
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool? Sex { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; }

        /// <summary>
        /// 驾龄
        /// </summary>
        public int? DrivingYears { get; set; }

        /// <summary>
        /// 驾驶证
        /// </summary>
        public string DrivingLicense { get; set; }

    }
}
