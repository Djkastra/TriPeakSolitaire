using System.Collections.Generic;
using UnityEngine;

namespace TriPeakSolitaire
{
    public interface ICardDeckFactory
    {
        Dictionary<CardValues, Card> CreateCards(Sprite[] cardFaces);
    }
}