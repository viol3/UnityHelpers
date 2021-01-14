using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper
{
    public class MouseOnPlane : MonoBehaviour
    {
        [SerializeField] private Transform _planeTransform;
        [SerializeField] private bool _activated = true;
        [SerializeField] private bool _holdRequired = true;
        [SerializeField] private string _planeLayerName = "MousePlane";

        public event System.Action<Vector3> OnMouseUpdate;

        void Update()
        {
            UpdateMouseEvents();
        }

        void UpdateMouseEvents()
        {
            if (!_activated)
            {
                return;
            }

            if (_holdRequired && !Input.GetMouseButton(0))
            {
                return;
            }
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50f, LayerMask.GetMask(_planeLayerName)) && hit.transform == _planeTransform)
            {
                OnMouseUpdate?.Invoke(hit.point);
            }
        }

        public void SetActive(bool value)
        {
            _activated = value;
        }
    }
}