using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace RoleGame{
	public class FinishScript : MonoBehaviour {
		
		Text text;
		void Start () {
			text = GameObject.Find ("History").GetComponent<Text> ();
			text.text = "\n\tОтыскал лучший из лучших все кусочки Сердца мира, оправдав тем самым доверие Круга Мудрейших."
					+ "\n\tНашел он место то, где Отшельник последние дни свои провел, и к жизни его вернул, дабы он вновь Артефакт великий воедино собрал."
					+ "\n\tУдивился несказанно Отшельник, что сыскался в мире способный к волшебству такому и помог он обратившемуся к нему с просьбой."
					+ "\n\tТак и восстановилось равновесие в мире, а герой наш вскоре и сам в Круг Мудрейших вошел, дабы молодых чародеев обучать для защиты мира сего."
					+ "";
		}
		public void Back()
		{
			Application.LoadLevel ("StartMenu");
		}
	}
}
