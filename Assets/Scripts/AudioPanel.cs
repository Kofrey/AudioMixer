using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _mixerVolumeName;
    [SerializeField] private string _prefsEnabledName;

    private void Start() 
    {
        _toggle.isOn = PlayerPrefs.GetInt(_prefsEnabledName, 1) == 1;
        _slider.value = PlayerPrefs.GetFloat(_mixerVolumeName, 1);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void ToggleAudio(bool enabled)
    {
        if (enabled)
            _mixer.audioMixer.SetFloat(_mixerVolumeName, Mathf.Log10(_slider.value) * 20);
        else 
            _mixer.audioMixer.SetFloat(_mixerVolumeName, -80);

        PlayerPrefs.SetInt(_prefsEnabledName, enabled ? 1 : 0);
    }

    public void ChangeVolume(float volume)
    {
        if (_toggle.isOn == false)
            _toggle.isOn = true;

        _mixer.audioMixer.SetFloat(_mixerVolumeName, Mathf.Log10(volume) * 20);  // Mathf.Lerp(-80, 0, volume));

        PlayerPrefs.SetFloat(_mixerVolumeName, volume);
    }
}
