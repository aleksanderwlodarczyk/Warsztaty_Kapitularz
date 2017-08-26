using UnityEngine;
using System.Collections;

public class MPlatConnector : MonoBehaviour
{
    public GameObject PlatformBig, PlatformSmall;

	void Awake ()
    {
        PlatformBig.transform.localScale = transform.localScale;
        PlatformSmall.transform.localScale = new Vector2(PlatformSmall.transform.localScale.x * transform.localScale.x, PlatformSmall.transform.localScale.y * transform.localScale.y);
        transform.localScale = Vector2.one;
	}
}
