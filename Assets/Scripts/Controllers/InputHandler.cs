/*
 * Resposible to handle the input from the player
 * Detects the tap on the card and deck
 */
namespace TriPeakSolitaire
{
    using UnityEngine;

    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private GamePlayController gamePlayController;
        private Camera mainCamera;

        void Start()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            DetectTap();
        }

        void DetectTap()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 rayPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);

                if (hit)
                {
                    if (hit.transform.CompareTag(GameConstant.CARD_TAG))
                    {
                        Card card = hit.transform.GetComponent<Card>();
                        HandleCardTap(card);
                    }
                    else if (hit.transform.CompareTag(GameConstant.DECK_TAG))
                    {
                        gamePlayController.DrawCardFromDeck();
                    }
                }
            }
        }

        void HandleCardTap(Card card)
        {
            if (card.IsFaceUp && gamePlayController.CanRemoveCard(card))
            {
                gamePlayController.RemoveCard(card);
            }
        }
    }

}