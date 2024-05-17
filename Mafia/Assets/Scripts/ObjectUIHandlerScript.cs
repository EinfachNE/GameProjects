using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System;

public class ObjectUIHandlerScript : MonoBehaviour
{
    public static ObjectUIHandlerScript objectUIHandlerScript;
    [SerializeField] GameObject HouseUI;
    [SerializeField] GameObject BuyingHouseUI;
    private bool UIOpen = false;

    // Start is called before the first frame update
    void Awake()
    {
        objectUIHandlerScript = this;
    }

    // Update is called once per frame
    void Update()
    {

     if (Input.GetMouseButtonDown(0)) {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (!UIOpen && hit.collider.gameObject.GetComponent<HouseStats>() != null) {
                OpenHouseUI(hit.collider.gameObject.GetComponent<HouseStats>());
            }
        }
    }

    public void SetUIOpen(bool value)
    {
        UIOpen = value;
    }

    public void OpenHouseUI(HouseStats houseStats)
    {
        if (houseStats.GetIsOwned())
        {
            UIOpen = true;
            HouseUI.SetActive(true);
            HouseUI.GetComponent<HouseUIHandler>().SetCurrentHouse(houseStats);
        }
        else
        {
            UIOpen = true;
            BuyingHouseUI.SetActive(true);
            BuyingHouseUI.GetComponent<BuyingHouseUIHandler>().SetCurrentHouse(houseStats);
        }
           
    }
}
