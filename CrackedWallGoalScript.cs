using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrackedWallGoalScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject effect;
    public Sprite newSprite;
    public GameObject VictoryPanel;
    public int spawneffect = 1;
    public CircleCollider2D CC2D;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        ActivateGoal();
    }
    public void ActivateGoal()
    {
        if (enemy == null)
        {
            SpawnEffect();
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().IsTouching(CC2D) && collision.gameObject.tag == "Player") 
        {
         VictoryPanel.SetActive(true);

        }
    }
   public void SpawnEffect()
    {
        if (spawneffect <= 0)
        {


        }
        else
        {
            Instantiate(effect, this.gameObject.transform);
            spawneffect = spawneffect - 1;
        }

    }
    
}
