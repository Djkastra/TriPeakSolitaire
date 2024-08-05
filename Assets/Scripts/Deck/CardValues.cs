/*
 * Holds the values for the cards in the deck.
 */
namespace TriPeakSolitaire
{
    public enum CardSuit
    {
        Hearts   = 0,
        Clubs    = 1,
        Spades   = 2,
        Diamonds = 3
    }
    
    public enum CardValue
    {
        Ace   = 1,
        Two   = 2,
        Three = 3,
        Four  = 4,
        Five  = 5,
        Six   = 6,
        Seven = 7,
        Eight = 8,
        Nine  = 9,
        Ten   = 10,
        Jack  = 11,
        Queen = 12,
        King  = 13
    }
    
    public class CardValues
    {
        public int Value { get { return value; } }
        public int Suit { get { return suit; } }

        readonly int value;
        readonly int suit;
        
        public CardValues(int suit, int value)
        {
            this.value = value;
            this.suit = suit;
        }
    }
}