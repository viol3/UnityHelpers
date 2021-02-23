using Ali.Helper.Idle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleIdleButton : MonoBehaviour
{
    [SerializeField] private Text _valueText;
    [SerializeField] private Text _upgradeText;
    [SerializeField] private Text _incomeText;
    private GrowingCurrencyData _gcd;
    public GrowingCurrencyData GCD { set => _gcd = value; }

    void Update()
    {
        UpdateView();
    }

    void UpdateView()
    {
        if (_gcd != null)
        {
            _valueText.text = _gcd.GetAmount().ToSimplifiedString();
            _upgradeText.text = _gcd.productionIncome.GetUpgradeCost().ToSimplifiedString();
            _incomeText.text = _gcd.productionIncome.GetValue().ToSimplifiedString() + "/sec";
        }
    }

    public void OnClick()
    {
        if(_gcd.CanBeUpgrade())
        {
            _gcd.Spend(_gcd.productionIncome.GetUpgradeCost());
            _gcd.Upgrade();
        }
    }
}
