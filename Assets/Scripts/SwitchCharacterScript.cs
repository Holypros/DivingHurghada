using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{

	// referenses to controlled game objects
	public GameObject avatar1, avatar2;

	// variable contains which avatar is on and active
	int whichAvatarIsOn = 1;

	// Use this for initialization
	void Start()
	{

		// anable first avatar and disable another one
		avatar1.gameObject.SetActive(true);
		avatar2.gameObject.SetActive(false);
	}

	// public method to switch avatars by pressing UI button
	public void SwitchAvatar()
	{

		// processing whichAvatarIsOn variable
		switch (whichAvatarIsOn)
		{

			// if the first avatar is on
			case 1:

				// then the second avatar is on now
				whichAvatarIsOn = 2;

				// disable the first one and anable the second one
				avatar1.gameObject.SetActive(false);
				avatar2.gameObject.SetActive(true);
				break;

			// if the second avatar is on
			case 2:

				// then the first avatar is on now
				whichAvatarIsOn = 1;

				// disable the second one and anable the first one
				avatar1.gameObject.SetActive(true);
				avatar2.gameObject.SetActive(false);
				break;
		}

	}
}
