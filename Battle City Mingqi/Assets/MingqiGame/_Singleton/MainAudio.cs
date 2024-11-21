using UnityEngine;

namespace YHBGAME.YHB_Singleton
{
    [RequireComponent(typeof(AudioSource))]
    public class MainAudio : SingletonBase<MainAudio>
    {
        
        private AudioSource thisAS = null;
        

        
        public void PlayMusic(string audioClip = "BGM")
        {
            
            if (thisAS == null)
            {
                thisAS = this.GetComponent<AudioSource>();

                if (thisAS.clip == null)
                {
                    AudioClip bgm = Resources.Load<AudioClip>(audioClip);

                    if (bgm == null)
                    {
                        return;
                    }

                    thisAS.clip = bgm;
                    thisAS.playOnAwake = true;
                    thisAS.loop = true;
                    thisAS.Play();
                }
            }
        }
       
    }
}