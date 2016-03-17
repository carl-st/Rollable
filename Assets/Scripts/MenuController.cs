using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {


	public MenuAnim CurrentMenu;

	public void Start(){
			ShowMenu (CurrentMenu);
		}


	public void ShowMenu(MenuAnim menu)
	{
		if (CurrentMenu != null)
			CurrentMenu.IsOpen = false;
		
		CurrentMenu = menu;
		CurrentMenu.IsOpen = true;
	}
}
