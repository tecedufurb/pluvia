using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject WaterObject;
    [SerializeField] private GameObject RainObject;
    [SerializeField] private GameObject SunObject;
    [SerializeField] private GameObject RainButton;
    [SerializeField] private GameObject DryButton;
    [SerializeField] private float GazeTime;

    private float mTimer;
    private bool mGazeAtRainButton;
    private bool mGazeAtDryButton;
    private bool mGazeAtDayNightButton;
    private bool mDay = true;

    void Update() {
        if (mGazeAtRainButton)
            StartRain();

        if (mGazeAtDryButton)
            StartDry();

        if (mGazeAtDayNightButton)
            DayNight();
    }

    private void StartRain() {
        mTimer += Time.deltaTime;
        if (mTimer >= GazeTime) {
            if (WaterObject.transform.position.y <= 17) {
                RainObject.SetActive(true);
                WaterObject.transform.position = new Vector3(249, WaterObject.transform.position.y + .05f, 249);
            }
            if (WaterObject.transform.position.y >= 17) {
                mGazeAtRainButton = false;
                RainObject.SetActive(false);
                mTimer = 0;
            }
        }
    }

    private void StartDry() {
        mTimer += Time.deltaTime;
        if (mTimer >= GazeTime) {
            if (WaterObject.transform.position.y >= 3)
                WaterObject.transform.position = new Vector3(249, WaterObject.transform.position.y - .05f, 249);

            if (WaterObject.transform.position.y <= 3) {
                mGazeAtDryButton = false;
                mTimer = 0;
            }
        }
    }
    
    private void DayNight() {
        SunObject.transform.RotateAround(Vector3.zero, Vector3.right, 15f * Time.deltaTime);
        SunObject.transform.LookAt(Vector3.zero);
    }
    
    public void PointerEnterRain() {
        mGazeAtRainButton = true;
        mGazeAtDryButton = false;
    }

    public void PointerEnterDry() {
        mGazeAtDryButton = true;
        mGazeAtRainButton = false;
    }
    
    public void PointerEnterDayNight() {
        if (mGazeAtDayNightButton)
            mGazeAtDayNightButton = false;
        else
            mGazeAtDayNightButton = true;
    }
    
    public void PointerExit() {

    }
}