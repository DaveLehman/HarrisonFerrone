using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
        if (gameManager == null)
        {
            Debug.Log("PickupItem script failed to find a game manager!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("A collision occurred");
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");
            gameManager.Items += 1;
        }
    }
}
