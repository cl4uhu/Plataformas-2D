using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Health _health; 

    AudioSource _audiosource;
    public Sprite[] _bomb;
    [SerializeField] private AudioClip _explosion; 
    public float _bombduration = 0.2f; 

    private SpriteRenderer _spriteRenderer;
    private bool _bombdamage = false; 

    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        _health = GameObject.Find("Personaje").GetComponent<Health>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && _bombdamage == false)
        {
            _audiosource.PlayOneShot(_explosion);
            _health._health -= 1;
            StartCoroutine(PlayBombAnimation());
            _bombdamage = true; 
        }
    }

    IEnumerator PlayBombAnimation()
    {
        foreach (Sprite sprite in _bomb)
        {
            _spriteRenderer.sprite = sprite; 
            yield return new WaitForSeconds(_bombduration / _bomb.Length);
        }
        Destroy(gameObject, _bombduration);
    }
}
