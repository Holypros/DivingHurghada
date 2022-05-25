using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{

	// referenses to controlled game objects
	public GameObject avatar1, avatar2, avatar3, avatar4, avatar5, avatar6;

	// variable contains which avatar is on and active
	int whichAvatarIsOn = 1; //Default 

	// Use this for initialization
	void Start()
	{

		// anable first avatar and disable others
		avatar1.gameObject.SetActive(true);

		avatar2.gameObject.SetActive(false);
		avatar3.gameObject.SetActive(false);
		avatar4.gameObject.SetActive(false);
		avatar5.gameObject.SetActive(false);
		avatar6.gameObject.SetActive(false);
	}

	// public method to switch avatars by pressing UI button
	public void SwitchAvatar()
	{

		// processing whichAvatarIsOn variable
		switch (whichAvatarIsOn)
		{
			// if the first avatar is on (default)
			case 1:

				// Set First (default)
				whichAvatarIsOn = 1;

				// Enable First and disable all others
				avatar1.gameObject.SetActive(false);

				avatar2.gameObject.SetActive(false);
				avatar3.gameObject.SetActive(false);
				avatar4.gameObject.SetActive(false);
				avatar5.gameObject.SetActive(false);
				avatar6.gameObject.SetActive(false);

				break;

			// if the second avatar is on
			case 2:

				// Set second
				whichAvatarIsOn = 2;

				// Enable second and disable all others
				avatar2.gameObject.SetActive(true);

				avatar1.gameObject.SetActive(false);
				avatar3.gameObject.SetActive(false);
				avatar4.gameObject.SetActive(false);
				avatar5.gameObject.SetActive(false);
				avatar6.gameObject.SetActive(false);

				break;

			// if the third avatar is on
			case 3:

				// Set third
				whichAvatarIsOn = 3;

				// Enable third and disable all others
				avatar3.gameObject.SetActive(true);

				avatar1.gameObject.SetActive(false);
				avatar2.gameObject.SetActive(false);
				avatar4.gameObject.SetActive(false);
				avatar5.gameObject.SetActive(false);
				avatar6.gameObject.SetActive(false);

				break;

			// if the fourth avatar is on
			case 4:

				// Set fourth
				whichAvatarIsOn = 4;

				// Enable fourth and disable all others
				avatar4.gameObject.SetActive(true);

				avatar1.gameObject.SetActive(false);
				avatar2.gameObject.SetActive(false);
				avatar3.gameObject.SetActive(false);
				avatar5.gameObject.SetActive(false);
				avatar6.gameObject.SetActive(false);

				break;

			case 5:

				// Set fifth
				whichAvatarIsOn = 5;

				// Enable fifth and disable all others
				avatar5.gameObject.SetActive(true);

				avatar1.gameObject.SetActive(false);
				avatar2.gameObject.SetActive(false);
				avatar3.gameObject.SetActive(false);
				avatar4.gameObject.SetActive(false);
				avatar6.gameObject.SetActive(false);

				break;

			case 6:

				// Set sixth
				whichAvatarIsOn = 6;

				// Enable sixth and disable all others
				avatar6.gameObject.SetActive(true);

				avatar1.gameObject.SetActive(false);
				avatar2.gameObject.SetActive(false);
				avatar3.gameObject.SetActive(false);
				avatar4.gameObject.SetActive(false);
				avatar5.gameObject.SetActive(false);

				break;

		}

	}
}
