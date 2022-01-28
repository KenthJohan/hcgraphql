using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;

namespace Demo
{
	public class Book
	{
		[Key]
		[ForeignKey("entity")]
		public int entity_id { get; set; }
		public virtual Entity entity { get; set; }
	}
}