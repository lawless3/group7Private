using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public int checkPointNum; //used to determine if the player is at this particular checkpoint
    public List<GameObject> destroyables;//used to store destroyable gameobject for reinstantiation
    [SerializeField] private Sprite completeSprite;
	// Use this for initialization
	void Start () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = completeSprite;
        }
    }

    // Update is called once per frame



}
