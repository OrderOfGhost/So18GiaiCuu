using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip NhacNen;
 
    public AudioSource adisrc;
    // Start is called before the first frame update
    void Start()
    {
        NhacNen = Resources.Load<AudioClip>("CURIOUS- Funny Comedy Music - The Crazy Venezolano Soundtrack");
        adisrc = GetComponent<AudioSource>();
        adisrc.PlayOneShot(NhacNen, 90f);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(loadnhacnen());
    }

    IEnumerator loadnhacnen()
    {
        yield return new WaitForSeconds(90f);
        adisrc.PlayOneShot(NhacNen, 90f);
    }
}
