using Ali.Helper.Idle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleExample : MonoBehaviour
{
    [SerializeField] private GrowingCurrencyData _gold;
    [SerializeField] private SimpleIdleButton _idleButton;

    float _timer = 0f;
    void Start()
    {
        _gold.Init();
        _idleButton.GCD = _gold;
    }

    private void Update()
    {
        ProductForSeconds();
    }

    void ProductForSeconds()
    {
        _timer += Time.deltaTime;
        if (_timer >= 1f)
        {
            _gold.Product(1f);
            _timer = 0f;
        }
    }

}
