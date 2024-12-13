using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound2: MonoBehaviour
{
     public AudioClip food,soda,destroy;
 
    public AudioSource adisrc;
    // Use this for initialization
    void Start () {
        food = Resources.Load<AudioClip>("scavengers_fruit2");
        soda = Resources.Load<AudioClip>("scavengers_soda2");
        destroy = Resources.Load<AudioClip>("Boom");
        adisrc = GetComponent<AudioSource>();
 
    }
 
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "food":
                adisrc.clip = food;
                adisrc.PlayOneShot(food, 1f);
                break;
 
            case "destroy":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 1f);
                break;
 
            case "soda":
                adisrc.clip = soda;
                adisrc.PlayOneShot(soda, 1f);
                break;
 
        }
    }
}
