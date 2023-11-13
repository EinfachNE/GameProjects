using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private PlayerScript player;
    [SerializeField] private SweetsScript sweets;
    private void Start()
    {
        player = References.player.GetComponent<PlayerScript>();
    }
    
    


}
