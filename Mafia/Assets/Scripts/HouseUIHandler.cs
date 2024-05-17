using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class HouseUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI productionAmountText;
    [SerializeField] TextMeshProUGUI productionMultiplyerText;

    private HouseStats currentHouse;


    public void SetCurrentHouse(HouseStats _currentHouse)
    {
        currentHouse = _currentHouse;
        UpdateHouseUIText();
    }
    public void UpdateHouseUIText()
    {
        productionAmountText.text = ((int)currentHouse.GetPlantationHandler().GetProductionAmount()).ToString();
        productionMultiplyerText.text = currentHouse.GetPlantationHandler().GetProductionWorth().ToString() + "$";
    }

    public void CloseHouseUI()
    {
        ObjectUIHandlerScript.objectUIHandlerScript.SetUIOpen(false);
        gameObject.SetActive(false);
    }

    public void IncreaseProductionAmount()
    {
        currentHouse.GetPlantationHandler().IncreaseProductionAmount();
        UpdateHouseUIText();
    }
    public void IncreaseProductionWorth()
    {
        currentHouse.GetPlantationHandler().IncreaseProductionWorth();
        UpdateHouseUIText();
    }
    public void IncreaseLocalStorageMax()
    {
        currentHouse.GetStorageHandler().IncreaseLocalStorageMax(1f);
    }
    public void UnlockPlantation()
    {
        currentHouse.GetPlantationHandler().UnlockPlantation();
    }
    public void SetLocalStorageMaxVisual()
    {

    }
}
