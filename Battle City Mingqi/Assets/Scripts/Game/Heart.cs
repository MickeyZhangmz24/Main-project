using UnityEngine;


public class Heart : MonoBehaviour
{
    
    public Sprite BrokenSprite = null;
   

   
    private SpriteRenderer sr = null; 
    
    
   
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
   

    
   
    public void Die()
    {
       
        sr.sprite = BrokenSprite;
        
        Instantiate(GameManager.Instance.EffectGO[0], this.transform.position, this.transform.rotation);
        
        PlayerManager.Instance.isDefeat = true;
        
        AudioSource.PlayClipAtPoint(GameManager.Instance.AudioClipArray[0], this.transform.position);
    }
    
}