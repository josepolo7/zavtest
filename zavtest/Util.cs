using System;
using Xamarin.Forms;

namespace zavtest
{
    public class Util
    {
        public Util()
        {
        }
        //**********************************************************************
        public string getRobotoFont()
        {
            string val = "Assets/Roboto-Regular.ttf";

            if (Device.RuntimePlatform == Device.iOS)
                val = "Roboto-Regular";
            else if (Device.RuntimePlatform == Device.Android)
                val = "Roboto-Regular.ttf#Roboto-Regular";

            return val;
        }
        //**********************************************************************
        public string getRussoFont()
        {
            string val = "Assets/RussoOne-Regular.ttf";

            if (Device.RuntimePlatform == Device.iOS)
                val = "RussoOne-Regular";
            else if (Device.RuntimePlatform == Device.Android)
                val = "RussoOne-Regular.ttf#RussoOne-Regular";

            return val;
        }
        //**********************************************************************
        public ImageSource getImageSource(string name)
        {
            ImageSource imageSource = ImageSource.FromFile(name);

            if (Device.RuntimePlatform == Device.iOS)
                imageSource = ImageSource.FromFile(name);
            else if (Device.RuntimePlatform == Device.Android)
                imageSource = ImageSource.FromFile("Resources/drawable/" + name);

            return imageSource;
        }
        //**********************************************************************
        public int getTextSize(int size)
        {
            int val = size;

            if (Device.RuntimePlatform == Device.iOS)
                val = size - 2;

            return val;
        }
        //**********************************************************************
        public double getScreenWidth(){
            return Application.Current.MainPage.Width;
        }
        //**********************************************************************


    }
}
