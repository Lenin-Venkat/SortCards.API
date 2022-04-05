using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortCards.Repository
{
    public interface ISortCardsRepository
    {
        Task<List<string>> GetSortedCardsList(List<string> InputList);
        Task<List<string>> SortSpecialCards(List<string> SpecialCards);
        Task<List<string>> SortSuits(List<string> Suits, string card);
    }
}
