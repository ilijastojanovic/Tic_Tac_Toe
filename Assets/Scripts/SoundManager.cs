using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider bgmVolumeSlider;
    [SerializeField] AudioSource bgmAudio;

    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] AudioSource buttonPressSound;
    [SerializeField] AudioSource xoPlacementSound;
    [SerializeField] AudioSource winSound;
    [SerializeField] AudioSource drawSound;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("bgmVolume"))
        {
            PlayerPrefs.SetFloat("bgmVolume", 1);
            LoadBGM();
        }else
        {
            LoadBGM();
        }

        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1);
            LoadSFX();
        }
        else
        {
            LoadSFX();
        }
    }

    public void ChangeVolume()
    {
        bgmAudio.volume = bgmVolumeSlider.value;
        SaveBGM();
    }

    public void ChangeVolumeSFX()
    {
        buttonPressSound.volume = sfxVolumeSlider.value;
        xoPlacementSound.volume = sfxVolumeSlider.value;
        winSound.volume = sfxVolumeSlider.value;
        drawSound.volume = sfxVolumeSlider.value;
        SaveSFX();
    }

    private void LoadBGM()
    {
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("bgmVolume");
    }

    private void SaveBGM()
    {
        PlayerPrefs.SetFloat("bgmVolume", bgmVolumeSlider.value);
    }

    private void LoadSFX()
    {
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void SaveSFX()
    {
        PlayerPrefs.SetFloat("sfxVolume", sfxVolumeSlider.value);
    }

}
 