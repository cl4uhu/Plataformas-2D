using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int _stars = 0;
    [SerializeField] private Text _starstext;
    [SerializeField] private AudioClip _starsound;
    AudioSource _audiosource;

    VictoryMenu _victorymenu;

    void Start()
    {
      _audiosource = GetComponent<AudioSource>();
      _victorymenu = GameObject.Find("VictoryMenu").GetComponent<VictoryMenu>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            _stars++;
            _starstext.text = "Collected Stars: " + _stars + "/6";
            _audiosource.PlayOneShot(_starsound);
        }
    }

    void Update()
    {
        if(_stars == 6)
        {
          _victorymenu.Victory();
        }
    }
}
