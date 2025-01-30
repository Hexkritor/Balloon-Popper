using TMPro;
using UnityEngine;

namespace Hexkritor.BalloonPopper.Data.Components
{
    public class HealthVisual : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text textField;

        public void SetText(int health)
        {
            textField.text = $"{health}";
        }
    }
}
