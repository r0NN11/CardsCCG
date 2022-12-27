using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Core.Scripts.UI.Card
{
    public class CardSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _playerHand;
        private List<CardInject.CardInject> _cardInjects;
        private GameSettings _gameSettings;
        private CardDefaultSettings _cardDefaultSettings;
        [Inject] private CardInject.CardInject.FactoryCardInject _factoryCardInject;

        [Inject]
        public void Constructor(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public CardSpawner()
        {
            _cardInjects = new List<CardInject.CardInject>();
        }

        private void Awake()
        {
            _cardDefaultSettings = Resources.Load<CardDefaultSettings>("CardDefaultSettings");
            CreateCards();
        }

        private void CreateCards()
        {
            if (_cardDefaultSettings.GetCards().Count < _gameSettings.GetSpawnCount())
            {
                Debug.Log("Add cards to card settings");
                return;
            }

            for (var i = 0; i < _gameSettings.GetSpawnCount(); i++)
            {
                _cardInjects.Add(_factoryCardInject.Create());
                _cardInjects[i].transform.SetParent(_playerHand);
                _cardInjects[i].SetUpCard(_cardDefaultSettings.GetCards()[i]);
            }
        }
    }
}