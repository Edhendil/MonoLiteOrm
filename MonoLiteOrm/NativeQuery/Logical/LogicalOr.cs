using System;
using System.Text;
using System.Collections.Generic;

namespace Mono.Mlo
{
	public class LogicalOr
	{
		
		private List<ILogicalCondition> conditions;
		
		public List<ILogicalCondition> Conditions {get{return this.conditions;}}
		
		public LogicalOr ()
		{
			this.conditions = new List<ILogicalCondition>();
		}
		
		public LogicalOr (params ILogicalCondition[] conditions) {
			this.conditions = new List<ILogicalCondition> (conditions);
		}
		
		public string ToQueryString() {
			StringBuilder builder = new StringBuilder();
			builder.Append ("(");
			this.conditions.ForEach((x) => builder.Append(x.ToQueryString() + " OR "));
			builder.Remove (builder.Length - 4,4);
			builder.Append (")");
			return builder.ToString ();
		}
	}
}

