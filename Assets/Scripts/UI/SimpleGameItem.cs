using TMPro;
using UnityEngine;

namespace UI
{
    public class SimpleGameItem : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _titleText;

        [SerializeField]
        private TMP_Text _descriptionText;

        [SerializeField]
        private TMP_Text _releaseDateText;

        public void SetTitleText(string name)
        {
            _titleText.text = name;
        }

        public void SetDescriptionText(string description)
        {
            _descriptionText.text = description;
        }

        public void SetReleaseDateText(string releaseDate)
        {
            _releaseDateText.text = releaseDate;
        }
    }
}