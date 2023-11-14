using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SweetsScript : MonoBehaviour
{

    [SerializeField] float sweetsPrice;
    private int ownedSweets;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI ownedSweetsText;
    [SerializeField] private TextMeshProUGUI lastChangeText;
    private PlayerScript playerScript;

    private float lastChange;
    private bool lastChangeRel;

    private void Start()
    {
        playerScript = References.player.GetComponent<PlayerScript>();
        lastChange = 0;
    }
    void Update()
    {
        priceText.SetText(sweetsPrice.ToString());
        lastChangeText.SetText(((int)lastChange).ToString() + "%");
        PriceFluctuation();
        if (lastChangeRel)
        {
            lastChangeText.color = Color.green;
        }
        else if (!lastChangeRel)
        {
            lastChangeText.color = Color.red;
        }

    }

    private bool trendactive = false;
    private float trendTimer = 0;
    bool trend = false;
    public void PriceFluctuation()
    {
        if (!trendactive)
        {
            trend = GenerateTrend();
        }
        else if(trendTimer <= 0)
        {
            if (trend)
            {
                sweetsPrice++;
                lastChange = 1/(sweetsPrice-1)*100;
                lastChangeRel = true;
            }
            else
            {
                sweetsPrice--;
                lastChange = 1 / (sweetsPrice + 1)*100;
                lastChangeRel = false;
                if (sweetsPrice <= 1)
                {
                    trendactive = false;
                }
            }
            if (Random.Range(0, 10) < 1)
            {
                trendactive = false;
            }
        trendTimer = 3f;
        }
        else
        {
            trendTimer -= Time.deltaTime;
        }
    }
    public bool GenerateTrend()
    {
        trendactive = true;
        if (sweetsPrice <= 1)
        {
            return true;
        }
        if (sweetsPrice >= 15)
        {
            return false;
        }
        else
        {
            int random = Random.Range(0, 2);
            return random == 0;
        }
        
    }

    public float GetSweetsPrice()
    {
        return sweetsPrice;
    }
    public void AddToSweetsPrice(float value)
    {
        sweetsPrice += value;
    }

    public void BuySweets()
    {
        if (playerScript.GetMoneyAmount() >= sweetsPrice)
        {
            playerScript.AddToMoneyAmount(-sweetsPrice);
            ownedSweets++;
            ownedSweetsText.SetText(ownedSweets.ToString());
            
        }
        
    }
    public void SellSweets()
    {
        
        if (sweetsPrice > 0 && ownedSweets > 0)
        {
            playerScript.AddToMoneyAmount(sweetsPrice * ownedSweets);
            sweetsPrice -= 1;
            ownedSweets = 0;
            ownedSweetsText.SetText(ownedSweets.ToString());
            lastChange = 0;
        }
        

    }
}
