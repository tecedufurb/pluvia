using System.Collections;
using UnityEngine;

public class ClimateManager : MonoBehaviour{
    
    [SerializeField] private GameObject rain;
    [SerializeField] private Transform river;
    [SerializeField] private Transform waterFall;
    private Vector3 waterFallInitialPosition;
    private Vector3 waterFallFinalPosition;
    private float minPosition = .7f;
    private float maxPosition = 12.2f;
    private float speed = 2f;

    private void Start() {
        waterFallInitialPosition = waterFall.position;
        waterFallFinalPosition = new Vector3(waterFall.position.x, -20f, waterFall.position.z);
    }
    
    /// <summary>
    /// Starts the coroutine MoveRiverUp witch will activate the rain and the waterfall (if they were disable)
    /// and move the river up while the player keeps pressing the button. 
    /// Called in the EventTrigger of the RainButton button.
    /// </summary>
    public void StartRain() {
        StartCoroutine(MoveRiverUp());
    }
    
    /// <summary>
    /// Starts the coroutine MoveRiverDown witch will disable the rain and move the river down
    /// while the player keeps pressing the button. If the river reaches its limit the waterfall
    /// will be disable too.
    /// Called in the EventTrigger of the DryButton button.
    /// </summary>
    public void StartDry() {
        StartCoroutine(MoveRiverDown());
    }

    /// <summary>
    /// Stops the coroutine MoveRiverUp and disables the rain.
    /// </summary>
    public void StopRain() {
        StopAllCoroutines();
        rain.SetActive(false);
    }

    private IEnumerator MoveRiverUp () {
        rain.SetActive(true);
        if (!waterFall.position.Equals(waterFallInitialPosition))
            waterFall.position = waterFallInitialPosition;   
                
        yield return new WaitForSeconds(2f);
        while (river.position.y < maxPosition) {
            river.position = new Vector3(river.position.x, 
                river.position.y + Time.deltaTime * speed, river.position.z);
            yield return null;
        }
        rain.SetActive(false);
    }

    private IEnumerator MoveRiverDown() {
        rain.SetActive(false);
        yield return new WaitForSeconds(.5f);
        while (river.position.y > minPosition) {
            river.position = new Vector3(river.position.x, 
                river.position.y - Time.deltaTime * speed, river.position.z);
            yield return null;
        }
        waterFall.position = waterFallFinalPosition;
    }
}