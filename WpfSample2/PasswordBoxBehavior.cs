using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfSample2
{
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        public string BindingPassword
        {
            get { return (string)GetValue(BindingPasswordProperty); }
            set { SetValue(BindingPasswordProperty, value); }
        }
        /// <summary>
        /// BindingPassword
        /// </summary>
        public static readonly DependencyProperty BindingPasswordProperty =
            DependencyProperty.Register(nameof(BindingPassword), typeof(string), 
                typeof(PasswordBoxBehavior), new PropertyMetadata(null));

        public ICommand EnterCommand
        {
            get { return (ICommand)GetValue(EnterCommandProperty); }
            set { SetValue(EnterCommandProperty, value); }
        }

        /// <summary>
        /// EnterCommand
        /// </summary>
        public static readonly DependencyProperty EnterCommandProperty =
            DependencyProperty.Register(nameof(EnterCommand), 
                typeof(ICommand), typeof(PasswordBoxBehavior), 
                new PropertyMetadata(null));


        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            EnterCommand?.Execute(null);
        }

        private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            BindingPassword = AssociatedObject.Password;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;

        }
    }
}
