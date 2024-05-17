using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public event EventHandler<OnMoneyAmountChangedEventArgs> onMoneyAmountChanged;
    public class OnMoneyAmountChangedEventArgs : EventArgs
    {
        public float amount;
    }
    public void MoneyAmountChanged(float changeAmount)
    {
        onMoneyAmountChanged?.Invoke(this, new GameEvents.OnMoneyAmountChangedEventArgs { amount = changeAmount });
    }
}
