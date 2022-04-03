using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortCards.Repository
{
    public class SortCardsRepository : ISortCardsRepository
    {
        public List<string> GetSortedCardsList(List<string> InputList)
        {
            List<string> 
                SpecialCards, 
                Diamonds, 
                Spades,
                Clubs, 
                Hearts, 
                SortedSpecialCards,
                SortedDiamonds, 
                SortedSpades, 
                SortedClubs, 
                SortedHearts,
                SortedCards
                = new List<string>();
            //InputList = new List<string>() { "3C", "JS", "2D", "PT","ST","QH","JH", "10H","AH","9H", "KH", "8S", "4T","2T", "AC", "4H", "RT", "JD","QD","KD","AD" };
            try
            {
                SpecialCards = InputList.Where(item => item.EndsWith('T')).ToList();
                Diamonds = InputList.Where(item => item.EndsWith('D')).ToList();
                Spades = InputList.Where(item => item.EndsWith('S')).ToList();
                Clubs = InputList.Where(item => item.EndsWith('C')).ToList();
                Hearts = InputList.Where(item => item.EndsWith('H')).ToList();
                SortedSpecialCards = SortSpecialCards(SpecialCards);
                SortedDiamonds = SortSuits(Diamonds, "D");
                SortedClubs = SortSuits(Clubs, "C");
                SortedHearts = SortSuits(Hearts, "H");
                SortedSpades = SortSuits(Spades, "S");
                SortedSpecialCards.AddRange(SortedDiamonds);
                SortedSpecialCards.AddRange(SortedSpades);
                SortedSpecialCards.AddRange(SortedClubs);
                SortedSpecialCards.AddRange(SortedHearts);
                SortedCards = SortedSpecialCards;
            }
            catch (Exception Ex)
            {
                throw;
            }
            return SortedCards;
        }

        public List<string> SortSpecialCards(List<string> SpecialCards) 
        {
            if (SpecialCards.Contains("4T"))
                SpecialCards[SpecialCards.IndexOf("4T")] = "1T";
            if (SpecialCards.Contains("ST"))
                SpecialCards[SpecialCards.IndexOf("ST")] = "OT";
            SpecialCards.Sort() ;
            if (SpecialCards.Contains("1T"))
                SpecialCards[SpecialCards.IndexOf("1T")] = "4T";
            if (SpecialCards.Contains("OT"))
                SpecialCards[SpecialCards.IndexOf("OT")] = "ST";
            return SpecialCards;
        }
        public List<string> SortSuits(List<string> Suits, string card)
        {
            if(Suits.Contains("10" + card))
                Suits[Suits.IndexOf("10" + card)] = "9" + card + "A";
            if (Suits.Contains("A" + card))
                Suits[Suits.IndexOf("A" + card)] = "Z" + card;
            if (Suits.Contains("K" + card))
                Suits[Suits.IndexOf("K" + card)] = "Y" + card;

            Suits.Sort();

            if (Suits.Contains("9" + card + "A"))
                Suits[Suits.IndexOf("9" + card + "A")] = "10" + card;
            if (Suits.Contains("Z" + card))
                Suits[Suits.IndexOf("Z" + card)] = "A" + card;
            if (Suits.Contains("Y" + card))
                Suits[Suits.IndexOf("Y" + card)] = "K" + card;
            return Suits;
        }
    }
}
