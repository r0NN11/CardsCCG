using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Core.Scripts.UI
{
    public class CanvasScaleUpdater : MonoBehaviour
    {
        [SerializeField] private CanvasScaler _canvasScaler;
        private Camera _mainCamera;

        private void UpdateScale()
        {
            var canvasAspect = _canvasScaler.referenceResolution.x / _canvasScaler.referenceResolution.y;

            var screenAspect = _mainCamera.aspect;
            _canvasScaler.matchWidthOrHeight = canvasAspect < screenAspect ? 1 : 0;
        }

        private void Awake()
        {
            _mainCamera = Camera.main;
            UpdateScale();
        }

        private void Update()
        {
            UpdateScale();
        }
    }
}