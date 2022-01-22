using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.AspNetCore;

namespace Demo
{
	public class User
	{
		[Key]
		[ForeignKey("entity")]
		public int entity_id { get; set; }
		public virtual Entity entity { get; set; }

		public Guid guid { get; set; }

		[GraphQLDescription("Your email")]
		public string email { get; set; }

		[MaxLength(36)]
		[MinLength(36)]
		public byte[] pwhash { get; set; }
	}

	
}