﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    /// <summary>
    /// Cập nhật allow null cho các thuộc tính ICollection
    /// </summary>
    /// 21/08 - Khôi
    public class Address
	{
		public Guid Id { get; set; }
		public string City { get; set; }
		public string District { get; set; }
		public string Ward { get; set; }
		public string DefaultAddress { get; set; }
		public bool Status { get; set; }
		public Guid IdAccount { get; set; }
		public Account? Account { get; set; }
	}
}
