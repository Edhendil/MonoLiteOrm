using System;

namespace Mono.Mlo
{
	public class EqualCondition
	{
		public virtual string ColumnName {get;set;}
		public virtual string EqualTo {get;set;}
		
		public EqualCondition ()
		{
		}
		
		public virtual string ToQueryString ()
		{
			return ColumnName + " = " + EqualTo;
		}
	}
}

