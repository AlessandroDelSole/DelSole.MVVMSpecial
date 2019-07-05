#pragma warning disable CS1591

using System;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Behaviors
{
    /// <summary>
    /// Base class for custom behaviors. Not intended for data validation.
    /// For data validation see <seealso cref="BaseValidatorBehavior{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        public T AssociatedObject { get; private set; }
        /// <summary>
        /// Raised when the behavior is attached to the specified object
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        /// <summary>
        /// Raised when the behavior is detaching from the specified object
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            AssociatedObject = null;
        }
        void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}