using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] int zone;
    [SerializeField] LightEffects luces;
    [SerializeField] Music music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            luces.ChangeColor(zone);
            music.ChangeMusic(zone);
        }
    }
}
