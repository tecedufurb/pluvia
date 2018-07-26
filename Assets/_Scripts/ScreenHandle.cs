using UnityEngine;

public class ScreenHandle : MonoBehaviour {

    [SerializeField] private Transform river;
    [SerializeField] private Transform sun;
    [SerializeField] private ClimeController climeController;

    private bool mActive = true;

    public void StartRain() {
        print("Clicou na chuva");
        climeController.StopAllCoroutines();
        float limit = river.position.y + 20f;
        climeController.StartWaterMovement(river, limit, 3f, Direction.UP);
    }

    public void StartDry() {
        print("Clicou no sol");
        climeController.StopAllCoroutines();
        float limit = river.position.y - 20f;
        climeController.StartWaterMovement(river, limit, 3f, Direction.DOWN);
    }

    public void StartDayNightCycle() {
        mActive = !mActive;

        float limit = sun.rotation.x + 1;
        climeController.StartSunMovement(sun, limit, mActive, 25f);
    }
}
