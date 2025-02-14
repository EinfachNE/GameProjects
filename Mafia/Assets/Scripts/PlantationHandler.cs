using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantationHandler : MonoBehaviour
{
    private StorageHandler localStorage;
    private HouseStats currentHouse;

    private bool plantationUnlocked = false;
    [SerializeField] private float productionAmount;
    [SerializeField] private float productionMultiplyer;
    private float productionTickMax = 5f;
    private float productionTick = 0f;
    private float totalProduction;

    private void Start()
    {
        if (gameObject.GetComponent<StorageHandler>() != null)
        {
            localStorage = gameObject.GetComponent<StorageHandler>();
        }
        if (gameObject.GetComponent<HouseStats>() != null)
        {
            currentHouse = gameObject.GetComponent<HouseStats>();
        }
    }

    private void GrowPlants()
    {
        if (localStorage.GetCurrentLocalStorageUsage() < localStorage.GetLocalStorageMax())
        {
            if (productionTick > 0)
            {
                productionTick -= Time.deltaTime;
            }
            else
            {
                HarvestPlants();
            }
        }
    }

    private void HarvestPlants()
    {
        productionTick = productionTickMax;

        totalProduction = productionAmount * productionMultiplyer;
        if (localStorage.GetCurrentLocalStorageUsage() + totalProduction < localStorage.GetLocalStorageMax())
        {
            localStorage.AddDrugAmount(totalProduction);
        }
        else
        {
            localStorage.SetCurrentLocalDrugStorage(localStorage.GetLocalStorageMax());
        }
        localStorage.SellDrugs();
    }

    private void Update()
    {
        if (currentHouse.GetIsOwned() && GetPlantationUnlocked()) {
            GrowPlants();
        }
    }


    public float GetProductionAmount()
    {
        return productionAmount;
    }
    public void IncreaseProductionAmount()
    {
        productionAmount += 1;
    }
    public float GetProductionWorth()
    {
        return productionMultiplyer;
    }
    public void IncreaseProductionWorth()
    {
        productionMultiplyer += .1f;
        productionMultiplyer = Mathf.Round(productionMultiplyer * 10f) * 0.1f;
    }
    public void UnlockPlantation()
    {
        plantationUnlocked = true;
    }
    public bool GetPlantationUnlocked()
    {
        return plantationUnlocked;
    }
    public float GetProductionTickMax()
    {
        return productionTickMax;
    }
}

