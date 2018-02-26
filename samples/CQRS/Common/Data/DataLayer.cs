using System;
using System.Collections.Generic;

namespace Data
{
    public class DataLayer
    {
        public IEnumerable<string> SaveEventData<T>(IEnumerable<T> eventData) where T : class
        {
            // Logic with MongoDB ... comes later

            throw new NotImplementedException();
        }
    }
}
