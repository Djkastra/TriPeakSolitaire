/*
 * Handles the card object and its properties
 */
using UnityEngine;

namespace TriPeakSolitaire
{
    public class Card : MonoBehaviour
    {
        public CardValues CardValueFace;
        public bool IsFaceUp;
        
        private Sprite faceUpSprite;
        private Sprite faceDownSprite;

        private SpriteRenderer spriteRenderer;
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public static Card CreateNewCard(GameObject cardPrefab)
        {
            var cardObj = Instantiate(cardPrefab);
            cardObj.tag = GameConstant.CARD_TAG;
            return cardObj.GetComponent<Card>();
        }

        public void UpdateCardUi(Sprite cardFaceUp, CardValues cardValues, Sprite cardFaceDown)
        {
            faceUpSprite = cardFaceUp;
            faceDownSprite = cardFaceDown;
            CardValueFace = cardValues;
            UpdateSprite();
        }

        public void UpdateSprite()
        {
            if(spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = IsFaceUp ? faceUpSprite : faceDownSprite;
        }
    }
}