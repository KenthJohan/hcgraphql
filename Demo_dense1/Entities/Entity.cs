using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;

namespace Demo
{
	public class Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string name { get; set; }
		public DateTime created { get; set; }
		public DateTime modified { get; set; }

		
		public virtual Book book { get; set; }
		public virtual User user { get; set; }
		public virtual Product product { get; set; }
		public virtual Building building { get; set; }

		public virtual List<Edge> edges { get; set; }
		public virtual List<Edge> edges1 { get; set; }
		public virtual List<Edge> edges2 { get; set; }
	}

}