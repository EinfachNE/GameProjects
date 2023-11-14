using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public static GameObject player;

    private void Awake()
    {
        player = gameObject;
    }
}
