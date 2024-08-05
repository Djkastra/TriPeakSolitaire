/*
 * Handles the game logic for the TriPeak Solitaire game.
 * Checks whether card can be flipped or not.
 */
using System.Collections.Generic;
using System.Linq;

namespace TriPeakSolitaire
{
    public class GameLogic
    {
        private readonly List<Card> tableauCards;

        public GameLogic(List<Card> tableauCards)
        {
            this.tableauCards = tableauCards;
        }
        
        private Dictionary<int, List<int>> coveringMap = new Dictionary<int, List<int>>
        {
            { 0, new List<int> { 3, 4 } },
            { 1, new List<int> { 5, 6 } },
            { 2, new List<int> { 7, 8 } },
            { 3, new List<int> { 9, 10 } },
            { 4, new List<int> { 10, 11 } },
            { 5, new List<int> { 12, 13 } },
            { 6, new List<int> { 13, 14 } },
            { 7, new List<int> { 15, 16 } },
            { 8, new List<int> { 16, 17 } },
            { 9, new List<int> { 18, 19 } },
            { 10, new List<int> { 19, 20 } },
            { 11, new List<int> { 20, 21 } },
            { 12, new List<int> { 21, 22 } },
            { 13, new List<int> { 22, 23 } },
            { 14, new List<int> { 23, 24 } },
            { 15, new List<int> { 24, 25 } },
            { 16, new List<int> { 25, 26 } },
            { 17, new List<int> { 26, 27 } }
        };


        public void CheckForFaceUpCards(List<Card> removedCardFromTableau)
        {
            for (var i = 0; i < 18; i++)
            {
                var card = tableauCards[i];

                if (!card.IsFaceUp)
                {
                    var coveringIndices = GetCoveringIndices(i);
                    var faceUpCards = coveringIndices.Where(index => tableauCards[index].IsFaceUp).ToList();
                    var allCoveringFaceUp = faceUpCards.Count > 0 && coveringIndices.Count == faceUpCards.Count &&
                                            faceUpCards.All(faceCardIndex =>
                                                removedCardFromTableau.Contains(tableauCards[faceCardIndex]));
                    if (allCoveringFaceUp)
                    {
                        card.IsFaceUp = true;
                        card.UpdateSprite();
                    }
                }
            }
        }

        private List<int> GetCoveringIndices(int cardIndex)
        {
            return coveringMap.TryGetValue(cardIndex, out var indices) ? indices : new List<int>();
        }
        
    }
}