using System;
using System.Collections.Generic;
using _Core.Scripts.UI.Card.Specification;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Core.Scripts.UI.Card
{
    public abstract class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Image _image;
        public static event Action<Card> OnBeginDrag;
        public event Action  OnEndDrag;
        public event Action OnDragging;
        protected readonly List<Specification.Specification> _specifications;

        protected Card()
        {
            _specifications = new List<Specification.Specification>();
        }

        protected string _title;
        protected string _description;

        public abstract void SetUpCard(CardSpecification cardSpecification);

        public List<Specification.Specification> GetSpecifications() => _specifications;
        public string GetTitle() => _title;
        public string GetDescription() => _description;
        public abstract Attack GetAttack();
        public abstract Health GetHealth();
        public abstract Mana GetMana();
        public void ActivateCard() => _image.raycastTarget = true;

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
        {
            OnBeginDrag?.Invoke(this);
            _image.raycastTarget = false;
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData)
        {
            OnEndDrag?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnDragging?.Invoke();
            transform.position = Input.mousePosition;
        }
    }
}