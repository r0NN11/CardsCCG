using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Core.Scripts.UI
{
    public class CanvasScaleUpdater : MonoBehaviour
    {
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private Camera _mainCamera;

        private void UpdateScale()
        {
            
            var canvasAspect = _canvasScaler.referenceResolution.x / _canvasScaler.referenceResolution.y;
            
            var screenAspect = _mainCamera.aspect;
            if (canvasAspect < screenAspect)
                _canvasScaler.matchWidthOrHeight = 1;
            else
                _canvasScaler.matchWidthOrHeight = 0;
        }

        private void Start()
        {
            _mainCamera=Camera.main;
            UpdateScale();
        }

        private void Update()
        {
            UpdateScale();
        }
    }
}