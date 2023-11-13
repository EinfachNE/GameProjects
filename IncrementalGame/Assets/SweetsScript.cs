using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class SweetsScript : MonoBehaviour
{

    [SerializeField] float sweetsPrice;
    private int ownedSweets;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI ownedSweetsText;
    [SerializeField] private TextMeshProUGUI currentProfitText;
    private PlayerScript playerScript;

    private float boughtFor;

    private void Start()
    {
        playerScript = References.player.GetComponent<PlayerScript>();
        boughtFor = 0;
    }
    void Update()
    {
        priceText.SetText(sweetsPrice.ToString());
        if (ownedSweets > 0)
        {
            currentProfitText.SetText(((int)(sweetsPrice*ownedSweets-boughtFor)*10).ToString() + "%");
        }
        else
        {
            currentProfitText.SetText(0.ToString());
        }
        PriceFluctuation();

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
               
            }
            else
            {
                sweetsPrice--;
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
            Debug.Log(trendTimer);
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
            boughtFor += sweetsPrice;
            
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
            boughtFor = 0;
        }
        

    }
}
