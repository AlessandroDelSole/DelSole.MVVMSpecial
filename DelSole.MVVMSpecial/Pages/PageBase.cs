﻿#pragma warning disable CS1591

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelSole.MVVMSpecial.Helpers;
using DelSole.MVVMSpecial.Interfaces;
using DelSole.MVVMSpecial.ViewModels;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Pages
{
    /// <summary>
    /// Base class for pages that implement content refresh and actions to close the page 
    /// </summary>
    public abstract class PageBase : ContentPage, IRefreshable
    {
        public void DisplayOnlyFrom(IEnumerable<Type> allowedViewModelTypes)
        {
            _filter = allowedViewModelTypes.ToArray();
        }
        protected PageBase()
        {
            MessagingCenter.Subscribe<ViewModelBase, MessagingCenterAlert>(this, "DisplayAlert", DisplayAlertFromMessagingCenter);
            MessagingCenter.Subscribe<ViewModelBase>(this, "ClosePageCommand", ClosePage);
        }

        private async void ClosePage(ViewModelBase obj)
        {
            MessagingCenter.Unsubscribe<ViewModelBase>(this, "ClosePageCommand");
            await Navigation.PopAsync();
        }

        public virtual async void DisplayAlertFromMessagingCenter(ViewModelBase arg1, MessagingCenterAlert arg2)
        {
            if (_filter != null && _filter.Length > 0)
            {
                if (_filter.Any(a => arg1.GetType() == a))
                {
                    await DisplayAlert(arg2.Title, arg2.Message, arg2.Cancel);

                }
            }
            else
            {
                await DisplayAlert(arg2.Title, arg2.Message, arg2.Cancel);

            }
        }

        private ViewModelBase _viewModel;
        private Type[] _filter;

        public ViewModelBase ViewModel
        {
            get => _viewModel;
            set { _viewModel = value; OnPropertyChanged(); }
        }

        public async Task Refresh(object[] constructorParams)
        {
            await Task.Run(() =>
            {
                var o = constructorParams.FirstOrDefault();
                if (o is ViewModelBase obase)
                {
                    ViewModel = obase;
                }
            });

        }
    }
}
