using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseStats : MonoBehaviour 
{
    private PlantationHandler plantationHandler;
    private StorageHandler storageHandler;

    [SerializeField] private int buyingCostAmount;
    [SerializeField] private bool isOwned;

    [SerializeField] private float rentAmount;
    private float rentAmountRemaining;
    private float totalRentAmount;

    


    private void Start()
    {
        if (gameObject.GetComponent<StorageHandler>() != null)
        {
            storageHandler = gameObject.GetComponent<StorageHandler>();
        }
        if (gameObject.GetComponent<PlantationHandler>() != null)
        {
            plantationHandler = gameObject.GetComponent<PlantationHandler>();
        }
    }

    public int GetBuyingCostAmount()
    {
        return buyingCostAmount;
    }
    public bool GetIsOwned()
    {
        return isOwned;
    }
    public void SetIsOwned(bool value)
    {
        isOwned = value;    
    }
    public PlantationHandler GetPlantationHandler()
    {
        return plantationHandler;
    }
    public StorageHandler GetStorageHandler()
    {
        return storageHandler;
    }


}
