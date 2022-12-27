using System.Collections.Generic;
using System.Linq;
using _Core.Scripts.UI.CardBattle;
using UnityEngine;


namespace _Core.Scripts.UI.Hand
{
    public class Hand : MonoBehaviour
    {
        [SerializeField] private HandLayoutController handLayoutController;
        private List<Card.Card> _cards;

        protected Hand()
        {
            _cards = new List<Card.Card>();
        }

        public List<Card.Card> GetCards() => _cards;

        public void Remove(Card.Card card)
        {
            _cards.Remove(card);
            handLayoutController.Align();
        }

        private void OnEnable()
        {
            GetAllCardsInHand();
            foreach (var card in _cards)
            {
                card.GetHealth().OnHealthEqualsZero += DeactivateCard;
            }
        }

        private void DeactivateCard()
        {
            var card = _cards.Find(card => card.GetHealth().GetValue() == 0);
            if (card == null)
                return;
            card.gameObject.SetActive(false);
            Remove(card);
        }

        private void GetAllCardsInHand()
        {
            _cards = GetComponentsInChildren<Card.Card>().ToList();
        }
    }
}