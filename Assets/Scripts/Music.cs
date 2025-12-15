using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource musicInit;
    [SerializeField] AudioSource secondMusic;
    [SerializeField] AudioSource thirdMusic;
    // Start is called before the first frame update
    void Start()
    {
        musicInit.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMusic(int n) {
        if (n == 3) {
            musicInit.Stop();
            secondMusic.Play();
           
        }
        if (n == 1)
        {
            secondMusic.Stop();
            thirdMusic.Play();

        }



    }
}
