using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StuartH
{
    /// <summary>
    ///CountDown - Display countdown timer to start game
    /// </summary>
    public class CountDown : MonoBehaviour
    {
        [SerializeField] private PlayerMovement player;
        [SerializeField] private Image image;
        [SerializeField] private List<Sprite> countDownSprites;
        public static event Action OnGameStart;
        private int index = 0;

        private void Awake()
        {
            if (player == null) player = FindObjectOfType<PlayerMovement>();
            player.SetEnabled(false);
            index = countDownSprites.Count;

        }

        private void Start() => InvokeRepeating(nameof(ChangeSprite), 0, 1f);

        private void ChangeSprite()
        {
            if (index == 0)
            {
                OnGameStart?.Invoke();
                //player.SetEnabled(true);
                Destroy(gameObject);
                return;
            }

            index--;
            image.sprite = countDownSprites[index];
        }

    }
}
