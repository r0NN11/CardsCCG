using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Core.Scripts.UI.CardBattle
{
    public class BaseZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool isAboveZone { get; private set; }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isAboveZone = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isAboveZone = false;
        }
    }
}