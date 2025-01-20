using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
[AddComponentMenu("TienCuong/AudioMixedManager")]
public class AudioMixedManager : MonoBehaviour
{
    public AudioMixer masterMixed;
    public Slider sliderMusic;
    public Slider sliderSFX;
    void Start()
    {
        float volumeMusic = PlayerPrefs.GetFloat("Music", 20);
        sliderMusic.value = volumeMusic;
        float volumeSFX = PlayerPrefs.GetFloat("SFX", 20);
        sliderSFX.value = volumeSFX;
        UpdateMusicVolume(volumeMusic);
        UpdateSFXVolume(volumeSFX);
    }

    // Update is called once per frame
    public void UpdateMusicVolume(float volume)
    {
        masterMixed.SetFloat("Music", volume);
        PlayerPrefs.SetFloat("Music", volume);
    }
    public void UpdateSFXVolume(float volume)
    {
        masterMixed.SetFloat("SFX", volume);
        PlayerPrefs.SetFloat("SFX", volume);
    }
}
