using System;
using System.Collections;
using System.Collections.Generic;
using _Core.Scripts.UI.Card.Specification;
using _Core.Scripts.UI.Hand;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Core.Scripts.UI
{
    public class CardValueChanger : MonoBehaviour
    {
        private GameSettings _gameSettings;
        private PlayerHand _playerHand;
        private List<Card.Card> _cards;

        [Inject]
        public void Constructor(GameSettings gameSettings, PlayerHand playerHand)
        {
            _gameSettings = gameSettings;
            _playerHand = playerHand;
        }

        private void Start()
        {
            _cards = _playerHand.GetCards();
        }

        public void ChangeCardsValue()
        {
            StartCoroutine(UpdateValueCards(_cards));
        }

        private Specification GetRandomSpecification(Card.Card card)
        {
            var specifications = card.GetSpecifications();
            var specification = specifications[Random.Range(0, specifications.Count)];
            return specification;
        }

        IEnumerator UpdateValueCards(List<Card.Card> cards)
        {
            List<Card.Card> tempCards = new List<Card.Card>(cards);
            if (tempCards.Count == 0)
                yield break;
            var tempCard = tempCards[0];
            tempCards.Remove(tempCard);
            Specification tempSpecification = GetRandomSpecification(tempCard);
            float timer = 0;
            var time = 0.5f;
            var currentSpecificationCard = tempSpecification.GetValue();
            var nextCurrentSpecificationCard = _gameSettings.GetNewValue();
            while (timer < time)
            {
                timer += Time.deltaTime;
                var f = timer / time;
                tempSpecification.SetValue((int) Mathf.Lerp(currentSpecificationCard, nextCurrentSpecificationCard, f));
                yield return null;
            }

            StartCoroutine(UpdateValueCards(tempCards));
        }
    }
}