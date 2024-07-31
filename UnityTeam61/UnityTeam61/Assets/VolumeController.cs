using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    public Button muteButton;
    private bool isMuted = false;
    private float previousVolume;

    public Sprite mutedImg;
    public Sprite unmutedImg;

    void Start()
    {
        InitializeVolumeSettings();

        volumeSlider.onValueChanged.AddListener(SetVolume);
        muteButton.onClick.AddListener(ToggleMute);

        Assert.IsNotNull(mutedImg, "Muted image not found");
        Assert.IsNotNull(unmutedImg, "Unmuted image not found");

        Debug.Log("Muted image loaded: " + (mutedImg != null));
        Debug.Log("Unmuted image loaded: " + (unmutedImg != null));

        UpdateButtonImage();
    }

    private void InitializeVolumeSettings()
    {
        if (audioSource != null)
        {
            volumeSlider.value = audioSource.volume;
            isMuted = audioSource.volume <= 0;
        }
    }

    private void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
            isMuted = volume <= 0;
            UpdateButtonImage();
        }
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            previousVolume = audioSource.volume;
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = previousVolume;
        }

        volumeSlider.value = audioSource.volume;
        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        muteButton.image.sprite = isMuted ? mutedImg : unmutedImg;
    }
}
