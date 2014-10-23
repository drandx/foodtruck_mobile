using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClickNDone.Core
{
	public class TermsConditionsViewModel:BaseViewModel
	{
		public TermsConditionsViewModel ()
		{
		}

		public async Task<TermsConditions> GetTermsConditions()
		{
			IsBusy = true;
			TermsConditions result;
			try
			{
				result = await service.GetTermsConditionsAsync(false);
			}
			finally 
			{
				IsBusy = false;
			}

			return result;
		} 

	}
}

