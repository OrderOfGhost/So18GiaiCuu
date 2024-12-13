using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScene2 : MonoBehaviour
{
    public AudioClip NhacNen;
 
    public AudioSource adisrc;
    // Start is called before the first frame update
    void Start()
    {
        NhacNen = Resources.Load<AudioClip>("scavengers_music");
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
