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

    private void OnCollisionEnter(Collision collision)
    {
      Debug.Log(gameObject.name + " a touché le " + collision.gameObject.name);

      if(collision.gameObject.name == "CenterSide" && collision.gameObject.CompareTag("DestroyableObj3"))
      {
        Debug.Log("Multiplicateur Augmente");
        collision.transform.parent.gameObject.SetActive(false);
      }

      
      if(collision.gameObject.name == "LeftSide" && collision.gameObject.CompareTag("DestroyableObj1"))
      {
        Debug.Log("Multiplicateur Augmente");
        collision.transform.parent.gameObject.SetActive(false);
      }

      if(collision.gameObject.name == "RightSide" && collision.gameObject.CompareTag("DestroyableObj2"))
      {
        Debug.Log("Multiplicateur Augmente");
        collision.transform.parent.gameObject.SetActive(false);

      }

      if(collision.gameObject.name == "DownSide" && collision.gameObject.CompareTag("DestroyableObj4"))
      {
        Debug.Log("Multiplicateur Augmente");
        collision.transform.parent.gameObject.SetActive(false);
      }


    }
}
