using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyingHouseUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI houseCostAmountText;
    private HouseStats currentHouse;



    public void SetCurrentHouse(HouseStats _currentHouse)
    {
        currentHouse = _currentHouse;
        houseCostAmountText.text = (currentHouse.GetBuyingCostAmount()).ToString();
    }

    public void CloseBuyingHouseUI()
    {
        ObjectUIHandlerScript.objectUIHandlerScript.SetUIOpen(false);
        gameObject.SetActive(false);
    }
    public void BuyHouse()
    {
        currentHouse.SetIsOwned(true);
        ObjectUIHandlerScript.objectUIHandlerScript.SetUIOpen(false);
        gameObject.SetActive(false);
    }
}
