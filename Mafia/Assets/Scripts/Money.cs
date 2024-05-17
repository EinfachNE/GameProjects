using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private float currentMoneyAmount = 0;

    private void Start()
    {
        GameEvents.instance.onMoneyAmountChanged += MoneyAmountChanged;
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = ((int)currentMoneyAmount).ToString() + "$";


    }
    public void MoneyAmountChanged(object sender, GameEvents.OnMoneyAmountChangedEventArgs e)
    {
        currentMoneyAmount += e.amount;
        e.amount = 0;
    }
}
