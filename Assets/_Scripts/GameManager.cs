using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private GameObject WaterObject;
    [SerializeField] private GameObject RainObject;
    [SerializeField] private GameObject SunObject;
    [SerializeField] private float GazeTime;

    private float mTimer;
    private bool mGazeAtRainButton;
    private bool mGazeAtDryButton;
    private bool mGazeAtDayNightButton;

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
        mTimer += Time.deltaTime;
        if (mTimer >= GazeTime) {
            SunObject.transform.RotateAround(Vector3.zero, Vector3.right, 15f * Time.deltaTime);
            SunObject.transform.LookAt(Vector3.zero);
        }
    }

    public void PointerEnterRain() {
        mGazeAtRainButton = true;
        mGazeAtDryButton = false;
    }

    public void PointerEnterDry() {
        mGazeAtDryButton = true;
        mGazeAtRainButton = false;
        RainObject.SetActive(false);
    }

    public void PointerEnterDayNight() {
        mGazeAtDayNightButton = true;
    }

    public void PointerExit() {

    }
}