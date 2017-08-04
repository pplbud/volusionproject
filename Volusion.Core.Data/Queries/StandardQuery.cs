using Volusion.Core.Models;

namespace Volusion.Core.Data.Queries
{
    public class StandardQuery
    {
        public StandardQuery()
        {
            ModelState = new ModelState { LogMessage = null };
        }

        public ModelState ModelState { get; set; }
    }
}