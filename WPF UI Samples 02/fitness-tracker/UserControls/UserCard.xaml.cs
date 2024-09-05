﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessTracker.UserControls
{
    /// <summary>
    /// Interaction logic for UserCard.xaml
    /// </summary>
    public partial class UserCard : UserControl
    {
        public UserCard()
        {
            InitializeComponent();
        }

        public string FullName
        {
            get => (string)GetValue(FullNameProperty);
            set => SetValue(FullNameProperty, FullName);
        }

        public static readonly DependencyProperty FullNameProperty = DependencyProperty.Register("FullName", typeof(string), typeof(UserCard));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, Title);
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(UserCard));

        public string Time
        {
            get => (string)GetValue(TimeProperty);
            set => SetValue(TimeProperty, Time);
        }

        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(string), typeof(UserCard));

        public ImageSource Image
        {
            get => (ImageSource)GetValue(ImageProperty);
            set => SetValue(ImageProperty, Image);
        }

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(UserCard));

        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, IsActive);
        }

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(UserCard));
    }
}
