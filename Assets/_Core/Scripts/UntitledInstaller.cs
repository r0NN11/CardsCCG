using _Core.Scripts.UI.Card;
using _Core.Scripts.UI.Card.CardInject;
using _Core.Scripts.UI.CardBattle;
using _Core.Scripts.UI.Hand;
using UnityEngine;
using Zenject;

namespace _Core.Scripts
{
    public class UntitledInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameSettings>().FromScriptableObjectResource("GameSettings").AsSingle();
            Container.Bind<PlayerHand>().FromInstance(FindObjectOfType<PlayerHand>(true)).AsSingle();
            CreateCards();
        }

        private void CreateCards()
        {
            string CARD = "Card_Variant";
            Container.BindFactory<CardInject, CardInject.FactoryCardInject>()
                .FromComponentInNewPrefabResource(CARD);
        }
    }
}