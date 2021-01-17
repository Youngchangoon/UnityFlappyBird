using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
    public SpriteRenderer topSpike;
    public SpriteRenderer bottomSpike;

    private float _totalHeight = 19.2f;
    private float _scrollSpeed;
    private bool _isAddingScore;
    private float _birdPosX;

    public void Init(float holeSize, float scrollSpeed, float birdPosX)
    {
        var bottomHeight = Random.Range(4f, _totalHeight - holeSize - 2f);
        var topHeight = _totalHeight - bottomHeight - holeSize;

        SetSpikeSize(bottomSpike, bottomHeight);
        SetColliderSize(bottomSpike, bottomHeight);       

        SetSpikeSize(topSpike, topHeight);
        SetColliderSize(topSpike, topHeight, true);

        _scrollSpeed = scrollSpeed;
        _isAddingScore = false;
        _birdPosX = birdPosX;
    }

    private void SetSpikeSize(SpriteRenderer spike, float height)
    {
        spike.size = new Vector2(bottomSpike.size.x, height);
    }

    private void SetColliderSize(SpriteRenderer spikeSpr, float height, bool isTop = false)
    {
        var bottomCollider = spikeSpr.GetComponent<BoxCollider2D>();
        bottomCollider.size = new Vector2(bottomCollider.size.x, height);
        bottomCollider.offset = new Vector2(0f, (isTop ? -1f : 1f) * (height / 2f));
    }

    private void Update()
    {
        transform.Translate(new Vector3(-_scrollSpeed * Time.deltaTime, 0f, 0f));       

        if (transform.position.x < -8f)
        {
            DestroyImmediate(gameObject);
            return;
        }

        if(transform.position.x < _birdPosX && _isAddingScore == false)
        {
            _isAddingScore = true;
            GameController.Instance.AddScore(1);
        }
    }
}

