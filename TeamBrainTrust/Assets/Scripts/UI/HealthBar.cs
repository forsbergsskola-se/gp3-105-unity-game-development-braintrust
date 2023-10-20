using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        public void SetupUI(int maxValue, int value)
        {
            Slider slider = GetComponent<Slider>();
            slider.maxValue = maxValue;
            slider.value = value;
        }
        
        public void UpdateUI(int value)
        {
            GetComponent<Slider>().value = value;
            
        }
    }
}