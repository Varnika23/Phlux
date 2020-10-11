using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(AudioSource))]
public class AutoPlacementOfObjectsInPlane : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    //[SerializeField]
    //private GameObject welcomePanel;

    [SerializeField]
    private GameObject placedPrefab_flask;

    private GameObject placedObject_flask;

    [SerializeField]
    private GameObject placedPrefab_bottle;

    private GameObject placedObject_bottle;

    //[SerializeField]
    //private Button dismissButton;

    [SerializeField]
    private ARPlaneManager arPlaneManager;

    //Insert the empty game object with the TextMesh attached
    public GameObject flaskText;
    AudioSource audioClip1;
    AudioSource audioClip2;
    AudioSource audioClip3;
    AudioSource audioClip4;


    void Awake()
    {
        //dismissButton.onClick.AddListener(Dismiss);
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneChanged;
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && placedObject_flask == null)
        {
            ARPlane arPlane = args.added[0];
            var rotation_flask = Quaternion.LookRotation(arPlane.transform.position);
            rotation_flask *= Quaternion.Euler(0, 260, 10);
            placedObject_flask = Instantiate(placedPrefab_flask, arPlane.transform.position, rotation_flask);
            placedObject_flask.transform.localScale -= new Vector3(0.5F, 0.5F, 0.5F);

            //var text_rescued = Instantiate(TextPrefab);
            //var position = arPlane.transform.position;
            //text_rescued.gameObject.transform.position = new Vector3(position.x, position.y + 0.1f, position.z);


            ////Instantiates the Object
            //GameObject rescuedTextBox = (GameObject)Instantiate(rescuedText, arPlane.transform.position, rotation_rescued);

            ////Grabs the TextMesh component from the game object
            //TextMesh theText = rescuedTextBox.transform.GetComponent<TextMesh>();

            ////Sets the text.
            //theText.text = "The Text";

            //var rotation_rescuer = Quaternion.LookRotation(arPlane.transform.position);
            //rotation_rescuer *= Quaternion.Euler(90, -90, 90);
            var rotation_bottle = Quaternion.LookRotation(placedObject_flask.transform.position);
            rotation_bottle *= Quaternion.Euler(0, 180, 0);
            //placedObject_bottle = Instantiate(placedPrefab_bottle, new Vector3((arPlane.transform.position.x)-0.2F,(arPlane.transform.position.y) + 0.42F, (arPlane.transform.position.z) + 0.45F), rotation_rescuer);
            placedObject_bottle = Instantiate(placedPrefab_bottle, new Vector3((placedObject_flask.transform.position.x) - 0.25F, (placedObject_rescued.transform.position.y) - 0.07F , (placedObject_rescued.transform.position.z)+ 0.1F), rotation_rescuer);
            placedObject_bottle.transform.localScale -= new Vector3(0.5F, 0.5F, 0.5F);

        }
    }

    //private void Dismiss() => welcomePanel.SetActive(false);
}
