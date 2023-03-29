using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAndTriggerScript : MonoBehaviour
{


    // NE FONCTIONNE PAS, peut etre à cause de l'animation?
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="DBS")
        {

            Debug.Log(other.name + " Est rentrée dans le trigger");



        }


    }









    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
