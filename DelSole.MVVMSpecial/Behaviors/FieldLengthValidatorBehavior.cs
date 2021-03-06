﻿#pragma warning disable CS1591

using System;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Behaviors
{
    /// <summary>
    /// Validate an Entry and cuts its content if longer than the
    /// value of the MaxLength property
    /// </summary>
    public class FieldLengthValidatorBehavior : BaseValidatorBehavior<Entry>
    {
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create("MaxLength", typeof(int),
                typeof(FieldLengthValidatorBehavior), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                if (e.NewTextValue.Length > 0 && e.NewTextValue.Length > MaxLength)
                {
                    IsValid = false;
                    ((Entry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
                }
                IsValid = true;
            }
            catch (Exception)
            {


            }
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }
    }
}
