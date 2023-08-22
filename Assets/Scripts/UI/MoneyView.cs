using AFSInterview.Items;
using System;
using TMPro;
using UnityEngine;

namespace AFSInterview
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI moneyView;

        private void OnEnable()
        {
            InventoryController.OnMoneyChanged += HandleItemsSold;
        }

        private void OnDisable()
        {
            InventoryController.OnMoneyChanged -= HandleItemsSold;
        }

        private void HandleItemsSold(int money)
        {
            moneyView.text = "Money: " + money;
        }
    }
}
