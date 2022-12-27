using System;
using _Core.Scripts.UI.CardBattle;
using DG.Tweening;
using UnityEngine;

namespace _Core.Scripts.UI.Card
{
    public class CardMoving : MonoBehaviour
    {
        [SerializeField] private float _timeScale = 0.25f;
        [SerializeField] private float _scaleValue = 1.5f;
        private CardBattleController _cardBattleController;
        private Card _currentCard;
        private Vector3 _defaultCardPlace;
        private Quaternion _defaultCardRotation;


        private void Start()
        {
            _cardBattleController = FindObjectOfType<CardBattleController>();
            Card.OnBeginDrag += delegate(Card card)
            {
                _defaultCardPlace = card.transform.position;
                _defaultCardRotation = card.transform.rotation;
                _currentCard = card;
                _currentCard.transform.DOScale(_scaleValue, _timeScale);
                _currentCard.transform.rotation = Quaternion.identity;
            };
        }

        private void Update()
        {
            if (_currentCard == null)
                return;
            if (Input.GetMouseButton(0)) return;
            if (!_cardBattleController.CheckPlaceCard(_currentCard))
                ReturnCard();
            _currentCard = null;
        }

        private void ReturnCard()
        {
            _currentCard.transform.DOMove(_defaultCardPlace, _timeScale);
            _currentCard.transform.DOLocalRotateQuaternion(_defaultCardRotation, _timeScale);
            _currentCard.transform.DOScale(0.75f, _timeScale);
            _currentCard.ActivateCard();
        }
    }
}