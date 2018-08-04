using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using zavtest.Model;

namespace zavtest
{
    public partial class MainPage : ContentPage
    {
        private MainPagePresenter presenter;
        private Util util;
        protected MainPagePresenter Presenter { get => presenter; set => presenter = value; }
        //**********************************************************************
        public MainPage()
        {
            //------------------------------------------------------------------
            Presenter = new MainPagePresenter();
            util = new Util();
            //------------------------------------------------------------------
            var listView = new ListView
            {
                RowHeight = 90,
                MinimumHeightRequest = 90,
                BackgroundColor = Color.Transparent,
            };
            listView.ItemsSource = presenter.categories;
            listView.ItemTemplate = new DataTemplate(getRowView);
            listView.ItemSelected += async (sender, e) =>
            {
                steelproCategory categoryRecord = (steelproCategory)e.SelectedItem;
                await DisplayAlert("Click en la celda ", categoryRecord.Name, "Aceptar");
                /*
                var categoryDetailPage = new CategoryDetailPage(categoryRecord); 
                await Navigation.PushAsync(categoryDetailPage);
                */
            };
            //------------------------------------------------------------------
            var backgroundImage = new Image
            {
                Source = util.getImageSource("background.png"),
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            //------------------------------------------------------------------
            StackLayout headerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Start
            };
            headerLayout.Children.Add(
                new Button
                {
                    WidthRequest = 48,
                    HeightRequest = 48,
                    BackgroundColor = Color.Transparent,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    Image = "arrow.png"
                }
            );
            headerLayout.Children.Add(
                new Image
                {
                    BackgroundColor = Color.Transparent,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.Fill,
                    Source = util.getImageSource("logo.png")
                }
            );
            //------------------------------------------------------------------
            StackLayout footerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.End
            };
            footerLayout.Children.Add(
                new Button
                {
                    WidthRequest = 48,
                    HeightRequest = 48,
                    BackgroundColor = Color.Transparent,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    Image = "zoom.png"
                }
            );
            footerLayout.Children.Add(
                new Entry
                {
                    BackgroundColor = Color.White,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Fill,
                    Margin = 8
                }
            );
            //------------------------------------------------------------------
            RelativeLayout pageLayout = new RelativeLayout
            {
                Margin = new Thickness(20),
                BackgroundColor = Color.Black,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            pageLayout.Children.Add(backgroundImage,
                xConstraint: Constraint.Constant(0),
                yConstraint: Constraint.Constant(0),
                widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));
            pageLayout.Children.Add(listView,
                xConstraint: Constraint.Constant(0),
                yConstraint: Constraint.Constant(0),
                widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));
            pageLayout.Children.Add(headerLayout,
                xConstraint: Constraint.Constant(0),
                yConstraint: Constraint.Constant(0),
                //yConstraint: Constraint.RelativeToParent((parent) => { return parent.Height - (parent.Height * 0.2);}),
                widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height * 0.35; }));
            pageLayout.Children.Add(footerLayout,
                xConstraint: Constraint.Constant(0),
                //yConstraint: Constraint.Constant(0),
                yConstraint: Constraint.RelativeToParent((parent) => { return parent.Height - (parent.Height * 0.3);}),
                widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height * 0.30; }));
            //------------------------------------------------------------------

            Content = pageLayout;
        }
        //**********************************************************************








        //**********************************************************************
        private ViewCell getRowView()
        {
            //------------------------------------------------------------------
            Frame leftFrame = new Frame
            {
                BackgroundColor = Color.FromHex("FFEEEEEE"),
                CornerRadius = 6,
                Padding = 10,
                Margin = new Thickness(10, 10, -4, 10),
                HasShadow = false
            };
            //------------------------------------------------------------------
            var leftLayout = new Grid
            {
                BackgroundColor = Color.Transparent
            };
            //------------------------------------------------------------------
            var iconImage = new Image
            {
                WidthRequest = 32,
                HeightRequest = 32,
                Margin = 5,
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            iconImage.SetBinding(Image.SourceProperty, "Image");
            //------------------------------------------------------------------
            leftLayout.Children.Add(iconImage);
            leftFrame.Content = leftLayout;
            //------------------------------------------------------------------




            //------------------------------------------------------------------
            Frame rightFrame = new Frame
            {
                BackgroundColor = Color.FromHex("88FFFFFF"),
                CornerRadius = 6,
                Padding = 5,
                Margin = new Thickness(-4, 10, 10, 10),
                HasShadow = false
            };
            //------------------------------------------------------------------
            var rightLayout = new Grid
            {
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            //------------------------------------------------------------------
            var labelLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Fill,
                Padding = new Thickness(50, 0, 0, 0)
            };
            var typeLabel = new Label
            {
                FontFamily = util.getRobotoFont(),
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                FontSize = util.getTextSize(16),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(0, 0, 0, -4)

            };
            var nameLabel = new Label
            {
                FontFamily = util.getRussoFont(),
                BackgroundColor = Color.Transparent,
                TextColor = Color.Black,
                FontSize = util.getTextSize(20),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Margin = new Thickness(0, -4, 0, 0)
            };
            typeLabel.SetBinding(Label.TextProperty, "Type");
            nameLabel.SetBinding(Label.TextProperty, "Name");
            labelLayout.Children.Add(typeLabel);
            labelLayout.Children.Add(nameLabel);
            //------------------------------------------------------------------
            rightLayout.Children.Add(labelLayout);
            rightFrame.Content = rightLayout;
            //------------------------------------------------------------------




            //------------------------------------------------------------------
            Grid container = new Grid
            {
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(0.015, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(0.685, GridUnitType.Star)},
                },
                ColumnSpacing = 0,
                RowSpacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            container.Children.Add(leftFrame, 0, 0);
            container.Children.Add(rightFrame, 2, 0);
            container.Children.Add(
                new BoxView
                {
                    Margin = new Thickness(0, 10, 0, 10),
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    Color = Color.Yellow
                },
                1, 0);
            //------------------------------------------------------------------
            var button = new Button
            {
                WidthRequest = 48,
                HeightRequest = 48,
                BackgroundColor = Color.Transparent,
                Margin = new Thickness(0, 0, 0, 0),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Image = "plus.png"
            };
            //------------------------------------------------------------------
            var cellLayout = new RelativeLayout();
            cellLayout.Children.Add(container,
                                    xConstraint: Constraint.Constant(0),
                                    yConstraint: Constraint.Constant(0),
                                    widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                                    heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));
            cellLayout.Children.Add(button,
                                    xConstraint: Constraint.RelativeToParent((parent) => { return parent.Width * 0.1; }),
                                    yConstraint: Constraint.RelativeToParent((parent)=> { return parent.Height * 0.6; }),
                                    widthConstraint: Constraint.RelativeToParent((parent) => { return parent.Width; }),
                                    heightConstraint: Constraint.RelativeToParent((parent) => { return parent.Height; }));
            //------------------------------------------------------------------
            return new ViewCell { View = cellLayout };
        }

    }
}
