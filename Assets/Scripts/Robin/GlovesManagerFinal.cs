using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovesManagerFinal : MonoBehaviour
{
  [SerializeField] private GameObject _BagFront;
  [SerializeField] private GameObject _BagLeft;
  [SerializeField] private GameObject _BagRight;
  [SerializeField] private GameObject _BagDown;
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
      Destroy(collision.transform.parent.gameObject);

      if(collision.gameObject.name == "FrontSide" && collision.gameObject.CompareTag("Front"))
      {
        Debug.Log("Multiplicateur Augmente");
      }

      
      if(collision.gameObject.name == "LeftSide" && collision.gameObject.CompareTag("Left"))
      {
        Debug.Log("Multiplicateur Augmente");
      }

      if(collision.gameObject.name == "RightSide" && collision.gameObject.CompareTag("Right"))
      {
        Debug.Log("Multiplicateur Augmente");

      }

      if(collision.gameObject.name == "DownSide" && collision.gameObject.CompareTag("Down"))
      {
        Debug.Log("Multiplicateur Augmente");
      }


    }
}
