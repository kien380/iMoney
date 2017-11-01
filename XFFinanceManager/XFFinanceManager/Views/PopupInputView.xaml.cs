using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFFinanceManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupInputView : ContentView
    {
        public EventHandler CloseButtonEventHandler { get; set; }

        public DateTime ToValueInputResult { get; set; }
        public DateTime FromValueInputResult { get; set; }

        public PopupInputView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty IsValidationLabelVisibleProperty =
            BindableProperty.Create(
                nameof(IsValidationLabelVisible),
                typeof(bool),
                typeof(PopupInputView),
                false, BindingMode.OneWay, null,
                (bindable, value, newValue) =>
                {
                    if ((bool)newValue)
                    {
                        ((PopupInputView)bindable).ValidationLabel.IsVisible = true;
                    }
                    else
                    {
                        ((PopupInputView)bindable).ValidationLabel.IsVisible = false;
                    }
                });

        public bool IsValidationLabelVisible
        {
            get { return (bool)GetValue(IsValidationLabelVisibleProperty); }
            set { SetValue(IsValidationLabelVisibleProperty, value); }
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            CloseButtonEventHandler?.Invoke(this, e);
        }

        private void InputDateFrom_DateSelected(object sender, DateChangedEventArgs e)
        {
            FromValueInputResult = InputDateFrom.Date;
        }

        private void InputDateTo_DateSelected(object sender, DateChangedEventArgs e)
        {
            ToValueInputResult = InputDateTo.Date;
        }
    }
}