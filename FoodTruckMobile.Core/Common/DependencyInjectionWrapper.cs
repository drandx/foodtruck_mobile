using System;
using System.ComponentModel.Design;

namespace DInteractive.Core
{
	public class DependencyInjectionWrapper
	{
		private static DependencyInjectionWrapper instance;
		private static ServiceContainer _container;

		private DependencyInjectionWrapper() 
		{
			_container = new ServiceContainer ();
		}

		public static DependencyInjectionWrapper Instance
		{
			get 
			{
				if (instance == null)
				{
					instance = new DependencyInjectionWrapper();
				}
				return instance;
			}
		}

		public ServiceContainer ServiceContainer()
		{
			return _container;
		}

	}
}

