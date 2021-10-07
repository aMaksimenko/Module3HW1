using System.Collections.Generic;
using HomeWork.Models;

namespace HomeWork.Helpers
{
    public class TitleComparer : IComparer<MyModel>
    {
        public int Compare(MyModel x, MyModel y)
        {
            return string.CompareOrdinal(x?.Title, y?.Title);
        }
    }
}