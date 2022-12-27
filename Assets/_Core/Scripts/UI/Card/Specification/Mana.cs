namespace _Core.Scripts.UI.Card.Specification
{
    public class Mana : Specification
    {
        public Mana(CardSpecification cardSpecification) : base(cardSpecification)
        {
            _value = _cardSpecification.GetCardSpecificationMana().GetManaValue();
        }
    }
}