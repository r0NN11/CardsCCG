using _Core.Scripts.UI.Card.Specification;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace _Core.Scripts.UI.Card
{
    [RequireComponent(typeof(DefaultCard))]
    public class CardDisplay : MonoBehaviour

    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TextMeshProUGUI _attack;
        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private TextMeshProUGUI _mana;
        [SerializeField] private Outline _outline;
        private Card _card;
        private int _currentDisplayValue;

        private void Start()
        {
            _card = GetComponent<Card>();
            _card.OnDragging += ActivateOutline;
            _card.OnEndDrag += DeactivateOutline;
            foreach (var specification in _card.GetSpecifications())
            {
                specification.OnValueChange += UpdateCardDisplay;
            }

            _attack.text = _card.GetAttack().GetValue().ToString();
            _health.text = _card.GetHealth().GetValue().ToString();
            _mana.text = _card.GetMana().GetValue().ToString();
            _title.text = _card.GetTitle();
            _description.text = _card.GetDescription();
        }

        private void UpdateCardDisplay(Specification.Specification specification)
        {
            switch (specification)
            {
                case Attack:
                    _attack.text = _card.GetAttack().GetValue().ToString();
                    break;
                case Health:
                    _health.text = _card.GetHealth().GetValue().ToString();
                    break;
                case Mana:
                    _mana.text = _card.GetMana().GetValue().ToString();
                    break;
            }
        }

        private void ActivateOutline() => _outline.enabled = true;
        private void DeactivateOutline() => _outline.enabled = false;
    }
}