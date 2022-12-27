namespace _Core.Scripts.UI.Card.Specification
{
    public class Attack : Specification
    {
        public Attack(CardSpecification cardSpecification) : base(cardSpecification)
        {
            _value = _cardSpecification.GetCardSpecificationAttack().GetManaValue();
        }
    }
}