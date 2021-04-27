using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    private int _items_collected = 0;
    private int _playerHP = 10;
    public int Items
    {
        get { return _items_collected; }
        set
        {
            _items_collected = value;
            Debug.LogFormat("Items: {0}", _items_collected);
        }
    }
    public int PlayerHP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
