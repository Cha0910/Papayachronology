using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace 파파야연대기.Classes
{
    public class GameText : PropertyChangedNotificationClass
    {
        private string tempText, selectButton1Text, selectButton2Text, selectButton3Text;
        private string selectButton1Image, selectButton2Image, selectButton3Image;
        private string selectButton1Probability, selectButton2Probability, selectButton3Probability;

        [JsonIgnore]
        public string TempText
        {
            get { return tempText; }
            set
            {
                tempText = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public string SelectButton1Text
        {
            get { return selectButton1Text; }
            set
            {
                selectButton1Text = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public string SelectButton2Text
        {
            get { return selectButton2Text; }
            set
            {
                selectButton2Text = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public string SelectButton3Text
        {
            get { return selectButton3Text; }
            set
            {
                selectButton3Text = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public string SelectButton1Image
        {
            get { return selectButton1Image; }
            set
            {
                selectButton1Image = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public string SelectButton2Image
        {
            get { return selectButton2Image; }
            set
            {
                selectButton2Image = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public string SelectButton3Image
        {
            get { return selectButton3Image; }
            set
            {
                selectButton3Image = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public string SelectButton1Probability
        {
            get { return selectButton1Probability; }
            set
            {
                selectButton1Probability = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public string SelectButton2Probability
        {
            get { return selectButton2Probability; }
            set
            {
                selectButton2Probability = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public string SelectButton3Probability
        {
            get { return selectButton3Probability; }
            set
            {
                selectButton3Probability = value;
                OnPropertyChanged();
            }
        }
    }
}
