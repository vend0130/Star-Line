using UnityEngine;
using UnityEngine.UI;

namespace Code.Game.Enemies
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private Image _currentHPImage;

        public void SetValue(float current, float max) =>
            _currentHPImage.fillAmount = current / max;
    }
}