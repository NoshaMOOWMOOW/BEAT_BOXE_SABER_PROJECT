using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesManagerFinal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
    
    }


    void OnTriggerEnter(Collider other)
    {
      Debug.Log(gameObject.name + " triggers " + other.gameObject.name);
      //other.transform.parent.gameObject.SetActive(false);
      other.gameObject.SetActive(false);

      if(other.gameObject.name == ("CenterSide") && other.gameObject.CompareTag("DestroyableObj3") ||
        other.gameObject.name == ("LeftSide") && other.gameObject.CompareTag("DestroyableObj1") ||
        other.gameObject.name == ("RightSide") && other.gameObject.CompareTag("DestroyableObj2") ||
        other.gameObject.name == ("DownSide") && other.gameObject.CompareTag("DestroyableObj4"))
      {
        Debug.Log("Multiplicateur Augmente");
      }

      if(other.gameObject.name == ("Front") && other.gameObject.CompareTag("OpposableObj"))
      {
        Debug.Log("the player hit opposable");
      }
    }
}
