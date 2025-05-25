using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CollectFuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colission)
    {
        if(colission.gameObject.CompareTag("Player"))
        {
            FuelController.instance.FillFuel();
            Destroy(gameObject);
        }
        
    }
}
