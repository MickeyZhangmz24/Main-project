using UnityEngine;


public class Bullect : MonoBehaviour
{
    
    private float moveSpeed = 10;
   

   
    public bool isPlayerBullect;
    

   
    void Update()
    {
        this.transform.Translate(this.transform.up * moveSpeed * Time.deltaTime, Space.World);
    }
  

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (isPlayerBullect == false)
                {
                  
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;

            case "Heart":
                
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;

            case "Enemy":
                if (isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;

            case "Wall":
                
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;

            case "Barrier":
               
                AudioSource.PlayClipAtPoint(GameManager.Instance.AudioClipArray[1], collision.transform.position);
                Destroy(gameObject);
                break;
        }
    }
   
}