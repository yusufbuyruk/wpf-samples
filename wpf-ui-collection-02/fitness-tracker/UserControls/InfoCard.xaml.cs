using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using MahApps.Metro.IconPacks;

namespace FitnessTracker.UserControls
{
    /// <summary>
    /// Interaction logic for InfoCard.xaml
    /// </summary>
    public partial class InfoCard : UserControl
    {
        public InfoCard()
        {
            InitializeComponent();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(InfoCard));

        public string Desc
        {
            get => (string)GetValue(DescProperty);
            set => SetValue(DescProperty, value);
        }

        public static readonly DependencyProperty DescProperty = DependencyProperty.Register("Desc", typeof(string), typeof(InfoCard));

        public string Percentage
        {
            get => (string)GetValue(PercentageProperty);
            set => SetValue(PercentageProperty, value);
        }

        public static readonly DependencyProperty PercentageProperty = DependencyProperty.Register("Percentage", typeof(string), typeof(InfoCard));

        public string BottomText
        {
            get => (string)GetValue(BottomTextProperty);
            set => SetValue(BottomTextProperty, value);
        }

        public static readonly DependencyProperty BottomTextProperty = DependencyProperty.Register("BottomText", typeof(string), typeof(InfoCard));

        public string Days
        {
            get => (string)GetValue(DaysProperty);
            set => SetValue(DaysProperty, value);
        }

        public static readonly DependencyProperty DaysProperty = DependencyProperty.Register("Days", typeof(string), typeof(InfoCard));

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(InfoCard));

        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }

        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(InfoCard));


        public PackIconMaterialKind Icon
        {
            get => (PackIconMaterialKind)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(PackIconMaterialKind), typeof(InfoCard));
    }
}
