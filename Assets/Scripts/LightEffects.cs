using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffects : MonoBehaviour
{
    [SerializeField]Color color1;
    [SerializeField] Color color2;
    [SerializeField] Color color3;
    Light luz;
    [SerializeField] PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        luz = GetComponent<Light>();
        luz.color = color2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeColor(int n) {
        if (n == 1)
        {
            luz.color = color1;
        }
        else if (n == 2)
        {
            luz.color = color1;
        }
        else if (n == 3) {
            luz.color = color3;
        }
    
    }
}
