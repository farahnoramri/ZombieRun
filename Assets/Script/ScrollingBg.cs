
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ScrollingBg : MonoBehaviour
{
    // NEW: Controls how fast the background moves
    // relative to the game speed
    [SerializeField]
    private float speedMultiplier = 0.05f;

    [SerializeField]
    private Renderer bgRenderer;

    // NEW: Reference to GameScript
    private GameScript _gameScript;

    // NEW: Store the material instance
    private Material bgMaterial;

    private void Start()
    {
        // NEW: Find GameScript
        _gameScript = FindAnyObjectByType<GameScript>();

        // NEW: Get material once instead of every frame
        if (bgRenderer != null)
        {
            bgMaterial = bgRenderer.material;
        }
    }

    private void Update()
    {
        if (_gameScript == null || bgMaterial == null)
            return;

        // NEW: Background speed follows game speed
        float scrollSpeed = _gameScript.currentSpeed * speedMultiplier;

        bgMaterial.mainTextureOffset += new Vector2(
            scrollSpeed * Time.deltaTime,
            0
        );
    }
}
