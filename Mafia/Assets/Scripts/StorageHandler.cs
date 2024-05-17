using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageHandler : MonoBehaviour
{
    private float localStorageMax = 10f;
    private float currentLocalStorageUsage = 0f;




    public float GetCurrentLocalStorageUsage()
    {
        return currentLocalStorageUsage;
    }
    public float GetLocalStorageMax()
    {
        return localStorageMax;
    }
    public void IncreaseLocalStorageMax(float value)
    {
        localStorageMax += value;
    }
    public void SetCurrentLocalDrugStorage(float value)
    {
        currentLocalStorageUsage = value;
    }
    public void AddDrugAmount(float value)
    {
        currentLocalStorageUsage += value;
    }
    public void SellDrugs()
    {
        GameEvents.instance.MoneyAmountChanged(currentLocalStorageUsage);
        SetCurrentLocalDrugStorage(0f);

    }
}
