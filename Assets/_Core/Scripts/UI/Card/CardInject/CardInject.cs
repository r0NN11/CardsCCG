using UnityEngine;
using Zenject;

namespace _Core.Scripts.UI.Card.CardInject
{
    public class CardInject : DefaultCard
    {
        public class FactoryCardInject : PlaceholderFactory<CardInject>
        {
        }
    }
}