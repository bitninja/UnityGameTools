using TMPro;
using UnityEngine;


namespace UnityGameTools
{
    public class UpdateableTextMeshPro : MonoBehaviour
    {
        //Both the gui and 3d versions of the TextMeshPro types inherit from this.
        public TMP_Text text; 

        [Tooltip("Formatted text with token that will be used to update the TextMeshPro instance.")]
        public string textFormat = "Text goes here - {value}";

        [Tooltip("The string token to substitute with the updated value.")]
        public string textToken = "{value}";

        [Tooltip("Place your version of text for true, for example: yes, on, pass.")]
        public string trueText = "true";

        [Tooltip("Place your version of text for false, for example: no, off, fail.")]
        public string falseText = "false";

        [Tooltip("Text to use when value is cleared.")]
        public string placeHolderText;

        void Awake()
        {
            if (text != null)
            {
                return;
            }

            text = GetComponent<TMP_Text>();

            ClearValue();
        }


        public void SetString(string val)
        {
            text.text = textFormat.Replace(textToken, val);
        }

        public void SetValue(float val) => SetString(val.ToString());
        public void SetValue(int val) => SetString(val.ToString());
        public void SetValue(bool val) => SetString(val ? trueText : falseText);

        public void ClearValue()
        {
            text.text = placeHolderText;
        }
    }
}