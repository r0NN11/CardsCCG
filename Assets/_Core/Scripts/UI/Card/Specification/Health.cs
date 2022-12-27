using System;

namespace _Core.Scripts.UI.Card.Specification
{
    public class Health : Specification
    {
        public event Action OnHealthEqualsZero;

        public Health(CardSpecification cardSpecification) : base(cardSpecification)
        {
            _value = _cardSpecification.GetCardSpecificationHealth().GetManaValue();
        }

        public override void SetValue(int value)
        {
            base.SetValue(value);
            if (value == 0)
                OnHealthEqualsZero?.Invoke();
        }
    }
}