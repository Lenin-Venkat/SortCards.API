using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortCards.Repository
{
    public interface ISortCardsRepository
    {
        List<string> GetSortedCardsList(List<string> InputList);
    }
}
