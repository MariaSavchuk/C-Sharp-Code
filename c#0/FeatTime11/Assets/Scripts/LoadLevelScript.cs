using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace RoleGame{
	public class LoadLevelScript : MonoBehaviour {

		int levelNum = 1;
		Text descr;
		string[] levelDescription = {
			"По Топям Гоблинов\n\nПервая частица Сердца хранится на болоте у диких лесных гоблинов. Говорят, его никто не охраняет...", 
			"В пещере Дальних Гор\n\nПо слухам, от одной из пещер в Дальних Горах исходит необъяснимая магическая сила. Следует ее проверить.",
			"Могильник древнего города\n\nНедалеко от Дальних Гор стоят руины древнего эльфийского города. Отметка на данной вам карте указывает именно на него.",
			"Нижнепрудский лес\n\nЖители деревни Нижние пруды жалуются на монстров, по описанию похожих на слуг хаоса, охраняющих частицы Сердца. Быть может, это и есть они?..",
			"Принцесса Сидерии\n\nКороль Сидерии утверждает, что часть Сердца хранится у него. Он готов отдать его вам, но только если вы спасете его дочь, обращенную в камень.",
			"Леса Сидерии\n\nПереданный вам королем Сидерии элемент Артефакта оказался не единственным в этой стране. Еще один кусочек затерялся в ее труднопроходимых лесах.",
			"Близко к цели\n\nВы обнаружили вулкан, в предгорьях которого, предположительно, много лет назад жил Великий Отшельник."
		};
		void Start () {
			levelNum = Settings.lastLevel + 1;
			for (int i=1; i<=Settings.Levels.Length; i++) {
				Toggle tog = GameObject.Find (string.Format("Level" + i.ToString())).GetComponent<Toggle>();
				if(i<=Settings.openedLevels)
					tog.interactable = true;
				else
					tog.interactable = false;
				if(i == levelNum)
					tog.isOn = true;
				else
					tog.isOn = false;
			}
			descr = GameObject.Find ("Description").GetComponent<Text> ();
			descr.text = levelDescription [levelNum - 1];
			//descr.text = levelNum.ToString ();
		}
		public void Back()
		{
			Application.LoadLevel("StartMenu");
		}
		public void Exit()
		{
			Application.Quit ();
		}
		public void ChooseLevel(int num)
		{
			descr = GameObject.Find ("Description").GetComponent<Text> ();
			levelNum = num;
			descr.text = levelDescription [num - 1];
			//descr.text = num.ToString ();
		}
		public void Load()
		{
			Settings.lastLevel = levelNum - 1;
			Application.LoadLevel (Settings.Levels [Settings.lastLevel]);
		}
		public void Save()
		{
			LoadHeroScript.Save ();
		}
}
}
