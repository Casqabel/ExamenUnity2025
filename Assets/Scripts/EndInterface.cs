using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndInterface : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI monedas;
    [SerializeField] TextMeshProUGUI muertes;
    // Start is called before the first frame update
    void Start()
    {
        monedas.text = "Monedas conseguidas: " + Stats.coins;
        muertes.text = "Veces muerto: " + Stats.deaths;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            Debug.Log("pulsado");
            Application.Quit();
        }
    }
}
