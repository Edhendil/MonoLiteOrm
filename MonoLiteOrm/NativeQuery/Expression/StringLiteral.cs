using System;

namespace Mono.Mlo
{
	public class StringLiteral : IQueryExpression
	{
		
		public virtual string Value {get;set;}
		
		public StringLiteral ()
		{
		}
		
		public virtual string ToQueryString() {
			return "'" + escapeCharacters(Value) + "'";
		}
		
		private string escapeCharacters(string toEscape) {
			return toEscape.Replace ("'","''");
		}
	}
}

