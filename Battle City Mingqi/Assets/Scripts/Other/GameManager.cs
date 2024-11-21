using YHBGAME.YHB_Singleton;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : SingletonBase<GameManager>
{
    
    private GameObject[] item = null;

    public GameObject[] ItemGO
    {
        get
        {
            if (item == null)
            {
                item = new GameObject[] {
                    Resources.Load<GameObject>("Map/Heart"),
                    Resources.Load<GameObject>("Map/Wall"),
                    Resources.Load<GameObject>("Map/Barriar"),
                    Resources.Load<GameObject>("Map/Born"),
                    Resources.Load<GameObject>("Map/River"),
                    Resources.Load<GameObject>("Map/Grass"),
                    Resources.Load<GameObject>("Map/AirBarriar"),
                };
            }

            return item;
        }
    }
   

    
    private GameObject player = null;

    public GameObject PlayerGO
    {
        get
        {
            if (player == null)
            {
                player = Resources.Load<GameObject>("Tank/Player");
            }

            return player;
        }
    }
    
    private GameObject[] enemys = null;

    public GameObject[] EnemyGO
    {
        get
        {
            if (enemys == null)
            {
                enemys = new GameObject[] {
                    Resources.Load<GameObject>("Tank/BigEnemy"),
                    Resources.Load<GameObject>("Tank/SmallEnemy"),
                };
            }

            return enemys;
        }
    }
   

    
    private GameObject[] bullect = null;

    public GameObject[] BullectGO
    {
        get
        {
            if (bullect == null)
            {
                bullect = new GameObject[] {
                    Resources.Load<GameObject>("Tank/EnemyBullect"),
                    Resources.Load<GameObject>("Tank/PlayerBullect"),
                };
            }

            return bullect;
        }
    }
  

    
    private AudioClip[] audioClips = null;

    public AudioClip[] AudioClipArray
    {
        get
        {
            if (audioClips == null)
            {
                audioClips = new AudioClip[] {
                    Resources.Load<AudioClip>("Die"),
                    Resources.Load<AudioClip>("Hit"),
                    Resources.Load<AudioClip>("EngineIdle"),
                    Resources.Load<AudioClip>("EngineDriving"),
                };
            }

            return audioClips;
        }
    }
   
    private GameObject[] effects = null;

    public GameObject[] EffectGO
    {
        get
        {
            if (effects == null)
            {
                effects = new GameObject[] {
                    Resources.Load<GameObject>("Effect/Explosion"),
                    Resources.Load<GameObject>("Effect/Shield"),
                };
            }

            return effects;
        }
    }
   
    public void OnStartBtnClick()
    {
        
        SceneManager.LoadScene(1);
    }
    
}