using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float moneyAmount;
    [SerializeField] private TextMeshProUGUI moneyText;

    void Start()
    {
        moneyAmount = 100f;
        moneyText.SetText((moneyAmount).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetMoneyAmount()
    {
        return moneyAmount;
    }
    public void AddToMoneyAmount(float value)
    {
        moneyAmount += value;
        moneyText.SetText((moneyAmount).ToString());
    }
}
