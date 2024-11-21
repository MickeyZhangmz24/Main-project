using UnityEngine;


public class Enemy : MonoBehaviour
{
   
    private Vector3 bullectEulerAngles = Vector3.zero;
    private float moveSpeed = 3;
    private float v = -1;
    private float h = 0;
    private float timeVal = 0;
    private float timeValChangeDirection = 0;
    private SpriteRenderer sr = null;
  

    
    public Sprite[] tankSprite = null;
 

    
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
   

   
    void Update()
    {
        
        if (timeVal >= 3)
        {
            
            Attack();
        }
        else
        {
            
            timeVal += Time.deltaTime;
        }
    }
    

   
    private void FixedUpdate()
    {
        Move();
    }
    

   
    private void Attack()
    {
       
        Instantiate(GameManager.Instance.BullectGO[0], this.transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
        
        timeVal = 0;
    }
    

   
    private void Move()
    {
        
        if (timeValChangeDirection >= 4)
        {
            
            int num = Random.Range(0, 8);

           
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else if (num > 2 && num <= 4)
            {
                h = 1;
                v = 0;
            }

            
            timeValChangeDirection = 0;
        }
        else
        {
          
            timeValChangeDirection += Time.fixedDeltaTime;
        }

        
        this.transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        
        if (v < 0)
        {
            
            sr.sprite = tankSprite[2];
            
            bullectEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);
        }

        if (v != 0)
        {
           
            return;
        }

       
        this.transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);

        
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }
    }
    

   
    private void Die()
    {
        
        PlayerManager.Instance.playerScore++;
        
        Instantiate(GameManager.Instance.EffectGO[0], transform.position, transform.rotation);
        
        Destroy(this.gameObject);
    }
   

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Enemy")
        {
            
            timeValChangeDirection = 4;
        }
    }
   
}