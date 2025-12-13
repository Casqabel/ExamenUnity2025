using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collect : MonoBehaviour
{
    [SerializeField] AudioSource source;
    public bool open;
    [SerializeField] TextMeshProUGUI text;

    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        open = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin")) {
            coins++;
            text.text = "Coins: " + coins;
            Destroy(other.gameObject);
            source.Play();
        }
    }
}
