using System.Collections.Generic;
using _Core.Scripts.UI.Card.Specification;
using Unity.VisualScripting;

namespace _Core.Scripts.UI.Card
{
    public class DefaultCard : Card
    {
        private Attack _attack;
        private Health _health;
        private Mana _mana;

        public override void SetUpCard(CardSpecification cardSpecification)
        {
            _title = cardSpecification.GetTitle();
            _description = cardSpecification.GetDescription();
            _attack = new Attack(cardSpecification);
            _health = new Health(cardSpecification);
            _mana = new Mana(cardSpecification);
            _specifications.Add(_attack);
            _specifications.Add(_health);
            _specifications.Add(_mana);
        }

        public override Attack GetAttack() => _attack;

        public override Health GetHealth() => _health;

        public override Mana GetMana() => _mana;
    }
}