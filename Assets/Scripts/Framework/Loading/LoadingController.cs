using GameSystem;
using UnityEngine;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour {

    public Image loadingProgressImg;
    public Text progressPercentText;

    private float _offsetMaxX;
    private Vector2 _curOffsetMax;
    private float _totalWidth;
    private float progressPercent;

    private void Start()
    {
        Vector2 offsetMax = loadingProgressImg.rectTransform.offsetMax;
        _offsetMaxX = offsetMax.x;
        _totalWidth = loadingProgressImg.rectTransform.rect.width;
        _curOffsetMax = new Vector2(_offsetMaxX - _totalWidth, offsetMax.y);
        progressPercent = 0f;
    }

    void Update () {
        if (SceneSystem.Ins.AsyncOp != null) {
            progressPercent = Mathf.Min(SceneSystem.Ins.AsyncOp.progress / 0.9f, 1f);
            float offsetX = _offsetMaxX - _totalWidth + progressPercent * _totalWidth;
            offsetX = Mathf.Min(_offsetMaxX, offsetX);
            _curOffsetMax.x = offsetX;
        }
        loadingProgressImg.rectTransform.offsetMax = _curOffsetMax;
        progressPercentText.text = string.Format("载入中...{0}%", Mathf.CeilToInt(progressPercent * 100f));
    }
}
