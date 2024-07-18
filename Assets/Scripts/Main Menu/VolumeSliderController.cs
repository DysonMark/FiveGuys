using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine.Audio;


namespace Leonardo.MainMenu.VolumeSlider
{
    public class VolumeSliderController : MonoBehaviour
    {

        [SerializeField] private AudioMixer audioMixer;
        
        
        [SerializeField] private TextMeshProUGUI volumeSliderText = null;
        [SerializeField] private float maxSliderAmount = 100.0f;
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private float changeRate; // The rate in which the value changes when the button is pressed
        
        private void Start()
        {
            if (PlayerPrefs.HasKey("Volume"))
            {
                SliderChange(PlayerPrefs.GetFloat("Volume"));
                SetVolume(PlayerPrefs.GetFloat("Volume"));
            }
        }

        public void SliderChange(float value)
        {
            float localValue = value * maxSliderAmount;
            volumeSliderText.text = localValue.ToString("0"); // To not show decimals.
            volumeSlider.value = value;
        }

        public void VolumeUp()
        {
            volumeSlider.value = Mathf.Clamp(volumeSlider.value + changeRate * Time.deltaTime, volumeSlider.minValue,
                volumeSlider.maxValue);
            TransferVolumeParameters(volumeSlider.value);
        }

        public void VolumeDown()
        {
            volumeSlider.value = Mathf.Clamp(volumeSlider.value - changeRate * Time.deltaTime, volumeSlider.minValue,
                volumeSlider.maxValue);
            TransferVolumeParameters(volumeSlider.value);
        }

        private void TransferVolumeParameters(float volumeValue)
        {
            SliderChange(volumeSlider.value);
            SetVolume(volumeSlider.value);
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        }
        
        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume)*20);
        }
        
        #region Debug Region
        // DEBUG PURPOSES
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                VolumeUp();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                VolumeDown();
            }
        }
        
        #endregion
        

    }
}