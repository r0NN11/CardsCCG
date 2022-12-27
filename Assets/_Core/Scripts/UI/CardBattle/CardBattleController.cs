using System;
using DG.Tweening;
using UnityEngine;

namespace _Core.Scripts.UI.CardBattle
{
    public class CardBattleController : MonoBehaviour
    {
        [SerializeField] private Hand.Hand _hand;
        [SerializeField] private BaseZone _zone;
        [SerializeField] private float _timeScale = 0.25f;
        [SerializeField] private float _scaleValue = 0.3f;
        public bool CheckPlaceCard(Card.Card currentCard)
        {
            if (!_zone.isAboveZone) return false;
            currentCard.transform.SetParent(_zone.transform);
            currentCard.transform.DOMove(_zone.transform.position, _timeScale);
            currentCard.transform.DOScale(_scaleValue, _timeScale);
            _hand.Remove(currentCard);
            return true;
        }
    }
}