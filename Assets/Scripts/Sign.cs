using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Sign : MonoBehaviour
{
    
    [SerializeField]TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
       
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) {
            text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            text.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            
            text.transform.LookAt(new Vector3(other.transform.position.x, text.transform.position.y, other.transform.position.z));
           
        }
    }
}
