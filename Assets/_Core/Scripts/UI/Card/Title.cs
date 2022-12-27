using DG.Tweening;
using TMPro;
using TMPro.Examples;
using UnityEngine;

namespace _Core.Scripts.UI.Card
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Title : MonoBehaviour
    {
        private TextMeshProUGUI _title;

        private void Start()
        {
            _title = GetComponent<TextMeshProUGUI>();
            if (_title.text.Length <= 12) return;
            var warpText = _title.GetComponent<WarpTextExample>().enabled = true;
            _title.rectTransform.DOLocalMoveY(1, 0);
        }
    }
}