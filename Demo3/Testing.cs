using System;
using System.Data;
using System.Data.Common;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;

//https://www.codeproject.com/Articles/5263745/Return-DataTable-Using-Entity-Framework

namespace Demo
{
	public static class Testing
	{

		
		public static void init(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<Demo_Context>();
				//If all tables are dropped then they will be created here:
				//dropall(context);
				//context.Database.ExecuteSqlRaw("DROP TABLE course_user_edges CASCADE");
				var del = context.Database.EnsureDeleted();
				if (del)
				{
					Log.Information("Arena: Database Deleted");
				}
				else
				{
					Log.Information("Arena: Database not Deleted");
				}
				var created = context.Database.EnsureCreated();
				if (created)
				{
					Log.Information("Arena: Database created");
				}
				else
				{
					Log.Information("Arena: Database not created, already exist");
				}
				Testing.db_add_example(context);
			}
		}

		public static void db_add_example(Demo_Context context)
		{

			var Root = new Bigtable{name="Root"};
			context.bigtable.Add(Root);
			context.SaveChanges();

			var Owner = new Bigtable{name="Owner"};
			context.bigtable.Add(Owner);
			context.SaveChanges();

			var Tower1 = new Bigtable{name="Tower1"};
			var Tower2 = new Bigtable{name="Tower2"};
			context.bigtable.Add(Tower1);
			context.bigtable.Add(Tower2);
			context.SaveChanges();


			var Carson = new Bigtable{name="Carson"};
			var Arturo = new Bigtable{name="Arturo"};
			var Gytis = new Bigtable{name="Gytis"};
			var Yan = new Bigtable{name="Yan"};
			var Peggy = new Bigtable{name="Peggy"};
			var Laura = new Bigtable{name="Laura"};
			context.bigtable.Add(Carson);
			context.bigtable.Add(Arturo);
			context.bigtable.Add(Gytis);
			context.bigtable.Add(Yan);
			context.bigtable.Add(Peggy);
			context.bigtable.Add(Laura);
			context.SaveChanges();

			var e = new Edge[]
			{
				new Edge{r_id = Owner.id, a_id = Carson.id, b_id = Tower1.id},
				new Edge{r_id = Owner.id, a_id = Carson.id, b_id = Tower2.id},
			};
			context.edges.AddRange(e);
			context.SaveChanges();


			/*

			var properties = new Course_Property[]
			{
				new Course_Property{course_id=1050,language=Language_Code.EN,name=Property_Name.TITLE,   value="Chemistry"},
				new Course_Property{course_id=1050,language=Language_Code.SE,name=Property_Name.TITLE,   value="Kemi"},
				new Course_Property{course_id=1050,language=Language_Code.EN,name=Property_Name.SUBTITLE,value="Chemistry is the scientific discipline involved with elements and compounds composed of atoms, molecules and ions."},
				new Course_Property{course_id=4022,language=Language_Code.EN,name=Property_Name.TITLE,   value="Microeconomics"},
				new Course_Property{course_id=4022,language=Language_Code.EN,name=Property_Name.SUBTITLE,value="Economics that studies the behavior of individuals and firms in making decisions regarding the allocation of scarce resources."},
				new Course_Property{course_id=1045,language=Language_Code.EN,name=Property_Name.TITLE,   value="Calculus"},
				new Course_Property{course_id=1045,language=Language_Code.SE,name=Property_Name.TITLE,   value="Kalkyl"},
				new Course_Property{course_id=2042,language=Language_Code.EN,name=Property_Name.TITLE,   value="Literature"},
				new Course_Property{course_id=2042,language=Language_Code.SE,name=Property_Name.TITLE,   value="Litteratur"},
				new Course_Property{course_id=2021,language=Language_Code.EN,name=Property_Name.TITLE,   value="Composition"},
				new Course_Property{course_id=2021,language=Language_Code.SE,name=Property_Name.TITLE,   value="Ackord"},
				new Course_Property{course_id=3141,language=Language_Code.EN,name=Property_Name.TITLE,   value="Trigonometry"},
				new Course_Property{course_id=3141,language=Language_Code.SE,name=Property_Name.TITLE,   value="Trigonometri"},
			};

			var courses = new Course[]
			{
			new Course{id=1050,title="Chemistry",category="Science"},
			new Course{id=4022,title="Microeconomics",category="Economics"},
			new Course{id=4041,title="Macroeconomics",category="Economics"},
			new Course{id=1045,title="Calculus",category="Math"},
			new Course{id=3141,title="Trigonometry",category="Math"},
			new Course{id=2021,title="Composition"},
			new Course{id=2042,title="Literature"}
			};

			var keywords = new Keyword[]
			{
				new Keyword{name="Artificiell Intelligens",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Bränsle",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Certifiering",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Design",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Digitalisering",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Energi",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Ekonomi",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Hållbarhet",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Produktion",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Ledarskap",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Miljö",is_category=true,is_tag=true,is_topic=true},
				new Keyword{name="Säkerhet",is_category=true,is_tag=true,is_topic=true},
				
				new Keyword{name="Math"},
				new Keyword{name="C#",is_tag=true},
				new Keyword{name="C++",is_tag=true},
				new Keyword{name="C",is_tag=true},
				new Keyword{name="Q#",is_tag=true},
				new Keyword{name="Java",is_tag=true},
				new Keyword{name="JavaScript",is_tag=true},
				new Keyword{name="TypeScript",is_tag=true},
				new Keyword{name="Elm",is_tag=true},
				new Keyword{name="Rust",is_tag=true},
				new Keyword{name="Python",is_tag=true},
				new Keyword{name="Julia",is_tag=true},
			};

			var course_keyword_edges = new Course_Keyword_Edge[]
			{
				new Course_Keyword_Edge{keyword_id=1, course_id=1045},
				new Course_Keyword_Edge{keyword_id=1, course_id=3141},
				new Course_Keyword_Edge{keyword_id=2, course_id=4022},
				new Course_Keyword_Edge{keyword_id=2, course_id=4041},
			};

			var enrollments = new Course_User_Edge[]
			{
			new Course_User_Edge{user_id=1,course_id=1050,grade=Grade.A,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=1,course_id=4022,grade=Grade.C,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=1,course_id=4041,grade=Grade.B,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=2,course_id=1045,grade=Grade.B,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=2,course_id=3141,grade=Grade.F,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=2,course_id=2021,grade=Grade.F,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=3,course_id=1050,grade=Grade.A,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=4,course_id=1050,grade=Grade.A,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=4,course_id=4022,grade=Grade.F,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=5,course_id=4041,grade=Grade.C,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=6,course_id=1045,grade=Grade.A,date=DateTime.Parse("2005-09-01")},
			new Course_User_Edge{user_id=7,course_id=3141,grade=Grade.A,date=DateTime.Parse("2005-09-01")},
			};




			foreach (Keyword s in keywords)
			{
				context.keywords.Add(s);
			}
			context.SaveChanges();
			foreach (User s in students)
			{
				context.users.Add(s);
			}
			context.SaveChanges();
			foreach (Course c in courses)
			{
				context.courses.Add(c);
			}
			context.SaveChanges();
			foreach (Course_Property s in properties)
			{
				context.course_properties.Add(s);
			}
			context.SaveChanges();
			foreach (Course_Keyword_Edge s in course_keyword_edges)
			{
				context.course_keyword_edges.Add(s);
			}
			context.SaveChanges();
			foreach (Course_User_Edge e in enrollments)
			{
				context.course_user_edges.Add(e);
			}
			context.SaveChanges();
			}
			*/
		}
	}
}