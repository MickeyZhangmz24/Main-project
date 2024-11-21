using UnityEngine;
using YHBGAME.YHB_Singleton;

namespace YHBGAME.YHB_Mono
{
   
    public class CameraShake : SingletonBase<CameraShake>
    {
       
        private Vector3 initPosition = Vector3.zero;
        private float distance = 0;
        private float timer = 0;
        private float timeCD = 0.16f;
        private bool isStartCameraShake = false;
       

        
        void Start()
        {
            
            initPosition = this.transform.localPosition;
            timer = timeCD;
        }
       

        
        void Update()
        {
           
            if (isStartCameraShake)
            {
                
                timer -= Time.deltaTime;
                
                this.transform.localPosition = initPosition + Random.insideUnitSphere * distance;

               
                if (timer <= 0)
                {
                    isStartCameraShake = false;
                    timer = timeCD;
                    this.transform.localPosition = initPosition;
                }
            }
        }
       

       
        public void StartCameraShake(float distance = 1, bool isOrigin = true)
        {
            
            if (this.isStartCameraShake)
            {
                return;
            }

            if (isOrigin)
            {
                initPosition = Vector3.zero;
            }
            else
            {
                
                initPosition = this.transform.localPosition;
            }

            this.distance = distance;
            isStartCameraShake = true;
        }
        
    }
}