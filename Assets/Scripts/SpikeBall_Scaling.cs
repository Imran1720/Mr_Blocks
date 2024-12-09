using UnityEngine;

public class SpikeBall_Scaling : MonoBehaviour
{

    [SerializeField]
    float rotationSpeed;

    public float scalingFactor = 1f, scalingSpeed = 15f, minScale = .5f, maxScale = 1.5f;

    private float currentScale;

    public float scaleDelay = .5f;
    bool isWainting = false;

    private float timer = 0f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        RotateObject();
        if (isWainting)
        {
            DelayScale();
        }
        else
        {
            ScaleObject();
        }
    }

    private void ScaleObject()
    {
        currentScale += scalingFactor * scalingSpeed * Time.deltaTime;
        currentScale = Mathf.Clamp(currentScale, minScale, maxScale);

        if (currentScale >= maxScale || currentScale <= minScale)
        {
            scalingFactor = -scalingFactor;
            isWainting = true;
        }
        ApplyScale();
    }

    private void ApplyScale()
    {
        transform.localScale = new Vector3(currentScale, currentScale, 1);
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    void DelayScale()
    {
        timer += Time.deltaTime;
        if (timer >= scaleDelay)
        {
            timer = 0f;
            isWainting = false;
        }
    }
}
