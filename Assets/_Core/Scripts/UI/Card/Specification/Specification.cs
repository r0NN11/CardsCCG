using System;
using UnityEngine;

namespace _Core.Scripts.UI.Card.Specification
{
    [Serializable]
    public abstract class Specification
    {
        public event Action <Specification> OnValueChange;
        protected int _value;
        protected readonly CardSpecification _cardSpecification;
        public int GetValue() => _value;

        public virtual void SetValue(int value)
        {
            _value = value;
            OnValueChange?.Invoke(this);
        }

        protected Specification(CardSpecification cardSpecification)
        {
            _cardSpecification = cardSpecification;
        }
    }
}