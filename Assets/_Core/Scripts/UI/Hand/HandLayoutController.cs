using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Core.Scripts.UI.Hand
{
    public class HandLayoutController : MonoBehaviour
    {
        [SerializeField] private float _offset = 8;
        [SerializeField] private Hand _hand;
        [SerializeField] private float _timeMove = 0.5f;
        [SerializeField] private float _angle = 10f;
        private List<Card.Card> _cards;


        public void Align()
        {
            var count = _cards.Count;
            if (count == 0)
                return;
            if (count == 1)
            {
                _cards[0].transform.DOMoveX(transform.position.x, _timeMove);
                _cards[0].transform.DORotateQuaternion(transform.rotation, _timeMove);
                return;
            }

            var offsetStart = count * _angle / 2f;
            for (var i = 0; i < _cards.Count; i++)
            {
                if (_cards[i] == null)
                    continue;
                GetPositionAtIndex(i, offsetStart, out var position, out var rotation);
                _cards[i].transform.DOMove(position, _timeMove);
                _cards[i].transform.DORotateQuaternion(rotation, _timeMove);
            }
        }

        private void Start()
        {
            _cards = _hand.GetCards();
            Align();
        }

        private void GetPositionAtIndex(int index, float offsetStart, out Vector3 position, out Quaternion rotation)
        {
            var val = _angle * index - offsetStart;
            rotation = transform.rotation * Quaternion.Euler(0, 0, -val);
            position = transform.position + rotation * transform.right * _offset * val;
        }
    }
}