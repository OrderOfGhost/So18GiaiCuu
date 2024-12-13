using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
   public AudioClip Attack, Shot, Dash,Powwer, Bidanh;
 
    public AudioSource adisrc;
    // Use this for initialization
    void Start () {
        Attack = Resources.Load<AudioClip>("sound 141");
        Shot = Resources.Load<AudioClip>("sound 2 (beng_s)");
        Dash = Resources.Load<AudioClip>("sound 591");
        Bidanh = Resources.Load<AudioClip>("sound 5 (qd_s)");
        Powwer = Resources.Load<AudioClip>("sound 255");
        adisrc = GetComponent<AudioSource>();
 
    }
 
    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "Attack":
                adisrc.clip = Attack;
                adisrc.PlayOneShot(Attack, 0.6f);
                break;
 
            case "Shot":
                adisrc.clip = Shot;
                adisrc.PlayOneShot(Shot, 0.8f);
                break;
 
            case "Dash":
                adisrc.clip = Dash;
                adisrc.PlayOneShot(Dash, 0.8f);
                break;

            case "Bidanh":
                adisrc.clip = Bidanh;
                adisrc.PlayOneShot(Bidanh, 0.8f);
                break;
            
            case "Powwer":
                adisrc.clip = Powwer;
                adisrc.PlayOneShot(Powwer, 1.2f);
                break;
 
        }
    }
}
