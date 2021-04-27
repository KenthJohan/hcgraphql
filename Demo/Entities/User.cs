using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;

namespace Demo
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		public Guid guid { get; set; }

		public string email { get; set; }

		[MaxLength(64)]
		[MinLength(64)]
		public byte[] pwhash64 { get; set; }
	}
}
