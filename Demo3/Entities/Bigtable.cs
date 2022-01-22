using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;

namespace Demo
{
	public class Bigtable
	{
		[Key]
		public int id { get; set; }


		[ForeignKey("parent")]
		public int parent_id { get; set; } = 1;
		public virtual Bigtable parent { get; set; }
		public virtual List<Bigtable> children { get; set; }
		public virtual List<Edge> edges { get; set; }
		public virtual List<Edge> edges1 { get; set; }
		public virtual List<Edge> edges2 { get; set; }


		
		public string name { get; set; }
	}



	public class Edge
	{
		[Key]
		[ForeignKey("r")]
		public int r_id { get; set; }
		public virtual Bigtable r { get; set; }

		[Key]
		[ForeignKey("a")]
		public int a_id { get; set; }
		public virtual Bigtable a { get; set; }
		
		[Key]
		[ForeignKey("b")]
		public int b_id { get; set; }
		public virtual Bigtable b { get; set; }
	}
}