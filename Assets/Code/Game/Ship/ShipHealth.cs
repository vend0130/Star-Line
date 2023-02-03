using System;
using Code.Game.Battle;
using Code.Services.Progress;
using UnityEngine;

namespace Code.Game.Ship
{
    public class ShipHealth : MonoBehaviour, ITakeDamage
    {
        public UnitType UnitType => UnitType.Player;
        public event Action DieHandler;

        private IProgressService _progressService;
        private HeartsView _heartsView;

        public void InitProgress(IProgressService progressService, HeartsView heartsView)
        {
            _progressService = progressService;
            _heartsView = heartsView;
        }

        public void TakeDamage(float damage)
        {
            if (Death())
                return;

            _progressService.Hearts--;
            _heartsView.DestroyHeart();

            if (Death())
                DieHandler?.Invoke();
        }

        private bool Death() =>
            _progressService.Hearts <= 0;
    }
}