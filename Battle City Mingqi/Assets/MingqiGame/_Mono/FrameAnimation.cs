using System;
using UnityEngine;

namespace YHBGAME.YHB_Mono
{
    
    public class FrameAnimation : MonoBehaviour
    {
        
        [Header("How long does the animation play?")]
        public float TotalTime = 1f;
        [Header("Total time, default is 1 second")]
        public int FrameRate = 10;
        [Header("Whether to loop the animation")]
        public bool Loop = true;
        [Header("Whether to destroy itself after playing it once")]
        public bool OnceDes = false;
        [Header("Array of sprite pictures to be played")]
        public Sprite[] SpriteArray;
       

        
        private SpriteRenderer spriteRenderer;
        private float loopTimer = 0;
        private float onceDesTimer = 0;
       

        
        void Start()
        {
            spriteRenderer = this.GetComponent<SpriteRenderer>();

            if (spriteRenderer == null)
            {
                spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
            }
        }
       

        
        void Update()
        {
            Play();
        }
        

       
        private void Play()
        {
            try
            {
                if (OnceDes)
                {
                    Loop = false;
                    onceDesTimer += Time.deltaTime;
                    int frameIndex = (int)(onceDesTimer / (TotalTime / FrameRate));

                    if (frameIndex >= SpriteArray.Length)
                    {
                       
                        spriteRenderer.sprite = SpriteArray[SpriteArray.Length - 1];

                        
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        spriteRenderer.sprite = SpriteArray[frameIndex];
                    }
                }

                if (Loop)
                {
                    loopTimer += Time.deltaTime;
                    int frameIndex = (int)(loopTimer / (TotalTime / FrameRate));
                    int frame = frameIndex % SpriteArray.Length;
                    spriteRenderer.sprite = SpriteArray[frame];
                }

            }
            catch (Exception e)
            {
                if (FrameRate == 0)
                {
                    Debug.LogError("Animation playback error---frame rate (denominator) cannot be 0 !");
                }
                else
                {
                    Debug.LogError("Animation playback error---The sprite image array cannot be empty !");
                }

                Debug.LogError(e.Message);
            }
        }
       
    }
}