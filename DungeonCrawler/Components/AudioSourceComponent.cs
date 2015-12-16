#define AUDIODEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;

namespace Components {
    class AudioSourceComponent : Component {
        public Dictionary<string, int> SoundBank { get; private set; }
        protected Dictionary<string, bool> loopBank = null;
        public string CurrentSound { get; private set; }

        public AudioSourceComponent(GameObject game) : base("AudioSourceComponent", game) {
            SoundBank = new Dictionary<string, int>();
            loopBank = new Dictionary<string, bool>();
        }

        public void AddSound(string name, string soundPath) {
            if (SoundBank.ContainsKey(name)) {
#if AUDIODEBUG
                Console.WriteLine("AudioSource trying to add an existing sound");
#endif
                return;
            }
            if (CurrentSound == null) {
                CurrentSound = name;
            }
            soundPath = soundPath.ToLower();
            int sound = 0;
            if (soundPath.EndsWith(".wav")) {
                sound = SoundManager.Instance.LoadWav(soundPath);
            }
            else if (soundPath.EndsWith(".mp3")) {
                sound = SoundManager.Instance.LoadMp3(soundPath);
            }
            else {
#if AUDIODEBUG
                Console.WriteLine("AudioSource trying to load invalid file-type");
#endif
                return;
            }
            SoundBank.Add(name, sound);
        }
        public void RemoveSound(string name) {
            if (SoundManager.Instance.IsPlaying(SoundBank[name])) {
#if AUDIODEBUG
                Console.WriteLine("AudioSource removing sound currently playing");
#endif
                SoundManager.Instance.StopSound(SoundBank[name]);

            }
            if (!SoundBank.ContainsKey(name)) {
#if AUDIODEBUG
                Console.WriteLine("AudioSource trying to remove nonexistant sound");
#endif
                return;
            }
            if (!loopBank.ContainsKey(name)) {
#if AUDIODEBUG
                Console.WriteLine("AudioSource trying to remove nonexistant sound");
#endif
                return;
            }
            SoundBank.Remove(name);
            loopBank.Remove(name);
        }
        public void PlaySound(string name, bool looping = false) {
            if (SoundManager.Instance.IsPlaying(SoundBank[name])) {
#if AUDIODEBUG
                Console.WriteLine("AudioSource trying to play a song already playing");
#endif
                return;
            }
            CurrentSound = name;
            loopBank[CurrentSound] = false;
            SoundManager.Instance.PlaySound(SoundBank[name]);
        }

        public void SetVolume(string name, float volume) {
            SoundManager.Instance.SetVolume(SoundBank[name], volume);
        }
        public override void OnUpdate(float dTime) {
            if (loopBank[CurrentSound]) {
                if (!SoundManager.Instance.IsPlaying(SoundBank[CurrentSound])) {
                    SoundManager.Instance.PlaySound(SoundBank[CurrentSound]);
                }
            }
        }
        public override void OnDestroy() {
            foreach (KeyValuePair<string,int> kvp in SoundBank) {
                SoundManager.Instance.UnloadSound(kvp.Value);
            }
        }
        
    }
}
