using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    bool end;
    // Start is called before the first frame update
    void Start()
    {
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !end) {
            end = true;
            Invoke("Fin", 3f);
                }
        
    }

    void Fin() {
        SceneManager.LoadScene("End");

    }
}
