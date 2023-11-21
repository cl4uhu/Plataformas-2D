using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int _health;
    public int _numOfHearts;

    public Image [] _hearts;

    MenuManager _menuManager; 

    void Update()
    {
        for (int i = 0; i < _hearts.Lenght; i++) 
        {
            if(_health > _numOfHearts)
            {
                _health = _numOfHearts;
            }
            if(_health < _numOfHearts)
            {
                _numOfHearts = _health;
            }
        
            if(i < _numOfHearts) 
            {
                _hearts[i].enabled = true;
            }
            else 
            {
                _hearts[i].enabled = false;
            }
    }

    if(_health == 0)
    {
            _menuManager.Lose();
    }
    }
}
