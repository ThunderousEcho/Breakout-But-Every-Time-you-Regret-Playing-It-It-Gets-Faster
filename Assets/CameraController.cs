using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(PostProcessingBehaviour))]
public class CameraController : MonoBehaviour {

    PostProcessingProfile profile;
    PostProcessingBehaviour postProcessingBehaviour;

    public static void RecalculateIntensityMultiplier() {
        intensityMultiplier = 1 + Mathf.Max(0, (140 - FindObjectsOfType<Brick>().Length) * 0.0375f);
        GameObject.Find("Music").GetComponent<AudioSource>().pitch = intensityMultiplier;
    }

    public static float intensityMultiplier = 1;
    public static float shake;
    public static float chromaticAberration;

    void Start () {
        profile = ScriptableObject.CreateInstance<PostProcessingProfile>();
        postProcessingBehaviour = GetComponent<PostProcessingBehaviour>();
        postProcessingBehaviour.profile = profile;

        profile.chromaticAberration.enabled = true;
        profile.motionBlur.enabled = true;
        profile.bloom.enabled = true;
    }
	
	void Update () {

        Vector3 position = Random.insideUnitCircle * shake * intensityMultiplier;
        position.z = -0.5f;
        transform.position = position;

        var chromaticAberrationSettings = profile.chromaticAberration.settings;
        chromaticAberrationSettings.intensity = (chromaticAberration + 1) * intensityMultiplier;
        profile.chromaticAberration.settings = chromaticAberrationSettings;

        chromaticAberration = Mathf.Lerp(chromaticAberration, 0, Time.deltaTime * 5);
        shake = Mathf.Lerp(shake, 0, Time.deltaTime * 5);
    }
}
