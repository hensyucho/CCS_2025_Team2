using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Canvas References")]
    [Tooltip("Screen Space Overlay Canvas")]
    public Canvas screenSpaceCanvas;

    [Header("Prefabs")]
    [Tooltip("HPGauge 프리팹 (Canvas 컴포넌트 없이 UI 요소만 포함)")]
    public GameObject hpGaugePrefab;

    private void Awake()
    {
        // 싱글턴 설정
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // 씬 전환 시 유지하려면 아래 주석 해제
        // DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Screen Space Overlay Canvas 하위에 HP 게이지 프리팹을 인스턴스화하여 반환합니다.
    /// </summary>
    /// <param name="position">초기 위치 (화면 좌표)</param>
    /// <param name="parent">부모 Transform (기본은 screenSpaceCanvas.transform)</param>
    /// <returns>생성된 HPGauge 컴포넌트</returns>
    public HPGauge GetHpGauge(Vector3 position, Transform parent = null)
    {
        if (screenSpaceCanvas == null)
        {
            Debug.LogError("Screen Space Canvas가 할당되지 않았습니다.");
            return null;
        }
        if (parent == null)
        {
            parent = screenSpaceCanvas.transform;
        }
        GameObject gaugeObj = Instantiate(hpGaugePrefab, position, Quaternion.identity, parent);
        HPGauge hpGauge = gaugeObj.GetComponent<HPGauge>();
        if (hpGauge == null)
        {
            Debug.LogError("생성된 프리팹에 HPGauge 컴포넌트가 없습니다.");
        }
        return hpGauge;
    }
}