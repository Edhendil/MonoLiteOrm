using System;
using System.Reflection;
using System.Collections.Generic;

namespace Mono.Mlo
{
	public class MonoLiteOrm
	{
		
		private MonoLiteOrm ()
		{
		}
		
		public static EntityManagerFactory getFactory(PersistenceContextConfig config) {
			AttributeConfigLoader configLoader = new AttributeConfigLoader();
			
			AssemblyMapping mappings = new AssemblyMapping();
			
			// convert names to assembly objects
			IEnumerable<Type> persistentTypes = AttributeUtils.GetTypesWithAttribute<Entity>(config.Assemblies);
			
			foreach (Type type in persistentTypes) {
				mappings.AddMapping (configLoader.createMapping(type));	
			}
			
			return new EntityManagerFactory(config, mappings);
		}
		
	}
}

