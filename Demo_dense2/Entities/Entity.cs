using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using HotChocolate.Types;

namespace Demo
{

	public class Basic
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string name { get; set; }
		public DateTime created { get; set; }
		public DateTime modified { get; set; }
	}

	public class Atttribute : Basic
	{

	}

	public class Language : Basic
	{

	}

	public class Value_Text : Basic
	{
		[ForeignKey("attribute")]
		public int attribute_id { get; set; }
		public virtual Atttribute attribute { get; set; }

		[ForeignKey("language")]
		public int language_id { get; set; }
		public virtual Language language { get; set; }
	}

}


/*
table_0001
table_0010
table_0011
table_0100


table
guid | archetype
0    | 0001


*/





