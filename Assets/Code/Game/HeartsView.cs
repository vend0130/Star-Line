using System.Collections.Generic;
using Code.Services.Bonuses;
using UnityEngine;

namespace Code.Game
{
    public class HeartsView : MonoBehaviour
    {
        private List<GameObject> _hearts = new List<GameObject>();
        private IBonusesService _bonusesService;

        public void AddHeart(GameObject heart) =>
            _hearts.Add(heart);

        public void DestroyHeart()
        {
            GameObject heart = _hearts[^1];
            _hearts.Remove(heart);
            Destroy(heart);
        }
    }
}