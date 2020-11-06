using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ali.Helper.UI.Dialogue
{
    public class DialogueChoice : MonoBehaviour
    {
        [SerializeField] private RectTransform _choicePanel;
        [SerializeField] private Text _choiceText;
        [SerializeField] private int _choiceIndex = 0;

        public event System.Action<int> OnClick;

        private bool _alreadyChoiced = false;

        public void OnChoiceClick()
        {
            if (_alreadyChoiced)
            {
                return;
            }
            _alreadyChoiced = true;
            Bounce();
            OnClick?.Invoke(_choiceIndex);
        }

        public void SetText(string text)
        {
            _choiceText.text = text;
        }

        public void Show(float duration)
        {
            _choicePanel.gameObject.SetActive(true);
            _choicePanel.localScale *= 0.5f;
            _choicePanel.DOScale(transform.localScale * 2f, duration);
        }

        public void Hide()
        {
            _choicePanel.gameObject.SetActive(false);
        }

        public void Reset()
        {
            _alreadyChoiced = false;
        }

        void Bounce()
        {
            _choicePanel.DOPunchScale(Vector3.one * 0.1f, 0.3f, 6);
        }

    }
}