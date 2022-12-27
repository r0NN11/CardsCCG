using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Core.Scripts.UI.Card
{
    [CreateAssetMenu(fileName = "CardDefaultSettings")]
    public class CardDefaultSettings : ScriptableObject
    {
        [SerializeField] private List<CardSpecification> _cards;
        public List<CardSpecification> GetCards() => _cards;
    }

    [Serializable]
    public struct CardSpecification
    {
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private CardSpecificationMana _cardSpecificationMana;
        [SerializeField] private CardSpecificationAttack _cardSpecificationAttack;
        [SerializeField] private CardSpecificationHealth _cardSpecificationHealth;
        public CardSpecificationMana GetCardSpecificationMana() => _cardSpecificationMana;
        public CardSpecificationAttack GetCardSpecificationAttack() => _cardSpecificationAttack;
        public CardSpecificationHealth GetCardSpecificationHealth() => _cardSpecificationHealth;
        public string GetTitle() => _title;
        public string GetDescription() => _description;
    }

    [Serializable]
    public class CardSpecificationMana
    {
        [SerializeField] private int _manaValue;
        public int GetManaValue() => _manaValue;
    }

    [Serializable]
    public class CardSpecificationAttack
    {
        [SerializeField] private int _attackValue;
        public int GetManaValue() => _attackValue;
    }

    [Serializable]
    public class CardSpecificationHealth
    {
        [SerializeField] private int _healthValue;
        public int GetManaValue() => _healthValue;
    }
}