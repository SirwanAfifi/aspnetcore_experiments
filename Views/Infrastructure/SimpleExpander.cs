using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Views.Infrastructure
{
    public class SimpleExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // do nothing - not required
        }
        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            // Turn these:
            /*
                "/Views/{1}/{0}.cshtml"
                "/Views/Shared/{0}.cshtml"
            */

            foreach (string location in viewLocations)
            {
                yield return location.Replace("Shared", "Common");
            }
            yield return "/Views/Legacy/{1}/{0}/View.cshtml";

            // Into these:
            /*
				/Views/Home/MyView.cshtml
				/Views/Common/MyView.cshtml
				/Views/Legacy/Home/MyView/View.cshtml
			 */
        }
    }
}