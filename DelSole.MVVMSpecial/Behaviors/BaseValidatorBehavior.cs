#pragma warning disable CS1591

using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Behaviors
{
    /// <summary>
    /// Base class for behaviors that provide data validation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseValidatorBehavior<T> : Behavior<T>,
        IValidatorBehavior where T : BindableObject
    {
        static readonly BindablePropertyKey IsValidPropertyKey =
            BindableProperty.CreateReadOnly("IsValid", typeof(bool),
            typeof(BaseValidatorBehavior<T>), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        /// <summary>
        /// Return whether an object has passed validation
        /// </summary>
        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            set { SetValue(IsValidPropertyKey, value); }
        }
    }
}
