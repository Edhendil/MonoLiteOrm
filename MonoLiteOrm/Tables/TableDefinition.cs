using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Mono.Mlo
{
	/// <summary>
	/// Table definition.
	/// 
	/// Contains all information about tables in the database based on attributes present in class definition.
	/// It is a physical table. With all foreign keys and such included.
	/// </summary>
	public class TableDefinition
	{
		
		private List<TableColumn> columns;
		
		public virtual string Name {get;set;}
		
		public TableDefinition ()
		{
			this.columns = new List<TableColumn>();
		}
		
		public virtual void addColumn(TableColumn column) {
			this.columns.Add (column);
			column.Table = this;
		}
		
		public virtual ReadOnlyCollection<TableColumn> getColumns() {
			return new ReadOnlyCollection<TableColumn>(this.columns);
		}
		
		public virtual string getTableSchema() {
			List<string> columnDefinitions = new List<string>();
			
			StringBuilder build = new StringBuilder();
			
			build.Append ("CREATE TABLE ");
			build.Append (this.Name);
			build.Append (" (");
			foreach (TableColumn col in this.columns) {
				columnDefinitions.Add (col.getColumnDefinition());
			}
			build.Append (String.Join (", ", columnDefinitions.ToArray()));
			build.Append (");");
			
			return build.ToString();
		}
	}
}

